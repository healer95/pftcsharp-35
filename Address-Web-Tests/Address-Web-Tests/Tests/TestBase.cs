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
            
            int l = Convert.ToInt32(random.NextDouble() * v);
            StringBuilder builder = new StringBuilder();
            for (int i=0; i<l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(random.NextDouble() * 223)));
            }
            return builder.ToString();
        }
    }
}
