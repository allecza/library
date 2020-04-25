using System;
using Library.Controller;
using Library.DataAccess;
using Library.Model;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            IEditBook libraryDaoDB = new EditBookDaoDB("localhost", "postgres", "1234", "Library");
            IGetBook readBookFromDaoDB =new  GetBookFromDaoDB("localhost", "postgres", "1234", "Library");
            ICreateBook createBookFromDaoDB=new CreateBookDaoDB("localhost", "postgres", "1234", "Library");
            var mainController = new MainController(libraryDaoDB,readBookFromDaoDB,createBookFromDaoDB);
            mainController.RunMainController();
        }
    }
}
