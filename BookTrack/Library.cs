using System;
using System.Collections.Generic;
using System.Linq;



namespace BookTrack
{
    internal class Library
    {
        private List<Book> _books;
        private List<Magazine> _magazines;
        private List<Comic> _comics;
        
        public Library()
        {
            _books = new List<Book>();
            _magazines = new List<Magazine>();
            _comics = new List<Comic>();
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
            {
                int compareResult = string.Compare(x.Author, y.Author, StringComparison.OrdinalIgnoreCase);

                if (compareResult != 0)
                    return compareResult;

                return string.Compare(x.Title, y.Title, StringComparison.OrdinalIgnoreCase);
            });

            _magazines.Sort((x, y) =>
            {
                int compareResult = DateTime.Compare(x.ReleaseDate, y.ReleaseDate);

                if (compareResult != 0)
                    return compareResult;

                return string.Compare(x.Title, y.Title, StringComparison.OrdinalIgnoreCase);
            });

            _comics.Sort((x, y) =>
            {
                int compareResult = string.Compare(x.Illustrator, y.Illustrator, StringComparison.OrdinalIgnoreCase);

                if (compareResult != 0)
                    return compareResult;

                return string.Compare(x.Title, y.Title, StringComparison.OrdinalIgnoreCase);
            });
        }

        public void SortDescending()
        {
            _books.Sort((x, y) =>
            {
                int compareResult = string.Compare(y.Author, x.Author, StringComparison.OrdinalIgnoreCase);

                if (compareResult != 0)
                    return compareResult;

                return string.Compare(y.Title, x.Title, StringComparison.OrdinalIgnoreCase);
            });

            _magazines.Sort((x, y) =>
            {
                int compareResult = DateTime.Compare(y.ReleaseDate, x.ReleaseDate);

                if (compareResult != 0)
                    return compareResult;

                return string.Compare(y.Title, x.Title, StringComparison.OrdinalIgnoreCase);
            });

            _comics.Sort((x, y) =>
            {
                int compareResult = string.Compare(y.Illustrator, x.Illustrator, StringComparison.OrdinalIgnoreCase);

                if (compareResult != 0)
                    return compareResult;

                return string.Compare(y.Title, x.Title, StringComparison.OrdinalIgnoreCase);
            });
        }

        public void ShowBookList()
        {
            Console.WriteLine("Список книг:\n");

            Console.WriteLine($"{"№",-4} {"Название",-35} {"Автор",-25} {"Жанр",-25} {"Страниц",-10} {"ISBN",-20}");
            Console.WriteLine(new string('-', 125));

            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"{i + 1,-4} {_books[i].Title,-35} {_books[i].Author,-25} {_books[i].Genre,-25} {_books[i].NumberOfPages,-10} {_books[i].ISBN,-20}");
            }
        }

        public void AddMagazine(Magazine magazine)
        {
            _magazines.Add(magazine);
        }

        public bool RemoveMagazine(int number)
        {
            if (_magazines.Count < number || number <= 0)
                return false;

            _magazines.RemoveAt(number - 1);

            return true;
        }

        public bool RemoveMagazine(string title)
        {
            var magazine = _magazines.FirstOrDefault(x => x.Title == title);

            if (magazine == null)
                return false;

            _magazines.Remove(magazine);

            return true;
        }

        public void ShowMagazineList()
        {
            Console.WriteLine("Список журналов:\n");

            Console.WriteLine($"{"№",-4} {"Наименование",-35} {"Номер выпуска",-25} {"Дата выхода",-10}");
            Console.WriteLine(new string('-', 90));

            for (int i = 0; i < _magazines.Count; i++)
            {
                Console.WriteLine($"{i + 1,-4} {_magazines[i].Title,-35} {_magazines[i].IssueNumber,-25} {_magazines[i].ReleaseDate.ToString("dd.MM.yyyy"),-10}");
            }
        }

        public void AddComic(Comic comic)
        {
            _comics.Add(comic);
        }

        public bool RemoveComic(int number)
        {
            if (_comics.Count < number || number <= 0)
                return false;

            _comics.RemoveAt(number - 1);

            return true;
        }

        public bool RemoveComic(string title)
        {
            var comic = _comics.FirstOrDefault(x => x.Title == title);

            if (comic == null)
                return false;

            _comics.Remove(comic);

            return true;
        }

        public void ShowComicList()
        {
            Console.WriteLine("Список комиксов:\n");

            Console.WriteLine($"{"№",-4} {"Наименование",-35} {"Иллюстратор",-25} {"Номер",-25}");
            Console.WriteLine(new string('-', 105));

            for (int i = 0; i < _comics.Count; i++)
            {
                Console.WriteLine($"{i + 1,-4} {_comics[i].Title,-35} {_comics[i].Illustrator,-25} {_comics[i].Number,-25}");
            }
        }
    }
}
