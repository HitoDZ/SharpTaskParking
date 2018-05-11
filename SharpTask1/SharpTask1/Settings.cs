using System.Collections.Generic;

namespace SharpTask1
{
    public class Settings
    {
        public int ParkingSpace { get; set; }
        public int Fine { get; set; }
        public int Timeout { get; set; }
        public Dictionary<CarType, double> Price;
    }
}