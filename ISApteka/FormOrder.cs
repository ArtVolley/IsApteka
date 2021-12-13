using ISApteka.Database;
using ISApteka.Database.Models;
using ISApteka.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISApteka
{
    public partial class FormOrder : Form
    {
        private FormCatalog FormCatalog { get; set; }
        private Repository Repository{ get; set; }
        private List<Store> Stores { get; set; }
        private List<MedicineCatalog> Medicines { get; set; }
        private List<MedicineOrder> MedicineGrids { get; set; }
        private List<OrderInfo> OrderInfos { get; set; }
        private int OrderId { get; set; }


        public FormOrder(Repository repository, FormCatalog formCatalog, List<Store> stores, List<MedicineCatalog> medicines)
        {
            InitializeComponent();

            Repository = repository;
            FormCatalog = formCatalog;
            Stores = stores;
            Medicines = medicines;

            Task.Run(() => this.InintializeOrder()).Wait();
            Task.Run(() => this.CreateOrder()).Wait();
            buOrder.Click += BuOrder_Click;
            FormClosed += FormOrder_FormClosed;
        }


        private async void BuOrder_Click(object sender, EventArgs e)
        {
            await UpdateOrder();
        }


        private async Task UpdateOrder()
        {
            float totalCost = 0;
            // update order info
            foreach (var medicineGrid in MedicineGrids)
            {
                totalCost += medicineGrid.TotalCost;
                foreach (var orderInfo in OrderInfos)
                {
                    if (medicineGrid.Id == orderInfo.MedicineId)
                    {
                        orderInfo.Amount = medicineGrid.Amount;
                        orderInfo.Cost = medicineGrid.Cost;
                    }
                    await Repository.UpdateOrderInfoIntoOrderInfo(orderInfo);
                }
            }
            // update order
            var order = new Order()
            {
                Id = OrderId,
                TotalCost = totalCost,
                IsPassed = 1
            };
            await Repository.UpdateOrderIntoOrders(order);
        }


        private async Task CreateOrder()
        {
            OrderInfos = new List<OrderInfo>();
            float totalCost = 0;
            // push order
            foreach (var medicineGrid in MedicineGrids)
            {
                totalCost += medicineGrid.TotalCost;
            }
            var order = new Order()
            {
                TotalCost = totalCost,
                IsPassed = 0
            };
            OrderId = await Repository.CreateOrderIntoOrders(order);
            // push orderInfo
            foreach (var medicineGrid in MedicineGrids)
            {
                var orderInfo = new OrderInfo()
                {
                    OrderId = OrderId,
                    MedicineId = medicineGrid.Id,
                    Amount = medicineGrid.Amount,
                    Cost = medicineGrid.Cost
                };
                int id = await Repository.CreateOrderInfoIntoOrderInfo(orderInfo);
                orderInfo.Id = id;
                OrderInfos.Add(orderInfo);
            }
        }


        private async Task InintializeOrder()
        {
            // grid settings
            dataGridOrder.AllowUserToAddRows = false;
            dataGridOrder.BackgroundColor = Color.White;
            dataGridOrder.AllowUserToResizeColumns = false;
            dataGridOrder.AllowUserToResizeRows = false;
            dataGridOrder.RowHeadersVisible = false;
            dataGridOrder.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridOrder.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridOrder.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOrder.GridColor = Color.White;

            MedicineGrids = new List<MedicineOrder>();            
            // convert medicines
            foreach (var medicine in Medicines)
            {
                // medicine info
                MedicineOrder medicineOrder = new()
                {
                    Id = medicine.Id,
                    Name = medicine.Name,
                    IsPrescription = medicine.IsPrescription
                };
                // store info
                var store = Stores.Find(x => x.MedicineId == medicine.Id);
                medicineOrder.Cost = store.Cost;
                medicineOrder.Amount = 1;
         
                MedicineGrids.Add(medicineOrder);
            }

            // push data to grid
            dataGridOrder.DataSource = MedicineGrids;

            // rename columns
            dataGridOrder.Columns[0].HeaderText = "Id";              // 2
            dataGridOrder.Columns[1].HeaderText = "Наименование";    // 3
            dataGridOrder.Columns[2].HeaderText = "Рецептурное";     // 4  
            dataGridOrder.Columns[3].HeaderText = "Количество";      // 5
            dataGridOrder.Columns[4].HeaderText = "Цена за единицу"; // 6
            dataGridOrder.Columns[5].HeaderText = "Цена";            // 7
            // editable
            dataGridOrder.Columns[0].ReadOnly = true;
            dataGridOrder.Columns[1].ReadOnly = true;
            dataGridOrder.Columns[2].ReadOnly = true;
            dataGridOrder.Columns[3].ReadOnly = false;
            dataGridOrder.Columns[4].ReadOnly = true;
            dataGridOrder.Columns[5].ReadOnly = true;

            // button -
            DataGridViewButtonColumn buMinus = new();
            buMinus.HeaderText = "Убрать";
            buMinus.Name = "buMinus";
            buMinus.Text = "-";
            buMinus.UseColumnTextForButtonValue = true;
            buMinus.FlatStyle = FlatStyle.Flat;
            buMinus.DefaultCellStyle.BackColor = Color.Black;
            buMinus.DefaultCellStyle.ForeColor = Color.White;
            dataGridOrder.Columns.Add(buMinus);

            // button +
            DataGridViewButtonColumn buPlus = new();
            buPlus.HeaderText = "Добавить";
            buPlus.Name = "buPlus";
            buPlus.Text = "+";
            buPlus.FlatStyle = FlatStyle.Flat;
            buPlus.DefaultCellStyle.BackColor = Color.Black;
            buPlus.DefaultCellStyle.ForeColor = Color.White;
            buPlus.UseColumnTextForButtonValue = true;
            dataGridOrder.Columns.Add(buPlus);


            dataGridOrder.Columns["Id"].Visible = false;
        }


        private void dataGridOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // -
            if (e.ColumnIndex == 0)
            {
                // - amount on this row
                int id = Convert.ToInt32(dataGridOrder.Rows[e.RowIndex].Cells[2].Value);
                var medicineGrid = MedicineGrids.Find(x => x.Id == id).Amount -= 1;
                dataGridOrder.UpdateCellValue(5, e.RowIndex);
                dataGridOrder.UpdateCellValue(7, e.RowIndex);
            }
            // +
            if (e.ColumnIndex == 1)
            {
                // + amount on this row
                int id = Convert.ToInt32(dataGridOrder.Rows[e.RowIndex].Cells[2].Value);
                var medicineGrid = MedicineGrids.Find(x => x.Id == id).Amount += 1;
                dataGridOrder.UpdateCellValue(5, e.RowIndex);
                dataGridOrder.UpdateCellValue(7, e.RowIndex);
            }
        }


        // update when change amount
        private void dataGridOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                dataGridOrder.UpdateCellValue(7, e.RowIndex);
            }
        }


        private void FormOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            FormCatalog.Show();
        }
    }
}
