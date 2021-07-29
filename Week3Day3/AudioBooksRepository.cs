using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day3
{
    class AudioBooksRepository : IDBrepository<AudioBook>
    {
        static TimeSpan duration = new TimeSpan(1, 15, 20);
        static List<AudioBook> audioBooks = new List<AudioBook>()
        {
        new AudioBook("Audio 1", "me", 20, duration),
        new AudioBook("Audio 2", "me", 25, duration),
        new AudioBook("Audio 3", "me", 28, duration),
        new AudioBook("Audio 4", "me", 15, duration)
    };
        
        public List<AudioBook> Fetch()
        {
            return audioBooks;
        }

        public List<AudioBook> FetchStaticList()
        {
            return audioBooks;
        }

        public bool AddAudioBook(AudioBook a)
        {
            int check = audioBooks.Count(t => t.Title == a.Title);
            if (check == 0)
            {
                audioBooks.Add(a);
                return true;
            }
            else return false; 
        }

        public List<AudioBook> ShowAudioBookByDuration(TimeSpan duration)
        {
            var audioBooksD = audioBooks.Where(t => t.Duration <= duration); 
            List<AudioBook> ab = new List<AudioBook>();
            if (audioBooksD.Count() > 0)
            {
                foreach (var audioBook in audioBooksD)
                {
                    ab.Add(audioBook);
                }
            }
            //List<AudioBook> audioBooksD = new List<AudioBook>();
            //foreach (var audioBook in audioBooks)
            //{
            //    if (audioBook.Duration <= duration)
            //    {
            //        audioBooksD.Add(audioBook);
            //    }
            //}

            //return audioBooksD;

            return ab;
        }

    }
}
