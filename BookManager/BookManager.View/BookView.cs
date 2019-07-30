using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.Models;


namespace BookManager.View
{
    public class BookView
    {
        readonly static string Book_Display_Format = "{0,-5} | {1,-10} | {2, -10} | {3, -15} | {4, -10}";

        public static int GetMenuChoice()
        {
            int _MenuChoice;
            while (true)
            {
                Console.WriteLine("What would you like to do, please choose an option:");
                Console.WriteLine(" - To add a new Book Title, press 1");
                Console.WriteLine(" - To List all Books in the inventory, press 2");
                Console.WriteLine(" - To Find a Book by ID, press 3");
                Console.WriteLine(" - To Update a Book's info, press 4");
                Console.WriteLine(" - To Delete a Book from the inventory, press 5");
                Console.WriteLine(" - To quit the application, enter 6");
                string User_Entry_string = Console.ReadLine();
                if (int.TryParse(User_Entry_string, out _MenuChoice))
                {
                    if (_MenuChoice > 0 && _MenuChoice < 7)
                    {
                        return _MenuChoice;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid entry, please try again.. ");
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid entry, please try again.. ");
                }

            }



        }

        public static Book GetNewBookInfo()
        {
            string _BookTitle;
            string _BookAuthorName;
            int _BookYear;
            float _BookMRP;

            Console.WriteLine("Please enter Book Details");
            while (true)
            {
                _BookTitle = AskBookTitle();
                if (Validate_Title(_BookTitle))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please try again.. ");
                }

            }
            while (true)
            {

                _BookAuthorName = AskForAuthor();

                if (Validate_Title(_BookAuthorName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please try again.. ");
                }

            }
            while (true)
            {
                Console.Write("Year Published: ");
                string _entry = AskYearPublished(); 

                if (Validate_PublishedYear(_entry, out int Year))
                {
                    _BookYear = Year;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid published year, please try again..");
                }

            }
            while (true)
            {
                string _entry = AskForMRP();
                if (Validate_MRP(_entry, out float MRP))
                {
                    _BookMRP = MRP;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid price, please try again..");
                }

            }

            Book book = new Book(_BookTitle, _BookAuthorName, _BookYear, _BookMRP);

            return book;
        }

        public static void DisplayBook(bool No_Books, Book book = null)
        {
            if (No_Books)
            {
                Console.WriteLine("No books added so far");
            }
            else
            {
                DisplayBookLine(book);
            }

        }
        public static int SearchBook()
        {
            int book_id;
            while (true)
            {
                Console.WriteLine("Please enter the Book ID: ");
                string User_entry = Console.ReadLine();
                if (int.TryParse(User_entry, out book_id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("that was not a valid entry, please try again..");
                }
            }
            return book_id;
        }
        public static Book EditBookInfo(Book book)
        {
            Console.WriteLine("Please provide new info as applicable, if no change required just press enter");

            string _NewTitle = AskBookTitle();
            if (!string.IsNullOrEmpty(_NewTitle))
            {
                book.Title = _NewTitle;
            }

            string _NewAuthor = AskForAuthor();
            if (!string.IsNullOrEmpty(_NewAuthor))
            {
                book.Author_Name = _NewAuthor;
            }

            while (true)
            {
                string _entry = AskYearPublished();
                if (!string.IsNullOrEmpty(_entry))
                {
                    if (Validate_PublishedYear(_entry, out int New_PublishedYear))
                    {
                        book.Year_Published = New_PublishedYear;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid published year, please try again..");
                    }
                }
                else
                {
                    break;
                }

            }
            while (true)
            {
                string _entry = AskForMRP();
                if (!string.IsNullOrEmpty(_entry))
                {
                    if (Validate_MRP(_entry, out float New_MRP))
                    {
                        book.MRP_in_USDollars = New_MRP;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid price, please try again..");
                    }
                }
                else
                {
                    break;
                }

            }

            return book;
        }
        public static bool ConfirmRemoveBook(Book book)
        {
            bool _UserConfirmed;
            Console.WriteLine("Requested book to be removed is:");
            DisplayHeader();
            DisplayBookLine(book);
            DisplayTrailer();

            while (true)
            {
                Console.WriteLine("Are you sure you want to remove this book? Please enter 'Y' for yes and 'N' for no");
                string UserEntry = Console.ReadLine();
                if ((UserEntry == "Y") || (UserEntry == "y"))
                {
                    _UserConfirmed = true;
                    break;
                }

            }

            return _UserConfirmed;

        }

        public static bool Validate_Title(string Title)
        {
            bool _ValidTitle = true;

            if (string.IsNullOrEmpty(Title) || string.IsNullOrWhiteSpace(Title))
            {
                _ValidTitle = false;
            }

            return _ValidTitle;
        }

        public static bool Validate_PublishedYear(string Entry, out int Year)
        {
            bool _ValidYear = true;
            Year = 0;

            if (int.TryParse(Entry, out int result))
            {
                Year = result;

                if (result > DateTime.Today.Year)
                {
                    _ValidYear = false;
                }

            }
            else
            {
                _ValidYear = false;
            }

            return _ValidYear;

        }
        public static bool Validate_MRP(string Entry, out float MRP)
        {
            bool _ValidMRP = true;
            MRP = 0;

            if (float.TryParse(Entry, out float result))
            {
                MRP = result;

                if (result < 0.01)
                {
                    _ValidMRP = false;
                }

            }
            else
            {
                _ValidMRP = false;
            }

            return _ValidMRP;

        }
        public static void DisplayHeader()
        {
            Console.WriteLine();
            Console.WriteLine("_______________________________________________________________________________");
            Console.WriteLine(Book_Display_Format, "ID", "Book Name", "Author", "Year Published", "MRP");
            Console.WriteLine("_______________________________________________________________________________");
        }

        public static void DisplayBookLine(Book book)
        {
            Console.WriteLine(Book_Display_Format, book.Id, book.Title, book.Author_Name, book.Year_Published, $"${book.MRP_in_USDollars}");

        }
        public static void DisplayTrailer()
        {
            Console.WriteLine("_______________________________________________________________________________");
        }
        public static string AskBookTitle()
        {
            string _entry;
            Console.Write("Book Name: ");
            _entry = Console.ReadLine();
            return _entry;
        }
        public static string AskForAuthor()
        {
            Console.Write("Author Name: ");
            string _entry = Console.ReadLine();
            return _entry;
        }
        public static string AskYearPublished()
        {
            Console.Write("Year Published: ");
            string _entry = Console.ReadLine();
            return _entry;
        }
        public static string AskForMRP()
        {
            Console.Write("Enter MRP: $ ");
            string _entry = Console.ReadLine();
            return _entry;
        }


    }

}
