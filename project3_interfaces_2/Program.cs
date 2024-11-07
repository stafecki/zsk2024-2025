using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3_interfaces_2
{
    public interface IVehicle
    {
        void Start();
        void Stop();
    }
    public interface IElectric : IVehicle
    {
        void ChargeBattery();
    }
    public abstract class Vehicle : IVehicle
    {
        public string Brand {  get; set; }
        public string Model { get; set; }
        public Vehicle(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }
        public virtual void Start()
        {
            Console.WriteLine($"{Brand} {Model} uruchamia się");
        }
        public virtual void Stop()
        {
            Console.WriteLine($"{Brand} {Model} zatrzymuje się");
        }
    }
    public class Car : Vehicle
    {
        public int NumberOfDoors {  get; set; }
        public Car(string brand, string model, int numberOfDoors) : base(brand, model)
        {
            NumberOfDoors = numberOfDoors;
        }
        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} z {NumberOfDoors} parami drzwi uruchamia się");
        }
        public override void Stop()
        {
            Console.WriteLine($"{Brand} {Model} z {NumberOfDoors} parami drzwi zatrzymuje się");
        }
    }
    public class ElectricCar : Car, IElectric
    {
        public int BatteryCapacity { get; set; }
        public ElectricCar(string brand, string model, int numberOfDoors, int batteryCapacity) : base(brand, model, numberOfDoors)
        {
            BatteryCapacity = batteryCapacity;
        }
        public void ChargeBattery()
        {
            Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity}kwh ładuje się");
        }
        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity}kwh uruchamia się");
        }
        public override void Stop()
        {
            Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity}kwh zatrzymuje się");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Car("Toyota", "Corolla", 4),
                new Car("Ford", "Mustang", 2),
                new ElectricCar("Telsa", "Model S", 4, 200),
                new ElectricCar("Nissan", "Leaf", 4, 40),
            };
            foreach (var vehicle in vehicles)
            {
                vehicle.Start();
                vehicle.Stop();
                if(vehicle is IElectric ElectricVehicle)
                {
                    ElectricVehicle.ChargeBattery();
                }
            }
            Console.ReadKey();
        }
    }
}
