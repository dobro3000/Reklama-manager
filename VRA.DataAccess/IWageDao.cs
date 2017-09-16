using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public interface IWageDao
    {
        Wage Get(int id);
        IList<Wage> GetAll();
        void Add(Wage wage);
        void Update(Wage wage);
        void Delete(int id);
        IList<Wage> SearchWage(string codeMachine, string mark);
    }
}
