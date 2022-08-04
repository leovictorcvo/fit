namespace gps
{
    static class Program
    {
        private static void Main()
        {
            GpsFitSolution(ReadFilePath()).ForEach(result => Console.WriteLine(result));


            string ReadFilePath()
            {
                string? filePath = null;
                bool validName = false;
                do
                {
                    Console.Write("Informe o nome do arquivo de entrada:");
                    filePath = Console.ReadLine();
                    validName = !string.IsNullOrEmpty(filePath?.Trim()) && System.IO.File.Exists(filePath);
                    if (!validName)
                        Console.WriteLine("Nome de arquivo inválido");
                } while (!validName);
                return filePath ?? String.Empty;
            }

            List<int> GpsFitSolution(string filePath)
            {
                var travels = GetTestsFromFile(filePath);
                return travels.Select(travel => travel.GetTimeToTravel()).ToList();
            }

            List<Travel> GetTestsFromFile(string filePath)
            {
                var tests = new List<Travel>();

                try
                {
                    var lines = System.IO.File.ReadAllLines(filePath).ToArray();
                    if (lines == null || lines.Length == 0)
                        throw new ArgumentException("Arquivo vazio");

                    int lineNumber = 0;
                    string GetLine() => lines[lineNumber++].ToLower();

                    if (!int.TryParse(GetLine(), out int numberOfTests))
                        throw new ArgumentException("Número de testes inválido");

                    for (int testNumber = 0; testNumber < numberOfTests; testNumber++)
                    {
                        if (!int.TryParse(GetLine(), out int numberOfCities))
                            throw new ArgumentException("Número de cidades inválido");
                        var citiesNames = GetLine().Split(' ');
                        var cities = citiesNames
                            .Where(name => !string.IsNullOrEmpty(name))
                            .Select(name => new City(name[0])).ToList();

                        if (!int.TryParse(GetLine(), out int numberOfRoads))
                            throw new ArgumentException("Quantidade de estradas inválida");
                        for (int roadNumber = 0; roadNumber < numberOfRoads; roadNumber++)
                        {
                            var roadDetail = GetLine().Split(' ');
                            var sourceCity = cities.SingleOrDefault(c => c.Name == roadDetail[0][0]);
                            var destinationCity = cities.SingleOrDefault(c => c.Name == roadDetail[1][0]);
                            var timeParsed = int.TryParse(roadDetail[2], out int travelTime);
                            if (sourceCity == null || destinationCity == null || !timeParsed)
                                throw new ArgumentException("Caminho a percorrer inválido");
                            sourceCity.AddRoad(new Road(destinationCity, travelTime));
                            destinationCity.AddRoad(new Road(sourceCity, travelTime));
                        }
                        var travelPath = GetLine();
                        tests.Add(new Travel(cities, travelPath));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("".PadLeft(10, '>'));
                    Console.WriteLine($"Erro: ${e.Message}");
                    Console.WriteLine("".PadLeft(10, '>'));
                    tests.Clear();
                }
                return tests;
            }
        }
    }
}