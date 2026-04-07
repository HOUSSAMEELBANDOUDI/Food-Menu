# Food Menu — ASP.NET Core MVC Application

A food menu web application built with **ASP.NET Core 8 MVC** and **Entity Framework Core**. Browse dishes, view ingredients, and search the menu.

## Tech Stack

- **ASP.NET Core 8** — MVC framework
- **Entity Framework Core 8** — ORM / database
- **SQL Server (LocalDB)** — database engine
- **Bootstrap 5** — responsive UI
- **Font Awesome** — icons

## Features

- Browse all dishes with images and prices
- View dish details with full ingredient list
- Search dishes by name
- Many-to-Many relationship (Dish ↔ Ingredient)
- Seed data with sample dishes and ingredients
- Async/await for database operations

## Project Structure

```
Food-Menu/
├── Controllers/
│   ├── HomeController.cs        # Redirects to Menu
│   └── MenuController.cs        # Index (list + search), Details, Create, Delete
├── Data/
│   └── AppDbContext.cs           # DbContext + seed data + Many-to-Many config
├── Models/
│   ├── Dish.cs                   # Dish entity (Name, ImageUrl, Price)
│   ├── Ingredient.cs             # Ingredient entity (Name)
│   └── DishIngredient.cs         # Junction table (Many-to-Many)
├── Views/
│   ├── Menu/
│   │   ├── Index.cshtml          # Grid of dishes with images
│   │   └── Details.cshtml        # Single dish + ingredients list
│   └── Shared/
│       └── _Layout.cshtml        # Navbar with search bar
├── Program.cs                    # App configuration + DI
└── appsettings.json              # Connection string
```

## Sample Data

| Dish | Price | Ingredients |
|------|-------|-------------|
| Pizza | $9.99 | Cheese, Tomato, Mushrooms, Olives |
| Burger | $7.99 | Cheese, Tomato, Onion, Beef, Lettuce |
| Pasta | $11.99 | Tomato, Garlic, Mushrooms, Cheese |
| Salad | $5.99 | Lettuce, Tomato, Onion, Olives |

## How to Run

```bash
git clone https://github.com/HOUSSAMEELBANDOUDI/Food-Menu.git
cd Food-Menu
dotnet restore
dotnet ef database update
dotnet run
```

Open **https://localhost:5001**

## Author

**Houssame El Bandoudi** — [GitHub](https://github.com/HOUSSAMEELBANDOUDI)
