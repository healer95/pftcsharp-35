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
    public class GroupHelper : BaseHelper
    {
        public GroupHelper(ApplicationManager manager) : base(manager) {}

        public GroupHelper Remove(int v)
        {
            if (!IsOnGroupsPage()) { manager.Navigation.GoToGroupsPage(); }
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public bool IsOnGroupsPage()
        {
            return driver.Url.Contains("/group.php") && !IsElementPresent(By.Name("delete"));
        }

        public GroupHelper Modyfy(int v, GroupData newData)
        {
            if (!IsOnGroupsPage()) { manager.Navigation.GoToGroupsPage(); }
            SelectGroup(v);
            InitGroupModification();
            FillGroupData(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Create(GroupData groupData)
        {
            if (!IsOnGroupsPage()) { manager.Navigation.GoToGroupsPage(); }
            InitGroupCreation();
            FillGroupData(groupData);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        //Group Creation
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupData(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        //Group Removal
        public GroupHelper SelectGroup(int index)
        {
            CheckHasGoup();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public void CheckHasGoup()
        {
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                InitGroupCreation();
                GroupData groupData = new GroupData("");
                FillGroupData(groupData);
                SubmitGroupCreation();
                ReturnToGroupsPage();
            }
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
    }
}
