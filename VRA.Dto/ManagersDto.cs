using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Содержить реализацию переменных таблицы Менеджеры.
    /// </summary>
  public  class ManagersDto
    {
        /// <summary>
        /// ИД текущего менеджера.
        /// </summary>
        public int IDManager { get; set; }

        /// <summary>
        /// ФИО текущего менеджера.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Дата начала работы текущего менеджера.
        /// </summary>
        public DateTime StartDateWork { get; set; }

        /// <summary>
        /// Процент с продаж текущего менеджера.
        /// </summary>
        public float PercentOnSale { get; set; }

        /// <summary>
        /// Номер телефона текущего менеджера.
        /// </summary>
        public double Phone { get; set; }

        /// <summary>
        /// Дополнительная информация о текущем менеджере.
        /// </summary>
        public string Note { get; set; }
    }
}
