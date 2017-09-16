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
    /// Логика взаимодействия для AddWageManager.xaml
    /// </summary>
    public partial class AddWageManager : Window
    {
        private IList<ManagersDto> managerGet = ProcessFactory.GetManagersProcess().GetList();

        private int _id;

        public AddWageManager()
        {
            InitializeComponent();

            this.cbManager.ItemsSource = (from a in managerGet orderby a.IDManager select a);

            tbCurrentSum.IsEnabled = false;
            tbSumOrders.IsEnabled = false;
            tbRest.IsEnabled = false;
        }

        public void Load(WageDto wage)
        {
            if (wage == null)
                return;

            this._id = wage.Manager.IDManager;
            tbCurrentSum.Text = wage.CurrentSum.ToString();
            tbSumOrders.Text = wage.SumOrders.ToString();
            tbPaid.Text = wage.Paid.ToString();
            tbRest.Text = wage.Rest.ToString();
           

            foreach (ManagersDto m in managerGet)
            {
                if (m.IDManager == wage.Manager.IDManager)
                {
                    this.cbManager.SelectedItem = m;
                    break;
                }
            }


            if ((wage.Rest == 0) && wage.Paid != 0)
                tbPaid.IsEnabled = false;

            cbManager.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (tbPaid.Text == null)
            {
                tbPaid.BorderBrush = Brushes.Red;
            }
            if (cbManager.Text == null)
            {
                cbManager.BorderBrush = Brushes.Red;
            }
            try
            {
                if (((float)Convert.ToDouble(tbCurrentSum.Text) - (float)Convert.ToDouble(tbPaid.Text)) < 0)
                {
                    MessageBox.Show("Сумма для выплаты не может составлять более " + tbCurrentSum.Text + " рyблей.");
                    return;
                }
            }
            catch 
            {
                return;
            }
            try
                    
            {
                WageDto man = new WageDto();
                man.Manager = cbManager.SelectedItem as ManagersDto;
                man.Paid = (float)Convert.ToDouble(tbPaid.Text);
                man.Rest = (float)Convert.ToDouble(tbCurrentSum.Text) - (float)Convert.ToDouble(tbPaid.Text);
                man.SumOrders = Convert.ToInt32(tbSumOrders.Text);
                man.CurrentSum = (float)Math.Round(Convert.ToDouble(tbCurrentSum.Text), 0);

                IWageProcessDb w = ProcessFactory.GetWageProcess();

                if (_id == 0)
                {
                    w.Add(man);
                }
                else
                {
                    if (man.Rest == 0)
                    {
                        man.Paid = 0;
                        man.CurrentSum = 0;
                    }
                    man.Manager.IDManager = _id;
                    w.Update(man);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            Close();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void tbPercent_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!(e.Key.GetHashCode() == 88) && !(e.Key.GetHashCode() == 145) && !((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
            {
                e.Handled = true;
            }

        }
    }
}
