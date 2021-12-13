﻿using ISApteka.Database;
using ISApteka.Database.Models;
using ISApteka.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ISApteka.Entities.Enums;

namespace ISApteka
{
    public partial class FormCatalog : Form
    {
        private FormMain FormMain { get; set; }
        private FormOrder FormOrder { get; set; }
        private FormMedicine FormMedicine { get; set; }
        private List<Store> Stores { get; set; }
        private List<MedicineCatalog> MedicineGrids { get; set; }
        private Repository Repository { get; set; }
        private Mode Mode { get; set; }


        public FormCatalog(Repository repository, Mode mode)
        {
            InitializeComponent();
            Repository = repository;
            Mode = mode;
            if (Mode == Mode.Edit)
            {
                buOrder.Visible = false;
            }
            else if (Mode == Mode.Read)
            {
                buAdd.Visible = false;
            }

            Task.Run(() => this.GridParameters()).Wait();
            buOrder.Click += BuOrder_Click;
            buAdd.Click += BuAdd_Click;
            FormClosed += FormCatalog_FormClosed;
        }

        private void BuAdd_Click(object sender, EventArgs e)
        {
            FormMedicine = new FormMedicine(Repository, this, 0, Stores, Mode.Add);
            FormMedicine.Show();
        }


        // order
        private void BuOrder_Click(object sender, EventArgs e)
        {
            List<MedicineCatalog> addedMedicines = new();
            List<Store> addedStores = new();
            // find added medicines and stores
            foreach (var medicineGrid in MedicineGrids)
            {
                if (medicineGrid.IsAdded == true)
                {
                    var addStore = Stores.Find(x => x.MedicineId == medicineGrid.Id);
                    addedMedicines.Add(medicineGrid);
                    addedStores.Add(addStore);
                }
            }
            if (addedMedicines.Count < 1)
            {
                MessageBox.Show("Заказ пустой!\nДобавьте лекарственные средства в заказ");
            }
            else
            {
                FormOrder = new FormOrder(Repository, this, addedStores, addedMedicines);
                FormOrder.Show();
            }
        }


        private async Task GridParameters()
        {
            // grid settings
            dataGridMedicines.AllowUserToAddRows = false;
            dataGridMedicines.BackgroundColor = Color.White;
            dataGridMedicines.AllowUserToResizeColumns = false;
            dataGridMedicines.AllowUserToResizeRows = false;
            dataGridMedicines.RowHeadersVisible = false;
            dataGridMedicines.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridMedicines.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridMedicines.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //dataGridMedicines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.;
            dataGridMedicines.GridColor = Color.White;

            await DataBinding();
            
            // rename columns
            dataGridMedicines.Columns[0].HeaderText = "Id";           // 1
            dataGridMedicines.Columns[1].HeaderText = "Наименование"; // 2
            dataGridMedicines.Columns[2].HeaderText = "Бренд";        // 3  
            dataGridMedicines.Columns[3].HeaderText = "Описание";     // 4
            dataGridMedicines.Columns[4].HeaderText = "Рецептурное";  // 5
            dataGridMedicines.Columns[5].HeaderText = "В наличии";    // 6
            dataGridMedicines.Columns[6].HeaderText = "Добавлен";     // 7
            // editable
            dataGridMedicines.Columns[0].ReadOnly = true;
            dataGridMedicines.Columns[1].ReadOnly = true;
            dataGridMedicines.Columns[2].ReadOnly = true;
            dataGridMedicines.Columns[3].ReadOnly = true;
            dataGridMedicines.Columns[4].ReadOnly = true;
            dataGridMedicines.Columns[5].ReadOnly = true;
            dataGridMedicines.Columns[6].ReadOnly = false;
            


            // button Go
            DataGridViewButtonColumn buGo = new();
            if (Mode == Mode.Edit)
            {
                buGo.HeaderText = "Редакировать";
            }
            buGo.HeaderText = "Перейти";
            buGo.Name = "buGo";
            buGo.Text = "->";
            buGo.FlatStyle = FlatStyle.Flat;
            buGo.DefaultCellStyle.BackColor = Color.Black;
            buGo.DefaultCellStyle.ForeColor = Color.White;
            buGo.UseColumnTextForButtonValue = true;
            dataGridMedicines.Columns.Add(buGo);

            //dataGridMedicines.Columns["buGo"].Width = 50;


            dataGridMedicines.Columns["Id"].Visible = false;
            if (Mode == Mode.Edit)
            {
                dataGridMedicines.Columns[6].Visible = false;
            }

            // size
            dataGridMedicines.Columns[0].Width = 50;
            dataGridMedicines.Columns[1].Width = 150;
            dataGridMedicines.Columns[2].Width = 100;
            dataGridMedicines.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridMedicines.Columns[4].Width = 90;
            dataGridMedicines.Columns[5].Width = 90;
            dataGridMedicines.Columns[6].Width = 80;
            dataGridMedicines.Columns[7].Width = 60;
        }

        public async Task DataBinding()
        {
            // take medicines
            Stores = await Repository.GetAllFromStores();
            MedicineGrids = new List<MedicineCatalog>();
            // convert medicines that have store
            foreach (var store in Stores)
            {
                var medicine = await Repository.GetMedicineByIdFromMedicines(store.MedicineId);
                MedicineCatalog medicineCatalog = new()
                {
                    Id = medicine.Id,
                    Name = medicine.Name,
                    Description = medicine.Description,
                    IsPrescription = medicine.IsPrescription,
                    IsAdded = false
                };
                // brand info
                if (medicine.BrandId != null)
                {
                    Brand brand = await Repository.GetBrandByIdInBrands(medicine.BrandId.Value);
                    medicineCatalog.Brand = brand.Name;
                }
                // store info
                if (store.Amount != null)
                {
                    medicineCatalog.Amount = store.Amount.Value;
                }
                else
                {
                    medicineCatalog.Amount = 0;
                }

                MedicineGrids.Add(medicineCatalog);
            }

            // push data to grid
            dataGridMedicines.DataSource = MedicineGrids;
        }


        // go
        private void dataGridMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Go
            if (e.ColumnIndex == 0)
            {
                // get id from this row
                int medicineId = Convert.ToInt32(dataGridMedicines.Rows[e.RowIndex].Cells[1].Value);
                FormMedicine = new FormMedicine(Repository, this, medicineId, Stores, Mode);
                FormMedicine.Show();
            }
        }
        

        // closed
        private void FormCatalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain = new FormMain(Repository);
            this.Hide();
            FormMain.Show();
        }
    }
}