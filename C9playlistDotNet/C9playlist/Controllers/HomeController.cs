using System.Threading.Tasks;
using System.Web.Mvc;
using C9playlist.Models;
using C9playlist.Service;

namespace C9playlist.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayListService _playListService;

        public HomeController(IPlayListService playListService)
        {
            _playListService = playListService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var viewModel = new IndexPageViewModel {DisplayedList = await _playListService.GetWholeList()};

            return View( viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(IndexPageViewModel model)
        {


            var viewModel = new IndexPageViewModel { DisplayedList = await _playListService.GetRandomListByNumber(model.SearchParams.NumberOfSongs) };

            return View(viewModel);
        }

    
    }
}