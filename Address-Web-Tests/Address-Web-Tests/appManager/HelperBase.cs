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
    public class BaseHelper
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        
        public BaseHelper(ApplicationManager manager)
        {
            this.manager = manager; 
            this.driver = manager.Driver;
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(By.Name("group_name")).Clear();
                driver.FindElement(By.Name("group_name")).SendKeys(text);
            }
        }
    }
}