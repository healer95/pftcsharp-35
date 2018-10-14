using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData groupdata = new GroupData("123");
            groupdata.Header = "1";
            groupdata.Footer = "2";
            groupHelper.FillGroupData(groupdata);
            groupHelper.SubmitGroupCreation();
            navigationHelper.GoToGroupsPage();
            loginHelper.Logout();
        }
    }
}