using System;
using System.Collections.Generic;
using System.Text;

namespace Library.View
{
    class EditBookMenuView : AbstractView
    {
        Dictionary<string, string> Menu = new Dictionary<string, string>
        {
            { "1", "Title" },
            {"2", "Author First Name" },
            {"3", "Author surname" },
            { "4", "Publisher "},
            {"5", "Year " },
            {"6", "Price" }

        };
        public override void PrintMenu()
        {
            Console.WriteLine("Edit menu");
            foreach (KeyValuePair<string, string> element in Menu)
            {
                Console.WriteLine($"{element.Key}) {element.Value}");
            }
            Console.WriteLine();
        }
    }
}
