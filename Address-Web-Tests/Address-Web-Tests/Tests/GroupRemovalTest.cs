using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Navigation.OpenHomePage();
            applicationManager.Authentification.Login(new AccountData("admin", "secret"));
            applicationManager.Navigation.GoToGroupsPage();
            applicationManager.Groups.SelectGroup(1);
            applicationManager.Groups.RemoveGroup();
            applicationManager.Groups.ReturnToGroupsPage();
            applicationManager.Authentification.Logout();
        }
    }
}
