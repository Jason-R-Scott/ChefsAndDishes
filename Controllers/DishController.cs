using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChefsAndDishes.Data;
using System.Linq;
using ChefsAndDishes.Models;
using ChefsAndDishes.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers
{
    public class DishController : Controller
    {
        private DataContext _context;

        public DishController(DataContext context)
        {
            _context = context;
        }

        // GET: /Home/---------------------------------------------------------

        [HttpGet]
        [Route("Dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = _context.Dishes
                .Include(d => d.Creator)
                .ToList();
            IEnumerable<Dish> SortedDishes = AllDishes.OrderByDescending(d => d.UpdatedAt);

            return View(SortedDishes);
        }

        // GET: /New/---------------------------------------------------------

        [HttpGet ("NewDish")]
        public IActionResult New()
        {
            List<Chef> AllChefs = _context.Chefs.ToList();
            
            ViewBag.Chefs = AllChefs;

            return View("NewDish");
        }

        // POST: /CREATE/---------------------------------------------------------

        [HttpPost ("CreateDish")]
        public IActionResult CreateDish(DishViewModel dish)
        {

            Dish newDish = new Dish
            {
                DishName = dish.DishName,
                Tastiness = dish.Tastiness,
                Calories = dish.Calories,
                ChefId = dish.ChefId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Add(newDish);
            _context.SaveChanges();

            return RedirectToAction("Dishes");
        }
    }
}