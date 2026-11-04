using System;
using System.Globalization;


namespace BookTrack
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int ch;
            bool isRunning = true;
            Library library = new Library();
            LibraryGeneration(library);

            while (isRunning)
            {
                Console.Write("1. Книги\n2. Журналы\n3. Комиксы\n4. Отсортировать всё по возрастанию" +
                    "\n5. Отсортировать всё по убыванию\n0. Выход\nВаш выбор: ");
                try
                {
                    ch = Convert.ToInt32(Console.ReadLine());
                    if (ch < 0 || ch > 5)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Что-то пошло не так\n");
                    continue;
                }
                switch (ch)
                {
                    case 1:
                        Console.WriteLine();
                        BookMenu(library);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        MagazineMenu(library);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        ComicMenu(library);
                        Console.WriteLine();
                        break;
                    case 4:
                        library.Sort(false);
                        Console.WriteLine("Списки отсортированы по возрастанию\n");
                        break;
                    case 5:
                        library.Sort(true);
                        Console.WriteLine("Списки отсортированы по убыванию\n");
                        break;
                    case 0:
                        isRunning = false;
                        break;
                }
            }
        }

        private static void BookMenu(Library library)
        {
            bool isRunnung = true;
            string title, author, genre, isbn;
            int ch, numberOfPages, number;
            while (isRunnung)
            {
                Console.Write("1. Добавить книгу\n2. Удалить книгу(по порядковому номеру)" +
                        "\n3. Удалить книгу(по названию)\n4. Вывести список книг\n0. Выход\nВаш выбор: ");
                try
                {
                    ch = Convert.ToInt32(Console.ReadLine());
                    if (ch < 0 || ch > 4)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Что-то пошло не так\n");
                    continue;
                }
                switch (ch)
                {
                    case 1:
                        Console.Write("Введите название книги: ");
                        title = Console.ReadLine();
                        Console.Write("Введите автора книги: ");
                        author = Console.ReadLine();
                        Console.Write("Введите жанр книги: ");
                        genre = Console.ReadLine();
                        Console.Write("Введите количество страниц в книге: ");
                        try
                        {
                            numberOfPages = Convert.ToInt32(Console.ReadLine());
                            if (numberOfPages <= 0)
                            {
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Количество страниц введено в неверном формате\n");
                            break;
                        }
                        Console.Write("Введите ISBN книги: ");
                        isbn = Console.ReadLine();
                        library.AddItem(new Book(title, author, numberOfPages, genre, isbn));
                        Console.WriteLine("Книга успешно добавлена\n");
                        break;
                    case 2:
                        Console.Write("Введите номер книги, которую хотите удалить: ");
                        try
                        {
                            number = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Номер книги введен в неверном формате\n");
                            break;
                        }
                        Console.WriteLine(library.RemoveItem(number, Library.ItemType.Book)
                            ? "Книга успешно удалена\n"
                            : "Книгу не удалось удалить\n");
                        break;
                    case 3:
                        Console.Write("Введите название книги, которую хотите удалить: ");
                        title = Console.ReadLine();
                        Console.WriteLine(library.RemoveItem(title, Library.ItemType.Book)
                            ? "Книга успешно удалена\n"
                            : "Книгу не удалось удалить\n");
                        break;
                    case 4:
                        library.ShowList(Library.ItemType.Book);
                        Console.WriteLine();
                        break;
                    case 0:
                        isRunnung = false;
                        break;
                }
            }
        }
        private static void MagazineMenu(Library library)
        {
            bool isRunning = true;
            string title, dateString;
            DateTime releaseDate;
            int ch, issueNumber;
            while (isRunning)
            {
                Console.Write("1. Добавить журнал\n2. Удалить журнал(по порядковому номеру)" +
                        "\n3. Удалить журнал(по названию)\n4. Вывести список журналов\n0. Выход\nВаш выбор: ");
                try
                {
                    ch = Convert.ToInt32(Console.ReadLine());
                    if (ch < 0 || ch > 4)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Что-то пошло не так\n");
                    continue;
                }
                switch (ch)
                {
                    case 1:
                        Console.Write("Введите наименование журнала: ");
                        title = Console.ReadLine();

                        Console.Write("Введите номер выпуска журнала: ");
                        try
                        {
                            issueNumber = Convert.ToInt32(Console.ReadLine());
                            if (issueNumber <= 0)
                            {
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Номер выпуска журнала введен в неверном формате\n");
                            break;
                        }

                        Console.Write("Введите дату выхода журнала (дд.мм.гггг): ");
                        dateString = Console.ReadLine();

                        if (!DateTime.TryParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate))
                        {
                            Console.WriteLine("Дата выхода журнала введена в неверном формате\n");
                            break;
                        }

                        library.AddItem(new Magazine(title, issueNumber, releaseDate));
                        Console.WriteLine("Журнал успешно добавлен\n");
                        break;
                    case 2:
                        Console.Write("Введите порядковый номер журнала, который хотите удалить: ");
                        try
                        {
                            issueNumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Номер журнала введен в неверном формате\n");
                            break;
                        }
                        Console.WriteLine(library.RemoveItem(issueNumber, Library.ItemType.Magazine)
                            ? "Журнал успешно удален\n"
                            : "Журнал не удалось удалить\n");
                        break;
                    case 3:
                        Console.Write("Введите название журнала, который хотите удалить: ");
                        title = Console.ReadLine();
                        Console.WriteLine(library.RemoveItem(title, Library.ItemType.Magazine)
                            ? "Журнал успешно удален\n"
                            : "Журнал не удалось удалить\n");
                        break;
                    case 4:
                        library.ShowList(Library.ItemType.Magazine);
                        Console.WriteLine();
                        break;
                    case 0:
                        isRunning = false;
                        break;
                }
            }
        }

        private static void ComicMenu(Library library)
        {
            bool isRunning = true;
            string title, illustrator;
            int ch, number;
            while (isRunning)
            {
                Console.Write("1. Добавить комикс\n2. Удалить комикс(по порядковому номеру)" +
                        "\n3. Удалить комикс(по названию)\n4. Вывести список комиксов\n0. Выход\nВаш выбор: ");
                try
                {
                    ch = Convert.ToInt32(Console.ReadLine());
                    if (ch < 0 || ch > 4)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Что-то пошло не так\n");
                    continue;
                }
                switch (ch)
                {
                    case 1:
                        Console.Write("Введите наименование комикса: ");
                        title = Console.ReadLine();

                        Console.Write("Введите иллюстратора комикса: ");
                        illustrator = Console.ReadLine();

                        Console.Write("Введите номер комикса: ");
                        try
                        {
                            number = Convert.ToInt32(Console.ReadLine());
                            if (number <= 0)
                            {
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Номер комикса введен в неверном формате\n");
                            break;
                        }

                        library.AddItem(new Comic(title, illustrator, number));
                        Console.WriteLine("Комикс успешно добавлен\n");
                        break;
                    case 2:
                        Console.Write("Введите порядковый номер комикса который хотите удалить: ");
                        try
                        {
                            number = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Номер комикса введен в неверном формате\n");
                            break;
                        }
                        Console.WriteLine(library.RemoveItem(number, Library.ItemType.Comic)
                            ? "Комикс успешно удален\n"
                            : "Комикс не удалось удалить\n");
                        break;
                    case 3:
                        Console.Write("Введите название комикса, который хотите удалить: ");
                        title = Console.ReadLine();
                        Console.WriteLine(library.RemoveItem(title, Library.ItemType.Comic)
                            ? "Комикс успешно удален\n"
                            : "Комикс не удалось удалить\n");
                        break;
                    case 4:
                        library.ShowList(Library.ItemType.Comic);
                        Console.WriteLine();
                        break;
                    case 0:
                        isRunning = false;
                        break;
                }
            }
        }
        private static void LibraryGeneration(Library library)
        {
            library.AddItem(new Book("Идиот", "Федор Достоевский", 640, "Роман", "978-5-17-090123-4"));
            library.AddItem(new Book("1984", "Джордж Оруэлл", 328, "Антиутопия", "978-5-17-087345-8"));
            library.AddItem(new Book("Братья Карамазовы", "Федор Достоевский", 1056, "Философский роман", "978-5-17-091234-5"));
            library.AddItem(new Book("Война и мир", "Лев Толстой", 1274, "Исторический роман", "978-5-17-089456-7"));
            library.AddItem(new Book("Бесы", "Федор Достоевский", 768, "Роман", "978-5-17-092345-6"));
            library.AddItem(new Book("Мастер и Маргарита", "Михаил Булгаков", 480, "Мистика", "978-5-17-093456-7"));
            library.AddItem(new Book("Евгений Онегин", "Александр Пушкин", 256, "Роман в стихах", "978-5-17-094567-8"));
            library.AddItem(new Book("Собачье сердце", "Михаил Булгаков", 192, "Сатира", "978-5-17-095678-9"));
            library.AddItem(new Book("Капитанская дочка", "Александр Пушкин", 192, "Исторический роман", "978-5-17-096789-0"));
            library.AddItem(new Book("Вечера на хуторе близ Диканьки", "Николай Гоголь", 320, "Мистика", "978-5-17-097890-1"));
            library.AddItem(new Book("Мёртвые души", "Николай Гоголь", 352, "Сатира", "978-5-17-098901-2"));
            library.AddItem(new Book("Преступление и наказание", "Федор Достоевский", 672, "Драма", "978-5-17-099012-3"));
            library.AddItem(new Book("Шинель", "Николай Гоголь", 96, "Повесть", "978-5-17-100123-4"));
            library.AddItem(new Book("Маленький принц", "Антуан де Сент-Экзюпери", 112, "Сказка", "978-5-17-101234-5"));

            library.AddItem(new Magazine("National Geographic", 1, new DateTime(2025, 3, 15)));
            library.AddItem(new Magazine("Наука и жизнь", 2, new DateTime(2025, 2, 10)));
            library.AddItem(new Magazine("Вокруг света", 3, new DateTime(2025, 5, 5)));
            library.AddItem(new Magazine("Forbes", 4, new DateTime(2025, 4, 12)));
            library.AddItem(new Magazine("Игромания", 5, new DateTime(2025, 1, 20)));
            library.AddItem(new Magazine("Мир фантастики", 6, new DateTime(2025, 3, 15)));
            library.AddItem(new Magazine("Популярная механика", 7, new DateTime(2025, 2, 10)));
            library.AddItem(new Magazine("Техника — молодёжи", 8, new DateTime(2025, 6, 8)));
            library.AddItem(new Magazine("GQ", 9, new DateTime(2025, 4, 12)));
            library.AddItem(new Magazine("Burda", 10, new DateTime(2025, 5, 5)));

            library.AddItem(new Comic("Человек-паук", "Стив Дитко", 1));
            library.AddItem(new Comic("Бэтмен: Начало", "Джим Ли", 2));
            library.AddItem(new Comic("Люди Икс", "Джек Кирби", 3));
            library.AddItem(new Comic("Железный человек", "Стив Дитко", 4));
            library.AddItem(new Comic("Супермен", "Джим Ли", 5));
            library.AddItem(new Comic("Фантастическая четвёрка", "Джек Кирби", 6));
            library.AddItem(new Comic("Халк", "Стив Дитко", 7));
            library.AddItem(new Comic("Зелёный фонарь", "Алекс Росс", 8));
            library.AddItem(new Comic("Дэдпул", "Роб Лайфелд", 9));
            library.AddItem(new Comic("Флэш", "Алекс Росс", 10));
            library.AddItem(new Comic("Тор", "Джек Кирби", 11));
            library.AddItem(new Comic("Сорвиголова", "Джим Ли", 12));
        }
    }
}
