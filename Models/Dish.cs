using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? Tastiness { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Calories entered must be above 0")]
        public int? Calories { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ChefId { get; set; }

        public Chef Creator { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}