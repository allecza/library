using System;
using Library.DataAccess;
using Npgsql;
using ShopOnline.DataAccess;

namespace Library
{
    internal class CreateBookDaoDB:ICreateBook
    {
        
        public DataBaseConnectionService DataBaseConnectionService { get; private set; }

        public CreateBookDaoDB(string hostAdress, string user, string password, string databaseName)
        {
            DataBaseConnectionService=new DataBaseConnectionService(hostAdress, user, password, databaseName);
        }

        public void AddAuthor(string firstName, string lastName)
        {
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string command = $@"INSERT INTO authors(first_name,surname)
                       VALUES('{firstName}','{lastName}')";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);
            preparedCommand.ExecuteNonQuery();
        }

        public void AddPublisher(string publisher)
        {
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string id = RandomizeString(3);
            string command = $@"INSERT INTO publishers(id,name)
                                VALUES('{id}','{publisher}')";
            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);
            preparedCommand.ExecuteNonQuery();
        }

        public void AddBook(long ISBN, string title, int year, double price, string firstName, string surname, string publisher)
        {
            using var con = DataBaseConnectionService.GetDatabaseConnectionObject();
            string id = RandomizeString(3);
            string command = $"INSERT INTO books (\"ISBN\",author_id, title, publisher_id, publication_year, price ) VALUES({ISBN}, (SELECT id FROM authors WHERE first_name = '{firstName}' AND surname = '{surname}'),'{title}',(SELECT id FROM publishers WHERE name = '{publisher}'),{year},{price})";

            con.Open();
            using var preparedCommand = new NpgsqlCommand(command, con);
            preparedCommand.ExecuteNonQuery();
        }

        private string RandomizeString(int howMany)
        {
            string id = "";
            string chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            for (int i = 0; i < howMany; i++)
            {
                int num = rand.Next(0, chars.Length - 1);
                id += chars[num];
            }
            return id;
        }
    }
}