using System;


namespace BookTrack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string title, author, genre;
            bool fl = true;
            int ch, numberOfPages, idx;
            Library library = new Library();
            library.AddBook(new Book("Идиот", "Федор Достоевский", 640, "Роман"));
            library.AddBook(new Book("1984", "Джордж Оруэлл", 328, "Антиутопия"));
            library.AddBook(new Book("Братья Карамазовы", "Федор Достоевский", 1056, "Философский роман"));
            library.AddBook(new Book("Война и мир", "Лев Толстой", 1274, "Исторический роман"));
            library.AddBook(new Book("Бесы", "Федор Достоевский", 768, "Роман"));
            library.AddBook(new Book("Мастер и Маргарита", "Михаил Булгаков", 480, "Мистика"));
            library.AddBook(new Book("Евгений Онегин", "Александр Пушкин", 256, "Роман в стихах"));
            library.AddBook(new Book("Собачье сердце", "Михаил Булгаков", 192, "Сатира"));
            library.AddBook(new Book("Капитанская дочка", "Александр Пушкин", 192, "Исторический роман"));
            library.AddBook(new Book("Вечера на хуторе близ Диканьки", "Николай Гоголь", 320, "Мистика"));
            library.AddBook(new Book("Мёртвые души", "Николай Гоголь", 352, "Сатира"));
            library.AddBook(new Book("Преступление и наказание", "Федор Достоевский", 672, "Драма"));
            library.AddBook(new Book("Шинель", "Николай Гоголь", 96, "Повесть"));
            library.AddBook(new Book("Маленький принц", "Антуан де Сент-Экзюпери", 112, "Сказка"));

            while (fl)
            {
                Console.Write("1. Добавить книгу\n2. Удалить книгу(по порядковому номеру)" +
                    "\n3. Удалить книгу(по названию)\n4. Отсортировать по авторам(от А до Я)" +
                    "\n5. Отсортировать по авторам(от Я до А)\n6. Вывести список книг\n0. Выход\nВаш выбор: ");
                try
                {
                    ch = Convert.ToInt32(Console.ReadLine());
                    if (ch < 0 || ch > 6)
                    {
                        throw new Exception();
                    }
                }
                catch {
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
                            if(numberOfPages <= 0)
                            {
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Количество страниц введено в неверном формате\n");
                            break;
                        }
                        library.AddBook(new Book(title, author, numberOfPages, genre));
                        Console.WriteLine("Книга успешно добавлена\n");
                        break;
                    case 2:
                        Console.Write("Введите номер книги, которую хотите удалить: ");
                        try
                        {
                            idx = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Номер книги введен в неверном формате\n");
                            break;
                        }
                        Console.WriteLine(library.RemoveBook(idx) 
                            ? "Книга успешно удалена\n" 
                            : "Книгу не удалось удалить\n");
                            break;
                    case 3:
                        Console.Write("Введите название книги, которую хотите удалить: ");
                        title = Console.ReadLine();
                        Console.WriteLine(library.RemoveBook(title) 
                            ? "Книга успешно удалена\n" 
                            : "Книгу не удалось удалить\n");
                        break;
                    case 4:
                        library.Sort();
                        Console.WriteLine("Книги отсортированы от А до Я\n");
                        break;
                    case 5:
                        library.SortDescending();
                        Console.WriteLine("Книги отсортированы от Я до А\n");
                        break;
                    case 6:
                        library.ShowList();
                        Console.WriteLine();
                        break;
                    case 0:
                        fl = false;
                        break;
                }
            }
        }
    }
}
