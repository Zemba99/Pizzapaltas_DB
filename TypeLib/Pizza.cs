using System;

namespace TypeLib
{
    public class PizzaRecipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Ingredient_id { get; set; }
        public int Pizza_id { get; set; }
    }
}
