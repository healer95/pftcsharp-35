using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("qwe")
            {
                Header = "q",
                Footer = "w"
            };
            applicationManager.Groups.CheckHasGoup();

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            applicationManager.Groups.Modyfy(0, newData);

            Assert.AreEqual(oldGroups.Count, applicationManager.Groups.GetGroupCount());
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            newGroups = newGroups.OrderBy(x => x.Name).ToList();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            { if (group.ID == oldData.ID) { Assert.AreEqual(newData.Name, group.Name); } }
        }
    }
}
