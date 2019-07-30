using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.Data;
using BookManager.Models;
using BookManager.View;

namespace BookManager.Data
{
    public class BookRepository
    {
        public List<Book> Books_List = new List<Book>();
        protected int book_id = 0; 
        
        public Book Create(Book book)
        {
            book_id++;
            book.Id = book_id;
            Books_List.Add(book);
            return book;
        }

        public List<Book> ReadAll()
        {
            return Books_List;
        }

        public Book ReadById(int book_id)
        {
            foreach(Book book in Books_List)
            {
                if (book.Id==book_id)
                {
                    return book;
                }
            }
            return null;
        }
        public void Update(int book_id, Book book)
        {
            foreach (Book book1 in Books_List)
            {
                if (book1.Id == book.Id)
                {
                    book1.Author_Name = book.Author_Name;
                    book1.Title = book.Title;
                    break;
                }

            }
        }
        public void Delete(int book_id)
        {
            foreach(Book book1 in Books_List)
            {
                if (book1.Id == book_id)
                {
                    int index = Books_List.IndexOf(book1);
                    Books_List.RemoveAt(index);
                    break;
                }


            }
        }
    }
}
