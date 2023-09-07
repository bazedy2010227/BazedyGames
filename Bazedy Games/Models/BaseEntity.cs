using System.ComponentModel.DataAnnotations;

namespace Bazedy_Games.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
    }
}
