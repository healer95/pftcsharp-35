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
            applicationManager.Navigation.GoToGroupsPage();
            applicationManager.Groups.CheckHasGoup();
            applicationManager.Groups.Modyfy(0, newData);
        }
    }
}
