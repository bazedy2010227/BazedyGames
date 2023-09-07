using Bazedy_Games.Data;
using Bazedy_Games.Models;
using Bazedy_Games.Settings;
using Bazedy_Games.ViewModels;

namespace Bazedy_Games.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _coverPath;
        public GameService(AppDbContext db,IWebHostEnvironment webHostEnvironment) 
        { 
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _coverPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.CoverPath}";
        }
        public async Task Create(CreateGameViewModel model)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(_coverPath, CoverName);

            using var stream = File.Create(path);
            await model.Cover.CopyToAsync(stream);
            stream.Dispose();
            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                Cover = CoverName,
                CategoryId = model.CategoryId,
                GameDevices = model.SelectedDevices.Select(d=> new GameDevice { DeviceId = d }).ToList() 
            };
            await _db.Games.AddAsync(game);
            await _db.SaveChangesAsync();
        }
    }
}
