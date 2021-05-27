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
    public class AppServiceTest
    {
        [TestMethod]
        public void TestAppService()
        {
            AppService appService = new AppService();

            Assert.IsNotNull(appService);
            Assert.IsTrue(appService.AddMeasurment(new Measurent()));
            Assert.IsTrue(appService.StartResidentExecutor());
            Assert.IsNotNull(appService.GetValues(DateTime.Now));
            Assert.IsNotNull(appService.GetAreas());
            Assert.IsNotNull(appService.SaveAreas(new List<Area>()));
        }
    }
}
