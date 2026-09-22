using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork1
{
    internal class BookDataAccess
    {
        private string fileName = "books.txt";
        private string backupFileName = "books_backup.txt";

        public void AddBook(Book book)
        {
            FileStream fs = new FileStream(fileName, FileMode.Append);

            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(
                book.Id + ", " +
                book.Title + ", " +
                book.Author + ", " +
                book.Price
            );

            writer.Close();
            fs.Close();

            Console.WriteLine("Book added successfully.");
        }

        public List<Book> GetAllBooks()
        {
          
            List<Book> books = new List<Book>();

            if (!File.Exists(fileName))
            {
                return books;
            }

            FileStream fs = new FileStream(fileName, FileMode.Open);

            StreamReader reader = new StreamReader(fs);

            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 4)
                {
                    int id = int.Parse(parts[0].Trim());
                    string title = parts[1].Trim();
                    string author = parts[2].Trim();
                    double price = double.Parse(parts[3].Trim());

                    Book book = new Book(id, title, author, price);

                    books.Add(book);
                }
            }

            reader.Close();
            fs.Close();

            return books;
        }
            
        

        public Book? FindBookById(int id)
        {
            List<Book> books = GetAllBooks();

            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null;
        }

        public void CreateBackup()
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("No books file found.");
                return;
            }

            FileStream source = new FileStream(fileName, FileMode.Open);
            FileStream destination = new FileStream(backupFileName, FileMode.Create);

            int byteData;

            while ((byteData = source.ReadByte()) != -1)
            {
                destination.WriteByte((byte)byteData);
            }

            source.Close();
            destination.Close();

            Console.WriteLine("Backup created successfully.");
        }
    }
}
