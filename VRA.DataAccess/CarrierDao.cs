using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    public class CarrierDao : BaseDao, ICarrierDao
    {
        /// <summary>
        /// Хранит информацию о предприятиях.
        /// </summary>
        private static IDictionary<int, Carrier> carrier;

        public void Add(Carrier customer)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Carrier(NameCarrier, TimeCarrier) VALUES(@carr, @time)";
                        cmd.Parameters.AddWithValue("@carr", customer.NameCarrier);
                        cmd.Parameters.AddWithValue("@time", customer.TimeCarrier);
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
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Carrier WHERE IDCarrier = @ID";
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }

        /// <summary>
        /// Получет текущее предприятие.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Carrier Get(int id)
        {
            if (carrier == null)
                Load();
            return carrier.ContainsKey(id) ? carrier[id] : null;
        }


        /// <summary>
        /// Удаляет информацию о предприятиях.
        /// </summary>
        public void Reset()
        {
            if (carrier == null)
                return;
            carrier.Clear();
        }

        /// <summary>
        /// Загружает информацию о предприятиях.
        /// </summary>
        /// <returns></returns>
        public List<Carrier> Load()
        {
            carrier = new Dictionary<int, Carrier>();
            try
            {
                var carriers = LoadInternal();
                foreach (var car in carriers)
                {
                    carrier.Add(car.IDCarrier, car);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return carrier.Values.ToList();
        }



        /// <summary>
        /// Загружает информацию о предприятиях.
        /// </summary>
        /// <returns></returns>
        private IList<Carrier> LoadInternal()
        {
            IList<Carrier> enterp = new List<Carrier>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT IDCarrier, NameCarrier, TimeCarrier FROM Carrier";
                        cmd.CommandType = CommandType.Text;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                enterp.Add(LoadEnterprise(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return enterp;
        }

        /// <summary>
        /// Получает информацию о предприятиях из текущей базы данных.
        /// </summary>
        /// <param name="reader">Строка подключаения.</param>
        /// <returns>Информация о предприятиях.</returns>
        private static Carrier LoadEnterprise(SqlDataReader reader)
        {
            Carrier enter = new Carrier();
            try
            {
                enter.IDCarrier = reader.GetInt32(reader.GetOrdinal("IDCarrier"));
                enter.NameCarrier = reader.GetString(reader.GetOrdinal("NameCarrier"));
                enter.TimeCarrier = reader.GetString(reader.GetOrdinal("TimeCarrier"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return enter;
        }

    }
}
