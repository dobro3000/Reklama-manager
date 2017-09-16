using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public class WageReportProcess : IWageReportProcess
    {
        private readonly IWageReportDao _debtDao;

        public WageReportProcess()
        {
            _debtDao = DaoFactory.GetWageReportDao();
        }

        public IList<WageReportDto> GetList()
        {
            return DtoConvert.Convert(_debtDao.GetAll());
        }
    }
}
