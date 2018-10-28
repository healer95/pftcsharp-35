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
            applicationManager.Groups.Modyfy(1, newData);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            newGroups = newGroups.OrderBy(x => x.Name).ToList();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
