using ISApteka.Database;
using ISApteka.Database.Models;
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
using static ISApteka.Entities.Enums;

namespace ISApteka
{
    public partial class FormMain : Form
    {
        private FormCatalog FormCatalog { get; set; }
        private FormAdmin FormAdmin { get; set; }
        private FormReports FormReports{ get; set; }
        private Repository Repository { get; set; }
        private User User { get; set; }


        public FormMain(User user, Repository repository)
        {
            InitializeComponent();

            Repository = repository;
            User = user;
            if (user.Role != Role.Admin)
            {
                buAdmin.Visible = false;
            }
            if (user.Role == Role.Pharmacist)
            {
                buEdit.Visible = false;
            }

            buCatalog.Click += BuCatalog_Click;
            buReport.Click += BuReport_Click;
            buEdit.Click += BuEdit_Click;
            buAdmin.Click += BuAdmin_Click;
            FormClosed += FormMain_FormClosed;
        }


        private void BuReport_Click(object sender, EventArgs e)
        {
            FormReports = new FormReports(User, Repository);
            this.Hide();
            FormReports.Show();
        }

        
        private void BuAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin = new FormAdmin(User, Repository);
            this.Hide();
            FormAdmin.Show();
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
