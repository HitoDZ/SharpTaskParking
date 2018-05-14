using System;

namespace SharpTask1
{
    public class Car
    {
        private float _ballanse;
        public float Ballanse
        {
            get { return _ballanse;}
            set
            {
                if (value >= 0)
                    _ballanse = value;
            }   
        }
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