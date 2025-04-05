
namespace RestaurantPosMAUI.Data;

public static class SeedData
{
    public static List<MenuCategory> GetMenuCategories()
    {
        return new List<MenuCategory>()
        {
            new MenuCategory{Id = 1, Name ="Beverages", Icon="drink.png"},
            new MenuCategory{Id = 2, Name ="Main Course", Icon="meal.png"},
            new MenuCategory{Id = 3, Name ="Snacks", Icon="snacks.png"},
            new MenuCategory{Id = 4, Name ="Desserts", Icon="cake.png"},
            new MenuCategory{Id = 5, Name ="Fast Food", Icon="fast_food.png"},
        };
    }
    public static List<MenuItem> GetMenuItems()
    {
        return new List<MenuItem>
        {
            new MenuItem { Id = 1, Name="Beer", Icon="beer.png", Description="new beer", Price=10},
            new MenuItem { Id = 2, Name="Biryani", Icon="biryani.png", Description="new biryani", Price=9},
            new MenuItem { Id = 3, Name="Buns", Icon="buns.png", Description="new buns", Price=2},
            new MenuItem { Id = 4, Name="Burger and Fries Combe", Icon="burger_fries_combo.png", Description="new Burger and Fries Combe", Price=10},
            new MenuItem { Id = 5, Name="Cake", Icon="cake.png", Description="new cake", Price=5},
            new MenuItem { Id = 6, Name="Chocolate", Icon="chocolate.png", Description="new chocolate", Price=11},
            new MenuItem { Id = 7, Name="Cocktail", Icon="cocktail.png", Description="new cocktail", Price=2},
            new MenuItem { Id = 8, Name="Coffee", Icon="coffee.png", Description="new coffee", Price=2},
            new MenuItem { Id = 9, Name="Cupcake", Icon="cupcake.png", Description="new cupcake", Price=4},
            new MenuItem { Id = 10, Name="Donut", Icon="donut.png", Description="new donut", Price=11},
            new MenuItem { Id = 11, Name="Energy Drink", Icon="energy_drink.png", Description="new energy drink", Price=15},
            new MenuItem { Id = 12, Name="fast Food", Icon="fast_food.png", Description="new fast food", Price=18},
            new MenuItem { Id = 13, Name="Rice", Icon="rice.png", Description="new rice", Price=5},
            new MenuItem { Id = 14, Name="Roasted Chicken", Icon="roasted_chicken.png", Description="new roasted chicken", Price=11},
            new MenuItem { Id = 15, Name="Salad Bowl", Icon="salad_bowl.png", Description="new salad bowl", Price=6},
            new MenuItem { Id = 16, Name="Salad Plate", Icon="salad_palte.png", Description="new salad plate", Price=7},
            new MenuItem { Id = 17, Name="Samosa", Icon="samosa.png", Description="new samosa", Price=30},
            new MenuItem { Id = 18, Name="Sandwich", Icon="sandwich.png", Description="new sandwich", Price=20},
            new MenuItem { Id = 19, Name="Snacks", Icon="snacks.png", Description="new snacks", Price=0},
            new MenuItem { Id = 20, Name="Soda", Icon="soda.png", Description="new soda", Price=10},
            new MenuItem { Id = 21, Name="Soft Drink", Icon="soft_dring.png", Description="new soft drink", Price=5},
            new MenuItem { Id = 22, Name="Soju", Icon="soju.png", Description="new soju", Price=8},
            new MenuItem { Id = 23, Name="Spaghetti", Icon="spaghetti.png", Description="new spaghetti", Price=5},
            new MenuItem { Id = 24, Name="Sushi", Icon="sushi.png", Description="new sushi", Price=14},
            new MenuItem { Id = 25, Name="Taco", Icon="taco.png", Description="new taco", Price=11},
            new MenuItem { Id = 26, Name="Tahi Food", Icon="thai_food.png", Description="new tahi food", Price=9},

            new MenuItem { Id = 27, Name="Thali", Icon="thali.png", Description="new thali", Price=1},
            new MenuItem { Id = 28, Name="Wrap", Icon="wrap.png", Description="new wrap", Price=18},
        };
    }

    public static List<MenuItemCategoryMapping> GetMenuItemCategoryMappings()
    {
        return new List<MenuItemCategoryMapping>
        {
            new MenuItemCategoryMapping { MenuCategoryId=1, MenuItemId=1},
            new MenuItemCategoryMapping { MenuCategoryId=20, MenuItemId=6},
            new MenuItemCategoryMapping { MenuCategoryId=21, MenuItemId=7},
            new MenuItemCategoryMapping { MenuCategoryId=23, MenuItemId=18},
            new MenuItemCategoryMapping { MenuCategoryId=22, MenuItemId=10},
            new MenuItemCategoryMapping { MenuCategoryId=3, MenuItemId=11},
            new MenuItemCategoryMapping { MenuCategoryId=31, MenuItemId=12},
            new MenuItemCategoryMapping { MenuCategoryId=24, MenuItemId=13},
            new MenuItemCategoryMapping { MenuCategoryId=25, MenuItemId=14},
            new MenuItemCategoryMapping { MenuCategoryId=26, MenuItemId=2},
            new MenuItemCategoryMapping { MenuCategoryId=2, MenuItemId=3},
            new MenuItemCategoryMapping { MenuCategoryId=27, MenuItemId=10},
            new MenuItemCategoryMapping { MenuCategoryId=17, MenuItemId=15},
            new MenuItemCategoryMapping { MenuCategoryId=7, MenuItemId=16},
            new MenuItemCategoryMapping { MenuCategoryId=7, MenuItemId=10},
            new MenuItemCategoryMapping { MenuCategoryId=18, MenuItemId=17},
            new MenuItemCategoryMapping { MenuCategoryId=28, MenuItemId=19},
            new MenuItemCategoryMapping { MenuCategoryId=18, MenuItemId=14},
            new MenuItemCategoryMapping { MenuCategoryId=16, MenuItemId=13},
            new MenuItemCategoryMapping { MenuCategoryId=15, MenuItemId=12},
            new MenuItemCategoryMapping { MenuCategoryId=14, MenuItemId=9},
            new MenuItemCategoryMapping { MenuCategoryId=13, MenuItemId=8},
            new MenuItemCategoryMapping { MenuCategoryId=12, MenuItemId=4},
            new MenuItemCategoryMapping { MenuCategoryId=19, MenuItemId=28},
            new MenuItemCategoryMapping { MenuCategoryId=11, MenuItemId=27},
            new MenuItemCategoryMapping { MenuCategoryId=9, MenuItemId=26},
            new MenuItemCategoryMapping { MenuCategoryId=10, MenuItemId=25},
            new MenuItemCategoryMapping { MenuCategoryId=4, MenuItemId=24},
            new MenuItemCategoryMapping { MenuCategoryId=15, MenuItemId=23},
            new MenuItemCategoryMapping { MenuCategoryId=5, MenuItemId=22},
            new MenuItemCategoryMapping { MenuCategoryId=5, MenuItemId=21},
            new MenuItemCategoryMapping { MenuCategoryId=5, MenuItemId=20},
            new MenuItemCategoryMapping { MenuCategoryId=6, MenuItemId=10},
            new MenuItemCategoryMapping { MenuCategoryId=6, MenuItemId=5},
        };
    }
}
