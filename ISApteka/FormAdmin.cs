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
using static ISApteka.Entities.Enums;

namespace ISApteka
{
    public partial class FormAdmin : Form
    {
        private FormMain FormMain { get; set; }
        private FormUser FormUser { get; set; }
        private Repository Repository { get; set; }
        private User User{ get; set; }
        private List<User> Users { get; set; }
        private List<UserAdmin> UserGrids { get; set; }


        public FormAdmin(User user, Repository repository)
        {
            InitializeComponent();

            Repository = repository;
            User = user;

            Task.Run(() => this.GridParameters()).Wait();
            FormClosed += FormCatalog_FormClosed;
            dataGridUsers.CellClick += DataGridUsers_CellClick;
            buAdd.Click += BuAdd_Click;
        }

        private void BuAdd_Click(object sender, EventArgs e)
        {
            FormUser = new FormUser(Repository, this, null, Mode.Add);
            FormUser.Show();
        }

        private async Task GridParameters()
        {
            // grid settings
            dataGridUsers.AllowUserToAddRows = false;
            dataGridUsers.BackgroundColor = Color.White;
            dataGridUsers.AllowUserToResizeColumns = false;
            dataGridUsers.AllowUserToResizeRows = false;
            dataGridUsers.RowHeadersVisible = false;
            dataGridUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridUsers.GridColor = Color.White;

            await DataBinding();

            // rename columns
            dataGridUsers.Columns[0].HeaderText = "Id";      // 1
            dataGridUsers.Columns[1].HeaderText = "Логин";   // 2
            dataGridUsers.Columns[2].HeaderText = "Пароль";  // 3  
            dataGridUsers.Columns[3].HeaderText = "Роль";    // 4
            dataGridUsers.Columns[4].HeaderText = "ФИО";     // 5
            dataGridUsers.Columns[5].HeaderText = "Телефон"; // 6
            dataGridUsers.Columns[6].HeaderText = "Почта";   // 7
            // editable
            dataGridUsers.Columns[0].ReadOnly = true;
            dataGridUsers.Columns[1].ReadOnly = true;
            dataGridUsers.Columns[2].ReadOnly = true;
            dataGridUsers.Columns[3].ReadOnly = true;
            dataGridUsers.Columns[4].ReadOnly = true;
            dataGridUsers.Columns[5].ReadOnly = true;
            dataGridUsers.Columns[6].ReadOnly = true;



            // button Go
            DataGridViewButtonColumn buGo = new();
            buGo.HeaderText = "Редакировать";            
            buGo.Name = "buGo";
            buGo.Text = "->";
            buGo.FlatStyle = FlatStyle.Flat;
            buGo.DefaultCellStyle.BackColor = Color.Black;
            buGo.DefaultCellStyle.ForeColor = Color.White;
            buGo.UseColumnTextForButtonValue = true;
            dataGridUsers.Columns.Add(buGo);


            dataGridUsers.Columns["Id"].Visible = false;

            // size
            dataGridUsers.Columns[0].Width = 50;
            dataGridUsers.Columns[1].Width = 150;
            dataGridUsers.Columns[2].Width = 150;
            dataGridUsers.Columns[3].Width = 110;
            dataGridUsers.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridUsers.Columns[5].Width = 110;
            dataGridUsers.Columns[6].Width = 150;
            dataGridUsers.Columns[7].Width = 150;
        }


        public async Task DataBinding()
        {
            // take medicines
            Users = await Repository.GetAllFromUsers();
            UserGrids = new List<UserAdmin>();
            // convert medicines that have store
            foreach (var user in Users)
            {

                UserAdmin userAdmin = new()
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    Role = user.Role,
                    Name = user.Name,
                    Phone = user.Phone,
                    Email = user.Email,
                };
                if (user.Birth != "")
                {
                    userAdmin.Birth = Convert.ToDateTime(user.Birth).ToString("dd.MM.yyyy");
                }

                UserGrids.Add(userAdmin);
            }

            // push data to grid
            dataGridUsers.DataSource = UserGrids;
        }

        
        private void DataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Go
            if (e.ColumnIndex == 0)
            {
                // get id from this row
                User user = new()
                {
                    Id = Convert.ToInt32(dataGridUsers.Rows[e.RowIndex].Cells[1].Value),
                    Login = Convert.ToString(dataGridUsers.Rows[e.RowIndex].Cells[2].Value),
                    Password = Convert.ToString(dataGridUsers.Rows[e.RowIndex].Cells[3].Value),
                    Role = (Role)(dataGridUsers.Rows[e.RowIndex].Cells[4].Value),
                    Name = Convert.ToString(dataGridUsers.Rows[e.RowIndex].Cells[5].Value),
                    Phone = Convert.ToString(dataGridUsers.Rows[e.RowIndex].Cells[6].Value),
                    Email = Convert.ToString(dataGridUsers.Rows[e.RowIndex].Cells[7].Value),
                    Birth = Convert.ToString(dataGridUsers.Rows[e.RowIndex].Cells[8].Value)
                };
                FormUser = new FormUser(Repository, this, user, Mode.Edit);
                FormUser.Show();
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
