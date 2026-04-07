using Microsoft.EntityFrameworkCore;
using Food_Menu.Models;

namespace Food_Menu.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite key for DishIngredient (Many-to-Many)
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);

            // Seed Data — Dishes
            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Pizza", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg", Price = 9.99 },
                new Dish { Id = 2, Name = "Burger", ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=500", Price = 7.99 },
                new Dish { Id = 3, Name = "Pasta", ImageUrl = "https://images.unsplash.com/photo-1621996346565-e3dbc646d9a9?w=500", Price = 11.99 },
                new Dish { Id = 4, Name = "Salad", ImageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?w=500", Price = 5.99 }
            );

            // Seed Data — Ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Cheese" },
                new Ingredient { Id = 2, Name = "Tomato" },
                new Ingredient { Id = 3, Name = "Onion" },
                new Ingredient { Id = 4, Name = "Mushrooms" },
                new Ingredient { Id = 5, Name = "Lettuce" },
                new Ingredient { Id = 6, Name = "Beef" },
                new Ingredient { Id = 7, Name = "Olives" },
                new Ingredient { Id = 8, Name = "Garlic" }
            );

            // Seed Data — DishIngredients (links)
            modelBuilder.Entity<DishIngredient>().HasData(
                // Pizza: Cheese, Tomato, Mushrooms, Olives
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 1, IngredientId = 4 },
                new DishIngredient { DishId = 1, IngredientId = 7 },
                // Burger: Cheese, Tomato, Onion, Beef, Lettuce
                new DishIngredient { DishId = 2, IngredientId = 1 },
                new DishIngredient { DishId = 2, IngredientId = 2 },
                new DishIngredient { DishId = 2, IngredientId = 3 },
                new DishIngredient { DishId = 2, IngredientId = 6 },
                new DishIngredient { DishId = 2, IngredientId = 5 },
                // Pasta: Tomato, Garlic, Mushrooms, Cheese
                new DishIngredient { DishId = 3, IngredientId = 2 },
                new DishIngredient { DishId = 3, IngredientId = 8 },
                new DishIngredient { DishId = 3, IngredientId = 4 },
                new DishIngredient { DishId = 3, IngredientId = 1 },
                // Salad: Lettuce, Tomato, Onion, Olives
                new DishIngredient { DishId = 4, IngredientId = 5 },
                new DishIngredient { DishId = 4, IngredientId = 2 },
                new DishIngredient { DishId = 4, IngredientId = 3 },
                new DishIngredient { DishId = 4, IngredientId = 7 }
            );
        }
    }
}
