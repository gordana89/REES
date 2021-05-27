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
    public class CalcFunction3Test
    {
        [TestMethod]
        public void Test()
        {
            ICalculation calc3 = new CalculationFunction3();

            Assert.IsNotNull(calc3);
            Assert.IsNotInstanceOfType(calc3, typeof(CalculationFunction2));
            Assert.IsNotInstanceOfType(calc3, typeof(CalculationFunction1));
        }
    }
}
