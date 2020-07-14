using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    [TestFixture]
    class AccountTest
    {
        Account source;
        Account destination;

        [SetUp]
        public void InitAccount()
        {
            // arrange
            source = new Account();
            source.Deposite(200.00F);
            destination = new Account();
            destination.Deposite(150.00F);
        }

        [Test]
        [Category("pass")]
        public void TransferFunds()
        {
            //act
            source.TransferFunds(destination, 100.00F);
            // assert - verify
            Assert.AreEqual(250.00F, destination.Balance);
            Assert.AreEqual(100.00F, source.Balance);
        }


        [Test, Category("pass")]
        [TestCase(200, 0, 78)]
        [TestCase(200, 0, 189)]
        [TestCase(200, 0, 1)]
        public void TransferMinFunds(int a, int b, int c)
        {
            Account source = new Account();
            source.Deposite(a);
            Account destination = new Account();
            destination.Deposite(b);

            source.TransferMinFunds(destination, c);
            Assert.AreEqual(c, destination.Balance);
        }
        void TransferMinFundsFail()
        {
            Account source = new Account();
            source.Deposite(200);
            Account destination = new Account();
            destination.Deposite(100);

            destination = source.TransferMinFunds(destination, 190);
            
        }
        [Test, Category("throws exception")]
        public void TransferMinFundsThrowException()
        {
            Assert.Throws(typeof(NotEnoughFundsException), new TestDelegate(TransferMinFundsFail));
        }

    }
    public class NotEnoughFundsException : ApplicationException
    {

    }
}
