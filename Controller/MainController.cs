using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Library.DataAccess;
using Library.Model;
using Library.View;

namespace Library.Controller
{
    public class MainController
    {
        IEditBook editBook;
        IGetBook readBook;
        ICreateBook createBook;

        AbstractView mainMenuView=new MainMenuView();
        AbstractView editBookView = new EditBookMenuView();
                               
        public MainController(IEditBook libraryDaoDB, IGetBook readBookFromDaoDB, ICreateBook createBookFromDaoDB)
        {
           editBook = libraryDaoDB;
           readBook = readBookFromDaoDB;
           createBook = createBookFromDaoDB;

        }

        public void RunMainController()
        {
            
            bool isMainControllerActive = true;
            
            while (isMainControllerActive)
            {
                mainMenuView.PrintMenu();
                int.TryParse(mainMenuView.GetUserInput("Your choice: "),out int userChoice);
                MainMenuChoice mainMenu=(MainMenuChoice)userChoice;
                
                switch (mainMenu)
                {
                    case MainMenuChoice.Add:
                        {
                            PreapareBookDeatalis(out long ISBN, out string first_name, out string surname, out string publisher, out string title, out int year, out double price);

                            createBook.AddAuthor(first_name, surname);
                            createBook.AddPublisher(publisher);
                            createBook.AddBook(ISBN, title, year, price, first_name, surname, publisher);
                            break;
                        }

                    case MainMenuChoice.Edit:
                        {
                            PrepareEdit(out int ISBN, out EditOptions editOptions);
                            switch (editOptions)
                            {
                                case EditOptions.FirstName:
                                    ChangeFirstName(ISBN);
                                    break;
                                case EditOptions.Title:
                                    ChangeTitle(ISBN);
                                    break;
                                case EditOptions.Surname:
                                    ChangeSurname(ISBN);
                                    break;
                                case EditOptions.Price:
                                    ChangeAPrice(ISBN);
                                    break;
                            }
                            break;
                        }
                        
                    case MainMenuChoice.Delete:
                        {
                            int.TryParse(mainMenuView.GetUserInput("Type a ISBN: "),out int ISBN);
                            IDelateBook delateBook = (IDelateBook)editBook;
                            delateBook.RemoveBook(ISBN);
                            break;
                        }
                        
                    case MainMenuChoice.SeeAllBooksByAuthor:
                        string author= this.mainMenuView.GetUserInput("Type author: ");
                        List<Book> books = readBook.GetBooksByAuthor(author);
                        mainMenuView.PrintBooks(books);
                        break;

                    case MainMenuChoice.Sort:
                        List<Book> bookAscendigByTitle = readBook.GetBooksAscendigByTitle();
                        this.mainMenuView.PrintBooks(bookAscendigByTitle);
                        break;

                    case MainMenuChoice.BooksCreatedByAuthor:
                        string authors = mainMenuView.GetAuthors();
                        List<Book> bookCreatedByAuthor = readBook.GetBooksByAuthors(authors);
                        this.mainMenuView.PrintBooks(bookCreatedByAuthor);
                        break;

                    case MainMenuChoice.BooksFromLastXYears:
                        int xYears=int.Parse(mainMenuView.GetUserInput("Type number of years: "));
                        List<Book> booksFromLastTenYears = readBook.GetBooksFromLastXYears(xYears);
                        mainMenuView.PrintBooks(booksFromLastTenYears);
                        break;

                    case MainMenuChoice.ValueOfLibrary:
                        decimal valueOfLibrary = editBook.GetLibraryValue();
                        mainMenuView.PrintMessage($"Total value of yours Library is: {valueOfLibrary}");
                        break;

                    case MainMenuChoice.Exit:
                        isMainControllerActive = false;
                        break;

                    default:
                       mainMenuView.PrintMessage("No option. Please try again");
                        break;
                }
            }
        }

        private void PreapareBookDeatalis(out long ISBN, out string first_name, out string surname, out string publisher, out string title, out int year, out double price)
        {
            List<string> bookDetails = mainMenuView.GetUserInputs(new string[] { "ISBN: ", "Author frist name: ", "Author surname: ", "Publisher: ", "Title: ", "Year: ", "Price: " });
            
            long.TryParse(bookDetails[0], out ISBN);
            first_name = bookDetails[1];
            surname = bookDetails[2];
            publisher = bookDetails[3];
            title = bookDetails[4];
            int.TryParse(bookDetails[5],out year);
            double.TryParse(bookDetails[6],out price);
        }

        private void ChangeAPrice(int bookISBN)
        {
            double.TryParse(mainMenuView.GetUserInput("Type new price"), out double newPrice);
            editBook.changeProductPrice(bookISBN,newPrice);
        }

        private void ChangeSurname(int bookISBN)
        {
            string newSurname = mainMenuView.GetUserInput("Type a surname");
            editBook.ChangeAuthorSurname(bookISBN, newSurname);
        }

        private void ChangeTitle(int bookISBN)
        {
            string newTitle = mainMenuView.GetUserInput("Type a new Title");
            editBook.ChangeBookTitle(bookISBN, newTitle);
        }

        private void ChangeFirstName(int bookISBN)
        {
            string newFirstName = mainMenuView.GetUserInput("Type a name");
            editBook.ChangeAuthorFirstName(bookISBN, newFirstName);
        }

        private void PrepareEdit(out int bookISBN, out EditOptions editOptions)
        {
            int.TryParse(mainMenuView.GetUserInput("Type book ISBN: "), out bookISBN);
            editBookView.PrintMenu();
            int sthToEdit;
            int.TryParse(mainMenuView.GetUserInput("What do you want to edit? "), out sthToEdit);
            editOptions = (EditOptions)sthToEdit;
        }
    }
    
}
