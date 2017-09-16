using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    public class TypeReklamaDao : BaseDao, ITypeReklamaDao
    {
        private static TypeReklama LoadReklama(SqlDataReader reader)
        {
            TypeReklama reklama = new TypeReklama();
            try
            {
                reklama.CarrierForReklama = reader.GetInt32(reader.GetOrdinal("IDCarrier"));
                reklama.Cost = (float)reader.GetDouble(reader.GetOrdinal("Cost"));
                //???
                reklama.IDTypeReklama = reader.GetInt32(reader.GetOrdinal("IDTypeReklama"));
                ///
                reklama.NameReklama = reader.GetString(reader.GetOrdinal("NameReklama"));
                reklama.Note = reader.GetString(reader.GetOrdinal("Note"));
                reklama.Position = reader.GetString(reader.GetOrdinal("Position"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return reklama;
        }

        public void Add(TypeReklama customer)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO TypeReklama(IDCarrier, Cost,  NameReklama, Note, Position) VALUES(@IDCarrier, @Cost, @NameReklama, @Note, @Position)";
                        cmd.Parameters.AddWithValue("@IDCarrier", customer.CarrierForReklama);
                        cmd.Parameters.AddWithValue("@Cost", customer.Cost);
                        //cmd.Parameters.AddWithValue("@IDTypeReklama", customer.IDTypeReklama);
                        cmd.Parameters.AddWithValue("@NameReklama", customer.NameReklama);
                        cmd.Parameters.AddWithValue("@Note", customer.Note);
                        cmd.Parameters.AddWithValue("@Position", customer.Position);
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
                    cmd.CommandText = "DELETE FROM TypeReklama WHERE IDTypeReklama = @ID1";
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

        public TypeReklama Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IDCarrier, Cost, IDTypeReklama, NameReklama, Note, Position FROM TypeReklama WHERE IDTypeReklama = @ID1 ";
                    cmd.Parameters.AddWithValue("@ID1", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadReklama(dataReader);
                    }
                }
            }
        }

        public IList<TypeReklama> GetAll()
        {
            IList<TypeReklama> machine = new List<TypeReklama>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT IDCarrier, Cost, IDTypeReklama, NameReklama, Note, Position FROM TypeReklama";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machine.Add(LoadReklama(dataReader));
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

        public IList<TypeReklama> SearchTypeReklama(string tbReklama, string cbCarrier, string tbPos, string tbCost)
        {

            IList<TypeReklama> machins = new List<TypeReklama>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Carrier.NameCarrier, TypeReklama.IDCarrier, TypeReklama.Cost, TypeReklama.IDTypeReklama, TypeReklama.NameReklama, TypeReklama.Note, TypeReklama.Position FROM TypeReklama JOIN Carrier ON TypeReklama.IDCarrier = Carrier.IDCarrier WHERE NameReklama like @tbReklama AND Carrier.NameCarrier like @cbCarrier AND TypeReklama.Position like @tbPos AND TypeReklama.Cost like @tbCost";
                        cmd.Parameters.AddWithValue("@tbReklama", "%" + tbReklama + "%");
                        cmd.Parameters.AddWithValue("@cbCarrier", "%" + cbCarrier + "%");
                        cmd.Parameters.AddWithValue("@tbPos", "%" + tbPos + "%");
                        cmd.Parameters.AddWithValue("@tbCost",  tbCost);
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machins.Add(LoadReklama(dataReader));
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

        public void Update(TypeReklama customer)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE TypeReklama SET IDCarrier = @IDCarrier, Cost = @Cost, NameReklama=@NameReklama, Note=@Note, Position=@Position WHERE IDTypeReklama = @ID1";
                        cmd.Parameters.AddWithValue("@IDCarrier", customer.CarrierForReklama);
                        cmd.Parameters.AddWithValue("@Cost", customer.Cost);
                        cmd.Parameters.AddWithValue("@ID1", customer.IDTypeReklama);
                        cmd.Parameters.AddWithValue("@NameReklama", customer.NameReklama);
                        cmd.Parameters.AddWithValue("@Note", customer.Note);
                        cmd.Parameters.AddWithValue("@Position", customer.Position);
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
