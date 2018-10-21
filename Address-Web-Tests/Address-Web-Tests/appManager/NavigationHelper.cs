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
    public class NavigationHelper : BaseHelper
    {
        private readonly string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url != baseURL + "addressbook/")
            {
                driver.Navigate().GoToUrl(baseURL + "addressbook/");
            }
        }

        public void GoToHomePage()
        {
            if (driver.Url != baseURL + "addressbook/")
            {
                driver.FindElement(By.LinkText("home")).Click();
            }
        }

        public void GoToGroupsPage()
        {
            if (driver.Url != baseURL + "addressbook/group.php" && !IsElementPresent(By.Name("delete")))
            {
                driver.FindElement(By.LinkText("groups")).Click();
            }
        }
    }
}
