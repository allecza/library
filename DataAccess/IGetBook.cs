using System.Collections.Generic;
using Library.Model;

namespace Library.Model
{
    public interface IGetBook
    {
        List<Book> GetBooksByAuthor(string author);
        List<Book> GetBooksAscendigByTitle();
        List<Book> GetBooksByAuthors(string author);
        List<Book>  GetBooksFromLastXYears(int years);
    }
}