using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
       
       
        [TestMethod]
        
        [DataRow(5, 5)]
        [DataRow(0, 0)]
        [DataRow(-1, 0)]
        [DataRow(10, 10)]
        [DataRow(5001, 0)]

        public void TestCateringMethods(int MoneyAdded, int ExpectedBalance)
        {
            Catering catering = new Catering();
            catering.AddMoney((decimal)MoneyAdded);
            Assert.IsTrue((decimal)ExpectedBalance == (decimal)catering.customerMoney);
            
        
        }

        [TestMethod]
        [DataRow(5, true)]
        [DataRow(-5, false)]
        [DataRow(5001, false)]
        

        public void TestCanAddMoney(int MoneyToAdd, bool ExpectedBalance)
        {
            Catering catering = new Catering();
            bool result = catering.CanAddMoney((decimal)MoneyToAdd);
            Assert.IsTrue(ExpectedBalance == result);
           
        }
        [TestMethod]
        [DataRow(5, 3995)]
        [DataRow(-5, 4000)]
        

        public void TestSpendMoney(int costOfPurchase, int expectedBalance)
        {
            Catering catering = new Catering();
            decimal moneyToAdd = 4000m;
            bool moneyAdded = catering.AddMoney(moneyToAdd);
            decimal result = catering.SpendMoney((decimal)costOfPurchase);
            Assert.AreEqual((decimal)expectedBalance, result);
        }

        [TestMethod]
        [DataRow(50, true)]
        [DataRow(-50, false)]
        [DataRow(10, true)]
        [DataRow(0,false)]

        public void TestIsQuantityEnough(int qtyWanted, bool expectedResult)
        {
            
            string itemCode = "B1";
           
            Catering catering = new Catering();
            CateringItem item = new CateringItem(itemCode, "string", 5m, "beverage");
            catering.addToList(item);
            bool result = catering.isQuantityEnough(itemCode, qtyWanted);
            Assert.AreEqual(expectedResult, result);
        }


    }
}
