using ISApteka.Database;
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
        private User User { get; set; }
        private FormOrder FormOrder { get; set; }
        private FormMedicine FormMedicine { get; set; }
        private List<MedicineCatalog> MedicineGrids { get; set; }
        private DataTable DataTable { get; set; }
        private Repository Repository { get; set; }
        private  Mode Mode { get; set; }

        public List<Store> Stores { get; set; }


        public FormCatalog(User user, Repository repository, Mode mode)
        {
            InitializeComponent();

            Repository = repository;
            User = user;
            Mode = mode;

            // buttons
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
            buSearch.Click += BuSearch_Click;
            teSearch.KeyDown += TeSearch_KeyDown;
            FormClosed += FormCatalog_FormClosed;
        }

        private void TeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuSearch_Click(sender, e);
            }
        }


        private void BuSearch_Click(object sender, EventArgs e)
        {
            DataTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Name", teSearch.Text);
        }


        private void BuAdd_Click(object sender, EventArgs e)
        {
            FormMedicine = new FormMedicine(User, Repository, this, 0, Mode.Add);
            FormMedicine.Show();
        }


        // order
        private void BuOrder_Click(object sender, EventArgs e)
        {
            List<string> prescriptionNames = new();
            List<MedicineCatalog> addedMedicines = new();
            // find added medicines
            for (int i = 0; i < DataTable.Rows.Count; i++)
            {            
                if (Convert.ToBoolean(DataTable.Rows[i].ItemArray[6].ToString()) == true)
                {
                    addedMedicines.Add(MedicineGrids[i]);   
                    if (Convert.ToBoolean(DataTable.Rows[i].ItemArray[4].ToString()) == true)
                    {
                        prescriptionNames.Add(DataTable.Rows[i].ItemArray[1].ToString());
                    }
                }
            }
            if (addedMedicines.Count < 1)
            {
                MessageBox.Show("Заказ пустой!\nДобавьте лекарственные средства в заказ");
            }
            else
            {
                if (prescriptionNames.Count > 0)
                {
                    string text = "Обязательно!\nСпросите рецепт на лекарственные средства:\n";
                    foreach (var name in prescriptionNames)
                    {
                        text += $"{name}\n";
                    }
                    MessageBox.Show(text);
                }
                FormOrder = new FormOrder(User, Repository, this, addedMedicines);
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
            DataTable = new();
            // convert medicines that have store
            foreach (var store in Stores)
            {
                var medicine = await Repository.GetByIdFromMedicines(store.MedicineId);
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
                    Brand brand = await Repository.GetByIdFromBrands(medicine.BrandId.Value);
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

            DataTable.Columns.Add("Id", typeof(int));
            DataTable.Columns.Add("Name", typeof(string));
            DataTable.Columns.Add("Brand", typeof(string));
            DataTable.Columns.Add("Description", typeof(string));
            DataTable.Columns.Add("IsPrescription", typeof(bool));
            DataTable.Columns.Add("Amount", typeof(int));
            DataTable.Columns.Add("IsAdded", typeof(bool));

            foreach (var medicineGrid in MedicineGrids)
            {
                DataTable.Rows.Add(new object[] { 
                    medicineGrid.Id, 
                    medicineGrid.Name,
                    medicineGrid.Brand,
                    medicineGrid.Description,
                    medicineGrid.IsPrescription,
                    medicineGrid.Amount,
                    medicineGrid.IsAdded,
                });
            }

            // push data to grid
            dataGridMedicines.DataSource = DataTable;
        }


        // go
        private void dataGridMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Go
            if (e.ColumnIndex == 0)
            {
                // get id from this row
                int medicineId = Convert.ToInt32(dataGridMedicines.Rows[e.RowIndex].Cells[1].Value);
                FormMedicine = new FormMedicine(User, Repository, this, medicineId, Mode);
                FormMedicine.Show();
            }
        }
        

        // closed
        private void FormCatalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain = new FormMain(User, Repository);
            this.Hide();
            FormMain.Show();
        }
    }
}
