using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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
            List<GroupData> oldgroups = applicationManager.Groups.GetGroupList();
            
            applicationManager.Groups.Create(groupData);
            List<GroupData> newgroups = applicationManager.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData groupData = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldgroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Create(groupData);
            List<GroupData> newgroups = applicationManager.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData groupData = new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldgroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Create(groupData);
            List<GroupData> newgroups = applicationManager.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }
    }
}