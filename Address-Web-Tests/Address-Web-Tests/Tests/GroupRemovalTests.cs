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
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Navigation.GoToGroupsPage();
            applicationManager.Groups.CheckHasGoup();
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, applicationManager.Groups.GetGroupCount());
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            newGroups = newGroups.OrderBy(x => x.Name).ToList();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
