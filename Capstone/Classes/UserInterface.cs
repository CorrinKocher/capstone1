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
                        catering.printAllList();

                        break;

                    case "2":
                        Console.WriteLine("(1) Add Money");
                        Console.WriteLine("(2) Select Products");
                        Console.WriteLine("(3) Complete Transaction");
                        string purchasingSelection = Console.ReadLine().ToString();
                        switch (purchasingSelection)
                        {
                            case "1":
                                break;
                            case "2":
                                Console.WriteLine("Enter the code of the item you would like to purchase");
                                string itemCode = Console.ReadLine();
                                Console.WriteLine("Please enter the quantity you would like to purchase");
                                int qtyToPurchase = int.Parse(Console.ReadLine());
                                catering.ModifyQuantity(itemCode, qtyToPurchase);
                                break;
                            case "3":
                                break;

                            default:
                                break;
                        }
                        break;

                    case "3":

                        break;


                    default:

                        Console.WriteLine("hi");
                        break;
                }
            }


        }
    }
}
