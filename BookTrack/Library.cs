using System;
using System.Collections.Generic;
using System.Linq;



namespace BookTrack
{
    internal class Library
    {
        private List<Book> books;
        
        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }


        public bool RemoveBook(int idx)
        {
            if(books.Count < idx || idx <= 0) return false;
            books.RemoveAt(idx - 1);
            return true;
        }
        public bool RemoveBook(string title)
        {
            if (books.Any(x => (x.Title == title)))
            {
                books.Remove(books.First(x => x.Title == title));
                return true;
            }
            else return false;
        }

        public void Sort()
        {
            books = books.OrderBy(x => x.Author).ToList();
        }

        public void SortDescending()
        {
            books = books.OrderByDescending(x => x.Author).ToList();
        }

        public void ShowList()
        {
            Console.WriteLine("Список книг:\n");

            Console.WriteLine($"{"№",-4} {"Название",-35} {"Автор",-25} {"Жанр",-25} {"Страниц",-10}");
            Console.WriteLine(new string('-', 105));

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1, -4} {books[i].Title, -35} {books[i].Author, -25} {books[i].Genre, -25} {books[i].NumberOfPages, -10}");
            }
        }
    }
}
