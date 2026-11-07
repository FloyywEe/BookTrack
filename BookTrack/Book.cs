namespace BookTrack
{
    internal class Book : ILibraryItem
    {
        public string Title {  get; private set; }
        public string Author { get; private set; }
        public int NumberOfPages { get; private set; }
        public string Genre {  get; private set; }
        public string ISBN {  get; private set; }
        public string Header { get; private set; } = $"Список книг:\n\n{"№",-4} {"Название",-35} {"Автор",-25} {"Жанр",-25} {"Страниц",-10} {"ISBN",-20}\n" + new string('-', 125);

        public Book(string title, string author, int numberOfPages, string genre, string iSBN)
        {
            Title = title;
            Author = author;
            NumberOfPages = numberOfPages;
            Genre = genre;
            ISBN = iSBN;
        }
        public Book(string title, string author, int numberOfPages) 
            : this(title, author, numberOfPages, "Без жанра", "Неизвестно") { }

        public string Info()
        {
            return $"{Title,-35} {Author,-25} {Genre,-25} {NumberOfPages,-10} {ISBN,-20}";
        }
    }
}
