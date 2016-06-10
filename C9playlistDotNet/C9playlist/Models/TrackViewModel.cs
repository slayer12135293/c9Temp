using System.Collections.Generic;

namespace C9playlist.Models
{
    public class TrackViewModel
    {
        public string AlbumName { get; set; }
        public string AlbumImg { get; set; }
        public List<string> ArtistNames { get; set; }
        public string SongName { get; set; }
        public string Uri { get; set; }
    }
}