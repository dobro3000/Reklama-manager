using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    public class DebtPayDao : BaseDao, IDebtPayDao
    {
        private static DebtPay LoadDebt(SqlDataReader reader)
        {
            DebtPay debt = new DebtPay();

            try
            {
                debt.Debt = (float)reader.GetDouble(reader.GetOrdinal("Debt"));
                debt.FinnalyDate = reader.GetDateTime(reader.GetOrdinal("FinallyDate"));
                debt.NameEnterprise = reader.GetString(reader.GetOrdinal("NameEnterprise"));
                debt.Phone = (float)reader.GetDouble(reader.GetOrdinal("Phone"));
                debt.Representative = reader.GetString(reader.GetOrdinal("Representative"));
                debt.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return debt;
        }

        public IList<DebtPay> GetAll()
        {
            IList<DebtPay> machine = new List<DebtPay>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT FinallyDate, Debt, NameEnterprise, Phone,Representative, StartDate FROM DebtReport";
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
