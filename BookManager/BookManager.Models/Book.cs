using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Models
{
    public class Book
    {
        public int Id{ get; set; }
        public string Title{ get; set; }
        public string Author_Name { get; set; }
        public int Year_Published { get; set; }
        public float MRP_in_USDollars { get; set; }
        public Book(string title, string author,int YearPublished, float MRP)
        {
            Id = 0;
            Title = title;
            Author_Name = author;
            Year_Published = YearPublished;
            MRP_in_USDollars = MRP;
        }






    }
}
