using HomeWork1;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        BookDataAccess dataAccess = new BookDataAccess();

        while (true)
        {
            Console.WriteLine("\n===== BOOK MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Find Book by ID");
            Console.WriteLine("4. Create Backup");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook(dataAccess);
                    break;

                case "2":
                    ViewAllBooks(dataAccess);
                    break;

                case "3":
                    FindBook(dataAccess);
                    break;

                case "4":
                    dataAccess.CreateBackup();
                    break;

                case "5":
                    Console.WriteLine("Program terminated.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddBook(BookDataAccess dataAccess)
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Book Title: ");
        string? title = Console.ReadLine();

        Console.Write("Enter Author Name: ");
        string? author = Console.ReadLine();

        Console.Write("Enter Price: ");
        double price = double.Parse(Console.ReadLine());

        Book book = new Book()
        {
            Id = id,
            Title = title,
            Author = author,
            Price = price
        };

        dataAccess.AddBook(book);
    }

    static void ViewAllBooks(BookDataAccess dataAccess)
    {
        List<Book> books = dataAccess.GetAllBooks();

        if (books.Count == 0)
        {
            Console.WriteLine("No books found.");
            return;
        }

        Console.WriteLine("\n===== ALL BOOKS =====");

        foreach (Book book in books)
        {
            book.DisplayInfo();
        }
    }

    static void FindBook(BookDataAccess dataAccess)
    {
        Console.Write("Enter Book ID to search: ");
        int id = int.Parse(Console.ReadLine());

        Book? book = dataAccess.FindBookById(id);

        if (book != null)
        {
            Console.WriteLine("\nBook Found:");
            book.DisplayInfo();
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
}