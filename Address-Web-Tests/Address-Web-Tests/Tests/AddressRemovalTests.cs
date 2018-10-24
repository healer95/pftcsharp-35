using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressRemovalTests : AuthTestBase
    {
        [Test]
        public void AddressRemovalTest()
        {
            applicationManager.Navigation.GoToHomePage();
            applicationManager.Addresses.CheckHasAddress();
            applicationManager.Addresses.Remove(0);
        }
    }
}
