using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    public class ManagersDao : BaseDao, IManagersDao
    {
        private static Managers LoadManagers(SqlDataReader reader)
        {
            Managers manager = new Managers();
            try
            {
                manager.FullName = reader.GetString(reader.GetOrdinal("FullNameManager"));
                manager.IDManager = reader.GetInt32(reader.GetOrdinal("IDManager"));
                manager.Note = reader.GetString(reader.GetOrdinal("Note"));
                manager.PercentOnSale = (float)reader.GetDouble(reader.GetOrdinal("PercentOnSale"));
                manager.Phone = reader.GetDouble(reader.GetOrdinal("Phone"));
                manager.StartDateWork = reader.GetDateTime(reader.GetOrdinal("StartDateWork"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return manager;
        }

        public void Add(Managers customer)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Managers(FullNameManager, Note, PercentOnSale,Phone,StartDateWork) VALUES(@FullNameManager,  @Note, @PercentOnSale,@Phone,@StartDateWork)";
                        cmd.Parameters.AddWithValue("@FullNameManager", customer.FullName);
                       // cmd.Parameters.AddWithValue("@IDManager", customer.IDManager);
                        cmd.Parameters.AddWithValue("@Note", customer.Note);
                        cmd.Parameters.AddWithValue("@PercentOnSale", customer.PercentOnSale);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        DateTime d = Convert.ToDateTime(customer.StartDateWork);
                        string date = d.ToString("yyyy-MM-dd 00:00:00.000");
                        cmd.Parameters.AddWithValue("@StartDateWork", date);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Managers WHERE IDManager = @ID1";
                    cmd.Parameters.AddWithValue("@ID1", id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Ошибка");
                    }
                }
            }
        }

        public Managers Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT FullNameManager, IDManager, Note, PercentOnSale,Phone,StartDateWork FROM Managers WHERE IDManager = @ID1 ";
                    cmd.Parameters.AddWithValue("@ID1", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadManagers(dataReader);
                    }
                }
            }
        }

        public IList<Managers> GetAll()
        {
            IList<Managers> machine = new List<Managers>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT FullNameManager, IDManager, Note, PercentOnSale,Phone,StartDateWork FROM Managers";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machine.Add(LoadManagers(dataReader));
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

        public IList<Managers> SearchManagers(string codeMachine, string mark)
        {
            /*
             * IList<Machine> machins = new List<Machine>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Machine.NumberOfRepairs, CodeMachine, Machine.IDEnterprise, Machine.IDCountry FROM Machine JOIN Enterprise ON Machine.IDEnterprise = Enterprise.IDEnterprise JOIN Country ON Machine.IDCountry = Country.IDCountry WHERE CodeMachine like @codeMachine AND Enterprise.NameEnterprise like @nameEnterprise AND Country.NameCountry like @nameCountry";
                        cmd.Parameters.AddWithValue("@codeMachine", "%" + codeMachine + "%");
                        cmd.Parameters.AddWithValue("@nameEnterprise", "%" + nameEnterprise + "%");
                        cmd.Parameters.AddWithValue("@nameCountry", "%" + nameCountry + "%");
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machins.Add(LoadMachine(dataReader));
                            }

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return machins;
             */
            throw new NotImplementedException();
        }

        public void Update(Managers customer)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Managers SET  FullNameManager = @FullNameManager,  Note=@Note, PercentOnSale=@PercentOnSale,Phone=@Phone, StartDateWork=@StartDateWork  WHERE  IDManager = @ID1";
                        cmd.Parameters.AddWithValue("@FullNameManager", customer.FullName);
                        cmd.Parameters.AddWithValue("@ID1", customer.IDManager);
                        cmd.Parameters.AddWithValue("@Note", customer.Note);
                        cmd.Parameters.AddWithValue("@PercentOnSale", customer.PercentOnSale);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        DateTime d = Convert.ToDateTime(customer.StartDateWork);
                        string date = d.ToString("yyyy-MM-dd 00:00:00.000");
                        cmd.Parameters.AddWithValue("@StartDateWork", date);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }
    }
}
