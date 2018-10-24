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
            List<GroupData> oldgroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Modyfy(1, newData);
            List<GroupData> newgroups = applicationManager.Groups.GetGroupList();
            oldgroups[0].Name = newData.Name;
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }
    }
}
