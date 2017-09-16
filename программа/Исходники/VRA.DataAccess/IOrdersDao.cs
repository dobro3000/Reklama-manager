using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public interface IOrdersDao
    {
        Orders Get(int id);
        IList<Orders> GetAll();
        void Add(Orders order);
        void Update(Orders order);
        void Delete(int id);
        IList<Orders> SearchOrders(string tbEnterprise, string cbTypeReklama, string cbManager);
    }
}
