using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;

namespace Library.View
{
    abstract public class AbstractView
    {
        abstract public void PrintMenu();

        public string GetUserInput(string message)
        {
            Console.Write(message);
            string output = Console.ReadLine();
            return output;
        }

        internal void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        internal void PrintBooks(List<Book> books)
        {
            if (books.Count > 0)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine(book.ToString());
                }
            }
            else
            {
                Console.WriteLine("No results");
            }
            Console.WriteLine();
        }

        internal string GetAuthors()
        {
            Console.WriteLine("Type number of authors:");
            int numberOfAuthors = int.Parse(Console.ReadLine());
            string authors = "";

            for (int i = 0; i < numberOfAuthors; i++)
            {
                Console.WriteLine($"Type {i + 1} author: ");
                authors += $"'{Console.ReadLine()}',";

            }
            authors = authors.Trim(',');
            return authors;
        }
        internal List<string> GetUserInputs(string[] questions)
        {
            List<string> answers = new List<string>();
            Console.WriteLine("Type :");
            foreach (var question in questions)
            {
                Console.WriteLine(question);
                string answer = Console.ReadLine();
                answers.Add(answer);
            }
            return answers;
        }
    }
}
