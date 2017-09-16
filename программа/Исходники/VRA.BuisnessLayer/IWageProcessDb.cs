using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public interface IWageProcessDb
    {
        IList<WageDto> GetList();

        WageDto Get(int id);

        void Add(WageDto wage);

        void Update(WageDto wage);

        void Delete(int id);

        IList<WageDto> SearchWage(string codeMachine, string nameEnterprise);
    }
}
