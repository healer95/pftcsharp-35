using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;
using Formatting = Newtonsoft.Json.Formatting;
using Excel = Microsoft.Office.Interop.Excel;

namespace qwerty
{
    class Program
    {
        public static Random random = new Random();

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                var dir = TryGetSolutionDirectoryInfo();
                args = new string[4];
                args[0] = "2";
                args[1] = "2";
                args[3] = "json";
                if (args[0] == "1" || args[0] == "groups") { args[2] = dir.FullName + @"\groups." + args[3]; }
                else { args[2] = dir.FullName + @"\addresses." + args[3]; }
                
                Console.WriteLine(@"Defaults used: create 2 instances in 'addresses.json'");
            }
            args[0].ToLower(); args[1].ToLower(); args[2].ToLower(); args[3].ToLower();
            if (args[0] != "1" && args[0] != "2" && args[0] != "grops" && args[0] != "addresses")
                { Console.Out.Write("Incorrect type: " + args[0]); return; }
            if (!(Convert.ToInt32(args[1]) > 0))
                { Console.Out.Write("Incorrect instances count: " + args[1]); return; }
            if (args[3] != "csv" && args[3] != "xml" && args[3] != "json" && args[3] != "xls")
                { Console.Out.Write("Unsupported format: " + args[0]); return; }

            int count = Convert.ToInt32(args[1]);
            string file = Path.Combine(Directory.GetCurrentDirectory(), args[2]);
            string format = args[3];
            if (args[0] == "1" || args[0] == "groups")
            {
                List<GroupData> instances = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    instances.Add(new GroupData(TestBase.GenerateRandomString(5))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "xls")
                {
                    WriteToXls(instances, file);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(file);

                    if (format == "csv")
                    {
                        WriteToCsv(instances, writer);
                        writer.Close();
                        //delete last \n
                        FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
                        fileStream.SetLength(fileStream.Length - 2);
                        fileStream.Close();
                    }
                    else if (format == "xml") { WriteToXml(instances, writer); }
                    else if (format == "json") { WriteToJson(instances, writer); }
                    else { Console.Out.Write("Unsupported format " + format); }

                    writer.Close();
                }
            }
            else
            {
                List<AddressData> instances = new List<AddressData>();
                for (int i = 0; i < count; i++)
                {
                    instances.Add(new AddressData(TestBase.GenerateRandomString(5))
                    {
                        Middlename = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(10),
                        Nickname = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Title = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                        Home = TestBase.GenerateRandomString(10),
                        Mobile = TestBase.GenerateRandomString(10),
                        Work = TestBase.GenerateRandomString(10),
                        Fax = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10),
                        Homepage = TestBase.GenerateRandomString(10),
                        Bmonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(random.Next(1, 12)),
                        Byear = Convert.ToString(random.Next(1000, 2500)),
                        Amonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(random.Next(1, 12)),
                        Ayear = Convert.ToString(random.Next(1000, 2500)),
                        Address2 = TestBase.GenerateRandomString(10),
                        Phone2 = TestBase.GenerateRandomString(10),
                        Notes = TestBase.GenerateRandomString(10)
                    });
                    instances[i].Bday = Convert.ToString(random.Next(1, DateTime.DaysInMonth(Convert.ToInt32(instances[i].Byear), (Convert.ToDateTime(instances[i].Bmonth + "." + instances[i].Byear)).Month)));
                    instances[i].Aday = Convert.ToString(random.Next(1, DateTime.DaysInMonth(Convert.ToInt32(instances[i].Ayear), (Convert.ToDateTime(instances[i].Amonth + "." + instances[i].Ayear)).Month)));
                }
                if (format == "xls")
                {
                    WriteToXls(instances, file);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(file);

                    if (format == "csv")
                    {
                        WriteToCsv(instances, writer);
                        writer.Close();
                        //delete last \n
                        FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
                        fileStream.SetLength(fileStream.Length - 2);
                        fileStream.Close();
                    }
                    else if (format == "xml") { WriteToXml(instances, writer); }
                    else if (format == "json") { WriteToJson(instances, writer); }
                    else { Console.Out.Write("Unsupported format " + format); }

                    writer.Close();
                }
            }
            Console.Out.WriteLine("Done");
            Console.Out.Write("Press Enter");
            Console.Read();
        }

        static void WriteToCsv(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("{0}\t{1}\t{2}",
                    group.Name,
                    group.Header,
                    group.Footer));
            }
        }
        static void WriteToCsv(List<AddressData> addresses, StreamWriter writer)
        {
            foreach (AddressData address in addresses)
            {
                writer.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\t{18}\t{19}\t{20}\t{21}\t{22}\t{23}",
                    address.Firstname,
                    address.Middlename,
                    address.Lastname,
                    address.Nickname,
                    address.Company,
                    address.Title,
                    address.Address,
                    address.Home,
                    address.Mobile,
                    address.Work,
                    address.Fax,
                    address.Email,
                    address.Email2,
                    address.Email3,
                    address.Homepage,
                    address.Bday,
                    address.Bmonth,
                    address.Byear,
                    address.Aday,
                    address.Amonth,
                    address.Ayear,
                    address.Address2,
                    address.Phone2,
                    address.Notes
                    ));
            }
        }

        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

        static void WriteToXml(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void WriteToXml(List<AddressData> addresses, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<AddressData>)).Serialize(writer, addresses);
        }

        static void WriteToJson(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }
        static void WriteToJson(List<AddressData> addresses, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(addresses, Formatting.Indented));
        }

        static void WriteToXls(List<GroupData> groups, string file)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            File.Delete(file);
            wb.SaveAs(file);
            app.Quit();
        }
        static void WriteToXls(List<AddressData> addresses, string file)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (AddressData address in addresses)
            {
                sheet.Cells[row, 1] = address.Firstname;
                sheet.Cells[row, 2] = address.Middlename;
                sheet.Cells[row, 3] = address.Lastname;
                sheet.Cells[row, 4] = address.Nickname;
                sheet.Cells[row, 5] = address.Company;
                sheet.Cells[row, 6] = address.Title;
                sheet.Cells[row, 7] = address.Address;
                sheet.Cells[row, 8] = address.Home;
                sheet.Cells[row, 9] = address.Mobile;
                sheet.Cells[row, 10] = address.Work;
                sheet.Cells[row, 11] = address.Fax;
                sheet.Cells[row, 12] = address.Email;
                sheet.Cells[row, 13] = address.Email2;
                sheet.Cells[row, 14] = address.Email3;
                sheet.Cells[row, 15] = address.Homepage;
                sheet.Cells[row, 16] = address.Bday;
                sheet.Cells[row, 17] = address.Bmonth;
                sheet.Cells[row, 18] = address.Byear;
                sheet.Cells[row, 19] = address.Aday;
                sheet.Cells[row, 20] = address.Amonth;
                sheet.Cells[row, 21] = address.Ayear;
                sheet.Cells[row, 22] = address.Address2;
                sheet.Cells[row, 23] = address.Phone2;
                sheet.Cells[row, 24] = address.Notes;
                row++;
            }

            File.Delete(file);
            wb.SaveAs(file);
            app.Quit();
        }
    }
}