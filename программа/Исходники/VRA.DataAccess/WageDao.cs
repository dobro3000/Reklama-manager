using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace VRA.DataAccess
{
    public class WageDao : BaseDao,IWageDao
    {
        private static Wage LoadWage(SqlDataReader reader)
        {
            Wage wage = new Wage();

            try
            {
                //wage.CurrentSum = (float)reader.GetDouble(reader.GetOrdinal("CurrentSum"));
                wage.Manager = reader.GetInt32(reader.GetOrdinal("IDManager"));
                //wage.Paid = (float)reader.GetDouble(reader.GetOrdinal("Paid"));
                //wage.Rest = (float)reader.GetDouble(reader.GetOrdinal("Rest"));
                //wage.SumOrders = reader.GetInt32(reader.GetOrdinal("SumOrders"));

                object decease1 = reader["Paid"];
                if (decease1 != DBNull.Value)
                    wage.Paid = (float)Convert.ToDouble(decease1);

                object decease2 = reader["Rest"];
                if (decease2 != DBNull.Value)
                    wage.Rest = (float)Convert.ToDouble(decease2);

                object decease3 = reader["SumOrders"];
                if (decease3 != DBNull.Value)
                    wage.SumOrders = Convert.ToInt32(decease3);

                object decease4 = reader["CurrentSum"];
                if (decease4 != DBNull.Value)
                    wage.CurrentSum  = (float)Convert.ToDouble(decease4);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка.");
            }

            return wage;
        }

        public void Add(Wage wage)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Wage(CurrentSum, IDManager, Paid, Rest, SumOrders) VALUES(@CurrentSum, @IDManager, @Paid, @Rest, @SumOrders)";
                        cmd.Parameters.AddWithValue("@IDManager", wage.Manager);

                        object decease1 = wage.CurrentSum.HasValue ? (object)wage.CurrentSum.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@CurrentSum", decease1);

                        object decease2 = wage.Paid.HasValue ? (object)wage.Paid.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@Paid", decease2);

                        object decease3 = wage.Rest.HasValue ? (object)wage.Rest.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@Rest", decease3);

                        object decease4 = wage.SumOrders.HasValue ? (object)wage.SumOrders.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@SumOrders", decease4);
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
                    cmd.CommandText = "DELETE FROM Wage WHERE IDManager = @ID1";
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

        public Wage Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CurrentSum,  IDManager, Paid, Rest, SumOrders FROM Wage WHERE IDManager = @ID1 ";
                    cmd.Parameters.AddWithValue("@ID1", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadWage(dataReader);
                    }
                }
            }
        }

        public IList<Wage> GetAll()
        {
            IList<Wage> machine = new List<Wage>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT CurrentSum, IDManager, Paid, Rest, SumOrders FROM Wage";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machine.Add(LoadWage(dataReader));
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

        public IList<Wage> SearchWage(string codeMachine, string mark)
        {
            /*
             IList<Machine> machins = new List<Machine>();
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
            return new List<Wage>();
        }

        public void Update(Wage wage)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Wage SET  CurrentSum = @CurrentSum,  Paid=@Paid, Rest=@Rest, SumOrders=@SumOrders WHERE IDManager = @ID1";
                        //cmd.Parameters.AddWithValue("@IDWage", wage.IDWage);
                        cmd.Parameters.AddWithValue("@ID1", wage.Manager);

                        object decease1 = wage.CurrentSum.HasValue ? (object)wage.CurrentSum.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@CurrentSum", decease1);

                        object decease2 = wage.Paid.HasValue ? (object)wage.Paid.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@Paid", decease2);

                        object decease3 = wage.Rest.HasValue ? (object)wage.Rest.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@Rest", decease3);

                        object decease4 = wage.SumOrders.HasValue ? (object)wage.SumOrders.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@SumOrders", decease4);
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
