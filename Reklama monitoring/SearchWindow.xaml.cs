using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VRA.BuisnessLayer;
using VRA.DataAccess;
using VRA.Dto;

namespace Reklama_monitoring
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        //private readonly IList<CountryDto> AllowCountry = ProcessFactory.GetCountryProcess().GetList();
        //private readonly IList<EnterpriseDto> AllowEnterprise = ProcessFactory.GetEnterpriseProcess().GetList();
        //public IList<TypeMachineDto> FindedTypeMachine;

        //private readonly IList<MachineDto> AllowMachine = ProcessFactory.GetMachinerProcess().GetList();
        //private readonly IList<RepairDto> AllowRepair = ProcessFactory.GetRepairProcess().GetList();
        //private readonly IList<TypeRepairDto> AllowTypeRepair = ProcessFactory.GetTypeRepairProcess().GetList();
        //private readonly IList<TypeMachineDto> AllowTypeMachine = ProcessFactory.GetTypeMachinProcess().GetList();
        private readonly IList<CarrierDto> AllowRepair = ProcessFactory.GetCarrierProcess().Load();
        private readonly IList<TypeReklamaDto> AllowTypeRepair = ProcessFactory.GetTypeReklamaProcess().GetList();
        private readonly IList<ManagersDto> AllowTypeMachine = ProcessFactory.GetManagersProcess().GetList();

        public IList<EnterprisesDto> FindedEnterprise;
        public IList<WageDto> FindedWage;
        public IList<TypeReklamaDto> FindedReklama;
        public IList<OrdersDto> FindedOrders;

        public bool exec;

        public SearchWindow(string status)
        {
            InitializeComponent();

            this.cbCarrier.ItemsSource = (from a in AllowRepair orderby a.NameCarrier select a);
            this.cbManager.ItemsSource = (from a in AllowTypeMachine orderby a.FullName select a); 
            this.cbTypeReklama.ItemsSource = (from a in AllowTypeRepair orderby a.NameReklama select a);

            switch (status)
            {
                case "Enterprises":
                    this.SearchTab.SelectedIndex = 1;
                    this.sOrdeds.Visibility = Visibility.Collapsed;
                    this.sReklama.Visibility = Visibility.Collapsed;
                    break;
                case "TypeReklama":
                    this.SearchTab.SelectedIndex = 0;
                    this.sOrdeds.Visibility = Visibility.Collapsed;
                    this.sEnterprise.Visibility = Visibility.Collapsed;
                    break;
                case "Orders":
                    this.SearchTab.SelectedIndex = 2;
                    this.sEnterprise.Visibility = Visibility.Collapsed;
                    this.sReklama.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchWage(object sender, RoutedEventArgs e)
        {
            //this.FindedMachine = ProcessFactory.GetMachinerProcess().SearchMachine(this.CodeMachine.Text, this.cbNameCountry.Text, this.cbNameEnterprise.Text);
            //this.exec = true;
            //this.Close();
        }

        private void SearchEnterpriseNow(object sender, RoutedEventArgs e)
        {
            this.FindedEnterprise = ProcessFactory.GetEnterpriseProcess().SearchEnterprises(this.tbNameEnterprise.Text, this.tbAddress.Text);
            this.exec = true;
            this.Close();
        }

        private void SearchReklamaNow(object sender, RoutedEventArgs e)
        {
            this.FindedReklama = ProcessFactory.GetTypeReklamaProcess().SearchTypeReklama(this.tbReklama.Text, this.cbCarrier.Text, tbPos.Text, tbCost.Text);
            this.exec = true;
            this.Close();
        }


        private void SearchOrders(object sender, RoutedEventArgs e)
        {
            this.FindedOrders = ProcessFactory.GetOrdersProcess().SearchOrders(this.tbEnterprise.Text, this.cbTypeReklama.Text, this.cbManager.Text);
            this.exec = true;
            this.Close();
            IEnumerable<OrdersDto> AllTrans = ProcessFactory.GetOrdersProcess().GetList();
            if (this.dpStartDate.Text != "")
            {
                IEnumerable<OrdersDto> trans = from I in AllTrans where (I.StartDate == Convert.ToDateTime(this.dpStartDate.Text)) select I;
                this.FindedOrders = trans.ToList();
            }

            this.exec = true;
            this.Close();

        }
    }
}
