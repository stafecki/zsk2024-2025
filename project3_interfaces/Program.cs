using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3_interfaces
{
    class Book : IComparable<Book>
    {
        string title;
        public string Author;
        public int YearOfPublication;
        public double Price;

        public Book(string title, string author, int yearOfPublication, double price)
        {
            this.title = title;
            Author = author;
            YearOfPublication = yearOfPublication;
            Price = price;
        }
        public override string ToString()
        {
            return $"{title}, {Author}, {YearOfPublication}, {Price}zł";
        }
        public int CompareTo(Book other)
        {
            return Price.CompareTo(other.Price);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("Hobbit", "Nowak", 1937, 45.99));
            books.Add(new Book("Hobbit 2", "Pawlak", 2000, 145.99));
            books.Add(new Book("Hobbit 3", "Kowalski", 2000, 5.99));
            books.Add(new Book("Hobbit 4", "Arbus", 2012, 5.99));

            Console.WriteLine("Lista książek: ");
            foreach(Book book in books)
            {
                Console.WriteLine(book.ToString());
            }

            books.Sort();

            Console.WriteLine("\nPosortowana lista książek: ");
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\nPosortowana lista książek wg. daty publikacji: ");
            var sortedByYear = books.OrderBy(b => b.YearOfPublication);
            foreach (Book book in sortedByYear)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\nPosortowana lista książek wg. autora (nierosnąco): ");
            var sortedByAuthor = books.OrderByDescending(b => b.Author);
            foreach (Book book in sortedByAuthor)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("\nPosortowana lista książek wg. ceny (nierosnąco), a nastepnie wg. roku publikacji od najstarszej ksiazki: ");
            var sortedByPriceAndYearOfPublication = books.OrderByDescending(b => b.Price).ThenBy(b => b.YearOfPublication);
            foreach (Book book in sortedByPriceAndYearOfPublication)
            {
                Console.WriteLine(book);
            }

            Console.ReadKey();
        }
    }
}
