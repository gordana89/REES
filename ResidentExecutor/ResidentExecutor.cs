using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class ResidentExecutor
    {
        private FileSistem fileSistem;
        private bool started = false;

        public ResidentExecutor() 
        {
            fileSistem = new FileSistem();
            Start();
        }

        public void Start() 
        {
            started = true;

            new Thread(() => {
                Do();
            }).Start();
        }

        public void Stop() 
        {
            started = false;
        }

        public void Do() 
        {
            do
            {
                if (fileSistem.Config[1]) 
                {
                    CalculationFunction1 calc1 = new CalculationFunction1();
                    calc1.Calculate(DateTime.Now);
                }

                if (fileSistem.Config[2])
                {
                    CalculationFunction2 calc2 = new CalculationFunction2();
                    calc2.Calculate(DateTime.Now);
                }

                if (fileSistem.Config[1])
                {
                    CalculationFunction3 calc3 = new CalculationFunction3();
                    calc3.Calculate(DateTime.Now);
                }

                Thread.Sleep(10 * 1000);

            } while (started);
        }
    }
}
