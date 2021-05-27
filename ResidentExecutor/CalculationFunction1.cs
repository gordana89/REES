using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class CalculationFunction1 : ICalculation
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

            double max = 0;

            foreach (Measurent m in data) 
            {
                if (m.Value > max) 
                {
                    max = m.Value;
                }
            }

            value.Cal1 = max;

            dao.StoreCalculation(value);
        }
    }
}
