using System.ComponentModel.DataAnnotations;

namespace Bazedy_Games.Attributes
{
    public class MaxSizeAttributes:ValidationAttribute
    {
        private readonly int _maxSize;
        public MaxSizeAttributes(int maxSize)
        {
            _maxSize = maxSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxSize)
                {
                    return new ValidationResult($"Max File Size Is {_maxSize/1024/1024} MB AreAllowed");
                }
            }
            return ValidationResult.Success;

        }
    }
}
