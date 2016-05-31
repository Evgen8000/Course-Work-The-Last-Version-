namespace Kursovaya.View
{
    partial class WorkerAdd
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
            this.Position = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SecondName = new System.Windows.Forms.TextBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.Year = new System.Windows.Forms.TextBox();
            this.Month = new System.Windows.Forms.TextBox();
            this.Day = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.Add_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Position
            // 
            this.Position.FormattingEnabled = true;
            this.Position.Items.AddRange(new object[] {
            "Повар",
            "Охранник",
            "Наблюдатель",
            "Бухгалтер",
            "Заведующий",
            "Директор"});
            this.Position.Location = new System.Drawing.Point(3, 141);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(273, 21);
            this.Position.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Должность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Имя";
            // 
            // SecondName
            // 
            this.SecondName.Location = new System.Drawing.Point(3, 61);
            this.SecondName.Name = "SecondName";
            this.SecondName.Size = new System.Drawing.Size(273, 20);
            this.SecondName.TabIndex = 23;
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(3, 22);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(273, 20);
            this.FirstName.TabIndex = 22;
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(158, 101);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(95, 20);
            this.Year.TabIndex = 34;
            // 
            // Month
            // 
            this.Month.Location = new System.Drawing.Point(83, 101);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(69, 20);
            this.Month.TabIndex = 33;
            // 
            // Day
            // 
            this.Day.Location = new System.Drawing.Point(8, 101);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(69, 20);
            this.Day.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Дата наема (ДД/ММ/ГГГГ)";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(177, 168);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 23);
            this.cancelButton.TabIndex = 36;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(3, 168);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(99, 23);
            this.Add_button.TabIndex = 35;
            this.Add_button.Text = "Принять";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // WorkerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 196);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.Day);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Position);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SecondName);
            this.Controls.Add(this.FirstName);
            this.Name = "WorkerAdd";
            this.Text = "WorkerAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Position;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SecondName;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox Year;
        private System.Windows.Forms.TextBox Month;
        private System.Windows.Forms.TextBox Day;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button Add_button;
    }
}