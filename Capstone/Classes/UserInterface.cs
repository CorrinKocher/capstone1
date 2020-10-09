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
        public Catering catering = new Catering();
        public FileAccess file = new FileAccess();
        public PurchaseList purchaseList = new PurchaseList();
        public void RunInterface()
        {
            file.FileReader(catering);
            string menuSelection = "";
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Please select from the following options");
                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");

                menuSelection = Console.ReadLine().ToString();

                switch (menuSelection)
                {
                    case "1":
                        PrintList();

                        break;

                    case "2":
                        List<Array> arrayList = new List<Array>();
                        bool transactionComplete = false;
                        string purchasingSelection = "";
                        while (!transactionComplete)
                        {
                            Console.WriteLine("(1) Add Money");
                            Console.WriteLine("(2) Select Products");
                            Console.WriteLine("(3) Complete Transaction");
                            Console.WriteLine("Your account balance is $" + catering.customerMoney);
                            purchasingSelection = Console.ReadLine().ToString();
                            switch (purchasingSelection)
                            {
                                case "1":
                                    Console.WriteLine("How much money would you like to add?");
                                    decimal wantToAdd = decimal.Parse(Console.ReadLine());
                                    catering.AddMoney(wantToAdd);

                                    break;
                                case "2":
                                    string itemCode = GetItemCode();

                                    Console.WriteLine("Please enter the quantity you would like to purchase");
                                    int qtyToPurchase = 0;
                                    bool isInventoryEnough = false;
                                    bool AreWeAbleToPurchase = false;

                                    while (AreWeAbleToPurchase == false)
                                    {
                                        qtyToPurchase = int.Parse(Console.ReadLine());
                                        isInventoryEnough = catering.isQuantityEnough(itemCode, qtyToPurchase);
                                        if (isInventoryEnough == false)
                                        {
                                            Console.WriteLine("Not enough stock, please reduce quantity.");
                                        }
                                        else if (isInventoryEnough == true)
                                        {
                                            AreWeAbleToPurchase = catering.EnoughMoney(qtyToPurchase, itemCode);
                                            if (AreWeAbleToPurchase == false)
                                            {
                                                Console.WriteLine("Not enough Money, please reduce quantity.");
                                            }
                                        }

                                    }

                                    CateringItem itemPurchased = catering.purchaseItems(itemCode, qtyToPurchase);
                                    PurchasedItems pItems = new PurchasedItems(qtyToPurchase, itemPurchased.Price, itemPurchased.Name, itemCode, itemPurchased.Type);
                                    generatePurchaseString(pItems);

                                    purchaseList.addToList(pItems);


                                    break;
                                case "3":
                                    getCompleteTransaction();
                                    transactionComplete = true;
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

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

        private string GetItemCode()
        {
            Console.WriteLine("Enter the code of the item you would like to purchase");
            bool validCode = false;
            string itemCode = "";

            while (validCode == false)
            {
                itemCode = Console.ReadLine();
                validCode = catering.isCodeValid(itemCode);
                if (validCode == false)
                {
                    Console.WriteLine("Wrong code, please enter a valid code.");
                }
            }

            return itemCode;
        }

        private void PrintList()
        {
            bool needList = true;
            int i = 0;
            while (needList) //NO CONSOLE WRITELINE
            {
                string printOut = catering.printList(i);
                if (printOut == null)
                {
                    needList = false;
                }
                i++;
                Console.WriteLine(printOut);

            }


            Console.WriteLine(catering.printAllList());
        }
        public void getCompleteTransaction()
        {
            decimal totalPurchasePrice = 0M;
            foreach (PurchasedItems item in purchaseList)
            {
                Console.WriteLine(item.QtyToPurchase + "   " + item.TypeFull + "   " + item.Name + "   $" + item.Price + "   $" + item.TotalPrice);
                totalPurchasePrice += item.TotalPrice;
            }
            Console.WriteLine("Total: $" + totalPurchasePrice);
        }
        public void generatePurchaseString(PurchasedItems item)
        {
            string logString = item.QtyToPurchase + "   " + item.Name + "   " + item.Code + "   $" + item.TotalPrice + "   $" + catering.customerMoney;
            file.fileWriterPurchase(logString);
        }


        //public static void MaxAmountCanAdd()
        //{
        //    Console.WriteLine("You add a maximum amount of $");
        //}
    }
}
