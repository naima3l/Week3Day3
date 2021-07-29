using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day3
{
    class BooksRepository :IDBrepository<Book>
    {
        static List<Book> books = new List<Book>();

        PaperBooksRepository pbr = new PaperBooksRepository();
        AudioBooksRepository abr = new AudioBooksRepository();

        public List<Book> Fetch()
        {
            List<PaperBook> paperBooks = pbr.FetchStaticList();
            List<AudioBook> audioBooks = abr.FetchStaticList();

            books.AddRange(paperBooks);
            books.AddRange(audioBooks);

            return books;
        }

        public List<Book> FetchStaticList()
        {
            return books;
        }
    }
}
