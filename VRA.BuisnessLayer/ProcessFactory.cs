using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess;

namespace VRA.BuisnessLayer
{
    public class ProcessFactory
    {
        public static ICarrierProcessDb GetCarrierProcess()
        {
            return new CarrierProcessDb();
        }

        public static IDebtProcessDb GetDebtProcess()
        {
            return new DebtProcessDb();
        }

        public static IEnterpriseProcessDb GetEnterpriseProcess()
        {
            return new EnterpriseProcessDb();
        }

        public static IManagersProcessDb GetManagersProcess()
        {
            return new ManagersProcessDb();
        }

        public static IOrdersProcessDb GetOrdersProcess()
        {
            return new OrdersProcessDb();
        }

        public static ITypeReklamaProcessDb GetTypeReklamaProcess()
        {
            return new TypeReklamaProcessDb();
        }
        public static IWageProcessDb GetWageProcess()
        {
            return new WageProcessDb();
        }

        public static ISettingsProcess GetSettingsProcess()
        {
            return new SettingsProcess();
        }

        public static IReportGenerator GetReport()
        {
            return new ReportGenerator();
        }

        public static IPraylistProcess GetPraylistProcess()
        {
            return new PraylistProcess();
        }
        public static IOrdersReportProcess GetOrdersReportProcess()
        {
            return new OrdersReportProcess();
        }
        public static IWageReportProcess GetWageReportProcess()
        {
            return new WageReportProcess();
        }
    }
}
