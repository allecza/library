using System.Collections.Generic;

namespace Library.Model
{
    public interface IEditBook
    {
        //void AddBook(List<string> booksDetalis);
        void changeProductPrice(int ISBN,double newPrice);
        void ChangeAuthorFirstName(int ISBN,string newName);
        void ChangeBookTitle(int bookISBN, string newTitle);
        void ChangeAuthorSurname(int bookISBN, string newSurname);
        decimal GetLibraryValue();
    }
}