
using System.Collections.Generic;

namespace C9playlist.Models
{
    public class BaseProperties
    {
        public string Limit { get; set; }
        public string Total { get; set; }
    }

    public class AlbumResultPageViewModel : BaseProperties
    {
        public IEnumerable<AlbumViewModel> Albums { get; set; }

    }

    public class ArtistResultPageViewModel : BaseProperties
    {
        public IEnumerable<ArtistViewModel> Artists { get; set; }
    }
    public class TrackResultPageViewModel : BaseProperties
    {
        public IEnumerable<TrackViewModel> Tracks { get; set; }
    }
    public class PlaylistResultPageViewModel : BaseProperties
    {
        public IEnumerable<PlayListViewModel> PlayLists { get; set; }
    }



}