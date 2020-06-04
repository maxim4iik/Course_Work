using System;
using System.Collections.Generic;

namespace RestaurantLibrary
{
    public class Ingredient : IComparable<Ingredient>//Используем библиотечный интерфейс Icomparable
    {
        public readonly string Name;
        public readonly double Weight;

        public Ingredient(string name, double weight)//Описание свойства
        {
            Name = name;
            Weight = weight;
        }

        public int CompareTo(Ingredient other)//Реализация обобщенного варианта интерфейса IComparable
        {
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)//Сравнение через вирутальный метод
        {
            return obj is Ingredient ingredient &&
                   Name == ingredient.Name &&
                   Weight == ingredient.Weight;
        }

        public override int GetHashCode()//Перегрузка используется для того, чтобы избежать снижения производительности
        {
            int hashCode = -1185841457;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Weight.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Ingredient(Name={Name},Weight={Weight})";
        }
    }
}
