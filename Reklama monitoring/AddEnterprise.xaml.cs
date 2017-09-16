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

namespace Reklama_monitoring
{
    /// <summary>
    /// Логика взаимодействия для AddEnterprise.xaml
    /// </summary>
    public partial class AddEnterprise : Window
    {
        private int _id;

        public AddEnterprise()
        {
            InitializeComponent();
        }

        public void Load(EnterprisesDto enterprise)
        {
            if (enterprise == null)
                return;

            _id = enterprise.IDEnterprise;
            tbAddress.Text = enterprise.Address.ToString();
            tbEmail.Text = enterprise.Email.ToString();
            tbNameEnterprise.Text = enterprise.NameEnterprise.ToString();
            tbPhone.Text = enterprise.Phone.ToString();
            tbRepresent.Text = enterprise.Representative.ToString();
            tbNote.Text = enterprise.Note.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbAddress.Text == "")
            {
                tbAddress.BorderBrush = Brushes.Red;
            }
            if (tbNameEnterprise.Text == "")
            {
                tbNameEnterprise.BorderBrush = Brushes.Red;
            }
            if (tbPhone.Text == "")
            {
                tbPhone.BorderBrush = Brushes.Red;
            }
            if (tbRepresent.Text == "")
            {
                tbRepresent.BorderBrush = Brushes.Red;
            }
            try
            {
                EnterprisesDto enter = new EnterprisesDto();
                enter.Address = tbAddress.Text;
                enter.Email = tbEmail.Text;
                enter.NameEnterprise = tbNameEnterprise.Text;
                enter.Note = tbNote.Text;
                enter.Phone = Convert.ToDouble(tbPhone.Text);
                enter.Representative = tbRepresent.Text;
                IEnterpriseProcessDb enterProcess = ProcessFactory.GetEnterpriseProcess();

                if (_id == 0)
                {
                    enterProcess.Add(enter);
                }
                else
                {
                    enter.IDEnterprise = _id;
                    enterProcess.Update(enter);
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

        private void tbPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
            {
                e.Handled = true;
            }
        }
    }
}
