using ISApteka.Database;
using ISApteka.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISApteka
{
    public partial class FormAuth : Form
    {
        private Thread Thread { get; set; }
        public Repository Repository { get; }
        public User User { get; set; }


        public FormAuth()
        {
            InitializeComponent();

            Repository = new Repository();
            tePassword.UseSystemPasswordChar = true;

            buAuth.Click += BuAuth_Click;
        }


        // bu auth click 
        private async void BuAuth_Click(object sender, EventArgs e)
        {
            User = await Repository.GetUserByLoginAndPasswodInUsers(teLogin.Text, tePassword.Text);
            if (User == null)
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
            else
            {               
                this.Close();

                Thread = new Thread(OpenCatalog);
                Thread.SetApartmentState(ApartmentState.STA);
                Thread.Start();
            }
        }


        private void OpenCatalog()
        {
            Application.Run(new FormMain(User, Repository));
        }

    }
}
