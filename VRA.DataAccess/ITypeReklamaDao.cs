using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public interface ITypeReklamaDao
    {
        TypeReklama Get(int id);
        IList<TypeReklama> GetAll();
        void Add(TypeReklama customer);
        void Update(TypeReklama customer);
        void Delete(int id);
        IList<TypeReklama> SearchTypeReklama(string tbReklama, string cbCarrier, string tbPos, string tbCost);
    }
}
