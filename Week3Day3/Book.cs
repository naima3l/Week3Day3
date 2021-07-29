using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day3
{
    abstract class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, decimal price )
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public virtual string Print()
        {
            return $"Titolo: {Title}, Autore: {Author}, Prezzo: {Price}";
        }
    }
}
