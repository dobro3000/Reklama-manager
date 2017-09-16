using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    class DebtProcessDb : IDebtProcessDb
    {
        private readonly IDebtPayDao _debtDao;

        public DebtProcessDb()
        {
            _debtDao = DaoFactory.GetDebtPayDao();
        }

        public IList<DebtDto> GetList()
        {
            return DtoConvert.Convert(_debtDao.GetAll());
        }
    }
}
