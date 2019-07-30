using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.Controllers;

namespace BookManager
{
    class Program
    {
        static void Main(string[] args)
        {
            BookController bookController = new BookController();
            bookController.Run();
            
        }
    }
}
