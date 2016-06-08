using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using C9playlist.Models;
using Newtonsoft.Json;
using WebGrease;

namespace C9playlist.Service
{
    public class PlayListService : IPlayListService
    {
        private readonly HttpClient _client;
        private const string Url = "http://jsonplaceholder.typicode.com/comments";

        public PlayListService()
        {
            _client = new HttpClient { BaseAddress = new Uri(Url) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<IEnumerable<SongListItemViewModel>> GetWholeList()
        {
            var response = await _client.GetAsync("");
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<IEnumerable<JsonObject>>(response.Content.ReadAsStringAsync().Result).OrderBy(x => x.name);
            return result.Select(x => new SongListItemViewModel { Name = x.name, Property1 = x.email });

        }

        public IEnumerable<SongListItemViewModel> GetListByArtist(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<SongListItemViewModel>> GetRandomListByNumber(int number)
        {
            var response = await _client.GetAsync("");
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<IEnumerable<JsonObject>>(response.Content.ReadAsStringAsync().Result).Take(number).OrderBy(x=>x.name);
           
            
            
            return result.Select(x => new SongListItemViewModel { Name = x.name, Property1 = x.email });

        }
    }
}