namespace BookTrack
{
    internal class Comic : ILibraryItem
    {
        public string Title {  get; private set; }
        public string Illustrator {  get; private set; }
        public int Number { get; private set; }
        public string Header { get; private set; } = $"Список комиксов:\n\n{"№",-4} {"Наименование",-35} {"Иллюстратор",-25} {"Номер",-25}\n" + new string('-', 105);

        public Comic(string title, string illustrator, int number)
        {
            Title = title;
            Illustrator = illustrator;
            Number = number;
        }

        public string Info()
        {
            return $"{Title,-35} {Illustrator,-25} {Number,-25}";
        }
    }
}
