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
    public class BaseHelper
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        
        public BaseHelper(ApplicationManager manager)
        {
            this.manager = manager; 
            this.driver = manager.Driver;
        }
    }
}