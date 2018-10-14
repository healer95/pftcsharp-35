using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressRemovalTests : TestBase
    {
        [Test]
        public void AddressRemovalTest()
        {
            applicationManager.Addresses.Remove(1);
        }
    }
}
