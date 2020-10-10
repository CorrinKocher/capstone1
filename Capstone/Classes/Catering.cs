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
        //original list of catering items
        private List<CateringItem> items = new List<CateringItem>();
        //file path
        private string filePath = @"C:\Catering";

        //displays all items inside items
        public List<CateringItem> AllItem
        {
            get
            {
                return this.items;
            }
        }

        public decimal customerMoney { get; set; } = 0M;


        //method for adding money, checks if money can be added first
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
        //checks if money can be added
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

        //spends that money
        public decimal SpendMoney(decimal costOfPurchase)
        {
            if(costOfPurchase > 0)
            {
                customerMoney -= costOfPurchase;
                return customerMoney;
            }
            return customerMoney;
        }
        //get file path
        public string GetFilePath()
        {
            return filePath;
        }
        
        //adds an item to our items list
        public void addToList(CateringItem item)
        {

            this.items.Add(item);
        }

        // checks to see if we have enough money to purchase a given quantity of an item
        public bool EnoughMoney(int qtyToPurchase, string itemCode)
        {
            //gets our item by the code given
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            //gets the final price
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

        //this does the actual purchase of items
        public CateringItem purchaseItems(string itemCode, int qtyToPurchase)
        {
            //gets our item by the code given
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            //final price
            decimal total = item.Price * qtyToPurchase;
            //updates quantity
            item.UpdateQuantity(qtyToPurchase);
            //spends the money and updates balance
            SpendMoney(total);
            return item;
        }

        // checks if the code user inputs is valid item
        public bool isCodeValid(string itemCode)
        {
            //gets our item by the code given if there, if invalid returns null
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            if (item == null)
            {
                return false;
            }
            else return true;
        }
        // checks that there is enough of an item in stock
        public bool isQuantityEnough(string itemCode, int qtyWanted)
        {
            //gets our item by the code given
            CateringItem item = this.items.Find(x => x.Code.Contains(itemCode));
            if (item.Quantity >= qtyWanted && qtyWanted > 0)
            {
                return true;
            }
            else return false;
        }

        // checks if an item is sold out
        public bool IsSoldOut (string itemCode)
        {
            //gets our item by the code given
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

        //returns the change and counts up the bills
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
