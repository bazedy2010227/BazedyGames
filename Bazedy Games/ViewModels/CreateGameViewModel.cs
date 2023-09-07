using Bazedy_Games.Attributes;
using Bazedy_Games.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bazedy_Games.ViewModels
{
    public class CreateGameViewModel
    {
        public string Name { get; set; }=string.Empty;
        [AllowedExtensionAttributes(FileSettings.Extension)]
        [MaxSizeAttributes(FileSettings.MaxFileSizeBytes)]
        public IFormFile Cover { get; set; } = default!;
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<int> SelectedDevices { get; set; }=new List<int>();
        public List<SelectListItem> Devices { get; set; } = new List<SelectListItem>();
        public string Description { get; set; }=string.Empty;
    }
}
