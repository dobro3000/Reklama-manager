using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    class OrdersReportProcess : IOrdersReportProcess
    {
        private readonly IOrdersReportDao _debtDao;

        public OrdersReportProcess()
        {
            _debtDao = DaoFactory.GetOrdersReportDao();
        }

        public IList<OrdersReportDto> GetList()
        {
            return DtoConvert.Convert(_debtDao.GetAll());
        }
    }
}
