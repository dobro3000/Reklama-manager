﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public interface IOrdersReportDao
    {
        IList<OrdersReport> GetAll();
    }
}
