using System;
using System.Collections.Generic;
using System.Text;
using Fridge;

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
