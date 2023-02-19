using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGmail
{
    class GenerateData
    {
        public static string RandomString(int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public static string GenerateRandonEmail(string nameDomen, int size)
        {
            string randomEmail = RandomString(size) + nameDomen;
            return randomEmail; 
        }

    }
}
