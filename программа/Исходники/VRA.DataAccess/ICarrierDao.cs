using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public interface ICarrierDao
    {
        List<Carrier> Load();
        
        void Add(Carrier customer);
       
        void Delete(int id);

        Carrier Get(int id);
    }
}
