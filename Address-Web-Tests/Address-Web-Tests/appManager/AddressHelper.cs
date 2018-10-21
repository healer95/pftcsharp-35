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

        private void CheckHasAddress()
        {
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                AddressData addressData = new AddressData("");
                Create(addressData);
                manager.Navigation.GoToHomePage();
            }
        }

        public bool IsOnHomePage()
        {
            return driver.Url.EndsWith("addressbook/") && !IsElementPresent(By.Name("delete"));
        }

        public AddressHelper Create (AddressData addressData)
        {
            InitAddressCreation();
            FillAddressData(addressData);
            SubmitAddressCreation();
            return this;
        }

        public AddressHelper Remove(int v)
        {
            if (!IsOnHomePage()) { manager.Navigation.GoToHomePage(); }
            SelectAddress(v);
            RemoveAddress();
            manager.Navigation.GoToHomePage();
            return this;
        }

        public AddressHelper RemoveAddress()
        {
            CheckHasAddress();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public AddressHelper SelectAddress(int index)
        {
            // несмотря на то что код одинаковый с группами, 
            // пусть будет отдельный метод,
            // т.к. не факт что всегда и везде будет одинаково
            CheckHasAddress();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public AddressHelper Modyfy(int v, AddressData newData)
        {
            if (!IsOnHomePage()) { manager.Navigation.GoToHomePage(); }
            SelectAddress(v);
            InitAddressModification(0);
            FillAddressData(newData);
            SubmitAddressModification();
            manager.Navigation.GoToHomePage();
            return this;
        }

        private AddressHelper SubmitAddressModification()
        {
            // несмотря на то что код одинаковый с группами, 
            // пусть будет отдельный метод,
            // т.к. не факт что всегда и везде будет одинаково
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private AddressHelper InitAddressModification(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ (index+1) +"]/td[8]/a/img")).Click();
            return this;
        }

        public AddressHelper FillAddressData(AddressData addressData)
        {
            Type(By.Name("firstname"), addressData.Firstname);
            if (addressData.Middlename != null)
            {
                driver.FindElement(By.Name("middlename")).Clear();
                driver.FindElement(By.Name("middlename")).SendKeys(addressData.Middlename);
            }
            if (addressData.Lastname != null)
            {
                driver.FindElement(By.Name("lastname")).Clear();
                driver.FindElement(By.Name("lastname")).SendKeys(addressData.Lastname);
            }
            if (addressData.Nickname != null)
            {
                driver.FindElement(By.Name("nickname")).Clear();
                driver.FindElement(By.Name("nickname")).SendKeys(addressData.Nickname);
            }
            if (addressData.Title != null)
            {

                driver.FindElement(By.Name("title")).Clear();
                driver.FindElement(By.Name("title")).SendKeys(addressData.Title);
            }
            if (addressData.Company != null)
            {

                driver.FindElement(By.Name("company")).Clear();
                driver.FindElement(By.Name("company")).SendKeys(addressData.Company);
            }
            if (addressData.Address != null)
            {

                driver.FindElement(By.Name("address")).Clear();
                driver.FindElement(By.Name("address")).SendKeys(addressData.Address);
            }
            if (addressData.Home != null)
            {

                driver.FindElement(By.Name("home")).Clear();
                driver.FindElement(By.Name("home")).SendKeys(addressData.Home);
            }
            if (addressData.Mobile != null)
            {

                driver.FindElement(By.Name("mobile")).Clear();
                driver.FindElement(By.Name("mobile")).SendKeys(addressData.Mobile);
            }
            if (addressData.Work != null)
            {

                driver.FindElement(By.Name("work")).Clear();
                driver.FindElement(By.Name("work")).SendKeys(addressData.Work);
            }
            if (addressData.Fax != null)
            {

                driver.FindElement(By.Name("fax")).Clear();
                driver.FindElement(By.Name("fax")).SendKeys(addressData.Fax);
            }
            if (addressData.Email != null)
            {

                driver.FindElement(By.Name("email")).Clear();
                driver.FindElement(By.Name("email")).SendKeys(addressData.Email);
            }
            if (addressData.Email2 != null)
            {

                driver.FindElement(By.Name("email2")).Clear();
                driver.FindElement(By.Name("email2")).SendKeys(addressData.Email2);
            }
            if (addressData.Email3 != null)
            {

                driver.FindElement(By.Name("email3")).Clear();
                driver.FindElement(By.Name("email3")).SendKeys(addressData.Email3);
            }
            if (addressData.Homepage != null)
            {

                driver.FindElement(By.Name("homepage")).Clear();
                driver.FindElement(By.Name("homepage")).SendKeys(addressData.Homepage);
            }
            if (addressData.Bday != null && addressData.Bmonth != null && addressData.Byear != null)
            {

                new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(addressData.Bday);
                new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(addressData.Bmonth);
                driver.FindElement(By.Name("byear")).Clear();
                driver.FindElement(By.Name("byear")).SendKeys(addressData.Byear);
            }
            if (addressData.Aday != null && addressData.Amonth != null && addressData.Ayear != null)
            {

                new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(addressData.Aday);
                new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(addressData.Amonth);
                driver.FindElement(By.Name("ayear")).Clear();
                driver.FindElement(By.Name("ayear")).SendKeys(addressData.Ayear);
            }
            if (addressData.Address2 != null)
            {

                driver.FindElement(By.Name("address2")).Clear();
                driver.FindElement(By.Name("address2")).SendKeys(addressData.Address2);
            }
            if (addressData.Phone2 != null)
            {

                driver.FindElement(By.Name("phone2")).Clear();
                driver.FindElement(By.Name("phone2")).SendKeys(addressData.Phone2);
            }
            if (addressData.Notes != null)
            {

                driver.FindElement(By.Name("notes")).Clear();
                driver.FindElement(By.Name("notes")).SendKeys(addressData.Notes);
            }
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
