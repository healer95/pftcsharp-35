﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressModificationTests : AddressesTestBase
    {
        [Test]
        public void AddressModificationTest()
        {
            AddressData newData = new AddressData("new1name")
            {
                Lastname = "newlname",
                Middlename = "newmname",
                Nickname = "newnname",
                Title = "newtitle",
                Company = "newcompanyname",
                Address = "newaddress",
                Home = "new5551",
                Mobile = "new5552",
                Work = "new5553",
                Fax = "new5554",
                Email = "new1@1.1",
                Email2 = "new2@2.2",
                Email3 = "new3@3.3",
                Homepage = "new1.1",
                Bday = "5",
                Bmonth = "May",
                Byear = "1991",
                Aday = "12",
                Amonth = "July",
                Ayear = "2005",
                Address2 = "newaddress2",
                Phone2 = "new5555",
                Notes = "newhello"
            };

            applicationManager.Navigation.GoToHomePage();
            applicationManager.Addresses.CheckHasAddress();

            List<AddressData> oldAddresses = applicationManager.Addresses.GetAddressList();
            AddressData oldData = oldAddresses[0];
            applicationManager.Addresses.Modyfy(0, newData);

            Assert.AreEqual(oldAddresses.Count, applicationManager.Addresses.GetAddressesCount());

            List<AddressData> newAddresses = applicationManager.Addresses.GetAddressList();
            oldAddresses[0].Firstname = newData.Firstname;
            oldAddresses = oldAddresses.OrderBy(x => x.ID).ToList();
            newAddresses = newAddresses.OrderBy(x => x.ID).ToList();

            foreach (AddressData group in newAddresses)
            { if (group.ID == oldData.ID) { Assert.AreEqual(newData.Firstname, group.Firstname); } }
        }
    }
}
