using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;

namespace Library.View
{
    class MainMenuView : AbstractView
    {

        Dictionary<string, string> MainMenu = new Dictionary<string, string>()
        {
            {"1", "Add book" },
            {"2", "Edit book" },
            {"3", "Delete book" },
            {"4","Search for books by author surname" },
            {"5","See all books available in the library sorted ascending by title" },
            {"6","How many books authors created." },
            {"7", "All books written in the last ... years" },
            {"8","know the value of my library" },
            {"0","exit" }

        };

        

        public override void PrintMenu()
        {
            Console.WriteLine("Main menu");
            foreach (KeyValuePair<string, string> element in MainMenu)
            {
                Console.WriteLine($"{element.Key}) {element.Value}");
            }
            Console.WriteLine();
        }
    }
}
