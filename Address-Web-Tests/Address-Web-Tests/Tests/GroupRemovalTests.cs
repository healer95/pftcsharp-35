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
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Navigation.GoToGroupsPage();
            applicationManager.Groups.CheckHasGoup();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            applicationManager.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, applicationManager.Groups.GetGroupCount());
        }
    }
}
