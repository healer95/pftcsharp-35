using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;
        public static Random random = new Random();

        [SetUp]
        public void SetupApplicationManager() 
        {
            applicationManager = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int v)
        {
            int l = random.Next(1, v);
            StringBuilder builder = new StringBuilder();
            for (int i=0; i<l; i++)
            {
                int temp = random.Next(33, 175);
                if (temp == 39) { temp++; } //' isn't parsable
                if (temp == 60) { temp++; } //< isn't parsable

                builder.Append(Encoding.ASCII.GetString(new byte[] { (Convert.ToByte(temp)) }));
            }
            return builder.ToString();
        }
    }
}
