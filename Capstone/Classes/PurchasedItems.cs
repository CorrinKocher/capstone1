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
        //set up purchased item constructor
        public PurchasedItems(int qtyToPurchase, decimal price, string name, string code, string type)
        {

            this.Code = code;
            this.Name = name;
            this.Price = price;
            this.Type = type;
            this.QtyToPurchase = qtyToPurchase;
            this.TotalPrice = qtyToPurchase * price;

        }
        public decimal TotalPrice  { get; set; }
        public int QtyToPurchase { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        //turns the single characted type (i.e. "B", "A", etc.) into the full string
        public string TypeFull {
            get
            {
                switch (Type)
                {
                    case "A":
                        return "Appetizer";
                        
                    case "B":
                        return "Beverage";
                       
                    case "E":
                        return "Entree";
                        
                    case "D":
                        return "Dessert";
                        

                    default:
                        return Type;
                }
            }

         }
    }
}
