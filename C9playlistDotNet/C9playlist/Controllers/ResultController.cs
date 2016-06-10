using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using C9playlist.Models;
using C9playlist.Service;

namespace C9playlist.Controllers
{
    public class ResultController : Controller
    {
        private readonly IPlayListService _playListService;

        public ResultController(IPlayListService playListService)
        {
            _playListService = playListService;
        }

        // GET: Result
        public async Task<ActionResult> AlbumResult(string albumName,
            string artistName,
            string playListName,
            string trackName,
            string type)
        {

            var viewModel = new AlbumResultPageViewModel();
            
            var result = await _playListService.GetListByArtistAlbum(artistName,albumName,type);

            var castedResult = result as RootObjectAlbum;
            if (castedResult != null)
            {
                viewModel.Limit = castedResult.Albums.Limit.ToString(CultureInfo.InvariantCulture);
                viewModel.Total = castedResult.Albums.Total.ToString(CultureInfo.InvariantCulture);

                viewModel.Albums = castedResult.Albums.Items.Select(x => new AlbumViewModel
                {
                    Image =  x.Images.Any()? x.Images.FirstOrDefault().Url:string.Empty,
                    Name = x.Name,
                    Id = x.Id,
                    Uri = x.Uri
                });
                
            }

            return View(viewModel);
        }
        public async Task<ActionResult> ArtistResult(string albumName,
            string artistName,
            string playListName,
            string trackName,
            string type)
        {



            var viewModel = new ArtistResultPageViewModel();

            var result = await _playListService.GetListByArtistAlbum(artistName, albumName, type);

            var castedResult = result as RootObjectArtist;
            if (castedResult != null)
            {
                viewModel.Limit = castedResult.Artists.Limit.ToString(CultureInfo.InvariantCulture);
                viewModel.Total = castedResult.Artists.Total.ToString(CultureInfo.InvariantCulture);

                viewModel.Artists = castedResult.Artists.Items.Select(x => new ArtistViewModel
                {
                    Image = x.Images.Count>0 ? x.Images.FirstOrDefault().Url : string.Empty,
                    Name = x.Name,
                    Url = x.Uri,
                    Id = x.Id,
                    TotalFollower = x.Followers.Total
                });
            }

            return View(viewModel);


        }
        public async Task<ActionResult> TrackResult(string albumName,
            string artistName,
            string playListName,
            string trackName,
            string type)
        {

            var viewModel = new TrackResultPageViewModel();

            try
            {
                var result = await _playListService.GetListBySongName(trackName);
                if (result != null)
                {
                    viewModel.Limit = result.Tracks.Limit.ToString(CultureInfo.InvariantCulture);
                    viewModel.Total = result.Tracks.Total.ToString(CultureInfo.InvariantCulture);

                    viewModel.Tracks = result.Tracks.Items.Select(x => new TrackViewModel
                    {
                        AlbumName = x.Album.Name,
                        AlbumImg = x.Album.Images.Count > 0 ? x.Album.Images.FirstOrDefault().Url : string.Empty,
                        ArtistNames = x.Artists.Select(y => y.Name).ToList(),
                        Uri = x.Uri,
                        SongName = x.Name

                    });
                }

                if (!string.IsNullOrEmpty(artistName))
                {
                    var filterList = new List<TrackViewModel>();
                    foreach (var track in viewModel.Tracks)
                    {
                        filterList.AddRange(from name in track.ArtistNames where name.ToLower().Contains(artistName.ToLower()) select track);
                    }
                    viewModel.Tracks = filterList;
                }

                if (!string.IsNullOrEmpty(albumName))
                {
                    var filterList = viewModel.Tracks.Where(x => x.AlbumName.ToLower().Contains(albumName.ToLower())).ToList();
                    viewModel.Tracks = filterList;
                }

                if (!string.IsNullOrEmpty(trackName))
                {
                    var filterList = viewModel.Tracks.Where(track => track.SongName.ToLower().Contains(trackName.ToLower())).ToList();
                    viewModel.Tracks = filterList;
                }

                return View(viewModel);

            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }


           





        }
        public async Task<ActionResult> PlaylistResult(string albumName,
            string artistName,
            string playListName,
            string trackName,
            string type)
        {
            var viewModel = new PlaylistResultPageViewModel();

            var result = await _playListService.GetListByPlaylistName(playListName);

            if (result != null)
            {
                viewModel.Limit = result.Playlists.Limit.ToString(CultureInfo.InvariantCulture);
                viewModel.Total = result.Playlists.Total.ToString(CultureInfo.InvariantCulture);

                viewModel.PlayLists = result.Playlists.Items.Select(x => new PlayListViewModel
                {
                    Image = x.Images.Count > 0 ? x.Images.FirstOrDefault().Url : string.Empty,
                    Name = x.Name,
                    Owner = x.Owner.Id,
                    Uri = x.Uri,
                    Id = x.Id
                });
            }

            return View(viewModel);
        }

    }
}