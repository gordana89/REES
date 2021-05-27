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
    public class CalcFunction2Test
    {
        [TestMethod]
        public void Test()
        {
            ICalculation calc2 = new CalculationFunction2();

            Assert.IsNotNull(calc2);
            Assert.IsNotInstanceOfType(calc2, typeof(CalculationFunction1));
            Assert.IsNotInstanceOfType(calc2, typeof(CalculationFunction3));
        }
    }
}
