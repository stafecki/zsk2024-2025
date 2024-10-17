using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3_hotel
{
    // Klasa bazowa dla osoby
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    // Klasa reprezentująca gościa, dziedziczy po klasie Person
    public class Guest : Person
    {
        public List<Room> ReservedRoomsList { get; set; }

        public Guest(string firstName, string lastName) : base(firstName, lastName)
        {
            ReservedRoomsList = new List<Room>();
        }

        public void ReserveRoom(Room room)
        {
            ReservedRoomsList.Add(room);
            Console.WriteLine($"Gość {FirstName} {LastName} zarezerwował pokój: {room.RoomNumber} ({room.RoomType})");
        }
    }

    // Klasa reprezentująca pokój
    public class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }

        public Room(int roomNumber, string roomType, decimal pricePerNight)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            PricePerNight = pricePerNight;
        }
    }

    // Klasa reprezentująca hotel
    public class Hotel
    {
        public List<Room> RoomsList { get; set; }
        public List<Guest> GuestsList { get; set; }
        public Hotel()
        {
            RoomsList = new List<Room>();
            GuestsList = new List<Guest>();
        }
        public void AddRoom(Room room)
        {
            RoomsList.Add(room);
        }
        public void DisplayRooms()
        {
            if (RoomsList.Count > 0)
            {
                Console.WriteLine("Pokoje w hotelu: ");
                foreach (Room room in RoomsList)
                {
                    Console.WriteLine($"Pokój {room.RoomNumber} - {room.RoomType} ({room.PricePerNight} PLN na noc)");
                }
            }
            else
            {
                Console.WriteLine("Brak pokoi w hotelu");
            }

        }
        public void AddGuest(Guest guest)
        {
            GuestsList.Add(guest);
            Console.WriteLine($"Dodano gościa {guest.FirstName} {guest.LastName} do listy gości");
        }
        public void DisplayGuests()
        {
            if (GuestsList.Count > 0)
            {
                Console.WriteLine("Goście w hotelu:");
                foreach (Guest guest in GuestsList)
                {
                    Console.WriteLine($"{guest.FirstName} {guest.LastName}");
                }
            }
            else
            {
                Console.WriteLine("Brak gości w hotelu");
            }

        }
        public void ReserveRoom(Guest guest, Room room)
        {
            guest.ReserveRoom(room);
            RoomsList.Remove(room);
        }
        public void DisplayReservedRooms()
        {

            Console.WriteLine("Zarezerwowane pokoje: ");
            foreach (Guest guest in GuestsList)
            {
                foreach (Room room in guest.ReservedRoomsList)
                {
                    Console.WriteLine($"Pokój {room.RoomNumber} ({room.RoomType}) - Zarezerwowany przez: {guest.FirstName} {guest.LastName}");
                }
            }

        }
    }

    public class Program
    {
        public static void Main()
        {
            /*Hotel hotel = new Hotel();

            // Dodawanie pokoi
            Room room1 = new Room(101, "Jednoosobowy", 200m);
            Room room2 = new Room(102, "Dwuosobowy", 300m);
            Room room3 = new Room(103, "Apartament", 500m);
            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            // Wyświetlanie pokoi przed rezerwacją
            hotel.DisplayRooms();
            Console.WriteLine();

            // Dodawanie gości
            Guest guest1 = new Guest("Jan", "Kowalski");
            Guest guest2 = new Guest("Anna", "Nowak");
            Guest guest3 = new Guest("Piotr", "Wiśniewski");
            hotel.AddGuest(guest1);
            hotel.AddGuest(guest2);
            hotel.AddGuest(guest3);

            // Rezerwowanie pokoi
            hotel.ReserveRoom(guest1, room1);
            hotel.ReserveRoom(guest2, room2);
            hotel.ReserveRoom(guest3, room3);
            Console.WriteLine();

            // Wyświetlanie informacji po rezerwacji
            hotel.DisplayGuests();
            Console.WriteLine();

            hotel.DisplayReservedRooms();
            Console.WriteLine();*/

            Hotel hotel = new Hotel();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Dodaj pokój");
                Console.WriteLine("2. Dodaj gościa");
                Console.WriteLine("3. Zarezerwuj pokój");
                Console.WriteLine("4. Wyświetl pokoje");
                Console.WriteLine("5. Wyświetl gości");
                Console.WriteLine("6. Wyświetl zarezerwowane pokoje");
                Console.WriteLine("7. Wyjdź");
                int choice = IntValidInput("Podaj swój wybór: ");
                switch(choice)
                {
                    case 1:
                        Console.Clear();
                        int roomNumber = IntValidInput("Podaj numer pokoju: ");
                        Console.WriteLine("Podaj typ pokoju: ");
                        string roomType = Console.ReadLine();
                        decimal pricePerNight = DecimalValidInput("Podaj cene za noc: ");
                        Room room = new Room(roomNumber, roomType, pricePerNight);
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Podaj imie gościa: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Podaj nazwisko gościa: ");
                        string lastName = Console.ReadLine();
                        Guest guest = new Guest(firstName,lastName);
                        hotel.AddGuest(guest);
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        break;
                    


                }
            }

            Console.ReadKey();
        }

        public static int IntValidInput(string prompt)
        {
            Console.Write(prompt);
            int input;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Niepoprawnie wprowadzone dane");
                }
            }
        }
        public static decimal DecimalValidInput(string prompt)
        {
            Console.Write(prompt);
            decimal input;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Niepoprawnie wprowadzone dane");
                }
            }
        }
    }
}
