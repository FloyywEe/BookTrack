using System;


namespace BookTrack
{
    internal interface ILibraryItem
    {
        string Title { get; }
        string Info();
        string Header { get; }
    }
}
