using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public class OrdersProcessDb : IOrdersProcessDb
    {
        private readonly IOrdersDao _ordersDao;

        public OrdersProcessDb()
        {
            _ordersDao = DaoFactory.GetOrdersDao();
        }

        public void Add(OrdersDto order)
        {
            _ordersDao.Add(DtoConvert.Convert(order));
        }

        public void Delete(int id)
        {
            _ordersDao.Delete(id);
        }

        public OrdersDto Get(int id)
        {
            return DtoConvert.Convert(_ordersDao.Get(id));
        }

        public IList<OrdersDto> GetList()
        {
            return DtoConvert.Convert(_ordersDao.GetAll());
        }

        public IList<OrdersDto> SearchOrders(string tbEnterprise, string cbTypeReklama, string cbManager)
        {
            return DtoConvert.Convert(_ordersDao.SearchOrders(tbEnterprise, cbTypeReklama,  cbManager));
        }

        public void Update(OrdersDto order)
        {
            _ordersDao.Update(DtoConvert.Convert(order));
        }
    }
}
