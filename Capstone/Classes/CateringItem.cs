using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain the definition for one catering item
    /// </summary>
    public class CateringItem
    {
        public CateringItem(string code, string name, decimal price, string type)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public int Quantity  { get; set; } = 50;
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public bool soldOut { get; set; } = false;

        //to string method
        public override string ToString()
        {
            return this.Code + "|" + this.Name + "|" + this.Price.ToString() + "|" + this.Quantity.ToString() + "|" + this.Type;
        }

        //updates the quantity of the item
        public void UpdateQuantity(int amtSold)
        {
            if(Quantity > 0 && amtSold <= Quantity)
            {
                Quantity -= amtSold;
            }
            
            
        }
        

    }
}
