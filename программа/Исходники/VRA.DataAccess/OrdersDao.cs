using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    public class OrdersDao : BaseDao, IOrdersDao
    {
        private static Orders LoadOrders (SqlDataReader reader)
        {
            Orders orders = new Orders();
            try
            {
                orders.Cost = (float)reader.GetDouble(reader.GetOrdinal("Cost"));
                orders.Debt = (float)reader.GetDouble(reader.GetOrdinal("Debt"));
                orders.FinallyDate = reader.GetDateTime(reader.GetOrdinal("FinallyDate"));
                orders.FullNameManager = reader.GetInt32(reader.GetOrdinal("IDManager"));
                orders.IDOrder = reader.GetInt32(reader.GetOrdinal("IDOrder"));
                orders.NameEnterprise = reader.GetInt32(reader.GetOrdinal("IDEnterprise"));
                orders.Paid = (float)reader.GetDouble(reader.GetOrdinal("Paid"));
                orders.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                orders.TypeReklama = reader.GetInt32(reader.GetOrdinal("IDTypeReklama"));
                orders.AllSum = (float)reader.GetDouble(reader.GetOrdinal("AllSum"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return orders;
        }

        public void Add(Orders order)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Orders(Cost, Debt, FinallyDate, IDManager,IDEnterprise,IDTypeReklama,Paid,StartDate, AllSum) VALUES(@Cost, @Debt, @FinallyDate, @IDManager,@IDEnterprise,@IDTypeReklama,@Paid,@StartDate, @AllSum)";
                        cmd.Parameters.AddWithValue("@Cost", order.Cost);
                        cmd.Parameters.AddWithValue("@Debt", order.Debt);
                        cmd.Parameters.AddWithValue("@IDManager", order.FullNameManager);
                        cmd.Parameters.AddWithValue("@AllSum", order.AllSum);
                        cmd.Parameters.AddWithValue("@IDEnterprise", order.NameEnterprise);
                        cmd.Parameters.AddWithValue("@Paid", order.Paid);

                        DateTime fd = Convert.ToDateTime(order.FinallyDate);
                        string datef = fd.ToString("yyyy-MM-dd 00:00:00.000");
                        cmd.Parameters.AddWithValue("@FinallyDate", datef);

                        DateTime d = Convert.ToDateTime(order.StartDate);
                        string date = d.ToString("yyyy-MM-dd 00:00:00.000");
                        cmd.Parameters.AddWithValue("@StartDate", date);

                        cmd.Parameters.AddWithValue("@IDTypeReklama", order.TypeReklama);
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
                    cmd.CommandText = "DELETE FROM Orders WHERE IDOrder = @ID1";
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

        public Orders Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Cost, Debt, FinallyDate, IDManager,IDOrder,IDEnterprise,Paid,StartDate,IDTypeReklama, AllSum FROM Orders WHERE IDOrders = @ID1 ";
                    cmd.Parameters.AddWithValue("@ID1", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadOrders(dataReader);
                    }
                }
            }
        }

        public IList<Orders> GetAll()
        {
            IList<Orders> machine = new List<Orders>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Orders";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machine.Add(LoadOrders(dataReader));
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

        public IList<Orders> SearchOrders(string tbEnterprise, string cbTypeReklama, string cbManager)
        {

            IList<Orders> machins = new List<Orders>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Orders.Cost, Orders.Debt, Orders.FinallyDate, Orders.IDManager,Orders.IDOrder,Orders.IDEnterprise,Orders.Paid,Orders.StartDate,Orders.IDTypeReklama, Orders.AllSum FROM Orders JOIN Enterprises ON Orders.IDEnterprise = Enterprises.IDEnterprise JOIN Managers ON Managers.IDManager = Orders.IDManager join TypeReklama on orders.IDTypeReklama = TypeReklama.IDTypeReklama WHERE Enterprises.NameEnterprise like @tbEnterprise AND Managers.FullNameManager like @tbManager AND TypeReklama.NameReklama like @tbReklama";
                        cmd.Parameters.AddWithValue("@tbEnterprise", "%" + tbEnterprise + "%");
                        cmd.Parameters.AddWithValue("@tbReklama", "%" + cbTypeReklama + "%");
                        cmd.Parameters.AddWithValue("@tbManager", "%" + cbManager + "%");
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machins.Add(LoadOrders(dataReader));
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

        public void Update(Orders order)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Orders SET Paid=@Paid, StartDate=@StartDate, IDTypeReklama=@IDTypeReklama, Cost = @Cost, Debt = @Debt, FinallyDate=@FinallyDate, IDManager=@IDManager,  IDEnterprise=@IDEnterprise, AllSum=@AllSum WHERE  IDOrder = @ID1";
                        cmd.Parameters.AddWithValue("@Cost", order.Cost);
                        cmd.Parameters.AddWithValue("@Debt", order.Debt);
                        cmd.Parameters.AddWithValue("@AllSum", order.AllSum);
                        cmd.Parameters.AddWithValue("@IDManager", order.FullNameManager);
                        cmd.Parameters.AddWithValue("@ID1", order.IDOrder);
                        cmd.Parameters.AddWithValue("@IDEnterprise", order.NameEnterprise);
                        cmd.Parameters.AddWithValue("@Paid", order.Paid);
                        cmd.Parameters.AddWithValue("@IDTypeReklama", order.TypeReklama);


                        DateTime fd = Convert.ToDateTime(order.FinallyDate);
                        string datef = fd.ToString("yyyy-MM-dd 00:00:00.000");
                        cmd.Parameters.AddWithValue("@FinallyDate", datef);

                        DateTime d = Convert.ToDateTime(order.StartDate);
                        string date = d.ToString("yyyy-MM-dd 00:00:00.000");
                        cmd.Parameters.AddWithValue("@StartDate", date);

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
