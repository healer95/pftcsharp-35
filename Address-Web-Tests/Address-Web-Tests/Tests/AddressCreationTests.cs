using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressCreationTests : AddressesTestBase
    {
        public static IEnumerable<AddressData> RandomGroupDataProvider()
        {
            List<AddressData> addresses = new List<AddressData>();
            for (int i = 0; i < 5; i++)
            {
                addresses.Add(new AddressData(GenerateRandomString(5))
                {
                    Lastname = GenerateRandomString(5),
                    Middlename = GenerateRandomString(5),
                    Nickname = GenerateRandomString(5),
                    Title = GenerateRandomString(5),
                    Company = GenerateRandomString(5),
                    Address = GenerateRandomString(5),
                    Home = GenerateRandomString(5),
                    Mobile = GenerateRandomString(5),
                    Work = GenerateRandomString(5),
                    Fax = GenerateRandomString(5),
                    Email = GenerateRandomString(5),
                    Email2 = GenerateRandomString(5),
                    Email3 = GenerateRandomString(5),
                    Homepage = GenerateRandomString(5),
                    Bmonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(random.Next(1, 12)),
                    Byear = Convert.ToString(random.Next(1000, 2500)),
                    Amonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(random.Next(1, 12)),
                    Ayear = Convert.ToString(random.Next(1000, 2500)),
                    Address2 = GenerateRandomString(5),
                    Phone2 = GenerateRandomString(5),
                    Notes = GenerateRandomString(5)
                });
                addresses[i].Bday = Convert.ToString(random.Next(1, DateTime.DaysInMonth(Convert.ToInt32(addresses[i].Byear), (Convert.ToDateTime(addresses[i].Bmonth + "." + addresses[i].Byear)).Month)));
                addresses[i].Aday = Convert.ToString(random.Next(1, DateTime.DaysInMonth(Convert.ToInt32(addresses[i].Ayear), (Convert.ToDateTime(addresses[i].Amonth + "." + addresses[i].Ayear)).Month)));
            }
            return addresses;
        }
        public static IEnumerable<AddressData> AddressDataFromCsvFile()
        {
            List<AddressData> groups = new List<AddressData>();
            string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\DataFiles\addresses.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split('\t');
                groups.Add(new AddressData(parts[0])
                {
                    Middlename = parts[1],
                    Lastname = parts[2],
                    Nickname = parts[3],
                    Company = parts[4],
                    Title = parts[5],
                    Address = parts[6],
                    Home = parts[7],
                    Mobile = parts[8],
                    Work = parts[9],
                    Fax = parts[10],
                    Email = parts[11],
                    Email2 = parts[12],
                    Email3 = parts[13],
                    Homepage = parts[14],
                    Bday = parts[15],
                    Bmonth = parts[16],
                    Byear = parts[17],
                    Aday = parts[18],
                    Amonth = parts[19],
                    Ayear = parts[20],
                    Address2 = parts[21],
                    Phone2 = parts[22],
                    Notes = parts[23]
                });
            }
            return groups;
        }

        public static IEnumerable<AddressData> AddressDataFromXmlFile()
        {
            return (List<AddressData>)
                new XmlSerializer(typeof(List<AddressData>))
                .Deserialize(new StreamReader(Directory.GetCurrentDirectory() + @"\DataFiles\addresses.xml"));
        }

        public static IEnumerable<AddressData> AddressDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<AddressData>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\DataFiles\addresses.json"));
        }

        public static IEnumerable<AddressData> AddressDataFromXlsFile()
        {
            List<AddressData> groups = new List<AddressData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Directory.GetCurrentDirectory() + @"\DataFiles\addresses.xls");
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new AddressData()
                {
                    Firstname = range.Cells[i, 1].Value,
                    Middlename = range.Cells[i, 2].Value,
                    Lastname = range.Cells[i, 3].Value,
                    Nickname = range.Cells[i, 4].Value,
                    Company = range.Cells[i, 5].Value,
                    Title = range.Cells[i, 6].Value,
                    Address = range.Cells[i, 7].Value,
                    Home = range.Cells[i, 8].Value,
                    Mobile = range.Cells[i, 9].Value,
                    Work = range.Cells[i, 10].Value,
                    Fax = range.Cells[i, 11].Value,
                    Email = range.Cells[i, 12].Value,
                    Email2 = range.Cells[i, 13].Value,
                    Email3 = range.Cells[i, 14].Value,
                    Homepage = range.Cells[i, 15].Value,
                    Bday = range.Cells[i, 16].Value,
                    Bmonth = range.Cells[i, 17].Value,
                    Byear = range.Cells[i, 18].Value,
                    Aday = range.Cells[i, 19].Value,
                    Amonth = range.Cells[i, 20].Value,
                    Ayear = range.Cells[i, 21].Value,
                    Address2 = range.Cells[i, 22].Value,
                    Phone2 = range.Cells[i, 23].Value,
                    Notes = range.Cells[i, 24].Value
            });
            }
            app.Quit();
            return groups;
        }

        [Test, TestCaseSource("AddressDataFromJsonFile")]
        public void AddressCreationTest(AddressData addressData)
        {
            List<AddressData> oldAddresses = AddressData.GetAll();

            applicationManager.Addresses.Create(addressData);
            
            oldAddresses.Add(addressData);
            Assert.AreEqual(oldAddresses.Count + 1, applicationManager.Addresses.GetAddressesCount());
            applicationManager.Navigation.GoToHomePage();
        }
        //to kill
        [Test]
        public void AddressCreationTest2()
        {
            AddressData addressData = new AddressData("1name")
            {
                Lastname = "1lname",
                Middlename = "1mname",
                Nickname = "1nname",
                Notes = "hello"
            };
            List<AddressData> oldAddresses = AddressData.GetAll();

            applicationManager.Addresses.Create(addressData);
            Assert.AreEqual(oldAddresses.Count + 1, applicationManager.Addresses.GetAddressesCount());
            applicationManager.Navigation.GoToHomePage();
        }

        //to kill
        [Test]
        public void EmptyAddressCreationTest()
        {
            AddressData addressData = new AddressData("") {};
            List<AddressData> oldAddresses = AddressData.GetAll();

            applicationManager.Addresses.Create(addressData);
            Assert.AreEqual(oldAddresses.Count + 1,applicationManager.Addresses.GetAddressesCount());
            applicationManager.Navigation.GoToHomePage();
        }

        [Test]
        public void TestAdderessesDBConectivity()
        {
            //DateTime start = DateTime.Now;
            //List<AddressData> fromUI = applicationManager.Addresses.GetAddressList();
            //DateTime end = DateTime.Now;
            //Console.Out.Write(end.Subtract(start));

            //start = DateTime.Now;
            //List<AddressData> fromDB = AddressData.GetAll();
            //end = DateTime.Now;
            //Console.Out.Write(end.Subtract(start));
        }
    }
}
