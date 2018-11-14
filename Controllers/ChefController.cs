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


    public class ChefController : Controller
    {
        
        private DataContext _context;

        public ChefController(DataContext context)
        {
            _context = context;
        }

        // GET: /Home/---------------------------------------------------------

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = _context.Chefs
                .Include(c => c.Dishes)
                .ToList();
            IEnumerable<Chef> SortedChefs = AllChefs.OrderByDescending(d => d.Dishes.Count);

            return View(SortedChefs);
        }

        // GET: /New/---------------------------------------------------------

        [HttpGet ("NewChef")]
        public IActionResult NewChef()
        {
            return View();
        }

        // POST: /CREATE/---------------------------------------------------------

        [HttpPost ("Create")]
        public IActionResult Create(ChefViewModel chef)
        {
            if (!ModelState.IsValid)
            {
                return View("NewChef");
            }

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(chef.DateOfBirth.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;

            if (dob > now)
            {
                ModelState.AddModelError("DateOfBirth", "Date of birth must be in the past!");
                return View("NewChef");
            }

            if (age < 18)
            {
                ModelState.AddModelError("DateOfBirth", "Chef must be 18 years of age!");
                return View("NewChef");
            }

            System.Console.WriteLine("#####################################");
            System.Console.WriteLine(age);

            Chef newChef = new Chef
            {
                FirstName = chef.FirstName,
                LastName = chef.LastName,
                Age = age,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Add(newChef);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
