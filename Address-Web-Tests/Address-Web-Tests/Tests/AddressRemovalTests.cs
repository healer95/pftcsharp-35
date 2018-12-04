using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressRemovalTests : AddressesTestBase
    {
        [Test]
        public void AddressRemovalTest()
        {
            applicationManager.Navigation.GoToHomePage();
            applicationManager.Addresses.CheckHasAddress();
            List<AddressData> oldAddresses = AddressData.GetAll();
            AddressData toBeRemoved = oldAddresses[0];
            applicationManager.Addresses.Remove(toBeRemoved);

            Assert.AreEqual(oldAddresses.Count - 1, applicationManager.Addresses.GetAddressesCount());
            applicationManager.Navigation.GoToHomePage();
        }
    }
}
