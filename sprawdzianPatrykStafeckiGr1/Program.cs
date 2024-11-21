
namespace sprawdzianPatrykStafeckiGr1
{
    interface ICar
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
            return $"{Brand} | {Model} | {Year} | {Owner}";
        }
    }
    public class ElectricCar : Car
    {
        public ElectricCar(string brand, string model, int year, string owner) : base(brand, model, year, owner)
        {
        }

        public override void Drive()
        {
            Console.WriteLine("Jazda na elektryczności");
        }
    }
    public class GasolineCar : Car
    {
        public GasolineCar(string brand, string model, int year, string owner) : base(brand, model, year, owner)
        {
        }
        public override void Drive()
        {
            Console.WriteLine("Jazda na bezynie");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Utwórz obiekty ElectricCar i GasolineCar z odpowiednimi markami, modelami, rokiem produkcji i właścicielami.
                        Car car1 = new ElectricCar("Tesla", "Model S", 2020, "Jan Kowalski");
            Car car2 = new GasolineCar("Ford", "Mustang", 2018, "Anna Nowak");
            Car car3 = new ElectricCar("Nissan", "Leaf", 2019, "Piotr Wiśniewski");
            Car car4 = new GasolineCar("BMW", "X5", 2017, "Katarzyna Zielińska");

            //Wywołaj metody StartEngine() i Drive() dla każdego obiektu.
            car1.StartEngine();
            car1.Drive();
            car2.StartEngine();
            car2.Drive();
            car3.StartEngine();
            car3.Drive();
            car4.StartEngine();
            car4.Drive();
            Console.WriteLine();

            //Utwórz listę cars zawierającą kilka obiektów ElectricCar i GasolineCar
            List<Car> cars = new List<Car>()
            {
                 new ElectricCar("Tesla", "Model S", 2020, "Jan Kowalski"),
                 new GasolineCar("Ford", "Mustang", 2018, "Anna Nowak"),
                 new ElectricCar("Nissan", "Leaf", 2019, "Piotr Wiśniewski"),
                 new GasolineCar("BMW", "X5", 2017, "Katarzyna Zielińska")
            };

            //Iteruj przez listę i wywołaj metody StartEngine() i Drive() dla każdego samochodu.
            foreach (Car car in cars)
            {
                car.StartEngine();
                car.Drive();
            }

            //Lista posortowana alfabetycznie wg. właściciela
            var SortedByOwner = cars.OrderBy(car => car.Owner);
            Console.WriteLine("\nLista posortowana alfabetycznie wg. właściciela:");
            DisplayCarsList(SortedByOwner, $"\nMarka | Model | Rok Produkcji | Właściciel");

            //Lista posortowana rosnąco wg. roku produkcji
            var SortedByYear = cars.OrderBy(car => car.Year);
            Console.WriteLine("\nLista posortowana rosnąco wg. roku produkcji:");
            DisplayCarsList(SortedByYear, $"\nMarka | Model | Rok Produkcji | Właściciel");

            //Lista posortowana alfabetycznie wg. marki
            var SortedByBrand = cars.OrderBy(car => car.Brand);
            Console.WriteLine("\nLista posortowana alfabetycznie wg. marki:");
            DisplayCarsList(SortedByBrand, $"\nMarka | Model | Rok Produkcji | Właściciel");

            //Lista posortowana alfabetycznie wg. modelu
            var SortedByModel = cars.OrderBy(car => car.Model);
            Console.WriteLine("\nLista posortowana alfabetycznie wg. modelu:");
            DisplayCarsList(SortedByModel, $"Marka | Model | Rok Produkcji | Właściciel");

            Console.WriteLine("Naciśnij dowolny przycisk aby przejść do menu. . .");
            Console.ReadKey();

            //menu
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Lista posortowana alfabetycznie wg. właściciela");
                Console.WriteLine("2. Lista posortowana rosnąco wg. roku produkcji");
                Console.WriteLine("3. Lista posortowana alfabetycznie wg. marki");
                Console.WriteLine("4. Lista posortowana alfabetycznie wg. modelu");
                Console.WriteLine("5. Wyjście z programu");
                int choice = GetUserInputInt("Wybierz opcje: ");
                switch(choice)
                {
                    case 1:
                        DisplayCarsList(SortedByOwner, $"\nMarka | Model | Rok Produkcji | Właściciel");
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować. . .");
                        Console.ReadKey();
                        break;
                    case 2:
                        DisplayCarsList(SortedByYear, $"\nMarka | Model | Rok Produkcji | Właściciel");
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować. . .");
                        Console.ReadKey();
                        break;
                    case 3:
                        DisplayCarsList(SortedByBrand, $"\nMarka | Model | Rok Produkcji | Właściciel");
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować. . .");
                        Console.ReadKey();
                        break;
                    case 4:
                        DisplayCarsList(SortedByModel, $"\nMarka | Model | Rok Produkcji | Właściciel");
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować. . .");
                        Console.ReadKey();
                        break;
                    case 5:
                        return;
                }
            }
        }

        private static void DisplayCarsList(IOrderedEnumerable<Car> sortedCars, string prompt)
        {
            Console.WriteLine(prompt);
            foreach (Car car in sortedCars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        static int GetUserInputInt(string prompt)
        {
            Console.Write(prompt);
            int input = 0;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(),out input))
                {
                    return input;
                }
                else
                {
                    Console.Write("Źle wprowadzone dane, spróbuj ponownie: ");
                }
            }
        }
       
    }
}
