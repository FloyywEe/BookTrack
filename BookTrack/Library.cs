using System;
using System.Collections.Generic;
using System.Linq;



namespace BookTrack
{
    internal class Library
    {
        private List<ILibraryItem> _library;
        
        public Library()
        {
            _library = new List<ILibraryItem>();
        }

        public void AddItem(ILibraryItem item)
        {
            _library.Add(item);
        }

        public bool RemoveItem<T>(string title) where T : class, ILibraryItem
        {
            ILibraryItem item = _library.FirstOrDefault(x => x.Title == title && x is T);

            if (item == null)
                return false;

            _library.Remove(item);

            return true;            
        }

        public bool RemoveItem<T>(int number) where T : class, ILibraryItem
        {
            int removeNumber, itemNumber;

            if (number <= 0)
                return false;

            for(removeNumber = 0, itemNumber = 0; itemNumber < number && removeNumber < _library.Count; removeNumber++)
            {
                if (_library[removeNumber] is T)
                    itemNumber++;
            }

            if (itemNumber < number)
                return false;

            _library.RemoveAt(removeNumber - 1);

            return true;
        }

        public void Sort(bool sortDescending)
        {
            var books = _library.OfType<Book>();
            var magazines = _library.OfType<Magazine>();
            var comics = _library.OfType<Comic>();

            if (sortDescending)
            {
                books = books.OrderByDescending(x => x.Author).ThenByDescending(x => x.Title);
                magazines = magazines.OrderByDescending(x => x.ReleaseDate).ThenByDescending(x => x.Title);
                comics = comics.OrderByDescending(x => x.Illustrator).ThenByDescending(x => x.Title);
            }
            else
            {
                books = books.OrderBy(x => x.Author).ThenBy(x => x.Title);
                magazines = magazines.OrderBy(x => x.ReleaseDate).ThenBy(x => x.Title);
                comics = comics.OrderBy(x => x.Illustrator).ThenBy(x => x.Title);
            }

            _library = books.Cast<ILibraryItem>().Concat(magazines).Concat(comics).ToList();
        }

        public void ShowList<T>() where T : class, ILibraryItem
        {
            var items = _library.OfType<T>().ToList();
            if (!items.Any())
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Console.WriteLine(items[0].Header);
            for(int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1,-4} {items[i].Info()}");
            }
        }
    }
}
