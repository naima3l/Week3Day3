using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day3
{
    class PaperBook : Book
    {
        public int PageNumber { get; set; }
        public int QuantityInStore { get; set; }
        public PaperBook(string title, string author, decimal price, int pageNumber, int quantityInStore) :
            base(title, author, price)
        {
            PageNumber = pageNumber;
            QuantityInStore = quantityInStore;
        }

        public override string Print()
        {
            return $"LibroCartaceo -> {base.Print()}, Numero di Pagine: {PageNumber}, Quantità in magazzino: {QuantityInStore}";
        }
    }
}
