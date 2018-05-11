using System.Collections.Generic;
using System;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace SharpTask1
{
    public class Parking
    {
        public int FreePlaces;
        private Settings _settings =new Settings();
        protected List<Transaction> listTransactions = new List<Transaction>();
        
        private static readonly Parking instance = new Parking();
        
        static  Parking()
        {
            
        }

        public string GetFreePlaces()
        {
            var a = "There " + FreePlaces.ToString() + " places";
            return a;
        }

        public string GetBalance()
        {
            var a = "Current balance of Parking " + Balance.ToString();
            return a;

        }

        private Parking()
        {
            FreePlaces = _settings.ParkingSpace;
        }

        public static Parking Instance
        {
            get { return instance; }
        }
        
        
        public Dictionary<int, Car> CarList = new Dictionary<int, Car>();
        public float Balance { get; set; }
        protected Dictionary<int, float> debts = new Dictionary<int, float>();

        public void AddCar(Car car)
        {
            if (FreePlaces <= 0)
            {
                Console.WriteLine("There no free place");
            }
            else
            {

                try
                {
                    if (car != null)
                    {
                        
                        CarList.Add(car.CarId, car);
                        FreePlaces -= 1;
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

        }
        public void DeleteCar(Car car)
        {
            try
            {
                if ((car != null ) && (!debts.ContainsKey(car.CarId)))
                {
                    
                    CarList.Remove(car.CarId);
                    FreePlaces += 1;

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

        public void Log()
        {
            float sum = 0;
            foreach (var i in listTransactions)
            {
                sum += i.Pay;
            }
            using (StreamWriter sw = new StreamWriter(System.IO.Directory.GetCurrentDirectory(), false, System.Text.Encoding.Default))

            {
                string text = DateTime.Now.ToString() + " - " + sum;
                sw.WriteLine(text);
                    
            }
            listTransactions.Clear();
        }

        public string getHistory()
        {
            
        }
        public void GetPay()
        {
            foreach (var i in CarList)
            {
                var price = _settings.Price[i.Value.TypeOfCar];
                if (debts.ContainsKey(i.Value.CarId) && i.Value.Ballanse >= debts[i.Value.CarId])
                {
                    i.Value.Ballanse -= debts[i.Value.CarId];
                    Balance += debts[i.Value.CarId];
                    Transaction t = new Transaction(i.Value.CarId, debts[i.Value.CarId]);
                    listTransactions.Add(t);
                    debts.Remove(i.Value.CarId);
                }
               
                if (i.Value.Ballanse >= price)
                {
                    i.Value.Ballanse -= price;
                    Balance += price;
                    Transaction t = new Transaction(i.Value.CarId, price);
                    listTransactions.Add(t);
                }
                else
                {
                    if (!debts.ContainsKey(i.Value.CarId))
                        debts.Add(i.Value.CarId, price*_settings.Fine);
                    debts[i.Value.CarId] += price * _settings.Fine;

                }
            }
        }
    }
}