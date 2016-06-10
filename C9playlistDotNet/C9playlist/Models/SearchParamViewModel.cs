namespace C9playlist.Models
{
    public class SearchParamViewModel
    {
        public int NumberOfSongs { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string PlayListName { get; set; }
        public string TrackName { get; set; }
        public ItemType ResultType { get; set; }

    }
}