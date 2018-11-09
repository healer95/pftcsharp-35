using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInforamtion()
        {
            ContactData fromTable = applicationManager.Contacts.GetContactsInformationFromTable();
            ContactData fromFrom = applicationManager.Contacts.GetContactsInformationFromTForm();

            Verify(fromTable, fromFrom);
        }
    }
}