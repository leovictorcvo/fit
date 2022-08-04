namespace gps
{
    public sealed class City : IEquatable<City>
    {
        public char Name { get; private set; }
        private readonly int delayTime;
        private readonly List<Road> roads;

        public City(char name)
        {
            Name = name;
            //cidades nomeadas com uma vogal (a, e, i, o ou u), estão atualmente com tráfego intenso de saída
            //isso causará um atraso de 5 horas na saída da cidade
            delayTime = "aeiou".Contains(name) ? 5 : 0;
            roads = new List<Road>();
        }

        #region [Equals]

        public override bool Equals(object? obj)
        {
            return obj is City &&
                Equals(obj as City);
        }

        public bool Equals(City? other) => Name.Equals(other?.Name);

        public override int GetHashCode() => HashCode.Combine(Name, delayTime);

        #endregion

        public void AddRoad(Road road)
        {
            roads.Add(road);
        }

        public int GetTimeToTravel(City destination, string visitedCities)
        {
            int bestTime = int.MaxValue;

            foreach (var road in roads)
            {
                if (road.Destination.Equals(destination) && road.TimeToTravel < bestTime)
                    bestTime = road.TimeToTravel;
                else if (!visitedCities.Contains(road.Destination.Name))
                {
                    var timeToTravel = road.Destination.GetTimeToTravel(destination, $"{visitedCities}{Name}");
                    timeToTravel = road.TimeToTravel > (int.MaxValue - timeToTravel) ? //will overflow
                                   int.MaxValue :
                                   timeToTravel + road.TimeToTravel;

                    if (timeToTravel < bestTime)
                        bestTime = timeToTravel;
                }
            }
            return delayTime > (int.MaxValue - bestTime) ? //will overflow
                    int.MaxValue :
                    bestTime + delayTime;
        }
    }
}