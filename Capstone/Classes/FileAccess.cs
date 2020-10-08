using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    public class FileAccess
    {
        private string filePath = @"C:\Users\Student\Catering\cateringsystem.csv";
        public void FileReader()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                Console.WriteLine("1");
                while (!reader.EndOfStream)
                {
                    Console.WriteLine("2");
                    string line = reader.ReadLine();

                    string[] parts = line.Split("|"); 

                    string code = parts[0];
                    string name = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    string type = parts[3];

                    //Console.Write("dog");
                    Console.Write(code);
                    //InventoryItems inventory = new InventoryItems(code, name, price, type);
                    //inventory.Add(parts);
                }
            }
        }
    }
}
