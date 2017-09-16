using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VRA.BuisnessLayer
{
    public interface IReportGenerator
    {
        void fillExcelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile);
        string genHtmlInfoRepairs(string rep);
        string genHtmlPraylist(string rep);
        string genHtmlOrdersReport(string rep);
        string genHtmlWageReport(string rep);
        string genHtmlRating();
        string genHtmlDataDebt(string rep);
    }
}
