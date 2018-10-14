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
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            InitAddressCreation();
            AddressData addressdata = new AddressData("1name");
                addressdata.Lastname = "lname";
                addressdata.Middlename = "mname";
                addressdata.Nickname = "nname";
                addressdata.Title = "title";
                addressdata.Company = "companyname";
                addressdata.Address = "address";
                addressdata.Home = "5551";
                addressdata.Mobile = "5552";
                addressdata.Work = "5553";
                addressdata.Fax = "5554";
                addressdata.Email = "1@1.1";
                addressdata.Email2 = "2@2.2";
                addressdata.Email3 = "3@3.3";
                addressdata.Homepage = "1.1";
                addressdata.Bday = "1";
                addressdata.Bmonth = "January";
                addressdata.Byear = "1999";
                addressdata.Aday = "2";
                addressdata.Amonth = "February";
                addressdata.Ayear = "2000";
                addressdata.Address2 = "address2";
                addressdata.Phone2 = "5555";
                addressdata.Notes = "hello";
            FillAddressData(addressdata);
            SubmitAddressCreation();
            navigationHelper.GoToHomePage();
            loginHelper.Logout();
        }
    }
}
