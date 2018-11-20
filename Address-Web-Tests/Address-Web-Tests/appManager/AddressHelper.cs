using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class AddressHelper : BaseHelper
    {
        public AddressHelper(ApplicationManager manager) : base(manager) { }
        private List<AddressData> addressCache = null;

        public int GetNumberOfResults()
        {
            manager.Navigation.GoToHomePage();
            string text=driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public AddressData GetAddressInformationFromTable(int index)
        {
            manager.Navigation.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new AddressData(firstname, lastname)
            {
                //Lastname = lastname,
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public string FormatDetails(AddressData a)
        {
            string temp = "";
            //1name mname lname\r\
            if (a.Firstname != "") { temp += a.Firstname; }
            if (a.Middlename != "") { temp += " " + a.Middlename; }
            if (a.Lastname != "") { temp += " " + a.Lastname; }
            if (a.Firstname != "" || a.Middlename != "" || a.Lastname != "") { temp = temp.TrimStart(' ') + @"\r\n"; }
            //nnname\r\
            if (a.Nickname != "") { temp += a.Nickname + @"\r\n"; }
            //title\r\n
            if (a.Title != "") { temp += a.Title + @"\r\n"; }
            //companyname\r\n
            if (a.Company != "") { temp += a.Company + @"\r\n"; }
            //address\r\n
            if (a.Address != "") { temp += a.Address + @"\r\n"; }
            //\r\n
            if (a.Nickname != "" || a.Title != "" || a.Company != "" || a.Address != "") { temp += @"\r\n"; }
            //H: 5551\r\n
            if (a.Home != "") { temp += "H: " + a.Home + @"\r\n"; }
            //M: 5552\r\n
            if (a.Mobile != "") { temp += "M: " + a.Mobile + @"\r\n"; }
            //W: 5553\r\n
            if (a.Work != "") { temp += "W: " + a.Work + @"\r\n"; }
            //F: 5554\r\n\r\n
            if (a.Fax != "") { temp += "F: " + a.Fax + @"\r\n\r\n"; }
            //1@1.1\r\n
            if (a.Email != "") { temp += a.Email + @"\r\n"; }
            //2@2.2\r\n
            if (a.Email2 != "") { temp += a.Email2 + @"\r\n"; }
            //3@3.3\r\n
            if (a.Email2 != "") { temp += a.Email3 + @"\r\n"; }
            //Homepage:\r\n1.1\r\n\r\n
            if (a.Homepage != "") { temp += @"Homepage:\r\n" + a.Homepage + @"\r\n"; }
            //Birthday 1.January 1999(19)\r\n
            if ((a.Bday != "" && a.Bday != "-" ) || (a.Bmonth != "" && a.Bmonth != "-") || a.Byear != "")
            {
                temp += @"\r\n";
                temp += "Birthday ";
                if (a.Bday != "" && a.Bday != "-") { temp += " " + a.Bday + "."; }
                if (a.Bmonth != "" && a.Bmonth != "-") { temp += " " + a.Bmonth; }
                if (a.Byear != "") { temp += " " + a.Byear; }

                if (a.Byear != "")
                {
                    temp += " (";
                    temp += (DateTime.Today.AddYears(-Convert.ToInt32(a.Byear))).Year;
                    temp += @")";
                }
               
            }
            //Anniversary 2.February 2000(18)\r\n\r\n
            if ((a.Aday != "" && a.Aday != "-") || (a.Amonth != "" && a.Amonth != "-") || a.Ayear != "")
            {
                temp += @"\r\n";
                temp += "Anniversary";
                if (a.Aday != "" && a.Aday != "-") { temp += " " + a.Aday + "."; }
                if (a.Amonth != "" && a.Amonth != "-") { temp += " " + a.Amonth; }
                if (a.Ayear != "") { temp += " " + a.Ayear; }

                if (a.Ayear != "")
                {
                    temp += " (";
                    temp += (DateTime.Today.AddYears(-Convert.ToInt32(a.Ayear))).Year;
                    temp += @")";
                }                
            }
            //address2\r\n\r\n
            if (temp != "" || a.Address2 != "" || a.Phone2 != "" || a.Notes != "")
            {
                temp += @"\r\n";
                if (a.Address2 != "") { temp += a.Address2; }
                if (a.Phone2 != "") { temp += @"\r\n\r\n"; }
                //P: 5555\r\n\r\n
                if (a.Phone2 != "") { temp += "P: " + a.Phone2; }
                //hello
                if (a.Notes != "") { temp += @"\r\n" + a.Notes; }
            }
            return temp;
        }

        public string GetAddressInformationFromDetails(int index)
        {
            manager.Navigation.GoToHomePage();
            InitAddressDetails(index);
            return driver.FindElement(By.Id("content")).Text;
        }

        public AddressData GetAddressInformationFromForm(int index)
        {
            manager.Navigation.GoToHomePage();
            InitAddressModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bday = GetSelected("bday");
            string bmonth = GetSelected("bmonth");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = GetSelected("aday");
            string amonth = GetSelected("amonth");
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new AddressData(firstname)
            {
                Middlename = middlename,
                Lastname = lastname,
                Nickname = nickname,
                Company = company,
                Title = title,
                Address = address,
                Home = home,
                Mobile = mobile,
                Work = work,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                Bday = bday,
                Bmonth = bmonth,
                Byear = byear,
                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
        }

        private string GetSelected(string v)
        {
            SelectElement temp = new SelectElement(driver.FindElement(By.Name(v)));
            return temp.SelectedOption.Text;
        }

        //Address Creation
        public AddressHelper InitAddressCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        private AddressHelper InitAddressModification(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td[8]/a/img")).Click();
            return this;
        }

        private AddressHelper InitAddressDetails(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td[7]/a/img")).Click();
            return this;
        }

        public void CheckHasAddress()
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

        internal List<AddressData> GetAddressList()
        {
            if (addressCache == null)
            {
                addressCache = new List<AddressData>();
                manager.Navigation.GoToHomePage();
                ICollection<IWebElement> rows = driver.FindElements(By.CssSelector("tr[name=entry"));
                foreach (IWebElement row in rows)
                {
                    var cells = row.FindElements(By.CssSelector("td"));
                    addressCache.Add(new AddressData(cells[2].Text, cells[1].Text));
                }
            }
            return addressCache;
        }

        public AddressHelper RemoveAddress()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            addressCache = null;
            return this;
        }

        public AddressHelper SelectAddress(int index)
        {
            // несмотря на то что код одинаковый с группами, 
            // пусть будет отдельный метод,
            // т.к. не факт что всегда и везде будет одинаково
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public AddressHelper Modyfy(int v, AddressData newData)
        {
            if (!IsOnHomePage()) { manager.Navigation.GoToHomePage(); }
            SelectAddress(v);
            InitAddressModification(0);
            string a = driver.FindElement(By.Name("lastname")).ToString();
            FillAddressData(newData);
            if (a == newData.Lastname) { driver.FindElement(By.Name("middlename")).SendKeys("1"+a); }
            SubmitAddressModification();
            return this;
        }

        private AddressHelper SubmitAddressModification()
        {
            // несмотря на то что код одинаковый с группами, 
            // пусть будет отдельный метод,
            // т.к. не факт что всегда и везде будет одинаково
            driver.FindElement(By.Name("update")).Click();
            addressCache = null;
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
            addressCache = null;
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
