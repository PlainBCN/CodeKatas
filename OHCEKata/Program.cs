using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OHCEKata
{
    public class Program
    {
      
        public static void Main(string[] args)
        {
            var now = DateTime.UtcNow;
           
            if (IsNight(now))
                Console.Write("Buenas noches Pedro!");
            else if (IsMorning(now))
                Console.Write("Buenos dias Pedro!");
        }

        private static bool IsNight(DateTime now)
        {
            return now.Hour >= 20 || now.Hour < 6;
        }

        private static bool IsMorning(DateTime now)
        {
            return now.Hour >= 6 && now.Hour < 12;
        }
    }
}
