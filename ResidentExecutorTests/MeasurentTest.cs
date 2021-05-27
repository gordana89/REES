using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResidentExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentExecutorTests
{
    [TestClass]
    public class MeasurentTest
    {
        [TestMethod]
        public void TestMeasurent()
        {
            Area area = new Area();
            area.Name = "NAME";
            Measurent measurent = new Measurent();
            measurent.Area = area;
            measurent.Value = 105;

            Assert.AreEqual(measurent.Area.Name, "NAME");
            Assert.AreEqual(measurent.Value, 105);
        }
    }
}
