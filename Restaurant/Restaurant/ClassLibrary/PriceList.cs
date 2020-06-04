using System.Collections.Generic;
using System.Linq;

namespace RestaurantLibrary
{
    public class PriceList
    {
        private readonly Dictionary<Dish, double> DishPrices;

        public PriceList()
        {
            DishPrices = new Dictionary<Dish, double>();//Используем Словарь(пара ключ-значение)
        }

        public PriceList AddDish(Dish dish, double price)
        {
            DishPrices.Add(dish, price);
            return this;
        }

        public virtual double PriceOf(Dish dish, int servings)
        {
            return DishPrices[dish] * servings;
        }

        public IReadOnlyList<Dish> Dishes
        {
            get
            {
                var ret = DishPrices.Keys.ToList();
                ret.Sort();
                return ret;
            }
        }
    }
}
