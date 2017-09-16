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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VRA.BuisnessLayer;
using VRA.DataAccess;
using VRA.Dto;
using System.IO;

namespace Reklama_monitoring
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                btnOrders_Click(null,null);
            }
            catch { MessageBox.Show("Подключение к базе данных отсутсвует!"); }
        }

        private string status; //Устанавливает, с какой таблицей в текущий момент работает пользователь 

        #region Menu strip

        private void btnDatabase_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();

        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountConnect window = new AccountConnect();
            window.ShowDialog();

           if(window.connect == true)
            {
                btnTypeCarrier.Visibility = Visibility.Visible;
                btnManagers.Visibility = Visibility.Visible;
                btnTypeReklama.Visibility = Visibility.Visible;
                btnSalaryCalculatoin.Visibility = Visibility.Visible;
                btnWage.Visibility = Visibility.Visible;
                btnDebtor.Visibility = Visibility.Visible;
                btnOrder.Visibility = Visibility.Visible;
            }
            btnManagers_Click(sender, e);
            Exit.Visibility = Visibility.Visible;
            Exit.HorizontalAlignment = HorizontalAlignment.Right;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
                btnTypeCarrier.Visibility = Visibility.Collapsed;
                btnManagers.Visibility = Visibility.Collapsed;
                btnTypeReklama.Visibility = Visibility.Collapsed;
                btnSalaryCalculatoin.Visibility = Visibility.Collapsed;
                btnWage.Visibility = Visibility.Collapsed;
                btnDebtor.Visibility = Visibility.Collapsed;
                btnOrder.Visibility = Visibility.Collapsed;
                Exit.Visibility = Visibility.Hidden;

            btnOrders_Click(sender, e);
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutThisProgram atp = new AboutThisProgram();
            atp.ShowDialog();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("readme.docx");
            }
            catch
            {

            }
        }

        #endregion

        #region Table

        private void btnManagers_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                //case "Managers": this.dgManagers.Visibility = Visibility.Hidden; break;
                case "Enterprises": this.dgEnterprises.Visibility = Visibility.Hidden; break;
                case "TypeReklama": this.dgReklama.Visibility = Visibility.Hidden; break;
                case "Orders": this.dgOrders.Visibility = Visibility.Hidden; break;
                case "Carrier": this.dgCarrier.Visibility = Visibility.Hidden; break;
                case "Wage": this.dgWage.Visibility = Visibility.Hidden; break;
               // case "Debt": this.dgDebt.Visibility = Visibility.Hidden; break;
            }
            this.dgManagers.Visibility = Visibility.Visible;
            status = "Managers";
            this.btnUpdateM_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Менеджеры";
            //this.btnAdd.Visibility = Visibility.Visible;
            //this.btnEdit.Visibility = Visibility.Collapsed;
            //this.btnDelete.Visibility = Visibility.Visible;
            //this.btnUpdate.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Collapsed;
        }

        private void btnEnterprises_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Managers": this.dgManagers.Visibility = Visibility.Hidden; break;
                //case "Enterprises": this.dgEnterprises.Visibility = Visibility.Hidden; break;
                case "TypeReklama": this.dgReklama.Visibility = Visibility.Hidden; break;
                case "Orders": this.dgOrders.Visibility = Visibility.Hidden; break;
                case "Carrier": this.dgCarrier.Visibility = Visibility.Hidden; break;
                case "Wage": this.dgWage.Visibility = Visibility.Hidden; break;
                //case "Debt": this.dgDebt.Visibility = Visibility.Hidden; break;
            }
            this.dgEnterprises.Visibility = Visibility.Visible;
            status = "Enterprises";
            this.btnUpdateE_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Предприятие";
            //this.btnAdd.Visibility = Visibility.Visible;
            //this.btnEdit.Visibility = Visibility.Collapsed;
            //this.btnDelete.Visibility = Visibility.Visible;
            //this.btnUpdate.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Managers": this.dgManagers.Visibility = Visibility.Hidden; break;
                case "Enterprises": this.dgEnterprises.Visibility = Visibility.Hidden; break;
                case "TypeReklama": this.dgReklama.Visibility = Visibility.Hidden; break;
                //case "Orders": this.dgOrders.Visibility = Visibility.Hidden; break;
                case "Carrier": this.dgCarrier.Visibility = Visibility.Hidden; break;
                case "Wage": this.dgWage.Visibility = Visibility.Hidden; break;
                //case "Debt": this.dgDebt.Visibility = Visibility.Hidden; break;
            }
            this.dgOrders.Visibility = Visibility.Visible;
            status = "Orders";
            this.btnUpdateO_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Заказы";
            //this.btnAdd.Visibility = Visibility.Visible;
            //this.btnEdit.Visibility = Visibility.Collapsed;
            //this.btnDelete.Visibility = Visibility.Visible;
            //this.btnUpdate.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnTypeReklama_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Managers": this.dgManagers.Visibility = Visibility.Hidden; break;
                case "Enterprises": this.dgEnterprises.Visibility = Visibility.Hidden; break;
                //case "TypeReklama": this.dgReklama.Visibility = Visibility.Hidden; break;
                case "Orders": this.dgOrders.Visibility = Visibility.Hidden; break;
                case "Carrier": this.dgCarrier.Visibility = Visibility.Hidden; break;
                case "Wage": this.dgWage.Visibility = Visibility.Hidden; break;
               // case "Debt": this.dgDebt.Visibility = Visibility.Hidden; break;
            }
            this.dgReklama.Visibility = Visibility.Visible;
            status = "TypeReklama";
            this.btnUpdateTR_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Вид рекламы";
            //this.btnAdd.Visibility = Visibility.Visible;
            //this.btnEdit.Visibility = Visibility.Collapsed;
            //this.btnDelete.Visibility = Visibility.Visible;
            //this.btnUpdate.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnTypeCarrier_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Managers": this.dgManagers.Visibility = Visibility.Hidden; break;
                case "Enterprises": this.dgEnterprises.Visibility = Visibility.Hidden; break;
                case "TypeReklama": this.dgReklama.Visibility = Visibility.Hidden; break;
                case "Orders": this.dgOrders.Visibility = Visibility.Hidden; break;
                case "Carrier": this.dgCarrier.Visibility = Visibility.Hidden; break;
                case "Wage": this.dgWage.Visibility = Visibility.Hidden; break;
                //case "Debt": this.dgDebt.Visibility = Visibility.Hidden; break;
            }
            this.dgCarrier.Visibility = Visibility.Visible;
            status = "Carrier";
            this.btnUpdateTC_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Носитель";
            //this.btnAdd.Visibility = Visibility.Visible;
            //this.btnEdit.Visibility = Visibility.Collapsed;
            //this.btnDelete.Visibility = Visibility.Visible;
            //this.btnUpdate.Visibility = Visibility.Hidden;
            this.btnSearch.Visibility = Visibility.Collapsed;
        }

        private void btnSalaryCalculatoin_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Managers": this.dgManagers.Visibility = Visibility.Hidden; break;
                case "Enterprises": this.dgEnterprises.Visibility = Visibility.Hidden; break;
                case "TypeReklama": this.dgReklama.Visibility = Visibility.Hidden; break;
                case "Orders": this.dgOrders.Visibility = Visibility.Hidden; break;
                case "Carrier": this.dgCarrier.Visibility = Visibility.Hidden; break;
                //case "Wage": this.dgWage.Visibility = Visibility.Hidden; break;
                //case "Debt": this.dgDebt.Visibility = Visibility.Hidden; break;
            }
            this.dgWage.Visibility = Visibility.Visible;
            status = "Wage";
            this.btnUpdateW_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Заработная плата";
            //this.btnAdd.Visibility = Visibility.Visible;
            //this.btnEdit.Visibility = Visibility.Collapsed;
            //this.btnDelete.Visibility = Visibility.Visible;
            //this.btnUpdate.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Hidden;
        }

        private void btnPaymentForService_Click(object sender, RoutedEventArgs e)
        {
            //switch (status)
            //{
            //    case "Managers": this.dgManagers.Visibility = Visibility.Hidden; break;
            //    case "Enterprises": this.dgEnterprises.Visibility = Visibility.Hidden; break;
            //    case "TypeReklama": this.dgReklama.Visibility = Visibility.Hidden; break;
            //    case "Orders": this.dgOrders.Visibility = Visibility.Hidden; break;
            //    case "Carrier": this.dgCarrier.Visibility = Visibility.Hidden; break;
            //    case "Wage": this.dgWage.Visibility = Visibility.Hidden; break;
            //    //case "Debt": this.dgDebt.Visibility = Visibility.Hidden; break;
            //}
            //this.dgDebt.Visibility = Visibility.Visible;
            //status = "Debt";
            //this.btnUpdateDebt_Click(sender, e);
            //this.statusLabel.Content = "Работа с таблицей: Оплата услуг";
            ////this.btnAdd.Visibility = Visibility.Visible;
            ////this.btnEdit.Visibility = Visibility.Collapsed;
            ////this.btnDelete.Visibility = Visibility.Visible;
            ////this.btnUpdate.Visibility = Visibility.Visible;
            ////this.btnShearc.Visibility = Visibility.Collapsed;
        }


        #endregion

        #region Left menu


        private void btnDataDebtList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rep;
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog
                {
                    DefaultExt = ".vrt",
                    Filter = "View Ridge Assistant Template files|*.vrt"
                };
                bool? result = true;
                if (result == true)
                {
                    StreamReader sr = new StreamReader("vra.vrt.txt");
                    rep = sr.ReadToEnd();
                    sr.Close();
                }
                else
                {
                    return;
                }
                string full_rep = ProcessFactory.GetReport().genHtmlDataDebt(rep);
                System.Windows.Forms.SaveFileDialog sdlg = new System.Windows.Forms.SaveFileDialog
                {
                    DefaultExt = ".html",
                    Filter = "Html Documents (.html)|*.html"
                };
                if (Convert.ToBoolean(sdlg.ShowDialog()) == true)
                {
                    string filename = sdlg.FileName;
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine(full_rep);
                    sw.Close();
                    System.Diagnostics.Process.Start(filename);
                }
            }
            catch (Exception exc)
            {

            }
        }

        private void btnImportExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<object> grid = null;

                switch (status)
                {
                    case "Managers": grid = this.dgManagers.ItemsSource.Cast<object>().ToList(); break;
                    case "Enterprises": grid = this.dgEnterprises.ItemsSource.Cast<object>().ToList(); break;
                    case "TypeReklama": grid = this.dgReklama.ItemsSource.Cast<object>().ToList(); break;
                    case "Orders": grid = this.dgOrders.ItemsSource.Cast<object>().ToList(); break;
                    case "Carrier": grid = this.dgCarrier.ItemsSource.Cast<object>().ToList(); break;
                    case "Wage": grid = this.dgWage.ItemsSource.Cast<object>().ToList(); break;
                }

                System.Windows.Forms.SaveFileDialog saveXlsxDialog = new System.Windows.Forms.SaveFileDialog
                {
                    DefaultExt = ".xlsx",
                    Filter = "Excel Files(.xlsx) | *.xlsx",
                    AddExtension = true,
                    FileName = status
                };

                bool? result = Convert.ToBoolean(saveXlsxDialog.ShowDialog());

                if (result == true)
                {
                    FileInfo xlsxFile = new FileInfo(saveXlsxDialog.FileName);
                    ProcessFactory.GetReport().fillExcelTableByType(grid, status, xlsxFile);
                    System.Diagnostics.Process.Start(xlsxFile.FullName);
                }
            }
            catch (Exception exc)
            {
            }
        }

        private void btnWage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rep;
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog
                {
                    DefaultExt = ".vrt",
                    Filter = "View Ridge Assistant Template files|*.vrt"
                };
                bool? result = true;
                if (result == true)
                {
                    StreamReader sr = new StreamReader("vra.vrt.txt");
                    rep = sr.ReadToEnd();
                    sr.Close();
                }
                else
                {
                    return;
                }
                string full_rep = ProcessFactory.GetReport().genHtmlWageReport(rep);
                System.Windows.Forms.SaveFileDialog sdlg = new System.Windows.Forms.SaveFileDialog
                {
                    DefaultExt = ".html",
                    Filter = "Html Documents (.html)|*.html"
                };
                if (Convert.ToBoolean(sdlg.ShowDialog()) == true)
                {
                    string filename = sdlg.FileName;
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine(full_rep);
                    sw.Close();
                    System.Diagnostics.Process.Start(filename);
                }
            }
            catch (Exception exc)
            {
            }
        }

        private void btnDebtor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rep;
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog
                {
                    DefaultExt = ".vrt",
                    Filter = "View Ridge Assistant Template files|*.vrt"
                };
                bool? result = true;
                if (result == true)
                {
                    StreamReader sr = new StreamReader("vra.vrt.txt");
                    rep = sr.ReadToEnd();
                    sr.Close();
                }
                else
                {
                    return;
                }
                string full_rep = ProcessFactory.GetReport().genHtmlInfoRepairs(rep);
                System.Windows.Forms.SaveFileDialog sdlg = new System.Windows.Forms.SaveFileDialog
                {
                    DefaultExt = ".html",
                    Filter = "Html Documents (.html)|*.html"
                };
                if (Convert.ToBoolean(sdlg.ShowDialog()) == true)
                {
                    string filename = sdlg.FileName;
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine(full_rep);
                    sw.Close();
                    System.Diagnostics.Process.Start(filename);
                }
            }
            catch (Exception exc)
            {
            }
        }

        private void btnPriceList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rep;
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog
                {
                    DefaultExt = ".vrt",
                    Filter = "View Ridge Assistant Template files|*.vrt"
                };
                bool? result = true;
                if (result == true)
                {
                    StreamReader sr = new StreamReader("vra.vrt.txt");
                    rep = sr.ReadToEnd();
                    sr.Close();
                }
                else
                {
                    return;
                }
                string full_rep = ProcessFactory.GetReport().genHtmlPraylist(rep);
                System.Windows.Forms.SaveFileDialog sdlg = new System.Windows.Forms.SaveFileDialog
                {
                    DefaultExt = ".html",
                    Filter = "Html Documents (.html)|*.html"
                };
                if (Convert.ToBoolean(sdlg.ShowDialog()) == true)
                {
                    string filename = sdlg.FileName;
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine(full_rep);
                    sw.Close();
                    System.Diagnostics.Process.Start(filename);
                }
            }
            catch (Exception exc)
            {
                
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rep;
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog
                {
                    DefaultExt = ".vrt",
                    Filter = "View Ridge Assistant Template files|*.vrt"
                };
                bool? result = true;
                if (result == true)
                {
                    StreamReader sr = new StreamReader("vra.vrt.txt");
                    rep = sr.ReadToEnd();
                    sr.Close();
                }
                else
                {
                    return;
                }
                string full_rep = ProcessFactory.GetReport().genHtmlOrdersReport(rep);
                System.Windows.Forms.SaveFileDialog sdlg = new System.Windows.Forms.SaveFileDialog
                {
                    DefaultExt = ".html",
                    Filter = "Html Documents (.html)|*.html"
                };
                if (Convert.ToBoolean(sdlg.ShowDialog()) == true)
                {
                    string filename = sdlg.FileName;
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine(full_rep);
                    sw.Close();
                    System.Diagnostics.Process.Start(filename);
                }
            }
            catch (Exception exc)
            {
                
            }
        }

        private void btnRating_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string full_rep = ProcessFactory.GetReport().genHtmlRating();
                if (File.Exists("data.js"))
                    File.Delete("data.js");
                System.IO.File.AppendAllText("data.js", "dataSet = " + full_rep);
                System.Diagnostics.Process.Start("graf.html");
            }
            catch
            {

            }
        }

        #endregion

        #region Right menu

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow search = new SearchWindow(status);
            {

            switch (status)
                {
                    case "Enterprises":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgEnterprises.ItemsSource = search.FindedEnterprise;
                        }
                        break;
                    case "TypeReklama":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgReklama.ItemsSource = search.FindedReklama;
                        }
                        break;
                    case "Orders":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgOrders.ItemsSource = search.FindedOrders;
                        }
                        break;
                case "Wage":
                    search.ShowDialog();
                    if (search.exec)
                    {
                        this.dgWage.ItemsSource = search.FindedWage;
                    }
                    break;

                default: MessageBox.Show("Для поиска необходимо выбрать таблицу!"); break;
                }
            }
        }

        #endregion

        #region Add_btn

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Managers": this.btnAddM_Click(sender, e); break;
                case "Enterprises": this.btnAddE_Click(sender, e); break;
                case "TypeReklama": this.btnAddTR_Click(sender, e); break;
                case "Orders": this.btnAddO_Click(sender, e); break;
                case "Carrier": this.btnAddC_Click(sender, e); break;
                case "Wage": this.btnAddW_Click(sender, e); break;
                //case "Debt": this.btnAddDebt_Click(sender, e); break;
                default: MessageBox.Show("Необходимо выбрать таблицу"); return;
            }
        }

        private void btnAddC_Click(object sender, RoutedEventArgs e)
        {
            AddCarrier window = new AddCarrier();
            window.ShowDialog();

            dgCarrier.ItemsSource = ProcessFactory.GetCarrierProcess().Load();
        }

        //private void btnAddDebt_Click(object sender, RoutedEventArgs e)
        //{
        //    //AddDebt window = new AddDebt();
        //    //window.ShowDialog();

        //    //dgDebt.ItemsSource = ProcessFactory.GetDebtProcess().GetList();
        //}

        private void btnAddE_Click(object sender, RoutedEventArgs e)
        {
            AddEnterprise window = new AddEnterprise();
            window.ShowDialog();

            dgEnterprises.ItemsSource = ProcessFactory.GetEnterpriseProcess().GetList();
        }

        private void btnAddM_Click(object sender, RoutedEventArgs e)
        {
            AddManagerData window = new AddManagerData();
            window.ShowDialog();

            dgManagers.ItemsSource = ProcessFactory.GetManagersProcess().GetList();

        }

        private void btnAddO_Click(object sender, RoutedEventArgs e)
        {
            AddOrder window = new AddOrder();
            window.ShowDialog();

            dgOrders.ItemsSource = ProcessFactory.GetOrdersProcess().GetList();
        }

        private void btnAddTR_Click(object sender, RoutedEventArgs e)
        {
            AddTypeReklama window = new AddTypeReklama();
            window.ShowDialog();

            dgReklama.ItemsSource = ProcessFactory.GetTypeReklamaProcess().GetList();
        }

        private void btnAddW_Click(object sender, RoutedEventArgs e)
        {
            AddWageManager window = new AddWageManager();
            window.ShowDialog();

            dgWage.ItemsSource = ProcessFactory.GetWageProcess().GetList();
        }
        #endregion

        #region Edit_btn

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Managers": this.btnEditM_Click(sender, e); break;
                case "Enterprises": this.btnEditE_Click(sender, e); break;
                case "TypeReklama": this.btnEditTR_Click(sender, e); break;
                case "Orders": this.btnEditO_Click(sender, e); break;
                case "Carrier": this.btnEditC_Click(sender, e); break;
                case "Wage": this.btnEditW_Click(sender, e); break;
                //case "Debt": this.btnEditDebt_Click(sender, e); break;
                default: MessageBox.Show("Необходимо выбрать таблицу!"); return;
            }
        }

        private void btnEditC_Click(object sender, RoutedEventArgs e)
        {
            CarrierDto item = dgCarrier.SelectedItem as CarrierDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            AddCarrier window = new AddCarrier();
            window.Load(item);
            window.ShowDialog();
            btnUpdateTC_Click(sender, e);
        }

        //private void btnEditDebt_Click(object sender, RoutedEventArgs e)
        //{
        //    //DebtDto item = dgDebt.SelectedItem as DebtDto;
        //    //if (item == null)
        //    //{
        //    //    MessageBox.Show("Выберите запись для редактирования", "Редактирование");
        //    //    return;
        //    //}

        //    //AddDebt window = new AddDebt();
        //    //window.Load(item);
        //    //window.ShowDialog();
        //    //btnUpdateDebt_Click(sender, e);
        //}

        private void btnEditE_Click(object sender, RoutedEventArgs e)
        {
            EnterprisesDto item = dgEnterprises.SelectedItem as EnterprisesDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            AddEnterprise window = new AddEnterprise();
            window.Load(item);
            window.ShowDialog();
            btnUpdateE_Click(sender, e);
        }

        private void btnEditM_Click(object sender, RoutedEventArgs e)
        {
            ManagersDto item = dgManagers.SelectedItem as ManagersDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            AddManagerData window = new AddManagerData();
            window.Load(item);
            window.ShowDialog();
            btnUpdateM_Click(sender, e);
        }

        private void btnEditO_Click(object sender, RoutedEventArgs e)
        {
            OrdersDto item = dgOrders.SelectedItem as OrdersDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            AddOrder window = new AddOrder();
            window.Load(item);
            window.ShowDialog();
            btnUpdateO_Click(sender, e);
        }

        private void btnEditTR_Click(object sender, RoutedEventArgs e)
        {
            TypeReklamaDto item = dgReklama.SelectedItem as TypeReklamaDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            AddTypeReklama window = new AddTypeReklama();
            window.Load(item);
            window.ShowDialog();
            btnUpdateTR_Click(sender, e);
        }

        private void btnEditW_Click(object sender, RoutedEventArgs e)
        {
            WageDto item = dgWage.SelectedItem as WageDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            AddWageManager window = new AddWageManager();
            window.Load(item);
            window.ShowDialog();
            btnUpdateW_Click(sender, e);
        }

        #endregion

        #region Delete_btn

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Managers": this.btnDeleteM_Click(sender, e); break;
                case "Enterprises": this.btnDeleteE_Click(sender, e); break;
                case "TypeReklama": this.btnDeleteTR_Click(sender, e); break;
                case "Orders": this.btnDeletetO_Click(sender, e); break;
                case "Carrier": this.btnDeleteC_Click(sender, e); break;
                case "Wage": this.btnDeleteW_Click(sender, e); break;
               // case "Debt": this.btnDeleteDebt_Click(sender, e); break;
                default: MessageBox.Show("Необходимо выбрать таблицу!"); return;
            }
        }

        private void btnDeleteC_Click(object sender, RoutedEventArgs e)
        {
            CarrierDto item = dgCarrier.SelectedItem as CarrierDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление носителя");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить " + item.NameCarrier + "?", "Удаление носителя", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetCarrierProcess().Delete(item.IDCarrier);

            btnUpdateTC_Click(sender, e);
        }

        private void btnDeleteE_Click(object sender, RoutedEventArgs e)
        {
            EnterprisesDto item = dgEnterprises.SelectedItem as EnterprisesDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление предприятия");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить " + item.NameEnterprise + "?", "Удаление предприятия", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetEnterpriseProcess().Delete(item.IDEnterprise);

            btnUpdateE_Click(sender, e);
        }

        //private void btnDeleteDebt_Click(object sender, RoutedEventArgs e)
        //{
        //    DebtDto item = dgDebt.SelectedItem as DebtDto;

        //    if (item == null)
        //    {
        //        MessageBox.Show("Выберите запись для удаления", "Удаление ремонта");
        //        return;
        //    }

        //    MessageBoxResult result = MessageBox.Show("Удалить ремонт от " + item.Enterprise + ", для станка " + item.Debt + "?", "Удаление ремонта", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        //    if (result != MessageBoxResult.Yes)
        //        return;

        //    ProcessFactory.GetDebtProcess().Delete(item.IDDebt);

        //    btnUpdateDebt_Click(sender, e);
        //}

        private void btnDeleteM_Click(object sender, RoutedEventArgs e)
        {
            ManagersDto item = dgManagers.SelectedItem as ManagersDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление менеджера");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить менеджера " + item.FullName + "?", "Удаление менеджера", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetManagersProcess().Delete(item.IDManager);

            btnUpdateM_Click(sender, e);
        }

        private void btnDeletetO_Click(object sender, RoutedEventArgs e)
        {
            OrdersDto item = dgOrders.SelectedItem as OrdersDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление заказа");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить " + item.IDOrder + "?", "Удаление заказа", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetOrdersProcess().Delete(item.IDOrder);

            btnUpdateO_Click(sender, e);
        }

        private void btnDeleteTR_Click(object sender, RoutedEventArgs e)
        {
            TypeReklamaDto item = dgReklama.SelectedItem as TypeReklamaDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление вида рекламы");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить рекламу " + item.NameReklama + "?", "Удаление вида рекламы", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetTypeReklamaProcess().Delete(item.IDTypeReklama);

            btnUpdateTR_Click(sender, e);
        }

        private void btnDeleteW_Click(object sender, RoutedEventArgs e)
        {
            WageDto item = dgWage.SelectedItem as WageDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление информации о з/п");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить информации о з/п для менеджера "  + item.Manager.FullName + " ?", "Удаление информации о з/п", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetWageProcess().Delete(item.Manager.IDManager);

            btnUpdateW_Click(sender, e);
        }

        #endregion'

        #region Update_btn

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Managers": this.btnUpdateM_Click(sender, e); break;
                case "Enterprises": this.btnUpdateE_Click(sender, e); break;
                case "TypeReklama": this.btnUpdateTR_Click(sender, e); break;
                case "Orders": this.btnUpdateO_Click(sender, e); break;
                case "Carrier": this.btnUpdateTC_Click(sender, e); break;
                case "Wage": this.btnUpdateW_Click(sender, e); break;
               // case "Debt": this.btnUpdateDebt_Click(sender, e); break;
                default: MessageBox.Show("Необходимо выбрать таблицу!"); return;
            }
        }

        private void btnUpdateM_Click(object sender, RoutedEventArgs e)
        {
            dgManagers.ItemsSource = ProcessFactory.GetManagersProcess().GetList();
        }

        private void btnUpdateO_Click(object sender, RoutedEventArgs e)
        {
            dgOrders.ItemsSource = ProcessFactory.GetOrdersProcess().GetList();

        }

        private void btnUpdateTR_Click(object sender, RoutedEventArgs e)
        {
            dgReklama.ItemsSource = ProcessFactory.GetTypeReklamaProcess().GetList();
        }

        //private void btnUpdateDebt_Click(object sender, RoutedEventArgs e)
        //{
        //    dgDebt.ItemsSource = ProcessFactory.GetDebtProcess().GetList();
        //}

        private void btnUpdateE_Click(object sender, RoutedEventArgs e)
        {
            dgEnterprises.ItemsSource = ProcessFactory.GetEnterpriseProcess().GetList();
        }

        private void btnUpdateW_Click(object sender, RoutedEventArgs e)
        {
            dgWage.ItemsSource = ProcessFactory.GetWageProcess().GetList();
        }

        private void btnUpdateTC_Click(object sender, RoutedEventArgs e)
        {
            dgCarrier.ItemsSource = ProcessFactory.GetCarrierProcess().Load();
        }

        #endregion

    }
}
