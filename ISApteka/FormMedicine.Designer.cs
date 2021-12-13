
namespace ISApteka
{
    partial class FormMedicine
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
            this.teName = new System.Windows.Forms.TextBox();
            this.teAmount = new System.Windows.Forms.TextBox();
            this.teForm = new System.Windows.Forms.TextBox();
            this.teComposition = new System.Windows.Forms.TextBox();
            this.teInstruction = new System.Windows.Forms.TextBox();
            this.teDescription = new System.Windows.Forms.TextBox();
            this.chIsPrescription = new System.Windows.Forms.CheckBox();
            this.coBrand = new System.Windows.Forms.ComboBox();
            this.laName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tePlace = new System.Windows.Forms.TextBox();
            this.laBrand = new System.Windows.Forms.Label();
            this.laPlace = new System.Windows.Forms.Label();
            this.teTotal = new System.Windows.Forms.TextBox();
            this.laTotal = new System.Windows.Forms.Label();
            this.teCost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buConfirm = new System.Windows.Forms.Button();
            this.buDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(158, 12);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(1047, 23);
            this.teName.TabIndex = 0;
            // 
            // teAmount
            // 
            this.teAmount.Location = new System.Drawing.Point(158, 41);
            this.teAmount.Name = "teAmount";
            this.teAmount.Size = new System.Drawing.Size(1047, 23);
            this.teAmount.TabIndex = 1;
            // 
            // teForm
            // 
            this.teForm.Location = new System.Drawing.Point(158, 70);
            this.teForm.Name = "teForm";
            this.teForm.Size = new System.Drawing.Size(1047, 23);
            this.teForm.TabIndex = 2;
            // 
            // teComposition
            // 
            this.teComposition.Location = new System.Drawing.Point(158, 99);
            this.teComposition.Multiline = true;
            this.teComposition.Name = "teComposition";
            this.teComposition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.teComposition.Size = new System.Drawing.Size(1047, 120);
            this.teComposition.TabIndex = 3;
            // 
            // teInstruction
            // 
            this.teInstruction.Location = new System.Drawing.Point(158, 225);
            this.teInstruction.Multiline = true;
            this.teInstruction.Name = "teInstruction";
            this.teInstruction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.teInstruction.Size = new System.Drawing.Size(1047, 120);
            this.teInstruction.TabIndex = 4;
            // 
            // teDescription
            // 
            this.teDescription.Location = new System.Drawing.Point(158, 351);
            this.teDescription.Multiline = true;
            this.teDescription.Name = "teDescription";
            this.teDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.teDescription.Size = new System.Drawing.Size(1047, 120);
            this.teDescription.TabIndex = 5;
            // 
            // chIsPrescription
            // 
            this.chIsPrescription.AutoSize = true;
            this.chIsPrescription.Location = new System.Drawing.Point(158, 477);
            this.chIsPrescription.Name = "chIsPrescription";
            this.chIsPrescription.Size = new System.Drawing.Size(97, 19);
            this.chIsPrescription.TabIndex = 6;
            this.chIsPrescription.Text = "Рецептурное";
            this.chIsPrescription.UseVisualStyleBackColor = true;
            // 
            // coBrand
            // 
            this.coBrand.FormattingEnabled = true;
            this.coBrand.Location = new System.Drawing.Point(158, 502);
            this.coBrand.Name = "coBrand";
            this.coBrand.Size = new System.Drawing.Size(1047, 23);
            this.coBrand.TabIndex = 7;
            // 
            // laName
            // 
            this.laName.AutoSize = true;
            this.laName.Location = new System.Drawing.Point(14, 15);
            this.laName.Name = "laName";
            this.laName.Size = new System.Drawing.Size(91, 15);
            this.laName.TabIndex = 8;
            this.laName.Text = "Наименование:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Количество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Форма:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Состав:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Инструкция:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Показания:";
            // 
            // tePlace
            // 
            this.tePlace.Location = new System.Drawing.Point(158, 532);
            this.tePlace.Name = "tePlace";
            this.tePlace.Size = new System.Drawing.Size(1047, 23);
            this.tePlace.TabIndex = 14;
            // 
            // laBrand
            // 
            this.laBrand.AutoSize = true;
            this.laBrand.Location = new System.Drawing.Point(14, 505);
            this.laBrand.Name = "laBrand";
            this.laBrand.Size = new System.Drawing.Size(42, 15);
            this.laBrand.TabIndex = 15;
            this.laBrand.Text = "Брэнд:";
            // 
            // laPlace
            // 
            this.laPlace.AutoSize = true;
            this.laPlace.Location = new System.Drawing.Point(13, 535);
            this.laPlace.Name = "laPlace";
            this.laPlace.Size = new System.Drawing.Size(97, 15);
            this.laPlace.TabIndex = 16;
            this.laPlace.Text = "Место на складе:";
            // 
            // teTotal
            // 
            this.teTotal.Location = new System.Drawing.Point(158, 561);
            this.teTotal.Name = "teTotal";
            this.teTotal.Size = new System.Drawing.Size(1047, 23);
            this.teTotal.TabIndex = 17;
            // 
            // laTotal
            // 
            this.laTotal.AutoSize = true;
            this.laTotal.Location = new System.Drawing.Point(13, 564);
            this.laTotal.Name = "laTotal";
            this.laTotal.Size = new System.Drawing.Size(127, 15);
            this.laTotal.TabIndex = 18;
            this.laTotal.Text = "Количество на складе:";
            // 
            // teCost
            // 
            this.teCost.Location = new System.Drawing.Point(158, 590);
            this.teCost.Name = "teCost";
            this.teCost.Size = new System.Drawing.Size(1047, 23);
            this.teCost.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 593);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Цена:";
            // 
            // buConfirm
            // 
            this.buConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buConfirm.Location = new System.Drawing.Point(1083, 619);
            this.buConfirm.Name = "buConfirm";
            this.buConfirm.Size = new System.Drawing.Size(122, 50);
            this.buConfirm.TabIndex = 21;
            this.buConfirm.Text = "ИЗМЕНИТЬ";
            this.buConfirm.UseVisualStyleBackColor = true;
            // 
            // buDelete
            // 
            this.buDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buDelete.Location = new System.Drawing.Point(12, 619);
            this.buDelete.Name = "buDelete";
            this.buDelete.Size = new System.Drawing.Size(122, 50);
            this.buDelete.TabIndex = 22;
            this.buDelete.Text = "УДАЛИТЬ";
            this.buDelete.UseVisualStyleBackColor = true;
            // 
            // FormMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1217, 680);
            this.Controls.Add(this.buDelete);
            this.Controls.Add(this.buConfirm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.teCost);
            this.Controls.Add(this.laTotal);
            this.Controls.Add(this.teTotal);
            this.Controls.Add(this.laPlace);
            this.Controls.Add(this.laBrand);
            this.Controls.Add(this.tePlace);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.laName);
            this.Controls.Add(this.coBrand);
            this.Controls.Add(this.chIsPrescription);
            this.Controls.Add(this.teDescription);
            this.Controls.Add(this.teInstruction);
            this.Controls.Add(this.teComposition);
            this.Controls.Add(this.teForm);
            this.Controls.Add(this.teAmount);
            this.Controls.Add(this.teName);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ЛЕКАРСТВЕННОЕ СРЕДСТВО";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teName;
        private System.Windows.Forms.TextBox teAmount;
        private System.Windows.Forms.TextBox teForm;
        private System.Windows.Forms.TextBox teComposition;
        private System.Windows.Forms.TextBox teInstruction;
        private System.Windows.Forms.TextBox teDescription;
        private System.Windows.Forms.CheckBox chIsPrescription;
        private System.Windows.Forms.ComboBox coBrand;
        private System.Windows.Forms.Label laName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tePlace;
        private System.Windows.Forms.Label laBrand;
        private System.Windows.Forms.Label laPlace;
        private System.Windows.Forms.TextBox teTotal;
        private System.Windows.Forms.Label laTotal;
        private System.Windows.Forms.TextBox teCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buConfirm;
        private System.Windows.Forms.Button buDelete;
    }
}