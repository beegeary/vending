using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingConsole;

namespace VendingTests
{
    [TestClass]
    public class VendingTest1
    {
            const double Penny = 2.5;
            const double Nickel = 5;
            const double Dime = 2.268;
            const double Quarter = 5.67;

        [TestInitialize]
        public void TestInitialize()
        {
        }

        //method should accept weight amount and return proper money amount
        [TestMethod]
        public void MachineAcceptsAndConvertsCoins()
        {
            Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Nickel) == .05M);
        }

        //and return zero if penny is inserted
        [TestMethod]
        public void MachineRejectsPennies()
        {
            Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Penny) == 0);
        }

        //application must return product to customer
        [TestMethod]
        public void CustomerPurchasesProduct()
        {
           // Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Penny) == 0);
        }

        //application must return change to customer overpaying, when change is available
        [TestMethod]
        public void MachineReturnsChange()
        {
            // Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Penny) == 0);
        }

        //application must return money inserted, if customer decides not to finalize sale
        [TestMethod]
        public void MachineReturnsInsertedMoney()
        {
            // Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Penny) == 0);
        }

        //when product is sold out, the customer must be made aware
        [TestMethod]
        public void ProductSoldOutAlert()
        {
            // Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Penny) == 0);
        }

        //when machine cannot make change, display must reflect this state
        [TestMethod]
        public void CannotMakeChange()
        {
            // Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Penny) == 0);
        }




    }
}
