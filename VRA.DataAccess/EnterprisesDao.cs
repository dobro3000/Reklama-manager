using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    public class EnterprisesDao : BaseDao, IEnterprisesDao
    {
        private static Enterprises LoadEnterprise(SqlDataReader reader)
        {
            Enterprises enterprise = new Enterprises();

            try
            {
                enterprise.Address = reader.GetString(reader.GetOrdinal("Address"));
                enterprise.Email = reader.GetString(reader.GetOrdinal("Email"));
                enterprise.Note = reader.GetString(reader.GetOrdinal("Note"));
                enterprise.IDEnterprise = reader.GetInt32(reader.GetOrdinal("IDEnterprise"));
                enterprise.NameEnterprise = reader.GetString(reader.GetOrdinal("NameEnterprise"));
                enterprise.Phone = reader.GetDouble(reader.GetOrdinal("Phone"));
                enterprise.Representative = reader.GetString(reader.GetOrdinal("Representative"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return enterprise;
        }

        public void Add(Enterprises customer)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Enterprises(Representative, Phone, Note,  Address, Email, NameEnterprise) VALUES(@Representative, @Phone, @Note,  @Address, @Email, @NameEnterprise)";
                        //cmd.Parameters.AddWithValue("@IDEnterprise", customer.IDEnterprise);
                        cmd.Parameters.AddWithValue("@Address", customer.Address);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@NameEnterprise", customer.NameEnterprise);
                        cmd.Parameters.AddWithValue("@Note", customer.Note);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Representative", customer.Representative);

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
                    cmd.CommandText = "DELETE FROM Enterprises WHERE IDEnterprise = @ID1";
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

        public Enterprises Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Representative, Phone, Note, IDEnterprise, Address, Email, NameEnterprise FROM Enterprises WHERE IDEnterprise = @ID1 ";
                    cmd.Parameters.AddWithValue("@ID1", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadEnterprise(dataReader);
                    }
                }
            }
        }

        public IList<Enterprises> GetAll()
        {
            IList<Enterprises> machine = new List<Enterprises>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Representative, Phone, Note, IDEnterprise, Address, Email, NameEnterprise FROM Enterprises";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machine.Add(LoadEnterprise(dataReader));
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

        public IList<Enterprises> SearchEnterprises(string codeMachine, string mark)
        {
            IList<Enterprises> machins = new List<Enterprises>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Enterprises  WHERE NameEnterprise like @codeMachine AND Address like @nameEnterprise";
                        cmd.Parameters.AddWithValue("@codeMachine", "%" + codeMachine + "%");
                        cmd.Parameters.AddWithValue("@nameEnterprise", "%" + mark + "%");
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machins.Add(LoadEnterprise(dataReader));
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
        }

        public void Update(Enterprises customer)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Enterprises SET Note=@Note, Phone=@Phone, Representative=@Representative, Address = @Address, Email=@Email, NameEnterprise=@NameEnterprise WHERE  IDEnterprise = @ID1";
                        cmd.Parameters.AddWithValue("@ID1", customer.IDEnterprise);
                        cmd.Parameters.AddWithValue("@Address", customer.Address);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@NameEnterprise", customer.NameEnterprise);
                        cmd.Parameters.AddWithValue("@Note", customer.Note);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Representative", customer.Representative);
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
