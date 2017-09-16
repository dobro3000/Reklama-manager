using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Содержит реализацию методов для работы с таблицей Вид рекламы.
    /// </summary>
   public class TypeReklamaDto
    {
        /// <summary>
        /// ИД текущего вида рекламы.
        /// </summary>
        public int IDTypeReklama { get; set; }

        /// <summary>
        /// Название текущего вида рекламы.
        /// </summary>
        public string NameReklama { get; set; }

        /// <summary>
        /// Носитель текущего вида рекламы.
        /// </summary>
        public CarrierDto CarrierForReklama { get; set; }

        /// <summary>
        /// Позиция текущего вида рекламы.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Цена текущего вида рекламы.
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Дополнительная информация к текущему виду рекламы.
        /// </summary>
        public string Note { get; set; }
    }
}
