using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public class TypeReklamaProcessDb : ITypeReklamaProcessDb
    {
        private readonly ITypeReklamaDao _reklamaDao;

        public TypeReklamaProcessDb()
        {
            _reklamaDao = DaoFactory.GetTypeReklamaDao();
        }

        public void Add(TypeReklamaDto reklama)
        {
            _reklamaDao.Add(DtoConvert.Convert(reklama));
        }

        public void Delete(int id)
        {
            _reklamaDao.Delete(id);
        }

        public TypeReklamaDto Get(int id)
        {
            return DtoConvert.Convert(_reklamaDao.Get(id));
        }

        public IList<TypeReklamaDto> GetList()
        {
            return DtoConvert.Convert(_reklamaDao.GetAll());
        }

        public IList<TypeReklamaDto> SearchTypeReklama(string tbReklama, string cbCarrier, string tbPos, string tbCost)
        {
            return DtoConvert.Convert(_reklamaDao.SearchTypeReklama( tbReklama,  cbCarrier,  tbPos,  tbCost));
        }

        public void Update(TypeReklamaDto reklama)
        {
            _reklamaDao.Update(DtoConvert.Convert(reklama));
        }
    }
}
