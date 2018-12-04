using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddressesTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareAddressesUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<AddressData> fromUI = applicationManager.Addresses.GetAddressList();
                List<AddressData> fromDB = AddressData.GetAll();
                fromUI = fromUI.OrderBy(x => x.ID).ToList();
                fromDB = fromDB.OrderBy(x => x.ID).ToList();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
