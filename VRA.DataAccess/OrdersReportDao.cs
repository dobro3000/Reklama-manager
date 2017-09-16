using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    public class OrdersReportDao : BaseDao, IOrdersReportDao
    {
        private static OrdersReport LoadDebt(SqlDataReader reader)
        {
            OrdersReport debt = new OrdersReport();

            try
            {
                debt.Cost = (float)reader.GetDouble(reader.GetOrdinal("Cost"));
                debt.FinallyDate = reader.GetDateTime(reader.GetOrdinal("FinallyDate"));
                debt.NameCarrier = reader.GetString(reader.GetOrdinal("NameCarrier"));
                debt.NameEnterprise = reader.GetString(reader.GetOrdinal("NameEnterprise"));
                debt.NameReklama = reader.GetString(reader.GetOrdinal("NameReklama"));
                debt.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return debt;
        }


        public IList<OrdersReport> GetAll()
        {
            IList<OrdersReport> machine = new List<OrdersReport>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT StartDate, NameReklama, NameEnterprise, NameCarrier,FinallyDate, Cost FROM OrdersReport";
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
