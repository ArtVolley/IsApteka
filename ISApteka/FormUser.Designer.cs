
namespace ISApteka
{
    partial class FormUser
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
            this.buConfirm = new System.Windows.Forms.Button();
            this.buDelete = new System.Windows.Forms.Button();
            this.laRole = new System.Windows.Forms.Label();
            this.laPass = new System.Windows.Forms.Label();
            this.laLogin = new System.Windows.Forms.Label();
            this.tePass = new System.Windows.Forms.TextBox();
            this.teLogin = new System.Windows.Forms.TextBox();
            this.laEmail = new System.Windows.Forms.Label();
            this.laPhone = new System.Windows.Forms.Label();
            this.laName = new System.Windows.Forms.Label();
            this.teEmail = new System.Windows.Forms.TextBox();
            this.tePhone = new System.Windows.Forms.TextBox();
            this.teName = new System.Windows.Forms.TextBox();
            this.laBirth = new System.Windows.Forms.Label();
            this.coRole = new System.Windows.Forms.ComboBox();
            this.daBirth = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // buConfirm
            // 
            this.buConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buConfirm.Location = new System.Drawing.Point(637, 236);
            this.buConfirm.Name = "buConfirm";
            this.buConfirm.Size = new System.Drawing.Size(122, 50);
            this.buConfirm.TabIndex = 22;
            this.buConfirm.Text = "ИЗМЕНИТЬ";
            this.buConfirm.UseVisualStyleBackColor = true;
            // 
            // buDelete
            // 
            this.buDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buDelete.Location = new System.Drawing.Point(12, 236);
            this.buDelete.Name = "buDelete";
            this.buDelete.Size = new System.Drawing.Size(122, 50);
            this.buDelete.TabIndex = 23;
            this.buDelete.Text = "УДАЛИТЬ";
            this.buDelete.UseVisualStyleBackColor = true;
            // 
            // laRole
            // 
            this.laRole.AutoSize = true;
            this.laRole.Location = new System.Drawing.Point(15, 73);
            this.laRole.Name = "laRole";
            this.laRole.Size = new System.Drawing.Size(36, 15);
            this.laRole.TabIndex = 29;
            this.laRole.Text = "Роль:";
            // 
            // laPass
            // 
            this.laPass.AutoSize = true;
            this.laPass.Location = new System.Drawing.Point(15, 44);
            this.laPass.Name = "laPass";
            this.laPass.Size = new System.Drawing.Size(58, 15);
            this.laPass.TabIndex = 28;
            this.laPass.Text = "Пароль: *";
            // 
            // laLogin
            // 
            this.laLogin.AutoSize = true;
            this.laLogin.Location = new System.Drawing.Point(15, 15);
            this.laLogin.Name = "laLogin";
            this.laLogin.Size = new System.Drawing.Size(51, 15);
            this.laLogin.TabIndex = 27;
            this.laLogin.Text = "Логин: *";
            // 
            // tePass
            // 
            this.tePass.Location = new System.Drawing.Point(128, 41);
            this.tePass.Name = "tePass";
            this.tePass.Size = new System.Drawing.Size(631, 23);
            this.tePass.TabIndex = 25;
            // 
            // teLogin
            // 
            this.teLogin.Location = new System.Drawing.Point(128, 12);
            this.teLogin.Name = "teLogin";
            this.teLogin.Size = new System.Drawing.Size(631, 23);
            this.teLogin.TabIndex = 24;
            // 
            // laEmail
            // 
            this.laEmail.AutoSize = true;
            this.laEmail.Location = new System.Drawing.Point(15, 160);
            this.laEmail.Name = "laEmail";
            this.laEmail.Size = new System.Drawing.Size(43, 15);
            this.laEmail.TabIndex = 35;
            this.laEmail.Text = "Почта:";
            // 
            // laPhone
            // 
            this.laPhone.AutoSize = true;
            this.laPhone.Location = new System.Drawing.Point(15, 131);
            this.laPhone.Name = "laPhone";
            this.laPhone.Size = new System.Drawing.Size(55, 15);
            this.laPhone.TabIndex = 34;
            this.laPhone.Text = "Телефон:";
            // 
            // laName
            // 
            this.laName.AutoSize = true;
            this.laName.Location = new System.Drawing.Point(15, 102);
            this.laName.Name = "laName";
            this.laName.Size = new System.Drawing.Size(45, 15);
            this.laName.TabIndex = 33;
            this.laName.Text = "ФИО: *";
            // 
            // teEmail
            // 
            this.teEmail.Location = new System.Drawing.Point(128, 157);
            this.teEmail.Name = "teEmail";
            this.teEmail.Size = new System.Drawing.Size(631, 23);
            this.teEmail.TabIndex = 32;
            // 
            // tePhone
            // 
            this.tePhone.Location = new System.Drawing.Point(128, 128);
            this.tePhone.Name = "tePhone";
            this.tePhone.Size = new System.Drawing.Size(631, 23);
            this.tePhone.TabIndex = 31;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(128, 99);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(631, 23);
            this.teName.TabIndex = 30;
            // 
            // laBirth
            // 
            this.laBirth.AutoSize = true;
            this.laBirth.Location = new System.Drawing.Point(15, 189);
            this.laBirth.Name = "laBirth";
            this.laBirth.Size = new System.Drawing.Size(92, 15);
            this.laBirth.TabIndex = 37;
            this.laBirth.Text = "Дата рождения:";
            // 
            // coRole
            // 
            this.coRole.FormattingEnabled = true;
            this.coRole.Location = new System.Drawing.Point(128, 70);
            this.coRole.Name = "coRole";
            this.coRole.Size = new System.Drawing.Size(631, 23);
            this.coRole.TabIndex = 38;
            // 
            // daBirth
            // 
            this.daBirth.Location = new System.Drawing.Point(128, 186);
            this.daBirth.Name = "daBirth";
            this.daBirth.Size = new System.Drawing.Size(631, 23);
            this.daBirth.TabIndex = 39;
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(771, 298);
            this.Controls.Add(this.daBirth);
            this.Controls.Add(this.coRole);
            this.Controls.Add(this.laBirth);
            this.Controls.Add(this.laEmail);
            this.Controls.Add(this.laPhone);
            this.Controls.Add(this.laName);
            this.Controls.Add(this.teEmail);
            this.Controls.Add(this.tePhone);
            this.Controls.Add(this.teName);
            this.Controls.Add(this.laRole);
            this.Controls.Add(this.laPass);
            this.Controls.Add(this.laLogin);
            this.Controls.Add(this.tePass);
            this.Controls.Add(this.teLogin);
            this.Controls.Add(this.buDelete);
            this.Controls.Add(this.buConfirm);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximumSize = new System.Drawing.Size(787, 337);
            this.MinimumSize = new System.Drawing.Size(787, 337);
            this.Name = "FormUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ПОЛЬЗОВАТЕЛЬ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buConfirm;
        private System.Windows.Forms.Button buDelete;
        private System.Windows.Forms.Label laRole;
        private System.Windows.Forms.Label laPass;
        private System.Windows.Forms.Label laLogin;
        private System.Windows.Forms.TextBox tePass;
        private System.Windows.Forms.TextBox teLogin;
        private System.Windows.Forms.Label laEmail;
        private System.Windows.Forms.Label laPhone;
        private System.Windows.Forms.Label laName;
        private System.Windows.Forms.TextBox teEmail;
        private System.Windows.Forms.TextBox tePhone;
        private System.Windows.Forms.TextBox teName;
        private System.Windows.Forms.Label laBirth;
        private System.Windows.Forms.ComboBox coRole;
        private System.Windows.Forms.DateTimePicker daBirth;
    }
}