using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingAddressFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingAddressFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<AddressData> oldList = group.GetAddresses();
            if (oldList.Count == 0) { Assert.Fail("No suffisient addresses found"};
            AddressData address = AddressData.GetAll().Intersect(oldList).First();
            
            applicationManager.Addresses.RemoveAddressFromGroup(address, group);

            List<AddressData> newList = group.GetAddresses();
            oldList.RemoveAt(0);
            oldList = oldList.OrderBy(x => x.ID).ToList();
            newList = newList.OrderBy(x => x.ID).ToList();

            Assert.AreEqual(oldList, newList);
        }
    }
}
