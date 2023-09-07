using System.ComponentModel.DataAnnotations;

namespace Bazedy_Games.Attributes
{
    public class AllowedExtensionAttributes:ValidationAttribute
    {
        private readonly string _extensions;
        public AllowedExtensionAttributes(string extensions)
        {
            _extensions = extensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var extensions = _extensions.Split(',').Contains(extension,StringComparer.OrdinalIgnoreCase);
                if (!extensions)
                {
                    return new ValidationResult($"images {_extensions} only Are Allowed");
                }
            }
            return ValidationResult.Success;

        }

    }
}
