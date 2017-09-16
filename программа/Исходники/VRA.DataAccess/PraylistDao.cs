using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    public class PraylistDao : BaseDao, IPraylistDao
    {
        private static Praylist LoadDebt(SqlDataReader reader)
        {
            Praylist debt = new Praylist();

            try
            {
                debt.Cost = (float)reader.GetDouble(reader.GetOrdinal("Cost"));
                debt.NameCarrier = reader.GetString(reader.GetOrdinal("NameCarrier"));
                debt.NameReklama = reader.GetString(reader.GetOrdinal("NameReklama"));
                debt.Position = reader.GetString(reader.GetOrdinal("Position"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return debt;
        }

        public IList<Praylist> GetAll()
        {
            IList<Praylist> machine = new List<Praylist>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Cost, NameCarrier, NameReklama, Position FROM Praylist";
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
