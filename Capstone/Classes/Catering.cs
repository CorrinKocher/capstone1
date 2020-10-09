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

        public List[] purchasedItems = new List[];

      
        public string GetFilePath()
        {
            return filePath;
        }
        

        public void addToList(CateringItem item)
        {

            this.items.Add(item);
        }

        public string printList(int i)
        {
            if (i > items.Count-1)
            {
                 return null;
            }
            return this.items[i].ToString();
            
        }
        
        public string printAllList()
        {
            foreach  (CateringItem item in items)
            {
                
                return item.ToString();
            }
            return "";
        }
        public CateringItem ModifyQuantity(string itemCode, int qtyToPurchase)
        {
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            item.UpdateQuantity(qtyToPurchase); //first or default would also work in place of fine
            //could also foreach. LINQ provides shortcuts foreachs

            return item;
        }
   
    }
    
}
