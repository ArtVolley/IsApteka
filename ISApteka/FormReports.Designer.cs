
namespace ISApteka
{
    partial class FormReports
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
            this.buMonth = new System.Windows.Forms.Button();
            this.buGeneral = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buMonth
            // 
            this.buMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buMonth.Location = new System.Drawing.Point(125, 201);
            this.buMonth.Name = "buMonth";
            this.buMonth.Size = new System.Drawing.Size(151, 36);
            this.buMonth.TabIndex = 3;
            this.buMonth.Text = "ОТЧЕТ ЗА МЕСЯЦ";
            this.buMonth.UseVisualStyleBackColor = true;
            // 
            // buGeneral
            // 
            this.buGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buGeneral.Location = new System.Drawing.Point(125, 134);
            this.buGeneral.Name = "buGeneral";
            this.buGeneral.Size = new System.Drawing.Size(151, 36);
            this.buGeneral.TabIndex = 2;
            this.buGeneral.Text = "ОБЩИЙ ОТЧЕТ";
            this.buGeneral.UseVisualStyleBackColor = true;
            // 
            // FormReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 370);
            this.Controls.Add(this.buMonth);
            this.Controls.Add(this.buGeneral);
            this.MaximumSize = new System.Drawing.Size(416, 409);
            this.MinimumSize = new System.Drawing.Size(416, 409);
            this.Name = "FormReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buMonth;
        private System.Windows.Forms.Button buGeneral;
    }
}