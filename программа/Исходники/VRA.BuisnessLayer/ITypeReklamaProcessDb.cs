using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public interface ITypeReklamaProcessDb
    {
        IList<TypeReklamaDto> GetList();

        TypeReklamaDto Get(int id);

        void Add(TypeReklamaDto reklama);

        void Update(TypeReklamaDto reklama);

        void Delete(int id);

        IList<TypeReklamaDto> SearchTypeReklama(string tbReklama, string cbCarrier, string tbPos, string tbCost);
    }
}
