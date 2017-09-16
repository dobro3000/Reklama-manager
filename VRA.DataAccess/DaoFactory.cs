using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public class DaoFactory
    {
        public static ICarrierDao GetCarrierDao()
        {
            return new CarrierDao();
        }

        public static IDebtPayDao GetDebtPayDao()
        {
            return new DebtPayDao();
        }

        public static IEnterprisesDao GetEnterprisesDao()
        {
            return new EnterprisesDao();
        }

        public static IOrdersDao GetOrdersDao()
        {
            return new OrdersDao();
        }

        public static IManagersDao GetManagersDao()
        {
            return new ManagersDao();
        }

        public static ITypeReklamaDao GetTypeReklamaDao()
        {
            return new TypeReklamaDao();
        }

        public static IWageDao GetWageDao()
        {
            return new WageDao();
        }

        public static SettingsDao GetSettingsDao()
        {
            return new SettingsDao();
        }

        public static IOrdersReportDao GetOrdersReportDao()
        {
            return new OrdersReportDao();
        }
        public static IPraylistDao GetPraylistDao()
        {
            return new PraylistDao();
        }
        public static IWageReportDao GetWageReportDao()
        {
            return new WageReportDao();
        }
    }
}
