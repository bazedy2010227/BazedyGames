using Bazedy_Games.ViewModels;

namespace Bazedy_Games.Services
{
    public interface IGameService
    {
        public Task Create(CreateGameViewModel model); 
    }
}
