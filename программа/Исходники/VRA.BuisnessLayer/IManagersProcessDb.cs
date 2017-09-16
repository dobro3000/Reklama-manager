using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public interface IManagersProcessDb
    {
        IList<ManagersDto> GetList();

        ManagersDto Get(int id);

        void Add(ManagersDto artist);

        void Update(ManagersDto artist);

        void Delete(int id);

        IList<ManagersDto> SearchManagers(string codeMachine, string nameEnterprise);
    }
}
