using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bazedy_Games.Services
{
    public interface ICategoryService
    {
        public List<SelectListItem> GetCategories();
    }
}
