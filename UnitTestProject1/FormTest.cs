using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceGame;

namespace UnitTestProject1
{
    [TestClass]
    [UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
    public class FormTest
    {
        // ***** Punter Name test - passed (Positive Test Case) ********* 
        [TestMethod]
        public void TestMethod1()
        {
            RaceForm form = new RaceForm();
            var actual = form.punter[0].GuyName;
            Assert.AreEqual("Ram", actual);
        }

        // ***** Punter Name test - passed (Negative Test Case) ********* 
        [TestMethod]
        public void TestMethod2()
        {
            RaceForm form = new RaceForm();
            var actual = form.punter[1].GuyName;
            Assert.AreNotEqual("Ram", actual);
        }
    }
}
