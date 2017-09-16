using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BuisnessLayer
{
    public interface IOrdersReportProcess
    {
        IList<OrdersReportDto> GetList();
    }
}
