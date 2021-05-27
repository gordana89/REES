using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class CalculationFunction2 : ICalculation
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

            double min = data[0].Value;

            foreach (Measurent m in data)
            {
                if (m.Value < min)
                {
                    min = m.Value;
                }
            }

            value.Cal2 = min;

            dao.StoreCalculation(value);
        }
    }
}
