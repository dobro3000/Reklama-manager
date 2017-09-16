using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public class OrdersReport
    {
        public string NameCarrier { get; set; }

        public string NameReklama { get; set; }

        public string NameEnterprise { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinallyDate { get; set; }

        public float Cost { get; set; }

        public float AllSum { get; set; }
    }
}
