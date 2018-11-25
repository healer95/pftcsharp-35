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
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new string[3];
                args[0] = "2";
                args[1] = @"C:\Users\healer-PC\Source\Repos\pftcsharp-35\Address-Web-Tests\Address-Web-Tests\groups.xls";
                args[2] = "xls";
                Console.WriteLine("Defaults used: 2 groups.xml");
            }
            int count = Convert.ToInt32(args[0]);
            string file = Path.Combine(Directory.GetCurrentDirectory(), args[1]);
            string format = args[2];
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(5))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            if (format == "xls")
            {
                WriteGroupsToXls(groups, file);
            }
            else
            {
                StreamWriter writer = new StreamWriter(file);

                if (format == "csv")
                {
                    WriteGroupsToCsv(groups, writer);
                    //delete last \n
                    FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
                    fileStream.SetLength(fileStream.Length - 2);
                    fileStream.Close();
                }
                else if (format == "xml") { WriteGroupsToXml(groups, writer); }
                else if (format == "json") { WriteGroupsToJson(groups, writer); }
                else { Console.Out.Write("Unsupported format " + format); }

                writer.Close();
            }
            Console.Read();
        }

        static void WriteGroupsToCsv(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("{0}\t{1}\t{2}",
                    group.Name,
                    group.Header,
                    group.Footer));
            }
        }

        static void WriteGroupsToXml(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJson(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }

        static void WriteGroupsToXls(List<GroupData> groups, string file)
        {
            Excel.Application app = new Excel.Application();
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
    }
}