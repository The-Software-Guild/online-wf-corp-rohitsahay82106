using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.View;
using BookManager.Models;
using BookManager.Data;

namespace BookManager.Controllers
{
    public class BookController
    {
        public BookRepository bookRepository = new BookRepository();

        public void Run()
        {
            bool _UserWantsToQuit = false;
            do
            {
                int _MenuChoice = BookView.GetMenuChoice();
                MenuChoice Choice = Process_MenuChoice(_MenuChoice);

                switch (Choice)
                {
                    case MenuChoice.Create:
                        CreateBook();
                        break;
                    case MenuChoice.ReadAll:
                        DisplayBooks();
                        break;
                    case MenuChoice.FindByID:
                        SearchBooks();
                        break;
                    case MenuChoice.Edit:
                        DisplayBooks();
                        EditBook();
                        break;
                    case MenuChoice.Delete:
                        DisplayBooks();
                        RemoveBook();
                        break;
                    case MenuChoice.Quit:
                        _UserWantsToQuit = true;
                        break;
                }
            } while (!_UserWantsToQuit);            
        }
        private void CreateBook()
        {
            Book book = BookView.GetNewBookInfo();
            bookRepository.Create(book);
            bool No_Books = false;
            BookView.DisplayHeader();
            BookView.DisplayBook(No_Books, book);
            BookView.DisplayTrailer();
            return; 
        }
        private void DisplayBooks()
        {
            List<Book> Books_List = bookRepository.ReadAll();
            bool No_Books;

            if (Books_List.Count == 0)
            {
                No_Books = true;
                BookView.DisplayBook(No_Books);
            }
            else
            {
                BookView.DisplayHeader();
                foreach (Book book in Books_List)
                {
                    No_Books = false;
                    BookView.DisplayBook(No_Books,book);
                }
                BookView.DisplayTrailer();
            }
        }
        private void SearchBooks()
        {
            int book_id = AskForID();
            bool _NoBooks = DoesBookExist(book_id, out Book book);
            if(_NoBooks)
            {
               BookView.DisplayBook(_NoBooks);
            }
            else
            {
                BookView.DisplayHeader();
                BookView.DisplayBook(_NoBooks, book);
                BookView.DisplayTrailer();
            }
            
        }
        private void EditBook()
        {
            int book_id = AskForID();
            bool _NoBooks = DoesBookExist(book_id, out Book book);
            if (_NoBooks)
            {
                BookView.DisplayBook(_NoBooks);
            }
            else
            {
                BookView.DisplayHeader();
                BookView.DisplayBook(_NoBooks, book);
                BookView.DisplayTrailer();
                book = BookView.EditBookInfo(book);
                bookRepository.Update(book_id, book);
            }

        }
        private void RemoveBook()
        {
            int book_id = AskForID();
            bool _NoBooks = DoesBookExist(book_id, out Book book);
            if (_NoBooks)
            {
                BookView.DisplayBook(_NoBooks);
            }
            else
            {
                bool _UserConfirmed = BookView.ConfirmRemoveBook(book);
                if (_UserConfirmed)
                {
                    bookRepository.Delete(book.Id);
                }
            }
        }        
        public int AskForID()
        {
            int book_id = BookView.SearchBook();
            return book_id;
        }
        public bool DoesBookExist(int book_id, out Book book)
        {
            bool _NoBooks;
            book = bookRepository.ReadById(book_id);
            if (book == null)
            {
                _NoBooks = true;
            }
            else
            {
                _NoBooks = false;
            }
            return _NoBooks;
        }
        public MenuChoice Process_MenuChoice(int _MenuChoice)
        {
            switch(_MenuChoice)
            {
                case 1:
                    return MenuChoice.Create;
                case 2:
                    return MenuChoice.ReadAll;
                case 3:
                    return MenuChoice.FindByID;
                case 4:
                    return MenuChoice.Edit;
                case 5:
                    return MenuChoice.Delete;
                case 6:
                    return MenuChoice.Quit;
            }
            return MenuChoice.Invalid;

        }
        public enum MenuChoice
        {
            Create=1,
            ReadAll=2,
            FindByID=3,
            Edit=4,
            Delete=5,
            Quit=6,
            Invalid
        }

    }

}
