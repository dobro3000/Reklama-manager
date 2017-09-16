using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess;
using VRA.Dto;

namespace VRA.BuisnessLayer
{
    class PraylistProcess : IPraylistProcess
    {
        private readonly IPraylistDao _debtDao;

        public PraylistProcess()
        {
            _debtDao = DaoFactory.GetPraylistDao();
        }

        public IList<PraylistDto> GetList()
        {
            return DtoConvert.Convert(_debtDao.GetAll());
        }
    }
}
