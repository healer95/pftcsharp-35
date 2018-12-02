using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupdUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = applicationManager.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromUI = fromUI.OrderBy(x => x.Name).ToList();
                fromDB = fromDB.OrderBy(x => x.Name).ToList();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
