using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    public class WageReportDao : BaseDao, IWageReportDao
    {
        private static WageReport LoadDebt(SqlDataReader reader)
        {
            WageReport debt = new WageReport();

            try
            {
                debt.CurrentSum = (float)reader.GetDouble(reader.GetOrdinal("CurrentSum"));
                debt.FullNameManager = reader.GetString(reader.GetOrdinal("FullNameManager"));
                debt.Paid = (float)reader.GetDouble(reader.GetOrdinal("Paid"));
                debt.Rest = (float)reader.GetDouble(reader.GetOrdinal("Rest"));
                debt.SumOrders = reader.GetInt32(reader.GetOrdinal("SumOrders"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return debt;
        }

        public IList<WageReport> GetAll()
        {
            IList<WageReport> machine = new List<WageReport>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT CurrentSum, FullNameManager, Paid, Rest, SumOrders FROM WageReport";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machine.Add(LoadDebt(dataReader));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return machine;
        }
    }
}
