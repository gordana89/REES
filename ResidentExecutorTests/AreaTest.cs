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
    public class AreaTest
    {

        [TestMethod]
        public void TestName() 
        {
            Area area = new Area();
            area.Name = "NAME";

            Assert.AreEqual(area.Name, "NAME");
            Assert.AreNotEqual(area.Code, "NAME");
        }

        [TestMethod]
        public void TestCode()
        {
            Area area = new Area();
            area.Code = "CODE";

            Assert.AreEqual(area.Code, "CODE");
            Assert.AreNotEqual(area.Name, "CODE");
        }
    }
}
