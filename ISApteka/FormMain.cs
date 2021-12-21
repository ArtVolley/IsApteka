using ISApteka.Database;
using ISApteka.Database.Models;
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
    public partial class FormMain : Form
    {
        private FormCatalog FormCatalog { get; set; }
        private Repository Repository { get; set; }
        private User User { get; set; }


        public FormMain(User user, Repository repository)
        {
            InitializeComponent();

            Repository = repository;
            User = user;

            buCatalog.Click += BuCatalog_Click;
            buEdit.Click += BuEdit_Click;
            FormClosed += FormMain_FormClosed;
        }

        private void BuEdit_Click(object sender, EventArgs e)
        {
            FormCatalog = new FormCatalog(User, Repository, Mode.Edit);
            this.Hide();
            FormCatalog.Show();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
        private void BuCatalog_Click(object sender, EventArgs e)
        {
            FormCatalog = new FormCatalog(User, Repository, Mode.Read);
            this.Hide();
            FormCatalog.Show();
        }
    }
}
