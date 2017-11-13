using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using FluentAssertions.Formatting;

namespace OHCEKata.Tests
{
    [TestClass]
    public class OhceScenarios
    {
        [TestMethod]
        public void WhenOhceStartsAtNightItSaysGoodNightWithYourName()
        {
            var now = DateTime.UtcNow;
            try
            {
                var nightTime = new DateTime(2015, 4, 4, 0, 0, 0);
                SetTime(nightTime);

                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    var name = "Pedro";
                    Program.Main(new[] { name });

                    string expected = $"Buenas noches {name}!";
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
            finally
            {
                SetTime(now);
            }
        }

        [TestMethod]
        public void WhenOhceStartsInTheMorningItSaysGoodMorningWithYourName()
        {
            var now = DateTime.UtcNow;
            try
            {
                var morningTime = new DateTime(2015, 4, 4, 11, 0, 0);
                SetTime(morningTime);

                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    var name = "Pedro";
                    Program.Main(new[] { name });

                    string expected = $"Buenos dias {name}!";
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
            finally
            {
                SetTime(now);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        private void SetTime(DateTime time)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear = (Int16)time.Year;
            st.wMonth = (Int16)time.Month;
            st.wDay = (Int16)time.Day;
            st.wHour = (Int16)time.Hour;
            st.wMinute = (Int16)time.Minute;
            st.wSecond = (Int16)time.Second;

            SetSystemTime(ref st);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }
    }
}
