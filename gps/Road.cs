namespace gps
{
    public class Road
    {
        public City Destination { get; private set; }
        public int TimeToTravel { get; private set; }

        public Road(City destination, int timeToTravel)
        {
            Destination = destination;
            TimeToTravel = timeToTravel;
        }
    }
}