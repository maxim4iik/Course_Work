using System.Collections.Generic;
using System.Linq;

namespace RestaurantLibrary
{
    public class Order
    {
        private readonly PriceList PriceList;
        private readonly List<(Dish, int)> _Dishes;

        public Order(PriceList priceList)//Описание Заказа
        {
            PriceList = priceList;
            _Dishes = new List<(Dish, int)>();
        }

        public void AddDish(Dish dish, int servings)//Добавление блюда в заказе
        {
            _Dishes.Add((dish, servings));
        }

        public IReadOnlyList<(Dish, int)> Dishes => _Dishes;

        public double Price => _Dishes.Sum(x => PriceList.PriceOf(x.Item1, x.Item2));

        public double Weight => _Dishes.Sum(x => x.Item2 * x.Item1.Weight);
    }
}
