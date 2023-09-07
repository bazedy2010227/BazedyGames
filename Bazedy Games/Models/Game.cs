﻿namespace Bazedy_Games.Models
{
    public class Game:BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
    }
}
