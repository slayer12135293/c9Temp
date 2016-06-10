using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using C9playlist.Models;
using Newtonsoft.Json;

namespace C9playlist.Service
{
    public class PlayListService : IPlayListService
    {
        private readonly HttpClient _client;
        private readonly string _serviceUrl = ConfigurationManager.AppSettings["serviceUrl"];
        private readonly string _clientId = ConfigurationManager.AppSettings["serviceUrl"];
        private readonly string _clientSecret= ConfigurationManager.AppSettings["serviceUrl"];


        public PlayListService()
        {
            _client = new HttpClient { BaseAddress = new Uri(_serviceUrl) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(Encoding.Default.GetBytes(_clientId+":"+_clientSecret)));

        }

     

        public async Task<object> GetListByArtistAlbum(string artist, string album, string resultType)
        {
            var query = string.Format("search?q=album%3A{0}+artist%3A{1}&type={2}", album, artist, resultType); 
            
            if (string.IsNullOrEmpty(artist))
            {
                query = string.Format("search?q=album%3A{0}&type={1}", album,resultType);
            }
            if (string.IsNullOrEmpty(album))
            {
                query = string.Format("search?q=artist%3A{0}&type={1}", artist, resultType);
            }

            var response = await _client.GetAsync(query);
            response.EnsureSuccessStatusCode();


            if (resultType == ItemType.Album.ToString().ToLower())
            {
                return JsonConvert.DeserializeObject<RootObjectAlbum>(response.Content.ReadAsStringAsync().Result);
                
            }
            if (resultType == ItemType.Artist.ToString().ToLower())
            {
                return JsonConvert.DeserializeObject<RootObjectArtist>(response.Content.ReadAsStringAsync().Result);
              
            }
            if (resultType == ItemType.Playlist.ToString().ToLower())
            {
                return JsonConvert.DeserializeObject<RootObjectPlaylist>(response.Content.ReadAsStringAsync().Result);
                
            }
            if (resultType == ItemType.Track.ToString().ToLower())
            {
                return JsonConvert.DeserializeObject<RootObjectTrack>(response.Content.ReadAsStringAsync().Result);
                
            }
            return null;
        }

        public async Task<RootObjectPlaylist> GetListByPlaylistName(string playlist)
        {
            var query = string.Format("search?q={0}&type=playlist", playlist);
            var response = await _client.GetAsync(query);
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<RootObjectPlaylist>(response.Content.ReadAsStringAsync().Result);
          


        }

        public async Task<RootObjectTrack> GetListBySongName(string songName)
        {
            var query = string.Format("search?q={0}&type=track", songName);
            var response = await _client.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<RootObjectTrack>(response.Content.ReadAsStringAsync().Result);
          


        }

    }
}