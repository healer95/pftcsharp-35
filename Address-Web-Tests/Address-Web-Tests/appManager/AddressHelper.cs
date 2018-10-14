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
    public class AddressHelper : BaseHelper
    {
        public AddressHelper(ApplicationManager manager) : base(manager) { }

        //Address Creation
        public AddressHelper InitAddressCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public AddressHelper Create (AddressData addressData)
        {
            InitAddressCreation();
            FillAddressData(addressData);
            SubmitAddressCreation();
            return this;
        }

        public AddressHelper FillAddressData(AddressData addressData)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(addressData.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(addressData.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(addressData.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(addressData.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(addressData.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(addressData.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(addressData.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(addressData.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(addressData.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(addressData.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(addressData.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(addressData.Email);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(addressData.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(addressData.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(addressData.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(addressData.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(addressData.Bmonth);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(addressData.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(addressData.Aday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(addressData.Amonth);
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(addressData.Ayear);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(addressData.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(addressData.Phone2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(addressData.Notes);
            return this;
        }

        public AddressHelper SubmitAddressCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        // public void DeleteAllAddresses()
        // {
        //     driver.FindElement(By.Id("MassCB")).Click();
        //     acceptNextAlert = true;
        //     driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        //     Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete .*? addresses[\\s\\S]$"));
        // }
    }
}
