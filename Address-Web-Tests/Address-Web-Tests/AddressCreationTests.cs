using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            OpenQA.Selenium.Chrome.ChromeOptions options = new OpenQA.Selenium.Chrome.ChromeOptions();
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);
            baseURL = "http://localhost:81/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        } //Selenium func

        [Test]
        public void AddressCreationTest()
        {
            CommonMethods.OpenHomePage(driver, baseURL);
            CommonMethods.Login(driver, new AccountData("admin", "secret"));
            InitAddressCreation();
            AddressData addressdata = new AddressData("1name");
                addressdata.Lastname = "lname";
                addressdata.Middlename = "mname";
                addressdata.Nickname = "nname";
                addressdata.Title = "title";
                addressdata.Company = "companyname";
                addressdata.Address = "address";
                addressdata.Home = "5551";
                addressdata.Mobile = "5552";
                addressdata.Work = "5553";
                addressdata.Fax = "5554";
                addressdata.Email = "1@1.1";
                addressdata.Email2 = "2@2.2";
                addressdata.Email3 = "3@3.3";
                addressdata.Homepage = "1.1";
                addressdata.Bday = "1";
                addressdata.Bmonth = "January";
                addressdata.Byear = "1999";
                addressdata.Aday = "2";
                addressdata.Amonth = "February";
                addressdata.Ayear = "2000";
                addressdata.Address2 = "address2";
                addressdata.Phone2 = "5555";
                addressdata.Notes = "hello";
            FillAddressData(addressdata);
            SubmitAddressCreation();
            GoToHomePage();
            // DeleteAllAddresses();
            CommonMethods.Logout(driver);
        }

        // private void DeleteAllAddresses()
        // {
        //     driver.FindElement(By.Id("MassCB")).Click();
        //     acceptNextAlert = true;
        //     driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        //     Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete .*? addresses[\\s\\S]$"));
        // }

        private void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        private void SubmitAddressCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillAddressData(AddressData addressdata)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(addressdata.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(addressdata.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(addressdata.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(addressdata.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(addressdata.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(addressdata.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(addressdata.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(addressdata.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(addressdata.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(addressdata.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(addressdata.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(addressdata.Email);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(addressdata.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(addressdata.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(addressdata.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(addressdata.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(addressdata.Bmonth);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(addressdata.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(addressdata.Aday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(addressdata.Amonth);
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(addressdata.Ayear);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(addressdata.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(addressdata.Phone2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(addressdata.Notes);
        }

        private void InitAddressCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private bool IsElementPresent(By by) //Selenium func
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent() //Selenium func
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText() //Selenium func
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
