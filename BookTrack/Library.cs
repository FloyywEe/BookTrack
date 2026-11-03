using System;
using System.Collections.Generic;
using System.Linq;



namespace BookTrack
{
    internal class Library
    {
        private List<Book> _books;
        
        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)  
        {
            _books.Add(book);
        }

        public bool RemoveBook(int number)
        {
            if (_books.Count < number || number <= 0)
                return false;

            _books.RemoveAt(number - 1);

            return true;
        }
        public bool RemoveBook(string title)
        {
            var book = _books.FirstOrDefault(x => x.Title == title);

            if (book == null)
                return false;
                
            _books.Remove(book);

            return true;
        }

        public void Sort()
        {
            _books.Sort((x, y) =>
                string.Compare(x.Author, y.Author, StringComparison.OrdinalIgnoreCase));
        }

        public void SortDescending()
        {
            _books.Sort((x, y) =>
                string.Compare(y.Author, x.Author, StringComparison.OrdinalIgnoreCase));
        }

        public void ShowList()
        {
            Console.WriteLine("Список книг:\n");

            Console.WriteLine($"{"№",-4} {"Название",-35} {"Автор",-25} {"Жанр",-25} {"Страниц",-10}");
            Console.WriteLine(new string('-', 105));

            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"{i + 1,-4} {_books[i].Title,-35} {_books[i].Author,-25} {_books[i].Genre,-25} {_books[i].NumberOfPages,-10}");
            }
        }
    }
}
