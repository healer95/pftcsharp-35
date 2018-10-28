using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData groupData = new GroupData("123")
            {
                Header = "1",
                Footer = "2"
            };
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            
            applicationManager.Groups.Create(groupData);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            newGroups = newGroups.OrderBy(x => x.Name).ToList();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData groupData = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Create(groupData);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            newGroups = newGroups.OrderBy(x => x.Name).ToList();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData groupData = new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Create(groupData);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            newGroups = newGroups.OrderBy(x => x.Name).ToList();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}