using System;
using System.Web.Mvc;
using C9playlist.Models;

namespace C9playlist.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new IndexPageViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(IndexPageViewModel model, FormCollection form)
        {

            if (!String.IsNullOrEmpty(model.SearchParams.TrackName))
            {
                return RedirectToAction("TrackResult", "Result", new
                {
                    albumName = model.SearchParams.AlbumName,
                    artistName = model.SearchParams.ArtistName,
                    playListName = model.SearchParams.PlayListName,
                    trackName = model.SearchParams.TrackName
                });

            }
            if (!String.IsNullOrEmpty(model.SearchParams.PlayListName))
            {
                return RedirectToAction("PlaylistResult", "Result", new
                {
                    albumName = model.SearchParams.AlbumName,
                    artistName = model.SearchParams.ArtistName,
                    playListName = model.SearchParams.PlayListName,
                    trackName = model.SearchParams.TrackName
                });

            }


            string resultType;
            switch (form["ResultType"])
            {
                case "0":
                    resultType = ItemType.Album.ToString().ToLower();
                    return RedirectToAction("AlbumResult", "Result", new
                    {
                        albumName = model.SearchParams.AlbumName,
                        artistName = model.SearchParams.ArtistName,
                        playListName = model.SearchParams.PlayListName,
                        trackName = model.SearchParams.TrackName,
                        type = resultType
                    });
                case "1":
                    resultType = ItemType.Artist.ToString().ToLower();
                    return RedirectToAction("ArtistResult", "Result", new
                    {
                        albumName = model.SearchParams.AlbumName,
                        artistName = model.SearchParams.ArtistName,
                        playListName = model.SearchParams.PlayListName,
                        trackName = model.SearchParams.TrackName,
                         type = resultType
                    });
                case "2":
                    resultType = ItemType.Track.ToString().ToLower();
                    return RedirectToAction("TrackResult", "Result", new
                    {
                        albumName = model.SearchParams.AlbumName,
                        artistName = model.SearchParams.ArtistName,
                        playListName = model.SearchParams.PlayListName,
                        trackName = model.SearchParams.TrackName,
                         type = resultType
                    });
                case "3":
                    resultType = ItemType.Playlist.ToString().ToLower();
                    return RedirectToAction("PlaylistResult", "Result", new
                    {
                        albumName = model.SearchParams.AlbumName,
                        artistName = model.SearchParams.ArtistName,
                        playListName = model.SearchParams.PlayListName,
                        trackName = model.SearchParams.TrackName,
                        type = resultType
                    });
                default:
                    resultType = ItemType.Track.ToString().ToLower();
                    return RedirectToAction("TrackResult", "Result", new
                    {
                        albumName = model.SearchParams.AlbumName,
                        artistName = model.SearchParams.ArtistName,
                        playListName = model.SearchParams.PlayListName,
                        trackName = model.SearchParams.TrackName,
                        type = resultType
                    });
            }
        }


    }
}