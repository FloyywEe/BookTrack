namespace BookTrack
{
    internal class Comic
    {
        public string Title {  get; private set; }
        public string Illustrator {  get; private set; }
        public int Number { get; private set; }

        public Comic(string title, string illustrator, int number)
        {
            Title = title;
            Illustrator = illustrator;
            Number = number;
        }
    }
}
