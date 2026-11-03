namespace BookTrack
{
    internal class Book
    {
        public string Title {  get; private set; }
        public string Author { get; private set; }
        public int NumberOfPages { get; private set; }
        public string Genre {  get; private set; }
        public string ISBN {  get; private set; }

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

    }
}
