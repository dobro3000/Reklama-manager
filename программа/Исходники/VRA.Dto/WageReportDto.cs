using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    public class WageReportDto
    {
        public int SumOrders { get; set; }
        public float CurrentSum { get; set; }
        public float Paid { get; set; }
        public float Rest { get; set; }
        public string FullNameManager { get; set; }
    }
}
