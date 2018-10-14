using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressCreationTests : TestBase
    {
        [Test]
        public void AddressCreationTest()
        {
            applicationManager.Navigation.OpenHomePage();
            applicationManager.Authentification.Login(new AccountData("admin", "secret"));
                        AddressData addressdata = new AddressData("1name")
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
            applicationManager.Addresses.InitAddressCreation();
            applicationManager.Addresses.FillAddressData(addressdata);
            applicationManager.Addresses.SubmitAddressCreation();
            applicationManager.Navigation.GoToHomePage();
            applicationManager.Authentification.Logout();
        }
    }
}
