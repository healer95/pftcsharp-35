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
    public class AddressRemovalTests : AuthTestBase
    {
        [Test]
        public void AddressRemovalTest()
        {
            applicationManager.Navigation.GoToHomePage();
            applicationManager.Addresses.CheckHasAddress();
            List<AddressData> oldAddresses = applicationManager.Addresses.GetAddressList();

            applicationManager.Addresses.Remove(0);
            List<AddressData> newAddresses = applicationManager.Addresses.GetAddressList();
            oldAddresses.RemoveAt(0);
            oldAddresses = oldAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            newAddresses = newAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            Assert.AreEqual(oldAddresses, newAddresses);
            applicationManager.Navigation.GoToHomePage();
        }
    }
}
