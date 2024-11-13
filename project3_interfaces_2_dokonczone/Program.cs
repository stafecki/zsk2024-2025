using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3_interfaces_2_dokonczone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace project3_interfaces_2
    {
        // Definicja interfejsu dla pojazdów
        public interface IVehicle
        {
            void Start(); // Metoda do uruchomienia pojazdu
            void Stop();  // Metoda do zatrzymania pojazdu
            void StartNavigation();
            void StopNavigation();
        }

        // Definicja interfejsu dla pojazdów elektrycznych
        public interface IElectricVehicle : IVehicle
        {
            void ChargeBattery(); // Metoda do ładowania baterii
        }

        public interface IHybridVehicle : IVehicle
        {
            void SwitchToElectricMode();
            void SwitchToFuelMode();
        }

        public interface IFourWheelDriveVehicle : IVehicle
        {
            void EngageFourWheelDrive();
            void DisengageFourWheelDrive();
        }

        // Klasa bazowa dla wszystkich pojazdów
        public abstract class Vehicle : IVehicle
        {
            public string Brand { get; set; }  // Marka pojazdu
            public string Model { get; set; } // Model pojazdu
            public string GPS { get; set; }

            // Konstruktor klasy Vehicle
            public Vehicle(string make, string model, string gps)
            {
                Brand = make;
                Model = model;
                GPS = gps;
            }

            // Wirtualna metoda do uruchomienia pojazdu
            public virtual void Start()
            {
                Console.WriteLine($"{Brand} {Model} uruchamia się.");
            }

            // Wirtualna metoda do zatrzymania pojazdu
            public virtual void Stop()
            {
                Console.WriteLine($"{Brand} {Model} zatrzymuje się.");
            }

            public void StartNavigation()
            {
                Console.WriteLine($"{Brand} {Model} rozpoczyna nawigację do {GPS}");
            }

            public void StopNavigation()
            {
                Console.WriteLine($"{Brand} {Model} zatrzymuje nawigację");
            }
        }

        // Klasa pochodna dla samochodów
        public class Car : Vehicle
        {
            public int NumberOfDoors { get; set; } // Liczba drzwi w samochodzie

            // Konstruktor klasy Car
            public Car(string make, string model, int numberOfDoors, string gps)
                : base(make, model, gps)
            {
                NumberOfDoors = numberOfDoors;
            }

            // Nadpisana metoda do uruchomienia samochodu
            public override void Start()
            {
                Console.WriteLine($"{Brand} {Model} z {NumberOfDoors} drzwiami uruchamia się.");
            }

            // Nadpisana metoda do zatrzymania samochodu
            public override void Stop()
            {
                Console.WriteLine($"{Brand} {Model} z {NumberOfDoors} drzwiami zatrzymuje się.");
            }
        }

        // Klasa pochodna dla samochodów elektrycznych
        public class ElectricCar : Car, IElectricVehicle
        {
            public int BatteryCapacity { get; set; } // Pojemność baterii w kWh

            // Konstruktor klasy ElectricCar
            public ElectricCar(string make, string model, string gps, int numberOfDoors, int batteryCapacity)
                : base(make, model, numberOfDoors, gps)
            {
                BatteryCapacity = batteryCapacity;
            }

            // Implementacja metody ładowania baterii
            public void ChargeBattery()
            {
                Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity} kWh ładuje się.");
            }

            // Nadpisana metoda do uruchomienia samochodu elektrycznego
            public override void Start()
            {
                Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity} kWh uruchamia się cicho.");
            }

            // Nadpisana metoda do zatrzymania samochodu elektrycznego
            public override void Stop()
            {
                Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity} kWh zatrzymuje się cicho.");
            }
        }

        public class HybridCar : Car, IHybridVehicle
        {
            public int BatteryCapacity { get; set; }
            public int FuelCapacity { get; set; }
            public HybridCar(string make, string model, int numberOfDoors, string gps, int batteryCapacity, int fuelCapacity) : base(make, model, numberOfDoors, gps)
            {
                BatteryCapacity = batteryCapacity;
                FuelCapacity = fuelCapacity;
            }

            public void SwitchToElectricMode()
            {
                Console.WriteLine($"{Brand} {Model} przełącza się na tryb elektryczny");
            }

            public void SwitchToFuelMode()
            {
                Console.WriteLine($"{Brand} {Model} przełącza się na tryb paliwowy");
            }

            public override void Start()
            {
                Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity} kWh i zbiornikiem paliwa o pojemności {FuelCapacity} litrów uruchamia się");
            }

            public override void Stop()
            {
                Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity} kWh i zbiornikiem paliwa o pojemności {FuelCapacity} litrów zatrzymuje się");
            }
        }

        public class FourWheelDriveCar : Car, IFourWheelDriveVehicle
        {
            public FourWheelDriveCar(string make, string model, int numberOfDoors, string gps) : base(make, model, numberOfDoors, gps)
            {
            }

            public void DisengageFourWheelDrive()
            {
                Console.WriteLine($"{Brand} {Model} wyłącza napęd na cztery koła");
            }

            public void EngageFourWheelDrive()
            {
                Console.WriteLine($"{Brand} {Model} włącza napęd na cztery koła");
            }

            public override void Start()
            {
                Console.WriteLine($"{Brand} {Model} z napędem na cztery koła uruchamia się");
            }

            public override void Stop()
            {
                Console.WriteLine($"{Brand} {Model} z napędem na cztery koła zatrzymuje się");
            }
        }

        // Klasa główna programu
        public class Program
        {
            public static void Main()
            {
                // Tworzenie listy pojazdów
                List<IVehicle> vehicles = new List<IVehicle>
        {
            new Car("Toyota", "Corolla", 4, "Poznań"),
            new Car("Honda", "Civic", 4, "Gniezno"),
            new Car("Ford", "Mustang", 2, "Gniezno"),
            new ElectricCar("Tesla", "Model S", "Poznań", 4, 100),
            new ElectricCar("Nissan", "Leaf", "Poznań", 4, 40),
            new ElectricCar("Chevrolet", "Bolt", "Poznań", 4, 60),

            new HybridCar("Toyota", "Prius", 4, "Warszawa", 8, 45)

        };

                // Iteracja przez listę pojazdów
                foreach (var vehicle in vehicles)
                {
                    vehicle.Start(); // Uruchomienie pojazdu
                    vehicle.Stop();  // Zatrzymanie pojazdu

                    // Sprawdzenie, czy pojazd jest elektryczny
                    if (vehicle is IElectricVehicle electricVehicle)
                    {
                        electricVehicle.ChargeBattery(); // Ładowanie baterii
                    }

                    if (vehicle is IHybridVehicle hybridVehicle)
                    {
                        hybridVehicle.SwitchToElectricMode();
                        hybridVehicle.SwitchToFuelMode();
                    }

                    Console.WriteLine(); // Pusta linia dla czytelności
                }

                Console.ReadKey();
            }
        }


    }
}
