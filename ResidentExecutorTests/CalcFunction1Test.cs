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
    public class CalcFunction1Test
    {
        [TestMethod]
        public void Test() 
        {
            ICalculation calc1 = new CalculationFunction1();

            Assert.IsNotNull(calc1);
            Assert.IsNotInstanceOfType(calc1, typeof(CalculationFunction2));
            Assert.IsNotInstanceOfType(calc1, typeof(CalculationFunction3));
        }
    }
}
