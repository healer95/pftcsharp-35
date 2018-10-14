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
            applicationManager.Navigation.OpenHomePage();
            applicationManager.Authentification.Login(new AccountData ("admin", "secret"));
            applicationManager.Navigation.GoToGroupsPage();
            GroupData groupdata = new GroupData("123")
            {
                Header = "1",
                Footer = "2"
            };
            applicationManager.Groups.InitGroupCreation();
            applicationManager.Groups.FillGroupData(groupdata);
            applicationManager.Groups.SubmitGroupCreation();
            applicationManager.Navigation.GoToGroupsPage();
            applicationManager.Authentification.Logout();
        }
    }
}