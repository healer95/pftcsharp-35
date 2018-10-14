﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected AddressHelper addressHelper;

        public ApplicationManager()
        {
            OpenQA.Selenium.Chrome.ChromeOptions options = new OpenQA.Selenium.Chrome.ChromeOptions();
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);
            baseURL = "http://localhost:81/";
            
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            addressHelper = new AddressHelper(this);
        }

        public LoginHelper Authentification
        {
            get { return loginHelper; }
        }
        public NavigationHelper Navigation
        {
            get { return navigationHelper; }
        }
        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
        public AddressHelper Addresses
        {
            get { return addressHelper; }
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}