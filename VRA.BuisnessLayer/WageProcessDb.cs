using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public class WageProcessDb : IWageProcessDb
    {
        private readonly IWageDao _wageDao;

        public WageProcessDb()
        {
            _wageDao = DaoFactory.GetWageDao();
        }

        public void Add(WageDto wage)
        {
            _wageDao.Add(DtoConvert.Convert(wage));
        }

        public void Delete(int id)
        {
            _wageDao.Delete(id);
        }

        public WageDto Get(int id)
        {
            return DtoConvert.Convert(_wageDao.Get(id));
        }

        public IList<WageDto> GetList()
        {
            return DtoConvert.Convert(_wageDao.GetAll());
        }

        public IList<WageDto> SearchWage(string codeMachine, string nameEnterprise)
        {
            return DtoConvert.Convert(_wageDao.SearchWage(codeMachine, nameEnterprise));
        }

        public void Update(WageDto wage)
        {
            _wageDao.Update(DtoConvert.Convert(wage));
        }
    }
}
