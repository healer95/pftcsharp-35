using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressInformationTest : AuthTestBase
    {
        [Test]
        public void TestAddressesInforamation()
        {
            AddressData fromTable = applicationManager.Addresses.GetAddressInformationFromTable(0);
            AddressData fromFrom = applicationManager.Addresses.GetAddressInformationFromForm(0);

            Assert.AreEqual(fromTable, fromFrom);
            Assert.AreEqual(fromTable.Address, fromFrom.Address);
            Assert.AreEqual(fromTable.AllPhones, fromFrom.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromFrom.AllEmails);
        }
    }
}