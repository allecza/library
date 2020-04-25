using System;
using System.Collections.Generic;
using System.Text;
using Library.DataAccess;
using Npgsql;
using ShopOnline.DataAccess;

namespace Library.Model
{
    public class EditBookDaoDB : IEditBook,IDelateBook
    {
        BookMaker objectMaker = new BookMaker();
        public DataBaseConnectionService DataBaseConnectionService { get; private set; }

        public EditBookDaoDB( string host, string user, string password,string dbName)
        {
            DataBaseConnectionService = new DataBaseConnectionService(host, user, password, dbName);
        }
       
        public void RemoveBook(int ISBN)
        {
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $"DELETE FROM books WHERE \"ISBN\"={ISBN}";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);
            preparedCommand.ExecuteNonQuery();
        }
      
        public void ChangeAuthorFirstName(int ISBN,string newName)
        {
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $"UPDATE authors SET first_name = '{newName}' WHERE id = (SELECT author_id FROM books WHERE \"ISBN\"= {ISBN})";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);
            preparedCommand.ExecuteNonQuery();
        }

        public void ChangeBookTitle(int ISBN, string newTitle)
        {
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $"UPDATE books SET title = '{newTitle}' WHERE \"ISBN\" = {ISBN} ";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);
            preparedCommand.ExecuteNonQuery();
        }

        public void ChangeAuthorSurname(int ISBN, string newSurname)
        {
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $"UPDATE authors SET surname = '{newSurname}' WHERE id = (SELECT author_id FROM books WHERE \"ISBN\"= {ISBN})";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);
            preparedCommand.ExecuteNonQuery();
        }

        public void changeProductPrice(int ISBN, double newPrice)
        {
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $"UPDATE books SET price = {newPrice} WHERE \"ISBN\" = {ISBN}";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);
            preparedCommand.ExecuteNonQuery();
        }

        public decimal GetLibraryValue()
        {
            decimal totalPrice = 0;
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $"SELECT CAST(SUM(price)AS decimal) FROM books";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);

            using NpgsqlDataReader rdr = preparedCommand.ExecuteReader();

            while (rdr.Read())
            {
                totalPrice = rdr.GetDecimal(0);
            }

            return totalPrice;
        }
    }
}
