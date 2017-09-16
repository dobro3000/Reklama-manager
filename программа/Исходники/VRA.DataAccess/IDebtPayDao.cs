using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public interface IDebtPayDao
    {
        IList<DebtPay> GetAll();
    }
}
