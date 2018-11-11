using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{ 
    [TestFixture]
    class AddressSearchTests : AuthTestBase
    {
        [Test]
        public void AddressSearchTest()
        {
            System.Console.Out.Write(applicationManager.Addresses.GetNumberOfResults());
        }
    }
}
