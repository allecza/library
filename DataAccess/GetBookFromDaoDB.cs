using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using ShopOnline.DataAccess;

namespace Library.Model
{
    class GetBookFromDaoDB: IGetBook
    {
        BookMaker objectMaker = new BookMaker();
        public DataBaseConnectionService DataBaseConnectionService { get; private set; }

        public GetBookFromDaoDB(string host, string user, string password, string dbName)
        {
            DataBaseConnectionService = new DataBaseConnectionService(host, user, password, dbName);
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> books = new List<Book>();
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $"SELECT authors.id, authors.first_name, authors.surname, books.\"ISBN\",books.title,books.publication_year, books.price,publishers.id,publishers.name FROM books LEFT JOIN authors ON books.author_id = authors.id LEFT JOIN publishers ON publishers.id = books.publisher_id WHERE authors.surname='{author}'";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);

            using NpgsqlDataReader rdr = preparedCommand.ExecuteReader();

            while (rdr.Read())
            {
                books = objectMaker.ParseDBTo(books, rdr);
            }

            return books;
        }

        public List<Book> GetBooksAscendigByTitle()
        {
            List<Book> books = new List<Book>();
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();

            string command = $"SELECT authors.id, authors.first_name, authors.surname, books.\"ISBN\",books.title,books.publication_year, books.price,publishers.id,publishers.name FROM books LEFT JOIN authors ON books.author_id = authors.id LEFT JOIN publishers ON publishers.id = books.publisher_id ORDER BY title ASC";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);

            using NpgsqlDataReader rdr = preparedCommand.ExecuteReader();

            while (rdr.Read())
            {
                books = objectMaker.ParseDBTo(books, rdr);
            }

            return books;
        }
        public List<Book> GetBooksByAuthors(string authors)
        {
            List<Book> books = new List<Book>();
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $"SELECT authors.id, authors.first_name, authors.surname, books.\"ISBN\",books.title,books.publication_year, books.price,publishers.id,publishers.name FROM books LEFT JOIN authors ON books.author_id = authors.id LEFT JOIN publishers ON publishers.id = books.publisher_id WHERE authors.surname in ({authors})";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);

            using NpgsqlDataReader rdr = preparedCommand.ExecuteReader();

            while (rdr.Read())
            {
                books = objectMaker.ParseDBTo(books, rdr);
            }

            return books;
        }
        public List<Book> GetBooksFromLastXYears(int years)
        {
            List<Book> books = new List<Book>();
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $"SELECT authors.id, authors.first_name, authors.surname, books.\"ISBN\",books.title,books.publication_year, books.price,publishers.id,publishers.name FROM books LEFT JOIN authors ON books.author_id = authors.id LEFT JOIN publishers ON publishers.id = books.publisher_id WHERE(CAST(EXTRACT(YEAR FROM CURRENT_TIMESTAMP) AS INTEGER) - books.publication_year) < {years}; ";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);

            using NpgsqlDataReader rdr = preparedCommand.ExecuteReader();

            while (rdr.Read())
            {
                books = objectMaker.ParseDBTo(books, rdr);
            }

            return books;
        }

       
    }
    
}
