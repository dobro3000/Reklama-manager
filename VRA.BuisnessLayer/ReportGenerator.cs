using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using VRA.Dto;
using System.Windows.Forms;

namespace VRA.BuisnessLayer
{
    public class ReportGenerator : IReportGenerator
    {
        public void fillExcelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile)
        {
            try
            {
                if (grid != null)
                {
                    ExcelPackage pck = new ExcelPackage(xlsxFile);
                    var excel = pck.Workbook.Worksheets.Add(status);
                    int x = 1;
                    int y = 1;

                    CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                    excel.Cells["A1:Z1"].Style.Font.Bold = true;
                    excel.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    excel.Cells.Style.Numberformat.Format = "General";

                    Object dtObj = new Object();

                    switch (status)
                    {
                        case "Managers": dtObj = new ManagersDto(); break;
                        case "Enterprises": dtObj = new EnterprisesDto() ; break;
                        case "TypeReklama": dtObj = new TypeReklamaDto() ; break;
                        case "Orders": dtObj = new OrdersDto() ; break;
                        case "Carrier": dtObj = new CarrierDto() ; break;
                        case "Wage": dtObj = new WageDto() ; break;
                    }
                    foreach (var prop in dtObj.GetType().GetProperties())
                    {
                        excel.Cells[y, x].Value = prop.Name.Trim();
                        x++;
                    }
                    foreach (var item in grid)
                    {
                        y++;
                        Object itemObj = item;
                        x = 1;
                        foreach (var prop in itemObj.GetType().GetProperties())
                        {
                            object t = prop.GetValue(itemObj, null);
                            object val;

                            if (t == null) val = "";
                            else
                            {
                                val = t.ToString();
                                if (t is ManagersDto)
                                    val = ((ManagersDto)t).FullName;

                                if (t is EnterprisesDto)
                                    val = ((EnterprisesDto)t).NameEnterprise;

                                if (t is CarrierDto)
                                    val = ((CarrierDto)t).NameCarrier;

                                if (t is TypeReklamaDto)
                                    val = ((TypeReklamaDto)t).NameReklama;
                            }
                            excel.Cells[y, x].Value = val;
                            x++;
                        }
                    }
                    excel.Cells.AutoFitColumns();
                    pck.Save();
                }
                else MessageBox.Show("Данные не загружены!");
            }
            catch (Exception exc)
            {
               // MessageBox.Show(exc.Message, "Ошибка");
            }
        }

        public string genHtmlPraylist(string rep)
        {
            List<object> works = ProcessFactory.GetPraylistProcess().GetList().Cast<object>().ToList();
            string res_html = "<h2>Прай-лист услуг предприятия ООО'Колорит'</h2><br/>";
            res_html += "<tr><td><b>Название рекламы</b></td><td><b>Носитель</b></td><td><b>Позиция</b></td><td><b>Стоимость (руб)</b></td></tr>";
            
            try
            {
                foreach (var work in works)
                {
                    PraylistDto WorkItem = (PraylistDto)work;
                    res_html += "<tr><td><p>" + WorkItem.NameReklama + "</p></td>";
                    res_html += "<td><p>" + WorkItem.NameCarrier + "</p></td>";
                    res_html += "<td><p>" + WorkItem.Position + "</p></td>";
                    res_html += "<td><p>" + WorkItem.Cost + "</p></td></tr>";

                }

                res_html = rep.Replace("[VRA_TABLE_REPORT]", res_html);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return res_html;
           // return "";
        }

        public string genHtmlInfoRepairs(string rep)
        {
            string res_html = "<h2>Отчет о задолжностях предприятий</h2><br/>";
            List<object> works = ProcessFactory.GetDebtProcess().GetList().Cast<object>().ToList();
            res_html += "<tr><td><b>Название предприятия</b></td><td><b>Представитель</b></td><td><b>Контактный номер</b></td><td><b>Дата начала размещения</b></td><td><b>Дата окончания размещения</b></td><td><b>Размер долга (руб)</b></td></tr>";

            try
            {
                foreach (var work in works)
                {
                    DebtDto WorkItem = (DebtDto)work;
                    if (WorkItem.Debt != 0)
                    {
                        res_html += "<tr><td><p>" + WorkItem.NameEnterprise + "</p></td>";
                        res_html += "<td><p>" + WorkItem.Representative + "</p></td>";
                        res_html += "<td><p>" + Convert.ToDouble(WorkItem.Phone) + "</p></td>";
                        res_html += "<td><p>" + WorkItem.StartDate.ToString("yyyy-dd-MM") + "</p></td>";
                        res_html += "<td><p>" + WorkItem.FinnalyDate.ToString("yyyy-dd-MM") + "</p></td>";
                        res_html += "<td><p>" + WorkItem.Debt + "</p></td></tr>";
                    }
                    else { }
                }

                res_html = rep.Replace("[VRA_TABLE_REPORT]", res_html);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return res_html;
            // return "";
        }

        public string genHtmlOrdersReport(string rep)
        {
            List<object> works = ProcessFactory.GetOrdersReportProcess().GetList().Cast<object>().ToList();
            string res_html = "<h2>Отчет о заказах</h2><br/>";
            res_html += "<tr><td><b>Предприятие</b></td><td><b>Название рекламы</b></td><td><b>Носитель</b></td><td><b>Дата начала размещения</b> </td><td><b>Дата окончания размещения</b></td><td><b>Сумма (руб)</b></td></tr>";

            try
            {
                foreach (var work in works)
                {
                    OrdersReportDto WorkItem = (OrdersReportDto)work;
                    res_html += "<tr><td><p>" + WorkItem.NameEnterprise + "</p></td>";
                    res_html += "<td><p>" + WorkItem.NameReklama + "</p></td>";
                    res_html += "<td><p>" + WorkItem.NameCarrier + "</p></td>";
                    res_html += "<td><p>" + WorkItem.StartDate.ToString("yyyy-dd-MM") + "</p></td>";
                    res_html += "<td><p>" + WorkItem.FinallyDate.ToString("yyyy-dd-MM") + "</p></td>";
                    res_html += "<td><p>" + WorkItem.Cost + "</p></td></tr>";

                }

                res_html = rep.Replace("[VRA_TABLE_REPORT]", res_html);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return res_html;
            // return "";
        }

        public string genHtmlWageReport(string rep)
        {
            List<object> works = ProcessFactory.GetWageReportProcess().GetList().Cast<object>().ToList();
            string res_html = "<h2>Отчет о з/п менеджеров</h2><br/>";
            res_html += "<tr><td><b>ФИО менеджера</b></td><td><b>Сумма заказов</b></td><td><b>Заработанная сумма (руб)</b></td><td><b>Выплачено (руб)</b> </td><td><b>Долг (руб)</b></td></tr>";

            try
            {
                foreach (var work in works)
                {
                    WageReportDto WorkItem = (WageReportDto)work;
                    res_html += "<tr><td><p>" + WorkItem.FullNameManager + "</p></td>";
                    res_html += "<td><p>" + WorkItem.SumOrders + "</p></td>";
                    res_html += "<td><p>" + WorkItem.CurrentSum + "</p></td>";
                    res_html += "<td><p>" + WorkItem.Paid + "</p></td>";
                    res_html += "<td><p>" + WorkItem.Rest + "</p></td></tr>";

                }

                res_html = rep.Replace("[VRA_TABLE_REPORT]", res_html);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return res_html;
            // return "";
        }

        public string genHtmlRating()
        {
            List<object> works = ProcessFactory.GetWageProcess().GetList().Cast<object>().ToList();
            string res_html = "[";
            try
            {

                foreach (var work in works)
                {
                    WageDto WorkItem = (WageDto)work;
                    res_html += "{x: '" + WorkItem.Manager.FullName + "', y: " + WorkItem.SumOrders + "},";
                }
                res_html = res_html.Remove(res_html.LastIndexOf(','), 1);
                res_html += "]";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return res_html;

        }

        public string genHtmlDataDebt(string rep)
        {
            string res_html = "<h2>Отчет о задолжностях предприятий</h2><br/>";
            List<object> works = ProcessFactory.GetDebtProcess().GetList().Cast<object>().ToList();
            res_html += "<tr><td><b>Название предприятия</b></td><td><b>Представитель</b></td><td><b>Контактный номер</b></td><td><b>Дата начала размещения</b></td><td><b>Дата окончания размещения</b></td></tr>";

            try
            {
                foreach (var work in works)
                {
                    DebtDto WorkItem = (DebtDto)work;
                    if (WorkItem.FinnalyDate <= DateTime.Now)
                    {
                        res_html += "<tr><td><p>" + WorkItem.NameEnterprise + "</p></td>";
                        res_html += "<td><p>" + WorkItem.Representative + "</p></td>";
                        res_html += "<td><p>" + Convert.ToDouble(WorkItem.Phone) + "</p></td>";
                        res_html += "<td><p>" + WorkItem.StartDate.ToString("yyyy-dd-MM") + "</p></td>";
                        res_html += "<td><p>" + WorkItem.FinnalyDate.ToString("yyyy-dd-MM") + "</p></td></tr>";
                    }
                    else { }
                }

                res_html = rep.Replace("[VRA_TABLE_REPORT]", res_html);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return res_html;
        }
    }
}
