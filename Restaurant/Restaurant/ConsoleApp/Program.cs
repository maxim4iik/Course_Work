using RestaurantLibrary;
using System;

namespace RestaurantApp
{
    class Program
    {
        static PriceList CreatePriceList()
        {
            PriceList ret;

            Console.Write("Enter discount code: ");
            switch (Console.ReadLine().ToLower())
            {
                case "":
                    ret = new PriceList();
                    break;
                case "25":
                    Console.WriteLine("Code has been succesfully activated! -25%!");
                    ret = new DiscountedPriceList(0.75);
                    break;
                case "50":
                    Console.WriteLine("Code has been succesfully activated! -50%!");
                    ret = new DiscountedPriceList(0.50);
                    break;
                default:
                    Console.WriteLine("Invalid code. :(");
                    ret = new PriceList();
                    break;
            }

            Dish steakWithMashedPotatoes = Dish.Builder()
                .AddIngredient(new Ingredient("Beef", 300.0))
                .AddIngredient(new Ingredient("Potato", 250.0))
                .Build("Steak with mashed potatoes");

            Dish chickenSoup = Dish.Builder()
                .AddIngredient(new Ingredient("Chicken", 150.0))
                .AddIngredient(new Ingredient("Onion", 50.0))
                .AddIngredient(new Ingredient("Potato", 140.0))
                .AddIngredient(new Ingredient("Sour cream", 60.0))
                .AddIngredient(new Ingredient("Water", 300.0))
                .Build("Chicken soup");

            Dish vegetableSalad = Dish.Builder()
                .AddIngredient(new Ingredient("Tomatoes", 80.0))
                .AddIngredient(new Ingredient("Cucumbers", 80.0))
                .AddIngredient(new Ingredient("Onion", 30.0))
                .AddIngredient(new Ingredient("Pepper", 40.0))
                .Build("Vegetables salad");

            return ret
                .AddDish(steakWithMashedPotatoes, 15.0)
                .AddDish(chickenSoup, 5.0)
                .AddDish(vegetableSalad, 3.0);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            PriceList priceList = CreatePriceList();

            Console.WriteLine();
            Console.WriteLine("Today's menu:");

            for (int i = 0; i < priceList.Dishes.Count; i++)
            {
                Console.WriteLine();
                Dish dish = priceList.Dishes[i];
                Console.WriteLine("  {0}) {1}", i + 1, dish.Name);
                foreach (Ingredient ingredient in dish.Ingredients)
                {
                    Console.WriteLine("      {0,-10} - {1,3}g", ingredient.Name, ingredient.Weight);
                }
                Console.WriteLine("     Total:        {0,3}g", dish.Weight);
                Console.WriteLine("     Price:        {0,3}$", priceList.PriceOf(dish, 1));
            }

            Order order = new Order(priceList);

            while (true)
            {
                Console.WriteLine();
                int x = EnterInt("Enter number of dish: ", 1, priceList.Dishes.Count) - 1;
                Dish dish = priceList.Dishes[x];

                int servings = EnterInt("Enter number of portions: ", 1, 10);

                order.AddDish(dish, servings);

                Console.WriteLine("Succesful!");

                Console.Write("End? (y/n): ");
                if (Console.ReadLine() == "y")
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Thank you for your order!");
            Console.WriteLine("Total: {0}$", order.Price);

            Console.ReadKey();
        }

        static int EnterInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int ret) && (ret >= min && ret <= max))
                {
                    return ret;
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
        }
    }
}
