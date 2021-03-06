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
        //path for reading n the menu
        private string filePathRead = @"C:\Catering\cateringsystem.csv";
        public void FileReader(Catering catering)
        { 
            using (StreamReader reader = new StreamReader(filePathRead))
            {

                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine();

                    string[] parts = line.Split("|");

                    string code = parts[0];
                    string name = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    string type = parts[3];

                    // make a catering item out of the strings we pulled out from file
                    CateringItem item = new CateringItem(code, name, price, type);

                    //add the item to our list of catering items
                    catering.addToList(item);

                }
            }
        }

        //some variable set up
        public bool shouldAppend = true;
        private string filePathWrite = @"C:\Catering\log.txt";

        //logs strings out to our log.txt file
        public void fileWriterPurchase(string logString)
        {
            using (StreamWriter writer = new StreamWriter(filePathWrite, shouldAppend))
            {
                //adds the time to the beginning of a given string
                string stringToLog = DateTime.Now.ToString() + " " + logString;

                writer.WriteLine(stringToLog);
            }
        }
    }
    

}


