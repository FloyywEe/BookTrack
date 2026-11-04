using System;


namespace BookTrack
{
    internal class Magazine : ILibraryItem
    {
        public string Title {  get; private set; }
        public int IssueNumber {  get; private set; }
        public DateTime ReleaseDate {  get; private set; }

        public Magazine(string title, int issueNumber, DateTime releaseDate)
        {
            Title = title;
            IssueNumber = issueNumber;
            ReleaseDate = releaseDate;  
        }

        public string Info()
        {
            return $"{Title,-35} {IssueNumber,-25} {ReleaseDate.ToString("dd.MM.yyyy"),-10}";
        }
    }
}
