using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public interface IManagersDao 
    {
        Managers Get(int id);
        IList<Managers> GetAll();
        void Add(Managers customer);
        void Update(Managers customer);
        void Delete(int id);
        IList<Managers> SearchManagers(string codeMachine, string mark);
    }
}
