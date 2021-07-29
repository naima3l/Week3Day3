using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day3
{
    class PaperBooksRepository : IDBrepository<PaperBook>
    {
        static List<PaperBook> paperBooks = new List<PaperBook>() 
        { 
            new PaperBook("Harry Potter e la pietra filosofale", "J.K.Rowling", 22, 350, 60),
            new PaperBook("Harry Potter e la camera dei segreti", "J.K.Rowling", 22, 350, 46),
            new PaperBook("Harry Potter e il prigioniero di Azkaban", "J.K.Rowling", 23, 400, 15),
            new PaperBook("Harry Potter e il calice di fuoco", "J.K.Rowling", 25, 500, 19),
            new PaperBook("Harry Potter e l'ordine della fenice", "J.K.Rowling", 30, 600, 34),
            new PaperBook("Harry Potter e il principe mezzosangue", "J.K.Rowling", 32, 700, 23),
            new PaperBook("Harry Potter e i doni della morte", "J.K.Rowling", 43, 1000, 6)
         };
        public List<PaperBook> Fetch()
        {
            return paperBooks;
        }

        public List<PaperBook> FetchStaticList()
        {
            return paperBooks;
        }

        public bool QtyBook(string title, int quantity)
        {
            int check = paperBooks.Count(t => t.Title == title);
            if (check == 0)
            {
                return false;
            }
            else
            {
                var pb = from p in paperBooks
                         where p.Title == title
                         select p;

                PaperBook paperBook = pb.First();
                paperBook.QuantityInStore = quantity;
                return true;
            }
        }

        internal List<PaperBook> ShowPaperBookByPrice(decimal price)
        {
            var paperb = paperBooks.Where(t => t.Price > price);
            List<PaperBook> pb = new List<PaperBook>();

            if (paperb.Count() > 0)
            {
                foreach (var paperBook in paperb)
                {
                    pb.Add(paperBook);
                }
            }

            return pb;
        }

        internal bool AddPaperBook(PaperBook p)
        {
            int c = paperBooks.Count(t => t.Title == p.Title);
            if (c == 0)
            {
                paperBooks.Add(p);
                return true;
            }
            else
            {
                foreach (var paperBook in paperBooks)
                {
                    if (paperBook.Title == p.Title)
                    {
                        paperBook.QuantityInStore++;
                    }
                }
                return false;
            }
            
        }
    }
}
