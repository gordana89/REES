using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class CalculationFunction3 : ICalculation
    {
        private DatabaseAccessLayer dao = new DatabaseAccessLayer();

        public void Calculate(DateTime date)
        {
            List<Measurent> data = dao.GetMeasurents(date);
            CalculationValue value = dao.GetCalculation(date);

            if (data.Count == 0)
            {
                return;
            }

            if (value == null)
            {
                value = new CalculationValue();
            }

            double sum = 0;

            foreach (Measurent m in data)
            {
                sum += m.Value;                
            }

            double avg = sum / data.Count;
            double sum2 = 0;


            foreach (Measurent m in data)
            {
                sum2 += Math.Pow(m.Value - avg, 2);
            }

            value.Cal3 = (1.0 / data.Count) * Math.Sqrt(sum2);

            dao.StoreCalculation(value);
        }
    }
}
