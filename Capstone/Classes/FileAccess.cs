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
       // public DateTime currentTime = DateTime.Now;
        //public Catering catering;
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


                    CateringItem item = new CateringItem(code, name, price, type);

                    catering.addToList(item);

                }
            }
        }
        public bool shouldAppend = true;
        public string formatTime = DateTime.Now.ToString();
        private string filePathWrite = @"C:\Catering\log.txt";
        public void fileWriterPurchase(string logString)
        {
            using (StreamWriter writer = new StreamWriter(filePathWrite, shouldAppend))
            {
                string stringToLog = DateTime.Now.ToString() + " " + logString;
                writer.WriteLine(stringToLog);
            }
        }
    }
    

}


