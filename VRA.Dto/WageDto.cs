using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Содержит описание переменных для работы таблицей Заработная плата.
    /// </summary>
   public class WageDto
    {
        /// <summary>
        /// ИД текущей з/п.
        /// </summary>
        public int IDWage { get; set; }

        /// <summary>
        /// Информация о текущем менеджеру.
        /// </summary>
        public ManagersDto Manager { get; set; }

        /// <summary>
        /// Сумма оформленных заказов текущим менеджером.
        /// </summary>
        public int? SumOrders { get; set; }

        /// <summary>
        /// Заработанная сумма текущим менеджером.
        /// </summary>
        public float? CurrentSum { get; set; }

        /// <summary>
        /// Выплаченная сумма текущему менеджеру.
        /// </summary>
        public float? Paid { get; set; }

        /// <summary>
        /// Невыплаченная сумма текущему менеджеру.
        /// </summary>
        public float? Rest { get; set; }
    }
}
