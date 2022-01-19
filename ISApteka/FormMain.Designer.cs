
namespace ISApteka
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buCatalog = new System.Windows.Forms.Button();
            this.buEdit = new System.Windows.Forms.Button();
            this.buReport = new System.Windows.Forms.Button();
            this.buAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buCatalog
            // 
            this.buCatalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buCatalog.Location = new System.Drawing.Point(90, 58);
            this.buCatalog.Name = "buCatalog";
            this.buCatalog.Size = new System.Drawing.Size(211, 36);
            this.buCatalog.TabIndex = 0;
            this.buCatalog.Text = "КАТАЛОГ ЛС";
            this.buCatalog.UseVisualStyleBackColor = true;
            // 
            // buEdit
            // 
            this.buEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buEdit.Location = new System.Drawing.Point(90, 189);
            this.buEdit.Name = "buEdit";
            this.buEdit.Size = new System.Drawing.Size(211, 36);
            this.buEdit.TabIndex = 2;
            this.buEdit.Text = "УПРАВЛЕНИЕ ЛС";
            this.buEdit.UseVisualStyleBackColor = true;
            // 
            // buReport
            // 
            this.buReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buReport.Location = new System.Drawing.Point(90, 125);
            this.buReport.Name = "buReport";
            this.buReport.Size = new System.Drawing.Size(211, 36);
            this.buReport.TabIndex = 1;
            this.buReport.Text = "СОСТАВИТЬ ОТЧЕТ";
            this.buReport.UseVisualStyleBackColor = true;
            // 
            // buAdmin
            // 
            this.buAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buAdmin.Location = new System.Drawing.Point(90, 255);
            this.buAdmin.Name = "buAdmin";
            this.buAdmin.Size = new System.Drawing.Size(211, 36);
            this.buAdmin.TabIndex = 3;
            this.buAdmin.Text = "АДМИНИСТРАЦИОННАЯ ПАНЕЛЬ";
            this.buAdmin.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 370);
            this.Controls.Add(this.buAdmin);
            this.Controls.Add(this.buReport);
            this.Controls.Add(this.buEdit);
            this.Controls.Add(this.buCatalog);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximumSize = new System.Drawing.Size(416, 409);
            this.MinimumSize = new System.Drawing.Size(416, 409);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ГЛАВНОЕ МЕНЮ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buCatalog;
        private System.Windows.Forms.Button buEdit;
        private System.Windows.Forms.Button buReport;
        private System.Windows.Forms.Button buAdmin;
    }
}