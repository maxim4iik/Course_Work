using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantLibrary
{
    public class Dish : IComparable<Dish>//Используем библиотечный интерфейс Icomparable
    {
        public readonly string Name;
        public readonly IReadOnlyList<Ingredient> Ingredients;//Используем библиотечный интерфейс IReadOnlyList

        private Dish(string name, IReadOnlyList<Ingredient> ingredients)//Описание свойства
        {
            Name = name;
            Ingredients = ingredients;
        }

        public double Weight => Ingredients.Sum(x => x.Weight);

        public int CompareTo(Dish other)//Реализация обобщенного варианта интерфейса IComparable
        {
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)//Сравнение через виртуальный метод
        {
            return obj is Dish dish &&
                   Name == dish.Name &&
                   EqualityComparer<IReadOnlyList<Ingredient>>.Default.Equals(Ingredients, dish.Ingredients) &&
                   Weight == dish.Weight;
        }

        public override int GetHashCode()//Перегрузка используется для того, чтобы избежать снижения производительности  
        {
            int hashCode = 2007676926;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<IReadOnlyList<Ingredient>>.Default.GetHashCode(Ingredients);
            hashCode = hashCode * -1521134295 + Weight.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Dish(Name={Name},Ingredients={Ingredients})";
        }

        public static DishBuilder Builder()//Используем паттерн Builder, который инкапсулирует создание объекта
        {
            return new DishBuilder();
        }

        public sealed class DishBuilder//"Строитель" блюд из ингридиентов, запрещающий переопределение
        {
            private readonly List<Ingredient> Ingredients;

            public DishBuilder()
            {
                Ingredients = new List<Ingredient>();
            }

            public DishBuilder AddIngredient(Ingredient ingredient)
            {
                Ingredients.Add(ingredient);
                return this;
            }

            public Dish Build(string name)
            {
                Ingredients.Sort();
                return new Dish(name, Ingredients);
            }
        }
    }
}
