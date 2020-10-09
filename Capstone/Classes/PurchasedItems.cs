using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class contains Items that have been purchased by the customer.
    /// </summary>
    public class PurchasedItems
    {
        public PurchasedItems(int qtyToPurchase, decimal price, string name, string code, string type)
        {

            this.Code = code;
            this.Name = name;
            this.Price = price;
            this.Type = type;
            this.QtyToPurchase = qtyToPurchase;
            this.TotalPrice = qtyToPurchase * price;

        }
        public int QtyToPurchase { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string TypeFull {
            get
            {
                switch (Type)
                {
                    case "A":
                        return "Appetizer";
                        break;
                    case "B":
                        return "Beverage";
                        break;
                    case "E":
                        return "Entree";
                        break;
                    case "D":
                        return "Dessert";
                        break;

                    default:
                        return Type;
                }
            }
         }
        public decimal TotalPrice  { get; set; }

    }
}
