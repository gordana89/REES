using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class DatabaseAccessLayer
    {
        private string connectionString = @"Server= DESKTOP-AOLAN1V\SQLEXPRESS; Database= re; Integrated Security=True;";

        public void StoreMeasurement(Measurent measurent) 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();    

            try
            {
                string sql = "INSERT INTO Measurment(MeasurmentValue, MeasurmentDate, AreaName, AreaCode) " +
                    "values('" + measurent.Value + "','" + measurent.Timestamp + "','" + measurent.Area.Name +"','" + measurent.Area.Code + "')";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                command.Dispose();
            }
            catch (Exception e) 
            {
                connection.Close();
            }

            connection.Close();
        }

        public void StoreCalculation(CalculationValue value)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string sql = string.Empty;
                value.Timestamp = DateTime.Now;

                if (value.Id > 0)
                {
                    sql = "UPDATE Calculation SET Calc1 = " + value.Cal1 + ", Calc2 = " + value.Cal2 + ", Calc3 = " + value.Cal3 +
                        ", CalculationDate = '" + value.Timestamp + "' WHERE Id = " + value.Id + ";";
                }
                else 
                {
                    sql = "INSERT INTO Calculation(Calc1, Calc2, Calc3, CalculationDate) values("+ value.Cal1 +", " + value.Cal2 +","+
                        value.Cal3 + ", '" + value.Timestamp + "')";
                }

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                command.Dispose();
            }
            catch (Exception e)
            {
                connection.Close();
            }

            connection.Close();
        }

        public List<Measurent> GetMeasurents(DateTime timestamp) 
        {
            List<Measurent> result = new List<Measurent>();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                string sql = "SELECT * FROM Measurment";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    Measurent measurent = new Measurent();
                    measurent.Value = reader.GetDouble(1);
                    measurent.Timestamp = reader.GetDateTime(2);
                    measurent.Area = new Area();
                    measurent.Area.Name = reader.GetString(3);
                    measurent.Area.Code = reader.GetString(4);
                    result.Add(measurent);
                }

                reader.Close();
                command.Dispose();

            }
            catch (Exception e)
            {
                connection.Close();
            }

            connection.Close();
            return result;
        }

        public CalculationValue GetCalculation(DateTime timestamp) 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                string sql = "SELECT * FROM Calculation WHERE CalculationDate > '"+ timestamp.Date + "' and CalculationDate < '" + timestamp.AddDays(1).Date + "'";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                CalculationValue value = new CalculationValue();

                while (reader.Read())
                {
                    value.Id = reader.GetInt32(0);
                    value.Cal1 = reader.GetDouble(1);
                    value.Cal2 = reader.GetDouble(2);
                    value.Cal3 = reader.GetDouble(3);
                    value.Timestamp = reader.GetDateTime(4);
                }

                reader.Close();
                command.Dispose();

                return value;
            }
            catch (Exception e)
            {
                connection.Close();
            }

            connection.Close();

            return null;
        }
    }
}
