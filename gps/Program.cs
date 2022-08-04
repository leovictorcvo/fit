namespace gps
{
    static class Program
    {
        private static void Main()
        {
            try
            {
                GpsFitSolution(ReadFilePath()).ForEach(result => Console.WriteLine(result));
            }
            catch (Exception e)
            {
                Console.WriteLine("".PadLeft(20, '>'));
                Console.WriteLine($"Erro: {e.Message}");
                Console.WriteLine("".PadLeft(20, '>'));
            }
        }

        private static string ReadFilePath()
        {
            string? filePath;
            bool validName;
            do
            {
                Console.Write("Informe o nome do arquivo de entrada:");
                filePath = Console.ReadLine();
                validName = !string.IsNullOrEmpty(filePath?.Trim()) && System.IO.File.Exists(filePath);
                if (!validName)
                    Console.WriteLine("Nome de arquivo inválido");
            } while (!validName);
            return filePath!;
        }

        private static List<int> GpsFitSolution(string filePath)
        {
            var travels = GetTestsFromFile(filePath);
            return travels.Select(travel => travel.GetTimeToTravel()).ToList();
        }

        private static List<Travel> GetTestsFromFile(string filePath)
        {
            var tests = new List<Travel>();
            int lineNumber = 0;
            string[] lines = Array.Empty<string>();

            #region [Local Methods]

            string[] ReadFile()
            {
                var lines = System.IO.File.ReadAllLines(filePath).ToArray();
                if (lines == null || lines.Length == 0)
                    throw new FileContentException("Arquivo vazio");
                return lines;
            }

            string GetLine() => lines[lineNumber++].ToLower();

            int GetNumberOfTests()
            {
                if (!int.TryParse(GetLine(), out int numberOfTests))
                    throw new FileContentException(message:"Número de testes inválido", lineNumber: lineNumber, content: lines[lineNumber - 1]);
                return numberOfTests;
            }

            List<City> GetCities()
            {
                if (!int.TryParse(GetLine(), out int numberOfCities))
                    throw new FileContentException(message:"Número de cidades inválido", lineNumber: lineNumber, content: lines[lineNumber - 1]);
                var citiesNames = GetLine().Split(' ');
                var cities = citiesNames
                    .Where(name => !string.IsNullOrEmpty(name))
                    .Select(name => new City(name[0])).ToList();
                return cities;
            }

            void SetCitiesRoads(List<City> cities)
            {
                if (!int.TryParse(GetLine(), out int numberOfRoads))
                    throw new FileContentException(message:"Quantidade de estradas inválida", lineNumber: lineNumber, content: lines[lineNumber - 1]);
                for (int roadNumber = 0; roadNumber < numberOfRoads; roadNumber++)
                {
                    var roadDetail = GetLine().Split(' ');
                    var sourceCity = cities.SingleOrDefault(c => c.Name == roadDetail[0][0]);
                    var destinationCity = cities.SingleOrDefault(c => c.Name == roadDetail[1][0]);
                    var timeParsed = int.TryParse(roadDetail[2], out int travelTime);
                    if (sourceCity == null || destinationCity == null || !timeParsed)
                        throw new FileContentException(message:"Estrada inválida", lineNumber: lineNumber, content: lines[lineNumber - 1]);

                    sourceCity.AddRoad(new Road(destinationCity, travelTime));
                    destinationCity.AddRoad(new Road(sourceCity, travelTime));
                }
            }

            #endregion

            lines = ReadFile();
            var numberOfTests = GetNumberOfTests();

            for (int testNumber = 0; testNumber < numberOfTests; testNumber++)
            {
                var cities = GetCities();
                SetCitiesRoads(cities);
                var travelPath = GetLine();
                tests.Add(new Travel(cities, travelPath));
            }
            return tests;
        }
    }
}