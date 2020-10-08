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
        {
            Console.WriteLine(this.items[i].ToString());
            
        }
   
    }
    
}
