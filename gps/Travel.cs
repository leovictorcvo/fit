namespace gps
{
    public class Travel
    {
        public List<City> Cities { get; private set; }
        public string Path { get; private set; }

        public Travel(List<City> cities, string path)
        {
            Cities = cities;
            Path = path;
        }

        public int GetTimeToTravel()
        {
            var citiesNames = Path.ToLower().Split(' ');
            var source = Cities.SingleOrDefault(city => city.Name == citiesNames[0][0]);
            var destination = Cities.SingleOrDefault(city => city.Name == citiesNames[1][0]);
            var visitedCities = "";

            if (source == null || destination == null)
            {
                Console.WriteLine("Error: Invalid travel path");
                return -1;
            }

            return source.GetTimeToTravel(destination, visitedCities);
        }
    }
}