﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using Microsoft.CSharp;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(30),
                    Footer = GenerateRandomString(30)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\DataFiles\groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split('\t');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(Directory.GetCurrentDirectory() + @"\DataFiles\groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\DataFiles\groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromXlsFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Directory.GetCurrentDirectory() + @"\DataFiles\groups.xls");
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            app.Quit();
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData groupData)
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            
            applicationManager.Groups.Create(groupData);

            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Groups.GetGroupCount());
            //List<GroupData> newGroups = GroupData.GetAll();
            //oldGroups.Add(groupData);
            //oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            //newGroups = newGroups.OrderBy(x => x.Name).ToList();
            //Assert.AreEqual(oldGroups, newGroups);
        }

        //kill
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData groupData = new GroupData("")
            {
                Header = "",
                Footer = ""
            }; 
            List<GroupData> oldGroups = GroupData.GetAll();

            applicationManager.Groups.Create(groupData);

            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Groups.GetGroupCount());
            //List<GroupData> newGroups = GroupData.GetAll();
            //oldGroups.Add(groupData);
            //oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            //newGroups = newGroups.OrderBy(x => x.Name).ToList();
            //Assert.AreEqual(oldGroups, newGroups);
        }

        //kill
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData groupData = new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldGroups = GroupData.GetAll();

            applicationManager.Groups.Create(groupData);

            Assert.AreEqual(oldGroups.Count, applicationManager.Groups.GetGroupCount());
            //List<GroupData> newGroups = GroupData.GetAll();
            //oldGroups.Add(groupData);
            //oldGroups = oldGroups.OrderBy(x => x.Name).ToList();
            //newGroups = newGroups.OrderBy(x => x.Name).ToList();
            //Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestGroupsDBConectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = applicationManager.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            Console.Out.Write(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDB = GroupData.GetAll();
            end = DateTime.Now;
            Console.Out.Write(end.Subtract(start));
        }
        [Test]
        public void TestGARDBConectivity()
        {
            foreach (AddressData v in GroupData.GetAll()[0].GetAddresses())
            {
                Console.Out.WriteLine(v);
            }
        }
    }
}