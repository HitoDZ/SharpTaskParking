using System;

namespace SharpTask1
{
    public class Car
    {
        //private int _ballanse;
        public float Ballanse { get; set; }
        public readonly CarType.carTypes TypeOfCar;
        public int CarId;

        public void AddBalance(float bal)
        {
            try
            {
                Ballanse += bal;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid sum");
            }
            
        }
    }
}