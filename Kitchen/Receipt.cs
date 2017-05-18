using System.Collections.Generic;

namespace Kitchen
{
    public class Receipt
    {
        public Receipt()
        {
            Ingredients = new List<Item>();
        }

        public string Name;
        public List<Item> Ingredients;
    }
}
