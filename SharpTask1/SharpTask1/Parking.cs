using System.Collections.Generic;
using System;
using System.Data.Common;

namespace SharpTask1
{
    public class Parking
    {
        private Settings _settings =new Settings();
        
        private static readonly Parking instance = new Parking();
        
        static  Parking()
        {
            
        }

        private Parking()
        {
            
        }

        public static Parking Instance
        {
            get { return instance; }
        }
        
        
        public Dictionary<int, Car> CarList = new Dictionary<int, Car>();

        public void AddCar(Car car)
        {
            try
            {
                if (car != null)
                {
                    CarList.Add(car.CarId,car);
                }
                else
                {
                    Console.WriteLine("Car is not valid");
                }
            }            
            catch (Exception e)
            {
                Console.WriteLine("Car is not valid");
            }
            
        }
        public void DeleteCar(Car car)
        {
            try
            {
                if ((car != null ) && (car.Ballanse>=0))
                {
                    
                    CarList.Remove(car.CarId);

                }
                else
                {
                    Console.WriteLine("Car cant be deleted. Chack your balance.");
                }
            }            
            catch (Exception e)
            {
                Console.WriteLine("There no such car");
            }
            
        }


        public void GetPay()
        {
            foreach (var i in CarList)
            {
                
                var price = _settings.Price[i.Value.TypeOfCar];
                if (i.Value.Ballanse >= price)
                {
                    i.Value.Ballanse -= price;
                    Transaction t = new Transaction();
                        
                }
                else
                {
                    i.Value.Ballanse -= price * _settings.Fine;

                }
            }
        }
    }
}