using System.Threading.Tasks;
using C9playlist.Models;

namespace C9playlist.Service
{
    public interface IPlayListService
    {
        Task<object> GetListByArtistAlbum(string artist, string album, string resultType);
        Task<RootObjectPlaylist> GetListByPlaylistName(string playlist);
        Task<RootObjectTrack> GetListBySongName(string songName);

       
    }
}
