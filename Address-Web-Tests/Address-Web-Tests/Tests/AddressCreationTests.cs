using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressCreationTests : AuthTestBase
    {
        [Test]
        public void AddressCreationTest()
        {
            AddressData addressData = new AddressData("1name")
            {
                Lastname = "lname",
                Middlename = "mname",
                Nickname = "nname",
                Title = "title",
                Company = "companyname",
                Address = "address",
                Home = "5551",
                Mobile = "5552",
                Work = "5553",
                Fax = "5554",
                Email = "1@1.1",
                Email2 = "2@2.2",
                Email3 = "3@3.3",
                Homepage = "1.1",
                Bday = "1",
                Bmonth = "January",
                Byear = "1999",
                Aday = "2",
                Amonth = "February",
                Ayear = "2000",
                Address2 = "address2",
                Phone2 = "5555",
                Notes = "hello"
            };
            List<AddressData> oldAddresses = applicationManager.Addresses.GetAddressList();

            applicationManager.Addresses.Create(addressData);
            List<AddressData> newAddresses = applicationManager.Addresses.GetAddressList();
            oldAddresses.Add(addressData);
            oldAddresses = oldAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            newAddresses = newAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            Assert.AreEqual(oldAddresses, newAddresses);
            applicationManager.Navigation.GoToHomePage();
        }
        [Test]
        public void AddressCreationTest2()
        {
            AddressData addressData = new AddressData("1name")
            {
                Lastname = "1lname",
                Middlename = "1mname",
                Nickname = "1nname",
                Notes = "hello"
            };
            List<AddressData> oldAddresses = applicationManager.Addresses.GetAddressList();

            applicationManager.Addresses.Create(addressData);
            List<AddressData> newAddresses = applicationManager.Addresses.GetAddressList();
            oldAddresses.Add(addressData);
            oldAddresses = oldAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            newAddresses = newAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            Assert.AreEqual(oldAddresses, newAddresses);
            applicationManager.Navigation.GoToHomePage();
        }

        [Test]
        public void EmptyAddressCreationTest()
        {
            AddressData addressData = new AddressData("") {};
            List<AddressData> oldAddresses = applicationManager.Addresses.GetAddressList();

            applicationManager.Addresses.Create(addressData);
            List<AddressData> newAddresses = applicationManager.Addresses.GetAddressList();
            oldAddresses.Add(addressData);
            oldAddresses = oldAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            newAddresses = newAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            Assert.AreEqual(oldAddresses, newAddresses);
            applicationManager.Navigation.GoToHomePage();
        }
    }
}
