
namespace ISApteka
{
    partial class FormCatalog
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
            this.dataGridMedicines = new System.Windows.Forms.DataGridView();
            this.buOrder = new System.Windows.Forms.Button();
            this.buAdd = new System.Windows.Forms.Button();
            this.teSearch = new System.Windows.Forms.TextBox();
            this.buSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMedicines)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridMedicines
            // 
            this.dataGridMedicines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridMedicines.BackgroundColor = System.Drawing.Color.White;
            this.dataGridMedicines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridMedicines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMedicines.GridColor = System.Drawing.Color.White;
            this.dataGridMedicines.Location = new System.Drawing.Point(12, 12);
            this.dataGridMedicines.Name = "dataGridMedicines";
            this.dataGridMedicines.RowTemplate.Height = 25;
            this.dataGridMedicines.ShowEditingIcon = false;
            this.dataGridMedicines.Size = new System.Drawing.Size(1170, 522);
            this.dataGridMedicines.TabIndex = 0;
            this.dataGridMedicines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMedicines_CellClick);
            // 
            // buOrder
            // 
            this.buOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buOrder.Location = new System.Drawing.Point(1049, 540);
            this.buOrder.Name = "buOrder";
            this.buOrder.Size = new System.Drawing.Size(133, 47);
            this.buOrder.TabIndex = 1;
            this.buOrder.Text = "ПЕРЕЙТИ К ЗАКАЗУ";
            this.buOrder.UseVisualStyleBackColor = true;
            // 
            // buAdd
            // 
            this.buAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buAdd.Location = new System.Drawing.Point(1049, 540);
            this.buAdd.Name = "buAdd";
            this.buAdd.Size = new System.Drawing.Size(133, 47);
            this.buAdd.TabIndex = 2;
            this.buAdd.Text = "ДОБАВИТЬ ЛС";
            this.buAdd.UseVisualStyleBackColor = true;
            // 
            // teSearch
            // 
            this.teSearch.Location = new System.Drawing.Point(13, 555);
            this.teSearch.Name = "teSearch";
            this.teSearch.PlaceholderText = "Наименование";
            this.teSearch.Size = new System.Drawing.Size(224, 23);
            this.teSearch.TabIndex = 3;
            // 
            // buSearch
            // 
            this.buSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buSearch.Location = new System.Drawing.Point(243, 540);
            this.buSearch.Name = "buSearch";
            this.buSearch.Size = new System.Drawing.Size(133, 47);
            this.buSearch.TabIndex = 4;
            this.buSearch.Text = "ПОИСК";
            this.buSearch.UseVisualStyleBackColor = true;
            // 
            // FormCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1194, 599);
            this.Controls.Add(this.buSearch);
            this.Controls.Add(this.teSearch);
            this.Controls.Add(this.buAdd);
            this.Controls.Add(this.buOrder);
            this.Controls.Add(this.dataGridMedicines);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FormCatalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "КАТАЛОГ ЛЕКАРСТВЕННЫХ СРЕДСТВ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMedicines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridMedicines;
        private System.Windows.Forms.Button buOrder;
        private System.Windows.Forms.Button buAdd;
        private System.Windows.Forms.TextBox teSearch;
        private System.Windows.Forms.Button buSearch;
    }
}