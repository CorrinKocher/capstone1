﻿using System;
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
        public Catering catering = new Catering();
        private string filePath = @"C:\Users\Student\Catering\cateringsystem.csv";
        public void FileReader()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    
                    string line = reader.ReadLine();

                    string[] parts = line.Split("|"); 

                    string code = parts[0];
                    string name = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    string type = parts[3];


                    CateringItem item = new CateringItem(code, name, price, type);

                    catering.addToList(item);
                    catering.printList(i);
                    i++;
                }
            }
        }
    }
}
