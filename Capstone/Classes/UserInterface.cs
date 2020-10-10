using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// ALL instances of Console.ReadLine and Console.WriteLine should 
    /// be in this class.
    /// </summary>
    public class UserInterface
    {
        //set up our objects
        public Catering catering = new Catering();
        public FileAccess file = new FileAccess();
        public PurchaseList purchaseList = new PurchaseList();
        
        //main interface
        public void RunInterface()
        {
            //read our caterng menu in
            file.FileReader(catering);

            //while loop condition
            bool done = false;
            //do a loop
            while (!done)
            {
                //Display main menu
                ShowMainMenu();
                //get our menu option
                string menuSelection = Console.ReadLine().ToString();

                //do a switch with menuSelection
                switch (menuSelection)
                {
                    case "1":
                        //log out the full list/menu of catering items
                        RetrievePrintList();

                        break;

                    case "2":
                        //set up a few conditions
                        bool transactionComplete = false;
                        string purchasingSelection = "";

                        //go into loop
                        while (!transactionComplete)
                        {
                            //display purchasing menu
                            ShowPurchasingMenu();
                            //take in user choice input
                            purchasingSelection = Console.ReadLine().ToString();

                            switch (purchasingSelection)
                            {
                                //Add that moola(money)
                                case "1":
                                    //prompt user for money to add
                                    Console.WriteLine("How much money would you like to add?");
                                    //set up variable for money
                                    decimal wantToAdd = decimal.Parse(Console.ReadLine());
                                    //add the money throught the AddMoney method
                                    catering.AddMoney(wantToAdd);
                                    // add a log to log.txt with the money and balance
                                    generateAddMoneyString(wantToAdd);

                                    break;

                                //select items for purchase
                                case "2":
                                    //prompt for code
                                    Console.WriteLine("Enter the code of the item you would like to purchase");
                                    //take in code
                                    string itemCode = Console.ReadLine();
                                    //is the code valid?
                                    bool validCode = catering.isCodeValid(itemCode);
                                    //if invalid, let user know and return to menu
                                    if (validCode == false)
                                    {
                                        Console.WriteLine("Invalid Code, returning to Menu.");
                                        break;
                                    }

                                    //check if the item is sold out
                                    bool IsItemSoldOut = catering.IsSoldOut(itemCode);
                                    //check if the item is sold out
                                    if (IsItemSoldOut)
                                    {
                                        Console.WriteLine("This item is Sold Out. Returning to Menu.");
                                        break;
                                    }

                                    //prompt for quantity to purchase
                                    Console.WriteLine("Please enter the quantity you would like to purchase");
                                    //store quantity in qtyToPurchase
                                    int qtyToPurchase = int.Parse(Console.ReadLine());
                                    //check if there is enough stock
                                    bool isInventoryEnough = catering.isQuantityEnough(itemCode, qtyToPurchase);
                                    //check if there is enough money
                                    bool AreWeAbleToPurchase = catering.EnoughMoney(qtyToPurchase, itemCode);

                                    //check if there is enough stock
                                    if (isInventoryEnough == false)
                                    {
                                        Console.WriteLine("Not enough stock, please reduce quantity. Returning to Menu.");
                                        break;
                                    }
                                    //check if there is enough money
                                    if (AreWeAbleToPurchase == false)
                                    {
                                        Console.WriteLine("Not enough Money, please reduce quantity. Returning to Menu.");
                                        break;
                                    }

                                    // if all conditions are good, then the next line grabs the item object
                                    CateringItem itemPurchased = catering.purchaseItems(itemCode, qtyToPurchase);
                                    //now we make a new object to represent the purchased item
                                    PurchasedItems pItems = new PurchasedItems(qtyToPurchase, itemPurchased.Price, itemPurchased.Name, itemCode, itemPurchased.Type);
                                    //generate string for log.txt
                                    generatePurchaseString(pItems);
                                    //add our items to our purchase list
                                    purchaseList.addToList(pItems);

                                    break;

                                //finish transaction, exit loop and return to main menu
                                case "3":
                                    //loop through all items in purchaseList and add totalprice up, then log out to customer
                                    getCompleteTransaction();
                                    //give customer their change
                                    Console.WriteLine(catering.ReturnChange());
                                    //log out to log.txt
                                    generateGiveChangeString();
                                    //transactionComplete == true exits the loop and returns to the main menu
                                    transactionComplete = true;
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

                    //exit the loop
                    case "3":
                        Console.WriteLine("Thank You For Using Our Service. Goodbye.");
                        done = !done;

                        break;


                    default:

                        Console.WriteLine("hi");
                        break;
                }
            }

        }

        //this is the main menu
        private static void ShowMainMenu()
        {
            Console.WriteLine("Please select from the following options");
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
        }

        //this is the purchasing menu, also displays current balance
        private void ShowPurchasingMenu()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine("Your account balance is $" + catering.customerMoney);
        }

        //lists out full catering items
        private void RetrievePrintList()
        {
            //loop through our list of catering items and log them out
            foreach (CateringItem item in this.catering.AllItem)
            {
                Console.WriteLine(item);
            }
            //empty line for formatting
            Console.WriteLine("");
        }

        //shows customer full list of items purchased and total
        public void getCompleteTransaction()
        {
            decimal totalPurchasePrice = 0M;
            //loop through all items in purchaseList and add totalprice up, then log out to customer
            foreach (PurchasedItems item in purchaseList)
            {
                Console.WriteLine(item.QtyToPurchase + "   " + item.TypeFull + "   " + item.Name + "   $" + item.Price + "   $" + item.TotalPrice);
                totalPurchasePrice += item.TotalPrice;
            }
            Console.WriteLine("Total: $" + totalPurchasePrice);
        }




        // sets up a string to log into log.txt
        public void generatePurchaseString(PurchasedItems item)
        {
            string logString = item.QtyToPurchase + "   " + item.Name + "   " + item.Code + "   $" + item.TotalPrice + "   $" + catering.customerMoney;
            file.fileWriterPurchase(logString);
        }

        // sets up a string to log into log.txt
        public void generateAddMoneyString(decimal moneyToAdd)
        {
            string logString = "ADD MONEY: " + "   $" + moneyToAdd + ".00   $" + catering.customerMoney;
            file.fileWriterPurchase(logString);
        }

        // sets up a string to log into log.txt, this also sets the customerMoney to 0, since we have at this point returned their money
        public void generateGiveChangeString()
        {
            string logString = "GIVE CHANGE: " + "   $" + catering.customerMoney + "   $" + "0.00";
            file.fileWriterPurchase(logString);
            catering.customerMoney = 0.00m;
        }

    }
}
