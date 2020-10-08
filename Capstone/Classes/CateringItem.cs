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

        int Quantity  {get; set;} = 50;
        string Code { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        string Type { get; set; }
        bool soldOut { get; set; } = false;

        public override string ToString()
        {
            return this.Code + "|" + this.Name + "|" + this.Price.ToString() + "|" + this.Type;
        }


    }
}
