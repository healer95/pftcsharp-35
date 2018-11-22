using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WebAddressbookTests;

namespace qwerty
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new string[2];
                args[0] = "2";
                args[1] = @"C:\Users\healer-PC\Source\Repos\pftcsharp-35\Address-Web-Tests\Address-Web-Tests\groups.csv";
                Console.WriteLine("Defaults used: 2 groups.csv");
            }
            int count = Convert.ToInt32(args[0]);
            string temp;
            StreamWriter writer = new StreamWriter(args[1]);
            for (int i = 0; i < count; i++)
            {
                temp = String.Format("{0}\t{1}\t{2}",
                    TestBase.GenerateRandomString(5),
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10));
                writer.WriteLine(temp);
                Console.Out.Write(temp);
            }
            writer.Close();

            //delete last \n
            FileStream fileStream = new FileStream(args[1], FileMode.Open, FileAccess.ReadWrite);
            fileStream.SetLength(fileStream.Length - 2);
            fileStream.Close();

            Console.Read();
        }
    }
}
