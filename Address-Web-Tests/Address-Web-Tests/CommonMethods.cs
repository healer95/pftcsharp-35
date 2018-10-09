using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public static class CommonMethods
    {
        public static void OpenHomePage(IWebDriver driver, string baseURL)
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public static void Login(IWebDriver driver, AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }

        public static void Logout(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
