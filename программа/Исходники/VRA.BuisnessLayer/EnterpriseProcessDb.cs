using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public class EnterpriseProcessDb : IEnterpriseProcessDb
    {
        private readonly IEnterprisesDao _enterpriseDao;

        public EnterpriseProcessDb()
        {
            _enterpriseDao = DaoFactory.GetEnterprisesDao();
        }

        public void Add(EnterprisesDto enterprise)
        {
            _enterpriseDao.Add(DtoConvert.Convert(enterprise));
        }

        public void Delete(int id)
        {
            _enterpriseDao.Delete(id);
        }

        public EnterprisesDto Get(int id)
        {
            return DtoConvert.Convert(_enterpriseDao.Get(id));
        }

        public IList<EnterprisesDto> GetList()
        {
            return DtoConvert.Convert(_enterpriseDao.GetAll());
        }

        public IList<EnterprisesDto> SearchEnterprises(string codeMachine, string nameEnterprise)
        {
            return DtoConvert.Convert(_enterpriseDao.SearchEnterprises(codeMachine, nameEnterprise));
        }

        public void Update(EnterprisesDto enterprise)
        {
            _enterpriseDao.Update(DtoConvert.Convert(enterprise));
        }
    }
}
