using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests;

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
                args[1] = @"C:\Users\healer-PC\Source\Repos\pftcsharp-35\Address-Web-Tests\Address-Web-Tests\groups.xml";
                args[2] = "xml";
                Console.WriteLine("Defaults used: 2 groups.xml");
            }
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            List<GroupData> groups = new List<GroupData>();
            string format = args[2];
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(5))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            if (format == "csv") {
                WriteGroupsToCsv(groups, writer);
                //delete last \n
                FileStream fileStream = new FileStream(args[1], FileMode.Open, FileAccess.ReadWrite);
                fileStream.SetLength(fileStream.Length - 2);
                fileStream.Close();
            }
            else if (format == "xml") { WriteGroupsToXml(groups, writer); }
            else { Console.Out.Write("Unsupported format " + format); }

            writer.Close();
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
    }
}
