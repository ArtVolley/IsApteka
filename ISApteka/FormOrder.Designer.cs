
namespace ISApteka
{
    partial class FormOrder
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
            this.dataGridOrder = new System.Windows.Forms.DataGridView();
            this.buOrder = new System.Windows.Forms.Button();
            this.laTotalCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridOrder
            // 
            this.dataGridOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOrder.BackgroundColor = System.Drawing.Color.White;
            this.dataGridOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrder.Location = new System.Drawing.Point(12, 12);
            this.dataGridOrder.Name = "dataGridOrder";
            this.dataGridOrder.RowTemplate.Height = 25;
            this.dataGridOrder.Size = new System.Drawing.Size(1258, 585);
            this.dataGridOrder.TabIndex = 0;
            this.dataGridOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrder_CellClick);
            this.dataGridOrder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrder_CellEndEdit);
            // 
            // buOrder
            // 
            this.buOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buOrder.Location = new System.Drawing.Point(1133, 603);
            this.buOrder.Name = "buOrder";
            this.buOrder.Size = new System.Drawing.Size(137, 46);
            this.buOrder.TabIndex = 1;
            this.buOrder.Text = "ПРОВЕСТИ ОПЛАТУ";
            this.buOrder.UseVisualStyleBackColor = true;
            // 
            // laTotalCost
            // 
            this.laTotalCost.AutoSize = true;
            this.laTotalCost.Location = new System.Drawing.Point(12, 619);
            this.laTotalCost.Name = "laTotalCost";
            this.laTotalCost.Size = new System.Drawing.Size(42, 15);
            this.laTotalCost.TabIndex = 2;
            this.laTotalCost.Text = "ИТОГ: ";
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1282, 661);
            this.Controls.Add(this.laTotalCost);
            this.Controls.Add(this.buOrder);
            this.Controls.Add(this.dataGridOrder);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ЗАКАЗ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridOrder;
        private System.Windows.Forms.Button buOrder;
        private System.Windows.Forms.Label laTotalCost;
    }
}