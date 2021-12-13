using ISApteka.Database;
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


        public FormMain(Repository repository)
        {
            InitializeComponent();
            Repository = repository;

            buCatalog.Click += BuCatalog_Click;
            buEdit.Click += BuEdit_Click;
            FormClosed += FormMain_FormClosed;
        }

        private void BuEdit_Click(object sender, EventArgs e)
        {
            FormCatalog = new FormCatalog(Repository, Mode.Edit);
            this.Hide();
            FormCatalog.Show();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
        private void BuCatalog_Click(object sender, EventArgs e)
        {
            FormCatalog = new FormCatalog(Repository, Mode.Read);
            this.Hide();
            FormCatalog.Show();
        }
    }
}
