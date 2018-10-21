using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            applicationManager.Authentification.Logout();
            AccountData account = new AccountData("admin", "secret");
            applicationManager.Authentification.Login(account);
            Assert.IsTrue(applicationManager.Authentification.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            applicationManager.Authentification.Logout();
            AccountData account = new AccountData("admin", "123");
            applicationManager.Authentification.Login(account);
            Assert.IsFalse(applicationManager.Authentification.IsLoggedIn(account));
        }
    }
}
