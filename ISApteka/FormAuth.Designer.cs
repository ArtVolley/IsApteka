
namespace ISApteka
{
    partial class FormAuth
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buAuth = new System.Windows.Forms.Button();
            this.teLogin = new System.Windows.Forms.TextBox();
            this.tePassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buAuth
            // 
            this.buAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buAuth.Location = new System.Drawing.Point(118, 145);
            this.buAuth.Name = "buAuth";
            this.buAuth.Size = new System.Drawing.Size(141, 23);
            this.buAuth.TabIndex = 2;
            this.buAuth.Text = "ВОЙТИ";
            this.buAuth.UseVisualStyleBackColor = true;
            // 
            // teLogin
            // 
            this.teLogin.Location = new System.Drawing.Point(118, 87);
            this.teLogin.MaximumSize = new System.Drawing.Size(141, 23);
            this.teLogin.MinimumSize = new System.Drawing.Size(141, 23);
            this.teLogin.Name = "teLogin";
            this.teLogin.PlaceholderText = "Логин";
            this.teLogin.Size = new System.Drawing.Size(141, 23);
            this.teLogin.TabIndex = 0;
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(118, 116);
            this.tePassword.Name = "tePassword";
            this.tePassword.PlaceholderText = "Пароль";
            this.tePassword.Size = new System.Drawing.Size(141, 23);
            this.tePassword.TabIndex = 1;
            // 
            // FormAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 232);
            this.Controls.Add(this.tePassword);
            this.Controls.Add(this.teLogin);
            this.Controls.Add(this.buAuth);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ВХОД В СИСТЕМУ \"ISApteka\"";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buAuth;
        private System.Windows.Forms.TextBox teLogin;
        private System.Windows.Forms.TextBox tePassword;
    }
}

