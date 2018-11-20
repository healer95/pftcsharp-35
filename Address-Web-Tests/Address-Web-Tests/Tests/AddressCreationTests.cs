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
        public static IEnumerable<AddressData> RandomGroupDataProvider()
        {
            List<AddressData> addresses = new List<AddressData>();
            for (int i = 0; i < 5; i++)
            {
                addresses.Add(new AddressData(GenerateRandomString(5))
                {
                    Lastname = GenerateRandomString(5),
                    Middlename = GenerateRandomString(5),
                    Nickname = GenerateRandomString(5),
                    Title = GenerateRandomString(5),
                    Company = GenerateRandomString(5),
                    Address = GenerateRandomString(5),
                    Home = GenerateRandomString(5),
                    Mobile = GenerateRandomString(5),
                    Work = GenerateRandomString(5),
                    Fax = GenerateRandomString(5),
                    Email = GenerateRandomString(5),
                    Email2 = GenerateRandomString(5),
                    Email3 = GenerateRandomString(5),
                    Homepage = GenerateRandomString(5),
                    Bmonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(random.Next(1, 12)),
                    Byear = Convert.ToString(random.Next(1000, 2500)),
                    Amonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(random.Next(1, 12)),
                    Ayear = Convert.ToString(random.Next(1000, 2500)),
                    Address2 = GenerateRandomString(5),
                    Phone2 = GenerateRandomString(5),
                    Notes = GenerateRandomString(5)
                });
                addresses[i].Bday = Convert.ToString(random.Next(1, DateTime.DaysInMonth(Convert.ToInt32(addresses[i].Byear), (Convert.ToDateTime(addresses[i].Bmonth + "." + addresses[i].Byear)).Month)));
                addresses[i].Aday = Convert.ToString(random.Next(1, DateTime.DaysInMonth(Convert.ToInt32(addresses[i].Ayear), (Convert.ToDateTime(addresses[i].Amonth + "." + addresses[i].Ayear)).Month)));
            }
            return addresses;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void AddressCreationTest(AddressData addressData)
        {
            List<AddressData> oldAddresses = applicationManager.Addresses.GetAddressList();

            applicationManager.Addresses.Create(addressData);
            List<AddressData> newAddresses = applicationManager.Addresses.GetAddressList();
            oldAddresses.Add(addressData);
            oldAddresses = oldAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            newAddresses = newAddresses.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname).ToList();
            Assert.AreEqual(oldAddresses, newAddresses);
            applicationManager.Navigation.GoToHomePage();
        }
        //to kill
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

        //to kill
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
