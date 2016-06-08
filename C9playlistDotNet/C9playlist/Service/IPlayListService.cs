using System.Collections.Generic;
using System.Threading.Tasks;
using C9playlist.Models;

namespace C9playlist.Service
{
    public interface IPlayListService
    {
        Task<IEnumerable<SongListItemViewModel>> GetWholeList();
        IEnumerable<SongListItemViewModel> GetListByArtist(string name);
        Task<IEnumerable<SongListItemViewModel>> GetRandomListByNumber(int number);
    }
}
