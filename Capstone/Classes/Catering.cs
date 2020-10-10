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

        public List<CateringItem> AllItem
        {
            get
            {
                return this.items;
            }
        }
        public decimal customerMoney { get; set; } = 0M;
        string response { get; set; }  = "";

        public bool AddMoney(decimal moneyToAdd)
        {
            if (CanAddMoney(moneyToAdd))
            {
                customerMoney += moneyToAdd;
                return true;
            }
            else
            {
                return false;
            }
                

        }
        public bool CanAddMoney (decimal moneyToAdd)
        {
            if (5000M >= customerMoney + moneyToAdd && moneyToAdd > 0)
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
            if(costOfPurchase > 0)
            {
                customerMoney -= costOfPurchase;
                return customerMoney;
            }
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
            if (item.Quantity >= qtyWanted && qtyWanted > 0)
            {
                return true;
            }
            else return false;
        }
        public bool IsSoldOut (string itemCode)
        {
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            if (item.Quantity == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ReturnChange()
        {
            int amtOfTwenties = (int)customerMoney / 20;
            Decimal remainingBalance = customerMoney % 20;

            int amtOfTens = (int)remainingBalance / 10;
            remainingBalance = (remainingBalance % 10);

            int amtOfFives = (int)remainingBalance / 5;
            remainingBalance = (remainingBalance % 5);

            int amtOfOnes = (int)remainingBalance / 1;
            remainingBalance = (remainingBalance % 1M);
           
            int amtOfQuarters = ((int)(remainingBalance * 100)) / 25;
            remainingBalance =(remainingBalance % 0.25M);
            
            int amtOfDimes = ((int)(remainingBalance * 100)) / 10;
            remainingBalance = (remainingBalance % .10M);

            int amtOfNickles = ((int)(remainingBalance * 100)) / 5;
            remainingBalance = (remainingBalance % .05M);

            string changeDueToCustomer = amtOfTwenties + " twenties, " + amtOfTens + " tens, " + amtOfFives + " fives, " + amtOfOnes + " ones " + amtOfQuarters + " quarters, " + amtOfDimes + " dimes and " + amtOfNickles + " nickles";
            return changeDueToCustomer;
        }
       
       
    } 
}
