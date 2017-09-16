using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public interface IOrdersProcessDb
    {
        IList<OrdersDto> GetList();

        OrdersDto Get(int id);

        void Add(OrdersDto order);

        void Update(OrdersDto order);

        void Delete(int id);

        IList<OrdersDto> SearchOrders(string tbEnterprise, string cbTypeReklama, string cbManager);
    }
}
