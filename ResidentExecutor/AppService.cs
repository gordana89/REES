using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class AppService
    {
        private ResidentExecutor residentExecutor;
        private FileSistem fileSistem;
        private DatabaseAccessLayer dao;

        public AppService() 
        {
            residentExecutor = new ResidentExecutor();
            fileSistem = new FileSistem();
            dao = new DatabaseAccessLayer();
        }

        public bool AddMeasurment(Measurent measurent) 
        {
            dao.StoreMeasurement(measurent);
            return true;
        }

        public bool StartResidentExecutor() 
        {
            residentExecutor.Start();
            return true;
        }

        public List<Area> GetAreas() 
        {
            return fileSistem.Areas;
        }

        public bool SaveAreas(List<Area> areas) 
        {
            fileSistem.SaveArea(areas);
            return true;
        }

        public List<CalculationValue> GetValues(DateTime date) 
        {
            List<CalculationValue> result = new List<CalculationValue>();

            result.Add(dao.GetCalculation(date));

            return result;
        }
    }
}
