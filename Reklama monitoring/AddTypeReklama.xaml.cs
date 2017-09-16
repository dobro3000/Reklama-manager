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
    /// Логика взаимодействия для AddTypeReklama.xaml
    /// </summary>
    public partial class AddTypeReklama : Window
    {
        private IList<CarrierDto> carrier = ProcessFactory.GetCarrierProcess().Load();

        private int _id;

        public AddTypeReklama()
        {
            InitializeComponent();

            this.cbCarrier.ItemsSource = (from a in carrier orderby a.IDCarrier select a);
        }

        public void Load(TypeReklamaDto reklama)
        {
            if (reklama == null)
                return;
            this._id = reklama.IDTypeReklama;
            tbCost.Text = reklama.Cost.ToString();
            tbNameReklama.Text = reklama.NameReklama.ToString();
            tbNote.Text = reklama.Note;
            tbPosition.Text = reklama.Position;

            foreach (CarrierDto c in carrier)
            {
                if( c.IDCarrier == reklama.CarrierForReklama.IDCarrier)
                {
                    this.cbCarrier.SelectedItem = c;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbCost.Text == "")
            {
                tbCost.BorderBrush = Brushes.Red;
            }
            if (tbNameReklama.Text == "")
            {
                tbNameReklama.BorderBrush = Brushes.Red;
            }
            if (tbPosition.Text == "")
            {
                tbPosition.BorderBrush = Brushes.Red;
            }
            if (cbCarrier.Text == "")
            {
                cbCarrier.BorderBrush = Brushes.Red;
            }


            try
            {
                TypeReklamaDto treklama = new TypeReklamaDto();
                treklama.CarrierForReklama = cbCarrier.SelectedItem as CarrierDto;
                treklama.Cost = (float)Convert.ToDouble(tbCost.Text);
                treklama.NameReklama = tbNameReklama.Text;
                treklama.Note = tbNote.Text;
                treklama.Position = tbPosition.Text;
                ITypeReklamaProcessDb tr = ProcessFactory.GetTypeReklamaProcess();

                if (_id == 0)
                {
                    tr.Add(treklama);
                }
                else
                {
                    treklama.IDTypeReklama = _id;
                    tr.Update(treklama);
                }
            }
            catch 
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
            if (!(e.Key.GetHashCode() == 142)  && !((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
            {
                e.Handled = true;
            }

        }
    }
}
