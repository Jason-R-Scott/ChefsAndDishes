using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.ViewModels
{
    public class ChefViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}