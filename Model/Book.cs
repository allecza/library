using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Book
    {
        public long ISBN { get; set; }
        Publisher publisher;
        Author author;
        
        public int Year { get; set; }
        public double Price { get; set; }

        public string Title { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Book(string title, string firstName, string lastName)
        {
            Title = title ;
            FirstName = firstName;
            LastName = lastName;
        }

        public Book(Author author, long iSBN, string title, int year, double price, Publisher publisher)
        {
            this.author = author;
            ISBN = iSBN;
            Title = title;
            Year = year;
            Price = price;
            this.publisher = publisher;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, First Name: {author.FirstName}, Last Name: {author.Surname}, Title: {Title}, Publisher: {publisher.Name}, Year: {Year}, Price:{Price} ";
        }
    }
}
