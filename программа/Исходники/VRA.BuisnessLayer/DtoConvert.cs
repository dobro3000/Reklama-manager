using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess;
using VRA.Dto;

namespace VRA.BuisnessLayer
{
    public class DtoConvert
    {

        #region Carrier

        public static CarrierDto Convert(Carrier carrier)
        {
            if (carrier == null) return null;
            CarrierDto carrierDto = new CarrierDto();
            carrierDto.IDCarrier = carrier.IDCarrier;
            carrierDto.NameCarrier = carrier.NameCarrier;
            carrierDto.TimeCarrier = carrier.TimeCarrier;
            return carrierDto;
        }

        public static Carrier Convert(CarrierDto carrierDto)
        {
            if (carrierDto == null) return null;
            Carrier carrier = new Carrier();
            carrier.IDCarrier = carrierDto.IDCarrier;
            carrier.NameCarrier = carrierDto.NameCarrier;
            carrier.TimeCarrier = carrierDto.TimeCarrier;
            return carrier;
        }

        internal static IList<CarrierDto> Convert(IList<Carrier> carrier)
        {
            var carries = new List<CarrierDto>();
            foreach (var con in carrier)
            {
                carries.Add(Convert(con));
            }
            return carries;
        }

        #endregion

        #region Enterprise

        public static EnterprisesDto Convert(Enterprises enterprise)
        {
            if (enterprise == null) return null;
            EnterprisesDto enterpriseDto = new EnterprisesDto();
            enterpriseDto.Address = enterprise.Address;
            enterpriseDto.Email = enterprise.Email;
            enterpriseDto.IDEnterprise = enterprise.IDEnterprise;
            enterpriseDto.NameEnterprise = enterprise.NameEnterprise;
            enterpriseDto.Note = enterprise.Note;
            enterpriseDto.Phone = enterprise.Phone;
            enterpriseDto.Representative = enterprise.Representative;
            return enterpriseDto;
        }

        public static Enterprises Convert(EnterprisesDto enterpriseDto)
        {
            if (enterpriseDto == null) return null;
            Enterprises enterprise = new Enterprises();
            enterprise.Address = enterpriseDto.Address;
            enterprise.Email = enterpriseDto.Email;
            enterprise.IDEnterprise = enterpriseDto.IDEnterprise;
            enterprise.NameEnterprise = enterpriseDto.NameEnterprise;
            enterprise.Note = enterpriseDto.Note;
            enterprise.Phone = enterpriseDto.Phone;
            enterprise.Representative = enterpriseDto.Representative;
            return enterprise;
        }

        internal static IList<EnterprisesDto> Convert(IList<Enterprises> enterprise)
        {
            var enterprises = new List<EnterprisesDto>();
            foreach (var con in enterprise)
            {
                enterprises.Add(Convert(con));
            }
            return enterprises;
        }

        #endregion

        #region Debt

        public static DebtDto Convert(DebtPay debt)
        {
            if (debt == null) return null;
            DebtDto debtDto = new DebtDto();
            debtDto.Debt = debt.Debt;
            debtDto.FinnalyDate = debt.FinnalyDate;
            debtDto.NameEnterprise = debt.NameEnterprise;
            debtDto.Phone = debt.Phone;
            debtDto.Representative = debt.Representative;
            debtDto.StartDate = debt.StartDate;
            return debtDto;
        }

        public static DebtPay Convert(DebtDto debt)
        {
            if (debt == null) return null;
            DebtPay debtDto = new DebtPay();
            debtDto.Debt = debt.Debt;
            debtDto.FinnalyDate = debt.FinnalyDate;
            debtDto.NameEnterprise = debt.NameEnterprise;
            debtDto.Phone = debt.Phone;
            debtDto.Representative = debt.Representative;
            debtDto.StartDate = debt.StartDate;
            return debtDto;
        }

        public static IList<DebtDto> Convert(IList<DebtPay> debt)
        {
            if (debt == null) return null;
            IList<DebtDto> depts = new List<DebtDto>();
            foreach (var con in debt)
            {
                depts.Add(Convert(con));
            }
            return depts;
        }

        #endregion

        #region Managers

        public static ManagersDto Convert(Managers manager)
        {
            if (manager == null) return null;
            ManagersDto managerDto = new ManagersDto();
            managerDto.FullName = manager.FullName;
            managerDto.IDManager = manager.IDManager;
            managerDto.Note = manager.Note;
            managerDto.PercentOnSale = manager.PercentOnSale;
            managerDto.Phone = manager.Phone;
            managerDto.StartDateWork = manager.StartDateWork;
            return managerDto;
        }

        public static Managers Convert(ManagersDto managerDto)
        {
            if (managerDto == null) return null;
            Managers manager = new Managers();
            manager.FullName = managerDto.FullName;
            manager.IDManager = managerDto.IDManager;
            manager.Note = managerDto.Note;
            manager.PercentOnSale = managerDto.PercentOnSale;
            manager.Phone = managerDto.Phone;
            manager.StartDateWork = managerDto.StartDateWork;
            return manager;
        }

        public static IList<ManagersDto> Convert(IList<Managers> manager)
        {
            if (manager == null) return null;
            IList<ManagersDto> man = new List<ManagersDto>();
            foreach (var con in manager)
            {
                man.Add(Convert(con));
            }
            return man;
        }

        #endregion

        #region Orders

        public static OrdersDto Convert(Orders orders)
        {
            if (orders == null) return null;
            OrdersDto ordersDto = new OrdersDto();
            ordersDto.Cost = orders.Cost;
            ordersDto.Debt = orders.Debt;
            ordersDto.AllSum = orders.AllSum;
            ordersDto.FinallyDate = orders.FinallyDate;
            ordersDto.FullNameManager = Convert(DaoFactory.GetManagersDao().Get(orders.FullNameManager));
            ordersDto.IDOrder = orders.IDOrder;
            ordersDto.NameEnterprise = Convert(DaoFactory.GetEnterprisesDao().Get(orders.NameEnterprise));
            ordersDto.Paid = orders.Paid;
            ordersDto.StartDate = orders.StartDate;
            ordersDto.TypeReklama = Convert(DaoFactory.GetTypeReklamaDao().Get(orders.TypeReklama));
            return ordersDto;
        }

        public static Orders Convert(OrdersDto ordersDto)
        {
            if (ordersDto == null) return null;
            Orders orders = new Orders();
            orders.Cost = ordersDto.Cost;
            orders.Debt = ordersDto.Debt;
            orders.AllSum = ordersDto.AllSum;
            orders.FinallyDate = ordersDto.FinallyDate;
            orders.FullNameManager = ordersDto.FullNameManager.IDManager;
            orders.IDOrder = ordersDto.IDOrder;
            orders.NameEnterprise = ordersDto.NameEnterprise.IDEnterprise;
            orders.Paid = ordersDto.Paid;
            orders.StartDate = ordersDto.StartDate;
            orders.TypeReklama = ordersDto.TypeReklama.IDTypeReklama;
            return orders;
        }

        public static IList<OrdersDto> Convert(IList<Orders> order)
        {
            if (order == null) return null;
            IList<OrdersDto> orderDto = new List<OrdersDto>();
            foreach (var con in order)
            {
                orderDto.Add(Convert(con));
            }
            return orderDto;
        }

        #endregion

        #region Type Reklama

        public static TypeReklamaDto Convert(TypeReklama reklama)
        {
            if (reklama == null) return null;
            TypeReklamaDto reklamaDto = new TypeReklamaDto();
            reklamaDto.CarrierForReklama = Convert(DaoFactory.GetCarrierDao().Get(reklama.CarrierForReklama));
            reklamaDto.Cost = reklama.Cost;
            reklamaDto.IDTypeReklama = reklama.IDTypeReklama;
            reklamaDto.NameReklama = reklama.NameReklama;
            reklamaDto.Note = reklama.Note;
            reklamaDto.Position = reklama.Position;
            return reklamaDto;
        }

        public static TypeReklama Convert(TypeReklamaDto reklamaDto)
        {
            if (reklamaDto == null) return null;
            TypeReklama reklama = new TypeReklama();
            reklama.CarrierForReklama = reklamaDto.CarrierForReklama.IDCarrier;
            reklama.Cost = reklamaDto.Cost;
            reklama.IDTypeReklama = reklamaDto.IDTypeReklama;
            reklama.NameReklama = reklamaDto.NameReklama;
            reklama.Note = reklamaDto.Note;
            reklama.Position = reklamaDto.Position;
            return reklama;
        }

        public static IList<TypeReklamaDto> Convert(IList<TypeReklama> reklama)
        {
            if (reklama == null) return null;
            IList<TypeReklamaDto> reklamaDto = new List<TypeReklamaDto>();
            foreach (var con in reklama)
            {
                reklamaDto.Add(Convert(con));
            }
            return reklamaDto;
        }

        #endregion

        #region Wage

        public static WageDto Convert(Wage country)
        {
            if (country == null) return null;
            WageDto countryDto = new WageDto();
            countryDto.CurrentSum = country.CurrentSum;
            countryDto.IDWage = country.IDWage;
            countryDto.Manager = Convert(DaoFactory.GetManagersDao().Get(country.Manager));
            countryDto.Paid = country.Paid;
            countryDto.Rest = country.Rest;
            countryDto.SumOrders = country.SumOrders;
            return countryDto;
        }

        public static Wage Convert(WageDto wageDto)
        {
            if (wageDto == null) return null;
            Wage country = new Wage();
            country.CurrentSum = wageDto.CurrentSum;
            country.IDWage = wageDto.IDWage;
            country.Manager = wageDto.Manager.IDManager;
            country.Paid = wageDto.Paid;
            country.Rest = wageDto.Rest;
            country.SumOrders = wageDto.SumOrders;
            return country;
        }

        internal static IList<WageDto> Convert(IList<Wage> wage)
        {
            var wages = new List<WageDto>();
            foreach (var con in wage)
            {
                wages.Add(Convert(con));
            }
            return wages;
        }


        #endregion

        #region OrdersReport

        public static OrdersReportDto Convert(OrdersReport debt)
        {
            if (debt == null) return null;
            OrdersReportDto debtDto = new OrdersReportDto();
            debtDto.Cost = debt.Cost;
            debtDto.FinallyDate = debt.FinallyDate;
            debtDto.NameCarrier = debt.NameCarrier;
            debtDto.NameEnterprise = debt.NameEnterprise;
            debtDto.NameReklama = debt.NameReklama;
            debtDto.StartDate = debt.StartDate;
            debtDto.AllSum = debt.AllSum;

            return debtDto;
        }

        public static OrdersReport Convert(OrdersReportDto debtDto)
        {
            if (debtDto == null) return null;
            OrdersReport debt = new OrdersReport();
            debtDto.Cost = debt.Cost;
            debtDto.FinallyDate = debt.FinallyDate;
            debtDto.NameCarrier = debt.NameCarrier;
            debtDto.NameEnterprise = debt.NameEnterprise;
            debtDto.NameReklama = debt.NameReklama;
            debtDto.StartDate = debt.StartDate;
            debtDto.AllSum = debt.AllSum;
            return debt;
        }

        public static IList<OrdersReportDto> Convert(IList<OrdersReport> debt)
        {
            if (debt == null) return null;
            IList<OrdersReportDto> depts = new List<OrdersReportDto>();
            foreach (var con in debt)
            {
                depts.Add(Convert(con));
            }
            return depts;
        }

        #endregion

        #region Praylist

        public static PraylistDto Convert(Praylist debt)
        {
            if (debt == null) return null;
            PraylistDto debtDto = new PraylistDto();
            debtDto.Cost = debt.Cost;
            debtDto.NameCarrier = debt.NameCarrier;
            debtDto.Position = debt.Position;
            debtDto.NameReklama = debt.NameReklama;
            return debtDto;
        }

        public static Praylist Convert(PraylistDto debt)
        {
            if (debt == null) return null;
            Praylist debtDto = new Praylist();
            debtDto.Cost = debt.Cost;
            debtDto.NameCarrier = debt.NameCarrier;
            debtDto.Position = debt.Position;
            debtDto.NameReklama = debt.NameReklama;
            return debtDto;
        }

        public static IList<PraylistDto> Convert(IList<Praylist> debt)
        {
            if (debt == null) return null;
            IList<PraylistDto> depts = new List<PraylistDto>();
            foreach (var con in debt)
            {
                depts.Add(Convert(con));
            }
            return depts;
        }

        #endregion

        #region WageReport

        public static WageReportDto Convert(WageReport debt)
        {
            if (debt == null) return null;
            WageReportDto debtDto = new WageReportDto();
            debtDto.CurrentSum = debt.CurrentSum;
            debtDto.FullNameManager = debt.FullNameManager;
            debtDto.Paid = debt.Paid;
            debtDto.Rest = debt.Rest;
            debtDto.SumOrders = debt.SumOrders;
            return debtDto;
        }

        public static WageReport Convert(WageReportDto debtDto)
        {
            if (debtDto == null) return null;
            WageReport debt = new WageReport();
            debtDto.CurrentSum = debt.CurrentSum;
            debtDto.FullNameManager = debt.FullNameManager;
            debtDto.Paid = debt.Paid;
            debtDto.Rest = debt.Rest;
            debtDto.SumOrders = debt.SumOrders;
            return debt;
        }

        public static IList<WageReportDto> Convert(IList<WageReport> debt)
        {
            if (debt == null) return null;
            IList<WageReportDto> depts = new List<WageReportDto>();
            foreach (var con in debt)
            {
                depts.Add(Convert(con));
            }
            return depts;
        }


        #endregion

    }
}
