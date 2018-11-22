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
                builder.Append(Encoding.ASCII.GetString(new byte[] { (Convert.ToByte(random.Next(33, 175))) }));
            }
            return builder.ToString();
        }
    }
}
