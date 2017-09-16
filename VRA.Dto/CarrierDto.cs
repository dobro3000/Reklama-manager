using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Содержит описание переменных для работы с таблицей Носитель.
    /// </summary>
    public class CarrierDto
    {
        /// <summary>
        /// ИД текущего носителя.
        /// </summary>
        public int IDCarrier { get; set; }

        /// <summary>
        /// Название текущего носителя.
        /// </summary>
        public string NameCarrier { get; set; }

        public string TimeCarrier { get; set; }
    }
}
