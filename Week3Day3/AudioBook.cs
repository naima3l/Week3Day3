using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day3
{
    class AudioBook : Book
    {
        public TimeSpan Duration { get; set; }

        public AudioBook(string title, string author, decimal price, TimeSpan duration):
            base(title,author, price)
        {
            Duration = duration;
        }

        public override string Print()
        {
            return $"Audio Libro -> {base.Print()}, Durata: {Duration}";
        }
    }
}
