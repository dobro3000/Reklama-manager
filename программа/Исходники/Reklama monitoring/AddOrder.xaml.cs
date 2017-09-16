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
using VRA.Dto;
using System.Globalization;
using System.Threading;

namespace Reklama_monitoring
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        private IList<ManagersDto> managerGet = ProcessFactory.GetManagersProcess().GetList();

        private IList<EnterprisesDto> enterpriseGet = ProcessFactory.GetEnterpriseProcess().GetList();

        private IList<TypeReklamaDto> reklamaGet = ProcessFactory.GetTypeReklamaProcess().GetList();

        private int _id;

        public AddOrder()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            Thread.CurrentThread.CurrentCulture = ci;

            InitializeComponent();

            this.cbManager.ItemsSource = (from a in managerGet orderby a.IDManager select a);

            this.cbEnterprise.ItemsSource = (from a in enterpriseGet orderby a.IDEnterprise select a);

            this.cbReklama.ItemsSource = (from a in reklamaGet orderby a.IDTypeReklama select a);

            tbAllSum.IsEnabled = false;
            tbDebt.IsEnabled = false;
        }

        public void Load(OrdersDto order)
        {
            if (order == null)
                return;

            this._id = order.IDOrder;
            dpStartDate.Text = order.StartDate.ToString();
            dpFinallyDate.Text = order.FinallyDate.ToString();
            tbDebt.Text = order.Debt.ToString();
            tbPaid.Text = order.Paid.ToString();
            tbSum.Text = order.Cost.ToString();
            tbAllSum.Text = order.AllSum.ToString();

            foreach (ManagersDto m in managerGet)
            {
                if (m.IDManager == order.FullNameManager.IDManager)
                {
                    this.cbManager.SelectedItem = m;
                    break;
                }
            }

            foreach (EnterprisesDto tr in enterpriseGet)
            {
                if (tr.IDEnterprise == order.NameEnterprise.IDEnterprise)
                {
                    this.cbEnterprise.SelectedItem = tr;
                    break;
                }
            }

            foreach (TypeReklamaDto tr in reklamaGet)
            {
                if (tr.IDTypeReklama == order.TypeReklama.IDTypeReklama)
                {
                    this.cbReklama.SelectedItem = tr;
                    break;
                }
            }

            if( order.Paid >= order.Cost)
            {
                tbPaid.IsEnabled = false;
            }

            cbEnterprise.IsEnabled = false;
            cbManager.IsEnabled = false;
            cbReklama.IsEnabled = false;
            cbEnterprise.IsEnabled = false;
            tbAllSum.IsEnabled = false;
            dpStartDate.IsEnabled = false;
            tbSum.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbPaid.Text == "")
            {
                tbPaid.BorderBrush = Brushes.Red;
            }
            if (tbSum.Text == "")
            {
                tbSum.BorderBrush = Brushes.Red;
            }
            if (dpFinallyDate.Text == "")
            {
                dpFinallyDate.BorderBrush = Brushes.Red;
            }
            if (dpStartDate.Text == "")
            {
                dpStartDate.BorderBrush = Brushes.Red;
            }
            if (cbEnterprise.Text == "")
            {
                cbEnterprise.BorderBrush = Brushes.Red;
            }
            if (cbManager.Text == "")
            {
                cbManager.BorderBrush = Brushes.Red;
            }
            if(cbReklama.Text == "")
            {
                cbReklama.BorderBrush = Brushes.Red;
            }
            try
            {
                if ((Convert.ToDouble(tbAllSum.Text) - Convert.ToDouble(tbPaid.Text) < 0))
                {
                    MessageBox.Show("Цена превышает размер " + tbAllSum.Text + " рублей.");
                    return;
                }
            }
            catch 
            {
                
            }
            try
            {
                if (Convert.ToDateTime(dpStartDate.Text) > Convert.ToDateTime(dpFinallyDate.Text))
                {
                    MessageBox.Show("Дата начала размещения рекламы не должна быть позже даты окончания рекламы.");
                    return;
                }
            }
            catch 
            {
                
            }

            try
            {
                OrdersDto or = new OrdersDto();
                or.Cost = (float)Convert.ToDouble(this.tbSum.Text);
                if (tbPaid.Text == "")
                {
                    or.Paid = 0;
                }
                else
                {
                    or.Paid = (float)Convert.ToDouble(this.tbPaid.Text);
                }
                or.FinallyDate = Convert.ToDateTime(this.dpFinallyDate.Text);
                or.FullNameManager = this.cbManager.SelectedItem as ManagersDto;
                or.NameEnterprise = this.cbEnterprise.SelectedItem as EnterprisesDto;
                or.StartDate = Convert.ToDateTime(this.dpStartDate.Text);
                or.TypeReklama = this.cbReklama.SelectedItem as TypeReklamaDto;
                
                int d1 = IntFromDMY(or.StartDate.Day, or.StartDate.Month, or.StartDate.Year);
                int d2 = IntFromDMY(or.FinallyDate.Day, or.FinallyDate.Month, or.FinallyDate.Year);
                int ddif = d2 - d1;

                if (or.TypeReklama.CarrierForReklama.TimeCarrier == "День")
                {
                    int t = 0;
                    if ((ddif / 30) == 0)
                        t = 1;
                    or.AllSum = (float)Math.Round(or.Cost * (ddif/1), 0);
                }
                else if (or.TypeReklama.CarrierForReklama.TimeCarrier == "Неделя")
                {
                    int t = 0;
                    if ((ddif / 30) == 0)
                        t = 1;
                    or.AllSum = (float)Math.Round(or.Cost * (ddif/7));
                }
                else
                {
                    int t = 0;
                    if ((ddif / 30) == 0)
                        t = 1;
                    or.AllSum = (float)Math.Round(or.Cost * t);
                }

                or.Debt = (float)Convert.ToDouble(or.AllSum) - (float)Convert.ToDouble(this.tbPaid.Text);

                IOrdersProcessDb orProcess = ProcessFactory.GetOrdersProcess();
                IWageProcessDb wageProcess = ProcessFactory.GetWageProcess();

                if (wageProcess.Get(or.FullNameManager.IDManager) == null)
                {

                    WageDto wage = new WageDto();
                    IManagersProcessDb mp = ProcessFactory.GetManagersProcess();
                    ManagersDto manager = mp.Get(or.FullNameManager.IDManager);
                    wage.CurrentSum = or.Cost * manager.PercentOnSale / 100;
                    wage.Manager = or.FullNameManager;
                    wage.Paid = 0;
                    wage.Rest = (float)Math.Abs(Convert.ToDouble(wage.Paid - wage.CurrentSum));
                    wage.SumOrders = 1;

                    wageProcess.Add(wage);

                }
                else
                {
                    IManagersProcessDb mp = ProcessFactory.GetManagersProcess();
                    ManagersDto manager = mp.Get(or.FullNameManager.IDManager);
                    IWageProcessDb wProcess = ProcessFactory.GetWageProcess();

                    WageDto wage = wProcess.Get(or.FullNameManager.IDManager);
                    wage.CurrentSum += or.Cost * manager.PercentOnSale / 100;
                    wage.Rest = (float)Math.Abs(Convert.ToDouble( wage.Paid - wage.CurrentSum));
                    wage.SumOrders += 1;

                    wageProcess.Update(wage);
                }

                if (_id == 0)
                {
                    orProcess.Add(or);
                }
                else
                {
                    or.IDOrder = _id;
                    orProcess.Update(or);
                }
            }
            catch (Exception exc)
            {
                return;
            }
            
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbPercent_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!(e.Key.GetHashCode() == 142) && !(e.Key.GetHashCode() == 88) && !((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
            {
                e.Handled = true;
            }
        }

        public int IntFromDMY(int day, int month, int year)
        {
            int m = (month - 14) / 12;
            return ((1461 * (year + 4800 + m)) / 4 + (367 * (month - 2 - 12 * m)) / 12 - (3 * ((year + 4900 + m) / 100)) / 4 + day - 32075) - 1757585;
        }

    }
}
