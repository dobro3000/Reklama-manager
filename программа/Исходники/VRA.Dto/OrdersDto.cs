using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Содержит реализацию переменных для работы с таблицей Заказы.
    /// </summary>
   public class OrdersDto
    {
        /// <summary>
        /// ИД текущего заказа.
        /// </summary>
        public int IDOrder { get; set; }

        /// <summary>
        /// Информация о менеджере, оформляющего текущий заказ.
        /// </summary>
        public ManagersDto FullNameManager { get; set; }

        /// <summary>
        /// Информация о предприятии, оформляющего текущий заказ.
        /// </summary>
        public EnterprisesDto NameEnterprise { get; set; }

        /// <summary>
        /// Информация о типе рекламы по текущему заказу.
        /// </summary>
        public TypeReklamaDto TypeReklama { get; set; }

        /// <summary>
        /// Цена текущего заказа.
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Дата начала размещения текущего заказа.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания размещения текущего заказа.
        /// </summary>
        public DateTime FinallyDate { get; set; }

        /// <summary>
        /// Оплаченная сумма от текущего заказа.
        /// </summary>
        public float Paid { get; set; }

        /// <summary>
        /// Долг по текущемму заказу.
        /// </summary>
        public float Debt { get; set; }

        public float AllSum { get; set; }
    }
}
