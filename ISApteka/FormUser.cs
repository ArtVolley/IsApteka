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
    public partial class FormUser : Form
    {
        private FormAdmin FormAdmin{ get; set; }
        private User User { get; set; }
        private Repository Repository { get; }
        private Mode Mode { get; set; }


        public FormUser(Repository repository, FormAdmin formAdmin, User user, Mode mode)
        {
            InitializeComponent();

            Repository = repository;
            FormAdmin = formAdmin;
            User = user;
            Mode = mode;

            if (Mode == Mode.Add)
            {
                buConfirm.Text = "Добавить";
                buDelete.Visible = false;
            }
            Task.Run(() => this.InintializeUser(user)).Wait();
            buConfirm.Click += BuConfirm_Click;
            buDelete.Click += BuDelete_Click;
        }

        private async void BuDelete_Click(object sender, EventArgs e)
        {
            await Repository.DeleteByIdIntoUsers(User.Id);
            await FormAdmin.DataBinding();
            this.Hide();
        }

        private async void BuConfirm_Click(object sender, EventArgs e)
        {
            if (Mode == Mode.Add)
            {
                await CreateUser();
            }
            else if (Mode == Mode.Edit)
            {
                await UpdateUser(User.Id);
            }
            await FormAdmin.DataBinding();
            this.Hide();
        }


        private async Task UpdateUser(int userId)
        {
            var selectedItem = (Role)coRole.SelectedItem;
            User updateUser = new()
            {
                Id = userId,
                Login = teLogin.Text,
                Password = tePass.Text,
                Role = selectedItem,
                Name = teName.Text,
                Phone = tePhone.Text,
                Email = teEmail.Text,
                Birth = daBirth.Value.ToString("dd.MM.yyyy"),

            };

            await Repository.UpdateByIdIntoUsers(updateUser);;
        }


        private async Task CreateUser()
        {
            var selectedItem = (Role)coRole.SelectedItem;
            User createUser = new()
            {
                Login = teLogin.Text,
                Password = tePass.Text,
                Role = (Role)selectedItem,
                Name = teName.Text,
                Phone = tePhone.Text,
                Email = teEmail.Text,
                Birth = daBirth.Value.ToString("dd.MM.yyyy"),

            };

            await Repository.CreateIntoUsers(createUser); ;
        }


        private async Task InintializeUser(User user)
        {
            try
            {
                // comboBox insert
                foreach (var role in Enum.GetValues(typeof(Role)))
                {
                    coRole.Items.Add(role);
                }

                // edit or read
                if (Mode != Mode.Add)
                {
                    teLogin.Text = user.Login;
                    tePass.Text = user.Password;
                    teName.Text = user.Name;
                    tePhone.Text = user.Phone;
                    teEmail.Text = user.Email;
                    
                    if (user.Birth != "")
                    {
                        daBirth.Value = Convert.ToDateTime(user.Birth);
                    }

                    coRole.SelectedItem = user.Role;
                }

                if (Mode == Mode.Add)
                {
                    coRole.SelectedItem = Role.Pharmacist;

                    daBirth.Value = Convert.ToDateTime("01.01.1800");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
