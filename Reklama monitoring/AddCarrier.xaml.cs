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
    /// Логика взаимодействия для AddCarrier.xaml
    /// </summary>
    public partial class AddCarrier : Window
    {
        private int _id;


        private static readonly string[] Nationalities = { "День", "Неделя", "Месяц" };

        public AddCarrier()
        {
            InitializeComponent();

            cbDataSet.ItemsSource = Nationalities;
        }

        public void Load(CarrierDto carrier)
        {
            if (carrier == null)
                return;
            _id = carrier.IDCarrier;
            tbNameCarrier.Text = carrier.NameCarrier;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbNameCarrier.Text == "")
            {
                tbNameCarrier.BorderBrush = Brushes.Red;
                return;
            }

            try
            {
                if ((!string.IsNullOrEmpty(tbNameCarrier.Text)))
                {
                    CarrierDto countr = new CarrierDto();
                    countr.NameCarrier = tbNameCarrier.Text;
                    countr.TimeCarrier = cbDataSet.Text;
                    ICarrierProcessDb workProcess = ProcessFactory.GetCarrierProcess();
                    if (_id == 0)
                    {
                        workProcess.Add(countr);
                    }
                    else
                    {
                        countr.IDCarrier = _id;
                        workProcess.Add(countr);
                    }
                }
            }
            catch 
            {
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
