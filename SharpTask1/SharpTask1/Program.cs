using System;
using System.IO;
using System.Threading;

namespace SharpTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Test");
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory()+"\\test.log");
            string a = System.IO.Directory.GetCurrentDirectory() + "\\test.log";
            StreamWriter sw = new StreamWriter(a, true, System.Text.Encoding.Default);
            sw.WriteLine("Hello World");
            sw.Close();*/
            
            Parking parking = Parking.Instance;

            Console.WriteLine(new String('_',50));
            parking.AddCar(new Car(1000));
            parking.AddCar(new Car(2000));
            parking.AddCar(new Car(3000));
            parking.AddCar(new Car(4000));

            //Console.WriteLine(parking.freePlaces);  
            parking.AddCar(new Car(1000));
            parking.AddCar(new Car(1000));

            Console.WriteLine(parking.AllCarList()[2].CarId);
            Console.WriteLine(parking.GetCar(parking.AllCarList()[2].CarId).TypeOfCar);
            Console.WriteLine(parking.freePlaces);
            parking.DeleteCar(parking.AllCarList()[2].CarId);
            Console.WriteLine(parking.freePlaces);
            Console.WriteLine(new String('_',50));
            Console.WriteLine(parking.GetFreePlaces());
            Console.WriteLine(parking.GetOccupiedPlaces());
            Console.WriteLine(new String('_',50));
            Console.WriteLine(new String('_',50));
            Console.WriteLine(parking.AllCarList()[2].Ballanse);
            parking.AllCarList()[2].AddBalance(100);
            Console.WriteLine(parking.AllCarList()[2].Ballanse);
            Console.WriteLine(new String('_',50));
            Console.WriteLine(new String('_',50));


            parking.PeriodicPayAsync(TimeSpan.FromTicks(parking._settings.Timeout));
            parking.PeriodicLogAsync(TimeSpan.FromTicks(parking._settings.Timeout*100));
            Console.WriteLine("fqwfqwgw");
            Console.WriteLine("fwqfqw");
           
            Console.ReadKey();
            parking.AllCarList()[1].AddBalance(100);
            Console.ReadKey();
           // Console.WriteLine(parking.GetMinTransactions()[0].CarId); 
            Console.ReadKey();
           // Console.WriteLine(parking.GetMinTransactions(parking.AllCarList()[1].CarId)[0].CarId);
            Console.ReadKey();

        }
    }
}