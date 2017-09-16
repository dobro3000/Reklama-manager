using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public class ManagersProcessDb : IManagersProcessDb
    {
        private readonly IManagersDao _managerDao;

        public ManagersProcessDb()
        {
            _managerDao = DaoFactory.GetManagersDao();
        }

        public void Add(ManagersDto artist)
        {
            _managerDao.Add(DtoConvert.Convert(artist));
        }

        public void Delete(int id)
        {
            _managerDao.Delete(id);
        }

        public ManagersDto Get(int id)
        {
            return DtoConvert.Convert(_managerDao.Get(id));
        }

        public IList<ManagersDto> GetList()
        {
            return DtoConvert.Convert(_managerDao.GetAll());
        }

        public IList<ManagersDto> SearchManagers(string codeMachine, string nameEnterprise)
        {
            return DtoConvert.Convert(_managerDao.SearchManagers(codeMachine, nameEnterprise));
        }

        public void Update(ManagersDto manager)
        {
            _managerDao.Update(DtoConvert.Convert(manager));
        }
    }
}
