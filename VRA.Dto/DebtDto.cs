using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Содержит реализацию переменных для работы с талицей Должники.
    /// </summary>
    public class DebtDto
    {
        /// <summary>
        /// Информация о текущем предприятии.
        /// </summary>
        public string NameEnterprise { get; set; }

        /// <summary>
        /// Сумма всех заказов текущего предприятия.
        /// </summary>
        public string Representative { get; set; }

        /// <summary>
        /// Сумма всех оплат текущего предприятия.
        /// </summary>
        public float Phone { get; set; }

        /// <summary>
        /// Долги по оплате текущего предприятия.
        /// </summary>
        public float Debt { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinnalyDate { get; set; }


    }
}
