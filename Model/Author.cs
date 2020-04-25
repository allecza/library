using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public Author(int id, string firstName, string surname)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
        }
    }
}
