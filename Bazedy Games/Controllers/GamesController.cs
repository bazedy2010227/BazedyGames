using Bazedy_Games.Data;
using Bazedy_Games.Services;
using Bazedy_Games.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bazedy_Games.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IDeviceService _deviceService;
        private readonly IGameService _gameService;
        public GamesController(IDeviceService deviceService,ICategoryService categoryService,IGameService gameService)
        {
            _deviceService = deviceService;
            _categoryService = categoryService;
            _gameService = gameService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameViewModel model = new()
            {
                Categories = _categoryService.GetCategories(),
                Devices = _deviceService.GetDevices()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _gameService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
