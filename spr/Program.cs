using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace spr
{
    public interface ICar
    {
        void StartEngine();
        void Drive();
    }
    public abstract class Car : ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Owner { get; set; }
        public Car(string brand, string model, int year, string owner)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Owner = owner;
        }
        public void StartEngine()
        {
            Console.WriteLine($"{Brand} {Model} uruchamia silnik");
        }
        public abstract void Drive();
        public override string ToString()
        {
            return $"{Brand} {Model} {Year} {Owner}";
        }
    }
    public class ElectricCar : Car
    {
        public ElectricCar(string brand, string model, int year, string owner) : base(brand, model, year, owner)
        {
            
        }
        public override void Drive()
        {
            Console.WriteLine("Jazda na elektryczności!");
        }
    }
    public class GasolineCar : Car
    {
        public GasolineCar(string brand, string model, int year, string owner) : base(brand, model, year, owner)
        {

        }
        public override void Drive()
        {
            Console.WriteLine("Jazda na benzynie!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ElectricCar ecar = new ElectricCar("Tesla", "S", 2022, "Janusz Kowalski");
            GasolineCar gcar = new GasolineCar("Syrenka", "105", 1970, "Janusz Kowalski");
            ecar.StartEngine();
            ecar.Drive();
            gcar.StartEngine();
            gcar.Drive();
            List<Car> cars = new List<Car>()
            {
                new ElectricCar("Tesla", "Model S", 2020, "Jan Kowalski"),
                new GasolineCar("Ford", "Mustang", 2018, "Anna Nowak"),
                new ElectricCar("Nissan", "Leaf", 2019, "Piotr Wiśniewski"),
                new GasolineCar("BMW", "X5", 2017, "Katarzyna Zielińska"),
                ecar,
                gcar
            };
            Console.WriteLine("\nSortowanie po właścicielu: ");
            cars.Sort((a, b) => a.Owner.CompareTo(b.Owner));
            foreach (var car in cars) Console.WriteLine(car);

            Console.WriteLine("\nSortowanie po roku produkcji: ");
            cars.Sort((a, b) => a.Year.CompareTo(b.Year));
            foreach (var car in cars) Console.WriteLine(car);

            Console.WriteLine("\nSortowanie po marce: ");
            cars.Sort((a, b) => a.Brand.CompareTo(b.Brand));
            foreach (var car in cars) Console.WriteLine(car);

            Console.WriteLine("\nSortowanie po właścicielu: ");
            cars.Sort((a, b) => a.Model.CompareTo(b.Model));
            foreach (var car in cars) Console.WriteLine(car);

            Console.WriteLine("Kliknij przycisk, aby przejść do menu . . . ");
            Console.ReadKey();
            Console.Clear();
            bool t = true;
            //Menu
            while (t)
            {
                Console.WriteLine("1. Sortowanie według właściciela\n2. Sortowanie według roku produkcji\n3. Sortowanie według marki\n4. Sortowanie według modelu\n5. Wyjście\n\nPodaj operację do wykonania: ");
                string input = Console.ReadLine();
                Console.Clear();
                ushort num;
                while (!ushort.TryParse(input, out num))
                {
                    Console.WriteLine("Złe dane!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("1. Sortowanie według właściciela\n2. Sortowanie według roku produkcji\n3. Sortowanie według marki\n4. Sortowanie według modelu\n5. Wyjście\n\nPodaj operację do wykonania: ");
                    input = Console.ReadLine();
                }
                switch (num)
                {
                    case 1:
                        Console.WriteLine("\nSortowanie po właścicielu: ");
                        cars.Sort((a, b) => a.Owner.CompareTo(b.Owner));
                        foreach (var car in cars) Console.WriteLine(car);
                        break;
                    case 2:
                        Console.WriteLine("\nSortowanie po roku produkcji: ");
                        cars.Sort((a, b) => a.Year.CompareTo(b.Year));
                        foreach (var car in cars) Console.WriteLine(car);
                        break;
                    case 3:
                        Console.WriteLine("\nSortowanie po marce: ");
                        cars.Sort((a, b) => a.Brand.CompareTo(b.Brand));
                        foreach (var car in cars) Console.WriteLine(car);
                        break;
                    case 4:
                        Console.WriteLine("\nSortowanie po właścicielu: ");
                        cars.Sort((a, b) => a.Model.CompareTo(b.Model));
                        foreach (var car in cars) Console.WriteLine(car);
                        break;
                    case 5:
                        t = false;
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}
