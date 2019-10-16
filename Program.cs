using System;
using System.Collections.Generic;

namespace Hungry_Ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet buffet = new Buffet();
            Ninja ninja = new Ninja();

            while(!ninja.IsFull){
                ninja.Eat(buffet.Serve());
            }
        }
    }
    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy;
        public bool IsSweet;
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string nam, int cal, bool spi, bool swe)
        {
            Name = nam;
            Calories = cal;
            IsSpicy = spi;
            IsSweet = swe;
        }
    }
    class Buffet
    {
        public List<Food> Menu;

        //constructor
        public Buffet()
        {
            Menu = new List<Food>();
            Menu.Add(new Food("Pizza", 700, false, false));
            Menu.Add(new Food("Pasta", 700, false, false));
            Menu.Add(new Food("Burrito", 700, false, true));
            Menu.Add(new Food("Taco", 300, false, true));
            Menu.Add(new Food("Burger", 700, false, false));
            Menu.Add(new Food("Hot Dog", 500, false, false));
            Menu.Add(new Food("French Fries", 300, false, false));
        }

        public Food Serve()
        {
            Random rand = new Random();
            return Menu[rand.Next(Menu.Count)];
        }
    }
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        // add a constructor
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        // add a public "getter" property called "IsFull"
        public bool IsFull
        {
            get
            {
                return calorieIntake > 1200;
            }
        }
        // build out the Eat method
        public void Eat(Food item)
        {
            if (IsFull == false)
            {
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.WriteLine($"Ninja ate {item.Name} which has {item.Calories} calories. Sweet: {item.IsSweet}; Spicy: {item.IsSpicy}");
            }
            else
            {
                Console.WriteLine("Ninja is full and cannot eat anymore");
            }
        }
    }
}
