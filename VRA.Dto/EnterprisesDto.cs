using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Содержить реализацию переменных для работы с таблицей Предприятия.
    /// </summary>
   public class EnterprisesDto
    {
        /// <summary>
        /// ИД текущего предприятия.
        /// </summary>
        public int IDEnterprise { get; set; }

        /// <summary>
        /// Название текущего предприятия.
        /// </summary>
        public string NameEnterprise { get; set; }

        /// <summary>
        /// ФИО представителя текущего предприятия.
        /// </summary>
        public string Representative { get; set; }

        /// <summary>
        /// Номер телефона текущего предприятия или номер представителя.
        /// </summary>
        public double Phone { get; set; }

        /// <summary>
        /// Адрес текущего предприятия.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// E-mail текущего предприятия или представителя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Дополнительная информация о текущем предприятии.
        /// </summary>
        public string Note { get; set; }
    }
}
