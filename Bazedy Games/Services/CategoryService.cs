using Bazedy_Games.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bazedy_Games.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _db;
        public CategoryService(AppDbContext db)
        {
            _db = db;
        }
        public List<SelectListItem> GetCategories()
        {
            return _db.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).OrderBy(c => c.Text).AsNoTracking().ToList();
        }
    }
}
