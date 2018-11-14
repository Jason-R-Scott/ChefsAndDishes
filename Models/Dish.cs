using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string DishName { get; set; }
        public int Tastiness { get; set; }
        public int Calories { get; set; }
        public int ChefId   { get; set; }
        public Chef Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}