using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccess
{
    public interface ICreateBook
    {
        public void AddBook(long ISBN, string title, int year, double price, string firstName, string surname, string publisher);
        public void AddAuthor(string firstName, string lastName);
        public void AddPublisher(string publisher);
    }
}
