using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public interface ICarrierProcessDb
    {
        IList<CarrierDto> Load();

        void Add(CarrierDto carrier);

        void Delete(int id);

        Carrier Get(int id);
    }
}
