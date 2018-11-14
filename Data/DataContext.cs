using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Chef> Chefs { get; set; }
    }
}