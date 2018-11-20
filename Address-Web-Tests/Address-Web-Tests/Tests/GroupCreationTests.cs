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
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(30),
                    Footer = GenerateRandomString(30)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData groupData)
        {
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            
            applicationManager.Groups.Create(groupData);

            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Groups.GetGroupCount());
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            newGroups = newGroups.OrderBy(x => x.Name).ToList();
            Assert.AreEqual(oldGroups, newGroups);
        }

        //kill
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

            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Groups.GetGroupCount());
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

            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Groups.GetGroupCount());
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            newGroups = newGroups.OrderBy(x => x.Name).ToList();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}