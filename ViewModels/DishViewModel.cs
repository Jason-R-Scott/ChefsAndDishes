using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.ViewModels
{
    public class DishViewModel
    {
        [Required]
        public string DishName { get; set; }
        [Required]
        [Range(1,5)]
        public int Tastiness { get; set; }
        [Required]
        [Range(1, Int16.MaxValue)]
        public int Calories { get; set; }
        public int ChefId   { get; set; }
    }
}