using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Library.Model
{
    class BookMaker
    {
        public List<Book> ParseDBTo(List<Book> books, NpgsqlDataReader rdr)
        {
            
            var author = new Author(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
            long ISBN = rdr.GetInt64(3);
            string title = rdr.GetString(4);
            int year = rdr.GetInt32(5);
            double price = rdr.GetDouble(6);
            var publisher = new Publisher(rdr.GetString(7), rdr.GetString(8));

            books.Add(new Book(author, ISBN, title, year, price, publisher));

            return books;
           
        }
    }
}
