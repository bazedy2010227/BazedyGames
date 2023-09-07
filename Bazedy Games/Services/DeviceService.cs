using Bazedy_Games.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bazedy_Games.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly AppDbContext _db;
        public DeviceService(AppDbContext db)
        {
            _db = db;
        }
        public List<SelectListItem> GetDevices()
        {
            return _db.Devices.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).OrderBy(d => d.Text).AsNoTracking().ToList();
        }
    }
}
