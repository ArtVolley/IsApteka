using ISApteka.Database;
using ISApteka.Database.Models;
using ISApteka.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using _excel = Microsoft.Office.Interop.Excel;
using static ISApteka.Entities.Enums;

namespace ISApteka
{
    public partial class FormReports : Form
    {
        private FormMain FormMain { get; set; }
        private Repository Repository { get; set; }
        private User User { get; set; }
        // Create an excel application object, workbook oject and worksheet object
        _Application excel = new _excel.Application();
        Workbook workbook;
        Worksheet worksheet;


        public FormReports(User user, Repository repository)
        {
            InitializeComponent();

            User = user;
            Repository = repository;

            FormClosed += FormReports_FormClosed;
            buGeneral.Click += BuGeneral_Click;
            buMonth.Click += BuMonth_Click;
        }

        private async void BuMonth_Click(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string monthReport = Path.Combine(docPath, "MonthReport.xlsx");

            if (File.Exists(monthReport))
            {
                File.Delete(monthReport);
            }

            await Excel(monthReport, Enums.ReportType.Month);

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(monthReport)
            {
                UseShellExecute = true
            };
            p.Start();
            
        }

        private async void BuGeneral_Click(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string generalReport = Path.Combine(docPath, "GeneralReport.xlsx");

            if (File.Exists(generalReport))
            {
                File.Delete(generalReport);
            }

            await Excel(generalReport, Enums.ReportType.General);

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(generalReport)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void FormReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain = new FormMain(User, Repository);
            this.Hide();
            FormMain.Show();
        }

        

        public async Task Excel(string path, Enums.ReportType report)
        {
            // new file
            this.workbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            this.worksheet = this.workbook.Worksheets[1];
            await NewSheet(report);
            workbook.SaveAs(path);
            workbook.Close();
        }

        
        public async Task NewSheet(Enums.ReportType report)
        {
            Worksheet sheet = excel.Worksheets.Add(After: this.worksheet);
            sheet.Columns[1].ColumnWidth = 50;
            sheet.Columns[2].ColumnWidth = 20;
            sheet.Columns[3].ColumnWidth = 15;
            sheet.Columns[4].ColumnWidth = 15;
            sheet.Cells[3, 1] = "Наименование лекарства";
            sheet.Cells[3, 2] = "Количество, ед";
            sheet.Cells[3, 3] = "Цена, руб";
            sheet.Cells[3, 4] = "Сумма, руб";

            if (report == Enums.ReportType.General)
            {
                var reports = await GetGeneralReport();
                // headers
                sheet.Cells[1, 1] = "Остатки на слкаде на дату";
                sheet.Cells[1, 2] = $"{DateTime.Now}";

                await BuildReport(sheet, reports);
            }
            if (report == Enums.ReportType.Month)
            {
                var reports = await GetMonthReport();
                // headers
                sheet.Cells[1, 1] = "Отчет продаж за месяц";
                sheet.Cells[1, 2] = $"{DateTime.Now.ToString("MMMM")}";
                
                await BuildReport(sheet, reports);
            }
        }


        public async Task BuildReport(Worksheet sheet, List<Report> reports)
        {
            if (reports != null)
            {
                double totalCost = 0;
                int totalAmount = 0;
                // report
                for (int i = 0; i < reports.Count; i++)
                {
                    sheet.Cells[i + 4, 1] = reports[i].Name;
                    sheet.Cells[i + 4, 2] = reports[i].Amount;
                    sheet.Cells[i + 4, 3] = reports[i].Cost;
                    sheet.Cells[i + 4, 4] = reports[i].FullCost;
                    totalCost += reports[i].FullCost;
                    totalAmount += reports[i].Amount;
                }
                // footer
                sheet.Cells[reports.Count + 5, 1] = "Всего лекарсвтенных средств:";
                sheet.Cells[reports.Count + 5, 2] = totalAmount;
                sheet.Cells[reports.Count + 5, 3] = "ИТОГО:";
                sheet.Cells[reports.Count + 5, 4] = totalCost;
            }
        }


        public async Task<List<Report>> GetMonthReport()
        {
            List<Report> reports = new();
            List<OrderInfo> removeOrderInfo = new();
            var orderInfos = await Repository.GetAllFromOrderInfo();
            // find orders not passed and another month
            foreach (var orderInfo in orderInfos)
            {
                var order = await Repository.GetByIdFormOrders(orderInfo.OrderId);
                if (order.IsPassed == 0)
                {
                    removeOrderInfo.Add(orderInfo);
                }
                if(Convert.ToDateTime(order.Date).Month != DateTime.Now.Month)
                {
                    removeOrderInfo.Add(orderInfo);
                }
            }
            // remove bad orders
            foreach (var remove in removeOrderInfo)
            {
                orderInfos.Remove(remove);
            }
            if (orderInfos != null)
            {
                // group by medicineId
                var orderInfosGrouped = from orderInfo in orderInfos
                                  group orderInfo by orderInfo.MedicineId;
                // convert to MonthReport
                foreach (IGrouping<int, OrderInfo> orderInfoGrouped in orderInfosGrouped)
                {
                    Report report = new();
                    var medicine = await Repository.GetByIdFromMedicines(orderInfoGrouped.Key);
                    report.Name = medicine.Name;
                    foreach (var orderInfo in orderInfoGrouped)
                    {
                        report.Amount += orderInfo.Amount;
                        report.Cost = orderInfo.Cost;
                    }

                    reports.Add(report);
                }
            }

            return reports;
        }


        public async Task<List<Report>> GetGeneralReport()
        {
            List<Report> reports = new();
            var stores = await Repository.GetAllFromStores();
            
            if (stores != null)
            {
                // convert to MonthReport
                foreach (var store in stores)
                {
                    Report report = new();
                    var medicine = await Repository.GetByIdFromMedicines(store.MedicineId);
                    report.Name = medicine.Name;
                    report.Amount += store.Amount ?? 0;
                    report.Cost = store.Cost;

                    reports.Add(report);
                }
            }

            return reports;
        }
    }
}
