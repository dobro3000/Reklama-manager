using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public interface IEnterprisesDao
    {
        Enterprises Get(int id);
        IList<Enterprises> GetAll();
        void Add(Enterprises customer);
        void Update(Enterprises customer);
        void Delete(int id);
        IList<Enterprises> SearchEnterprises(string codeMachine, string mark);
    }
}
