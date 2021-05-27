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
    public class FileSistemTest
    {
        [TestMethod]
        public void TestFileSistem() 
        {
            FileSistem fs = new FileSistem();

            Assert.IsNotNull(fs.Areas);
            Assert.IsNotNull(fs.Config);
        }
    }
}
