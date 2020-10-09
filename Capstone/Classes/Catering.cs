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

        public decimal customerMoney { get; set; } = 0M;
        string response { get; set; }  = "";

        public void AddMoney(decimal moneyToAdd)
        {
            if (CanAddMoney(moneyToAdd))
            {
                customerMoney += moneyToAdd;
            }

        }
        public bool CanAddMoney (decimal moneyToAdd)
        {
            if (5000M >= customerMoney + moneyToAdd)
            {
               return true;
            }
            else  
            {
                return false;
            }
        }

        public decimal SpendMoney(decimal costOfPurchase)
        {
            customerMoney -= costOfPurchase;
            return customerMoney;
        }
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

        public bool EnoughMoney(int qtyToPurchase, string itemCode)
        {
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            decimal total = item.Price * qtyToPurchase;
            if (total > customerMoney)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public CateringItem purchaseItems(string itemCode, int qtyToPurchase)
        {
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            decimal total = item.Price * qtyToPurchase;
            item.UpdateQuantity(qtyToPurchase);
            SpendMoney(total);
            return item;
        }

        public bool isCodeValid(string itemCode)
        {
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            if (item == null)
            {
                return false;
            }
            else return true;
        }

        public bool isQuantityEnough(string itemCode, int qtyWanted)
        {
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            if (item.Quantity >= qtyWanted)
            {
                return true;
            }
            else return false;
        }
       
    } 
}
