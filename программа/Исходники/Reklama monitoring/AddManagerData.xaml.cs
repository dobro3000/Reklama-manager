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
    /// Логика взаимодействия для AddManagerData.xaml
    /// </summary>
    public partial class AddManagerData : Window
    {
        private int _id;

        public AddManagerData()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            Thread.CurrentThread.CurrentCulture = ci;

            InitializeComponent();
        }

        public void Load(ManagersDto man)
        {
            if (man == null)
                return;

            this._id = man.IDManager;
            tbFullNameManager.Text = man.FullName.ToString();
            tbPercent.Text = man.PercentOnSale.ToString();
            tbPhone.Text = man.Phone.ToString();
            tbNote.Text = man.Note ?? "";
            dpDate.Text = man.StartDateWork.ToString();

            dpDate.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbFullNameManager.Text == "")
            {
                tbFullNameManager.BorderBrush = Brushes.Red;
            }
            if (tbPercent.Text == "")
            {
                tbPercent.BorderBrush = Brushes.Red;
            }
            if (tbPhone.Text == "")
            {
                tbPhone.BorderBrush = Brushes.Red;
            }
            if (dpDate.Text == "")
            {
                dpDate.BorderBrush = Brushes.Red;
            }
            try
            {
                if (Convert.ToDouble(tbPercent.Text) >= 100)
                {
                    MessageBox.Show("Процент от продаж не можетпревышить 100%.");
                    return;
                }
            }
            catch
            {
                return;
            }

            try
            {
                ManagersDto man = new ManagersDto();
                man.FullName = tbFullNameManager.Text;
                man.Note = tbNote.Text;
                man.PercentOnSale = (float)Convert.ToDouble(tbPercent.Text);
                man.Phone = Convert.ToDouble(tbPhone.Text);
                man.StartDateWork = Convert.ToDateTime(dpDate.Text);

                IManagersProcessDb manager = ProcessFactory.GetManagersProcess();

                if (_id == 0)
                {
                    manager.Add(man);
                }
                else
                {
                    man.IDManager = _id;
                    manager.Update(man);
                }

            }
            catch
            {
                return;
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tbPhone_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
           
            if (!((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
            {
                e.Handled = true;
            }
        }

        private void tbPercent_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!(e.Key.GetHashCode() == 142) && !((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
            {
                e.Handled = true;
            }
           
        }
    }
}
