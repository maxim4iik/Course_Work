namespace RestaurantLibrary
{
    public class DiscountedPriceList : PriceList
    {
        private readonly double Modifier;

        public DiscountedPriceList(double modifier)
        {
            Modifier = modifier;
        }

        public override double PriceOf(Dish dish, int servings)
        {
            return Modifier * base.PriceOf(dish, servings);//Изменяем Цену из прайслиста с учетом нашего Модифаера(напримен скидочного кода)
        }
    }
}
