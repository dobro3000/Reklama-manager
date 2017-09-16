using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public interface IEnterpriseProcessDb
    {
        IList<EnterprisesDto> GetList();

        EnterprisesDto Get(int id);

        void Add(EnterprisesDto enterprise);

        void Update(EnterprisesDto enterprise);

        void Delete(int id);

        IList<EnterprisesDto> SearchEnterprises(string codeMachine, string nameEnterprise);
    }
}
