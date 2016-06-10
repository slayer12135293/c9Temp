using System.Collections.Generic;

namespace C9playlist.Models
{
    public class ExternalUrls
    {
        public string Spotify { get; set; }
    }

    public class Followers
    {
        public object Href { get; set; }
        public int Total { get; set; }
    }

    public class ItemArtist
    {
        public ExternalUrls ExternalUrls { get; set; }
        public Followers Followers { get; set; }
        public List<object> Genres { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class Artists
    {
        public string Href { get; set; }
        public List<ItemArtist> Items { get; set; }
        public int Limit { get; set; }
        public object Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }

    public class RootObjectArtist
    {
        public Artists Artists { get; set; }
    }




    public class Image
    {
        public int? Height { get; set; }
        public string Url { get; set; }
        public int? Width { get; set; }
    }

    public class ItemAlbum
    {
        public string AlbumType { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class Albums
    {
        public string Href { get; set; }
        public List<ItemAlbum> Items { get; set; }
        public int Limit { get; set; }
        public object Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }

    public class RootObjectAlbum
    {
        public Albums Albums { get; set; }
    }



    
    public class ExternalUrls2
    {
        public string Spotify { get; set; }
    }

    public class Owner
    {
        public ExternalUrls2 ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class Tracks
    {
        public string Href { get; set; }
        public int Total { get; set; }
    }

    public class Item
    {
        public bool Collaborative { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public object Public { get; set; }
        public string SnapshotId { get; set; }
        public Tracks Tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class Playlists
    {
        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }

    public class RootObjectPlaylist
    {
        public Playlists Playlists { get; set; }
    }
    



    public class Artist
    {
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class ExternalIds
    {
        public string Isrc { get; set; }
    }

    public class ExternalUrls3
    {
        public string Spotify { get; set; }
    }

    public class ItemTrack
    {
        public ItemAlbum Album { get; set; }
        public List<Artist> Artists { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public ExternalIds ExternalIds { get; set; }
        public ExternalUrls3 ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string PreviewUrl { get; set; }
        public int TrackNumber { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class TracksTracType
    {
        public string Href { get; set; }
        public List<ItemTrack> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }

    public class RootObjectTrack
    {
        public TracksTracType Tracks { get; set; }
    }

















}