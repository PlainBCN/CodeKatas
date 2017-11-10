using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OHCEKata.Tests
{
    [TestClass]
    public class OhceScenarios
    {
        [TestMethod]
        public void GivenTimeAsNight_WhenOhceStart_ThenWeReceiveAGoodNight()
        {
            var name = "Pedro";
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(new[] { name });

                string expected = $"Buenas noches {name}!";
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
