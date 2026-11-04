using System;
using System.Collections.Generic;
using System.Linq;



namespace BookTrack
{
    internal class Library
    {
        private List<ILibraryItem> _library;
        public enum ItemType {Book, Magazine, Comic}
        
        public Library()
        {
            _library = new List<ILibraryItem>();
        }

        public void AddItem(ILibraryItem item)
        {
            _library.Add(item);
        }

        public bool RemoveItem(string title, ItemType type)
        {
            if (type != ItemType.Book && type != ItemType.Magazine && type != ItemType.Comic)
                return false;

            ILibraryItem item = _library.FirstOrDefault(x => x.Title == title && IsItemOfType(type, x));

            if (item == null)
                return false;

            _library.Remove(item);

            return true;            
        }

        public bool RemoveItem(int number, ItemType type)
        {
            if(type != ItemType.Book && type != ItemType.Magazine && type != ItemType.Comic)
                return false;

            int countItem = _library.Count(x => IsItemOfType(type, x));


            if (countItem < number || number <= 0)
                return false;

            int removeNumber, itemNumber;

            for(removeNumber = 0, itemNumber = 0; itemNumber < number; removeNumber++)
            {
                if (IsItemOfType(type, _library[removeNumber]))
                    itemNumber++;
            }

            _library.RemoveAt(removeNumber - 1);

            return true;
        }

        public void Sort(bool sortDescending)
        {

            List<ILibraryItem> books = sortDescending
                ? _library.OfType<Book>().OrderByDescending(x => x.Author).ThenByDescending(x => x.Title).Cast<ILibraryItem>().ToList()
                : _library.OfType<Book>().OrderBy(x => x.Author).ThenBy(x => x.Title).Cast<ILibraryItem>().ToList();

            List<ILibraryItem> magazines = sortDescending
                ? _library.OfType<Magazine>().OrderByDescending(x => x.ReleaseDate).ThenByDescending(x => x.Title).Cast<ILibraryItem>().ToList()
                : _library.OfType<Magazine>().OrderBy(x => x.ReleaseDate).ThenBy(x => x.Title).Cast<ILibraryItem>().ToList();

            List<ILibraryItem> comics = sortDescending
                ? _library.OfType<Comic>().OrderByDescending(x => x.Illustrator).ThenByDescending(x => x.Title).Cast<ILibraryItem>().ToList()
                : _library.OfType<Comic>().OrderBy(x => x.Illustrator).ThenBy(x => x.Title).Cast<ILibraryItem>().ToList();

            _library = books.Concat(magazines.Concat(comics)).ToList();
        }

        public void ShowList(ItemType type)
        {
            switch (type)
            {
                case ItemType.Book:
                    Console.WriteLine("Список книг:\n");
                    Console.WriteLine($"{"№",-4} {"Название",-35} {"Автор",-25} {"Жанр",-25} {"Страниц",-10} {"ISBN",-20}");
                    Console.WriteLine(new string('-', 125));

                    for (int i = 0, j = 0; i < _library.Count; i++)
                    {
                        if (!(_library[i] is Book))
                            continue;

                        Console.WriteLine($"{j + 1,-4} {_library[i].Info()}");
                        j++;
                    }

                    break;
                case ItemType.Magazine:
                    Console.WriteLine("Список журналов:\n");
                    Console.WriteLine($"{"№",-4} {"Наименование",-35} {"Номер выпуска",-25} {"Дата выхода",-10}");
                    Console.WriteLine(new string('-', 90));

                    for (int i = 0, j = 0; i < _library.Count; i++)
                    {
                        if (!(_library[i] is Magazine))
                            continue;

                        Console.WriteLine($"{j + 1,-4} {_library[i].Info()}");
                        j++;
                    }

                    break;
                case ItemType.Comic:
                    Console.WriteLine("Список комиксов:\n");
                    Console.WriteLine($"{"№",-4} {"Наименование",-35} {"Иллюстратор",-25} {"Номер",-25}");
                    Console.WriteLine(new string('-', 105));

                    for (int i = 0, j = 0; i < _library.Count; i++)
                    {
                        if (!(_library[i] is Comic))
                            continue;

                        Console.WriteLine($"{j + 1,-4} {_library[i].Info()}");
                        j++;
                    }

                    break;
                default:
                    Console.WriteLine("Некорректное значение ItemType");
                    break;
            }
        }

        private bool IsItemOfType(ItemType type, ILibraryItem item)
        {
            return (type == ItemType.Book && item is Book ||
                type == ItemType.Magazine && item is Magazine ||
                type == ItemType.Comic && item is Comic);
        }
    }
}
