using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public class CarrierProcessDb : ICarrierProcessDb
    {
        private readonly ICarrierDao _carrierDao;

        public CarrierProcessDb()
        {
            _carrierDao = DaoFactory.GetCarrierDao();
        }

        public void Add(CarrierDto carrier)
        {
            _carrierDao.Add(DtoConvert.Convert(carrier));
        }

        public void Delete(int id)
        {
            _carrierDao.Delete(id);
        }

        public IList<CarrierDto> Load()
        {
            return DtoConvert.Convert(_carrierDao.Load());
        }

        public Carrier Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
