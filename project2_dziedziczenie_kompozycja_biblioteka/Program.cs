using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2_dziedziczenie_kompozycja_biblioteka
{
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

    public class Author : Person
    {
        public List<Book> BookList { get; set; }

        public Author(string firstName, string lastName) : base(firstName, lastName)
        {
            BookList = new List<Book>();
        }

        public void AddBook(Book book)
        {
            BookList.Add(book);
        }

        public void DisplayBooks()
        {
            Console.WriteLine("Lista książek: ");
            foreach (Book book in BookList)
            {
                Console.WriteLine(book.Title);
            }
        }
    }

    public class Reader : Person
    {
        public List<Book> BorrowedBooksList { get; set; }
        public Reader(string firstName, string lastName) : base(firstName, lastName)
        {
            BorrowedBooksList = new List<Book>();
        }
        public void BorrowBook(Book book)
        {
            BorrowedBooksList.Add(book);
            Console.WriteLine($"Czytelnik {FirstName} {LastName} wypożyczył książke o tytule: \"{book.Title}\"");
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }
        public Book(string title, Author author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }
    }

    public class Library
    {
        public List<Book> BooksList { get; set; }
        public List<Reader> ReaderList { get; set; }
        public Library()
        {
            BooksList = new List<Book>();
            ReaderList = new List<Reader>();
        }
        public void AddBook(Book book)
        {
            BooksList.Add(book);
            Console.WriteLine($"Dodano książkę: \"{book.Title}\"");
        }
        public void AddReader(Reader reader)
        {
            ReaderList.Add(reader);
            Console.WriteLine($"Dodano czytelnika: {reader.FirstName} {reader.LastName}");
        }
        public void BorrowBook(Reader reader, Book book)
        {
            if (BooksList.Contains(book))
            {
                reader.BorrowBook(book);
                BooksList.Remove(book);
            }
            else
            {
                Console.WriteLine($"Książka o tytule \"{book.Title}\" nie jest dostępna w bibliotece");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Author author1 = new Author("Adam", "Mickiewicz");
            Book book1 = new Book("Pan Tadeusz", author1, 1834);
            author1.AddBook(book1);

            Reader reader1 = new Reader("Jan", "Kowalski");
            Library library1 = new Library();
            library1.AddBook(book1);
            library1.AddReader(reader1);
            library1.BorrowBook(reader1 , book1);
            /*library1.BorrowBook(reader1 , book1);*/
            Console.ReadKey();
        }
    }
}
