using System;
using System.Linq;
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
            BalanceSheet bal;

        [TestInitialize]
        public void TestInitialize()
        {
            VendingMachine vend = new VendingMachine();
            bal = new BalanceSheet();
        }

        //method should accept weight amount and return proper money amount
        [TestMethod]
        public void MachineAcceptsAndConvertsCoins()
        {
            Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Nickel) == .05M);
            Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Dime) == .1M);
            Assert.IsTrue(VendingConsole.VendingMachine.ConvertCoin(Quarter) == .25M);
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
            bal.Inserted = 1.00M;
            bal.ColaInventory = 2;
            int invLevel = bal.ColaInventory;
            bal.SelectItem(1);
            Assert.IsTrue(bal.ColaInventory == (invLevel- 1));
        }

        //application must return change to customer overpaying, when change is available
        [TestMethod]
        public void MachineReturnsChange()
        {
            bal.Inserted = 1.05M;
            bal.SelectItem(1);
            Assert.IsTrue(bal.Change==.05M);
        }

        //application must return money inserted, if customer decides not to finalize sale
        [TestMethod]
        public void MachineReturnsInsertedMoney()
        {
            bal.ClearInserted();
            Assert.IsTrue(bal.Inserted == 0); ;
        }

        //when product is sold out, the customer must be made aware
        [TestMethod]
        public void ProductSoldOutAlert()
        {
            bal.ColaInventory = 0;
            Assert.IsFalse(bal.ColaInvString.All(char.IsDigit)); 
            //reflects that value is textual, such as "sold out" or "empty"
        }

        //when machine cannot make change, display must reflect this state
        [TestMethod]
        public void CannotMakeChange()
        {
            bal.CashBalance = .05M;
            Assert.IsTrue(bal.CanMakeChange==false);
        }




    }
}
