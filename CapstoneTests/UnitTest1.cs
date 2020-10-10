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
        //[DataRow(0, 0)]
        //[DataRow(-1, 0)]
        //[DataRow(10, 10)]
        //[DataRow(5001, 0)]

        public void TestCateringMethods(int MoneyAdded, decimal ExpectedBalance)
        {
            Catering catering = new Catering();
            catering.AddMoney((decimal)MoneyAdded);
            Assert.IsTrue(ExpectedBalance == (decimal)MoneyAdded);
            //Assert.AreEqual(ExpectedBalance, MoneyAdded);
            //should I change test method to return a decimal instead of a void?
            //do i need to cast ExpectedBalance into a decimal as well?
        
        }

        [TestMethod]
        [DataRow(5, 5)]
        
        public decimal TestAddMoneyMethod( decimal MoneyAdded, decimal ExpectedBalance)
        {
            Catering catering = new Catering();
            catering.AddMoney(MoneyAdded);
            decimal expected = catering.customerMoney;
            //Assert.AreEqual(ExpectedBalance, catering.customerMoney);
            return catering.customerMoney;
        }




    }
}
