
namespace ISApteka
{
    partial class FormAdmin
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
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.buAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridUsers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Location = new System.Drawing.Point(12, 12);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.RowTemplate.Height = 25;
            this.dataGridUsers.Size = new System.Drawing.Size(1331, 662);
            this.dataGridUsers.TabIndex = 0;
            // 
            // buAdd
            // 
            this.buAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buAdd.Location = new System.Drawing.Point(1210, 680);
            this.buAdd.Name = "buAdd";
            this.buAdd.Size = new System.Drawing.Size(133, 47);
            this.buAdd.TabIndex = 3;
            this.buAdd.Text = "ДОБАВИТЬ";
            this.buAdd.UseVisualStyleBackColor = true;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1355, 739);
            this.Controls.Add(this.buAdd);
            this.Controls.Add(this.dataGridUsers);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АДМИНКА";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUsers;
        private System.Windows.Forms.Button buAdd;
    }
}