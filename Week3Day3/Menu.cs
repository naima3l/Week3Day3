using System;
using System.Collections.Generic;

namespace Week3Day3
{
    internal class Menu
    {
        // L'utente può decide se stampare a video tutti i libri cartecei, tutti gli audiolibri o tutti i libri
        // Vorrà stampare tutte le proprietà
        // Nel caso scelga di stampare tutti i libri, oltre alle proprietà stampare se è audiol o libro cart

        // Un utente può decidere di inserire un nuovo audiolibro
        //un utente può modificare la quantità in magazzino di un libro cartaceo

        //data una durata visualizzare gli audiolibri con durata <= della durata inserita
        //data un prezzo visualizzare i libri cartacei con prezzo > del prezzo inserito

        //Un utente può decidere di inserire un nuovo libro cartaceo, se il libro esiste già, ne aumenta la quantità
        internal static void Start()
        {
            int choice;
            bool check = false;

            PaperBooksRepository pbr = new PaperBooksRepository();
            AudioBooksRepository abr = new AudioBooksRepository();
            BooksRepository br = new BooksRepository();

            Console.WriteLine("Benvenuto nella libreria!");
            do
            {
                Console.WriteLine("\nInserisci 1 per stampare tutti i libri cartacei \nInserisci 2 per stampare tutti gli Audiolibri \nInserisci 3 per stampare tutti i libri \nInserisci 4 per aggiungere un audio libro \nInserisci 5 per modificare la quantità in magazzino di un libro cartaceo \nInserisci 6 per visualizzare gli audiolibri con durata <= della durata inserita \nInserisci 7 per visualizzare i libri cartacei con prezzo > del prezzo inserito \nInserisci 8 per inserire un nuovo libro cartaceo \nInserisci 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 8)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }


                switch (choice)
                {
                    case 1: //libri cartacei
                        List<PaperBook> paperBooks = pbr.Fetch();
                        foreach (var paperBook in paperBooks)
                        {
                            Console.WriteLine(paperBook.Print());
                        }
                        break;
                    case 2: //audiolibri
                        List<AudioBook> audioBooks = abr.Fetch();
                        foreach (var audioBook in audioBooks)
                        {
                            Console.WriteLine(audioBook.Print());
                        }
                        break;
                    case 3: //tutti i libri
                        List<Book> books = br.Fetch();
                        foreach (var book in books)
                        {
                            Console.WriteLine(book.Print());
                        }
                        break;
                    case 4: //aggiungere audio libro
                        AddAudioBook(abr);
                        break;
                    case 5: //modificare la quantità nel magazzino dei libri cartacei
                        ChangeQty(pbr.Fetch(), pbr);
                        break;
                    case 6: //visualizzare gli audiolibri con durata <= della durata inserita
                        ShowAudioBooksByDuration(abr);
                        break;
                    case 7: //visualizzare i libri cartacei con prezzo > del prezzo inserito
                        ShowPaperBooksByPrice(pbr);
                        break;
                    case 8: //inserire un nuovo libro cartaceo
                        AddPaperBook(pbr);
                        break;
                    case 0:
                        Console.WriteLine("Ciao ciao!");
                        check = true;
                        break;
                }
            } while (check == false);
        }

        private static void AddPaperBook(PaperBooksRepository pbr)
        {
            Console.WriteLine("\nAggiungi un nuovo libro cartaceo!");
            Console.WriteLine("Inserisci titolo");
            string title = Console.ReadLine();
            Console.WriteLine("Inserisci autore");
            string author = Console.ReadLine();
            Console.WriteLine("Inserisci prezzo");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.WriteLine("Inserisci un prezzo valido!");
            }
            Console.WriteLine("Inserisci il numero di pagine");
            int pages;
            while (!int.TryParse(Console.ReadLine(), out pages) || pages <=0)
            {
                Console.WriteLine("Inserisci un numeo valido");
            }
            PaperBook p = new PaperBook(title, author, price, pages, 1);
            bool check = pbr.AddPaperBook(p);
            if (check == true)
            {
                Console.WriteLine("Il libro cartaceo è stato inserito correttamente");
            }
            else Console.WriteLine("Il libro cartaceo non è stato inserito perchè esiste già un libro con lo stesso titolo nella lista, ma ho incrementato il numero in magazzino");
        }

        private static void ShowPaperBooksByPrice(PaperBooksRepository pbr)
        {
            Console.WriteLine("Inserisci prezzo");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.WriteLine("Inserisci un prezzo valido!");
            }

            List<PaperBook> pbPrice = pbr.ShowPaperBookByPrice(price);
            if (pbPrice.Count >= 1)
            {
                Console.WriteLine("\nI libri cartacei con prezzo > di quello inserito sono : \n");
                foreach (var paperBook in pbPrice)
                {
                    Console.WriteLine(paperBook.Print());
                }
            }
            else Console.WriteLine("Nessun libro cartaceo ha prezzo > di quello inserito");
        }

        private static void ShowAudioBooksByDuration(AudioBooksRepository abr)
        { 
            Console.WriteLine("\nInserisci durata in formato 'Hh:Mm:Ss'\n");
            TimeSpan duration;
            while (!TimeSpan.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("Inserisci una durata valida in formato 'Hh:Mm:Ss'");
            }
            List<AudioBook> abDuration = abr.ShowAudioBookByDuration(duration);
            if (abDuration.Count >= 1)
            {
                Console.WriteLine("\nGli audio libri con durata <= di quella inserita sono : \n");
                foreach (var audioBook in abDuration)
                {
                    Console.WriteLine(audioBook.Print());
                }
            }
            else Console.WriteLine("Nessun audio libro ha durata <= di quella inserita");
        }

        private static void ChangeQty(List<PaperBook> paperBooks, PaperBooksRepository pbr)
        {
            Console.WriteLine("\nDi quale libro vuoi modificare la quantità tra quelli in elenco?\n");
            foreach (var paperBook in paperBooks)
            {
                Console.WriteLine(paperBook.Print());
            }
            Console.WriteLine("\nInserisci il titolo del libro di cui vuoi modificare la quantità in magazzino\n");
            string title = Console.ReadLine();
            Console.WriteLine("Inserisci la nuova quantità");
            int qty;
            while (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
            {
                Console.WriteLine("Scelta non valida! Riprova inserendo un numero intero maggiore di zero");
            }
            bool check = pbr.QtyBook(title,qty);
            if(check == true)
            {
                Console.WriteLine("La quantità è stata modificata correttamente");
            }
            else Console.WriteLine("Mi dispiace ma il libro che hai inserito non esiste");
        }

        private static void AddAudioBook(AudioBooksRepository abr)
        {
            Console.WriteLine("\nAggiungi un nuovo audio libro!");
            Console.WriteLine("Inserisci titolo");
            string title = Console.ReadLine();
            Console.WriteLine("Inserisci autore");
            string author = Console.ReadLine();
            Console.WriteLine("Inserisci prezzo");
            decimal price;
            while(!decimal.TryParse(Console.ReadLine(),out price) || price <= 0)
            {
                Console.WriteLine("Inserisci un prezzo valido!");
            }
            Console.WriteLine("Inserisci durata in formato 'HH,MM,SS'");
            TimeSpan duration;
            while(!TimeSpan.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("Inserisci una durata valida in formato 'HH,MM,SS'");
            }
            AudioBook a = new AudioBook(title, author, price, duration);
            bool check = abr.AddAudioBook(a);
            if(check == true)
            {
                Console.WriteLine("L'audio libro è stato inserito correttamente");
            }
            else Console.WriteLine("L'audio libro non è stato inserito perchè esiste già un libro con lo stesso titolo nella lista");

        }
    }
}