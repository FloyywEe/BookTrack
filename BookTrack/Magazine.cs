using System;


namespace BookTrack
{
    internal class Magazine
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
    }
}
