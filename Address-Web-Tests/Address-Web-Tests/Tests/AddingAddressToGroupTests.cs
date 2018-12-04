using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingAddressToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingAddressToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<AddressData> oldList = group.GetAddresses();
            AddressData address = AddressData.GetAll().Except(oldList).First();

            applicationManager.Addresses.AddAddressToGroup(address, group);

            List<AddressData> newList = group.GetAddresses();
            oldList.Add(address);
            oldList = oldList.OrderBy(x => x.ID).ToList();
            newList = newList.OrderBy(x => x.ID).ToList();

            Assert.AreEqual(oldList, newList);
        }
    }
}
