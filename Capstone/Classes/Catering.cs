using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for a catering system
    /// </summary>
    public class Catering
    {
        private List<CateringItem> items = new List<CateringItem>();

        private string filePath = @"C:\Catering"; // You will likely need to create this folder on your machine

      
        public string GetFilePath()
        {
            return filePath;
        }
        

        public void addToList(CateringItem item)
        {

            this.items.Add(item);
        }

        public void printList(int i)
        {   //NO CONSOLE WRITELINE HERE!!! 
            Console.WriteLine(this.items[i].ToString());
            
        }
        public void printAllList()
        {
            foreach  (CateringItem item in items)
            {
                //NO CONSOLE WRITELINE HERE!!! 
                Console.WriteLine(item.ToString());
            }
        }
        public void ModifyQuantity(string itemCode, int qtyToPurchase)
        {
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            //this.items.Find(x => x.Quantity.Subtract(qtyToPurchase));
            item.UpdateQuantity(qtyToPurchase); //first or default would also work in place of fine
            //could also foreach. LINQ provides shortcuts foreachs


        }
   
    }
    
}
