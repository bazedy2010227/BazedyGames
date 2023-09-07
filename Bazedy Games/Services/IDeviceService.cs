using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bazedy_Games.Services
{
    public interface IDeviceService
    {
        public List<SelectListItem> GetDevices();

    }
}
