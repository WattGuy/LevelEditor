namespace NextStep
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dlcBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.targetsData = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.addTypeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addNumberBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.stepsBox = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.onBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.targetsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addNumberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // typeBox
            // 
            this.typeBox.DisplayMember = "0";
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "РАНДОМ",
            "ГОЛУБОЙ",
            "ЗЕЛЕНЫЙ",
            "РОЗОВЫЙ",
            "ОРАНЖЕВЫЙ",
            "СВЕТЛО ЗЕЛЕНЫЙ",
            "ЦЕМЕНТ"});
            this.typeBox.Location = new System.Drawing.Point(478, 25);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(312, 21);
            this.typeBox.TabIndex = 2;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тип";
            // 
            // dlcBox
            // 
            this.dlcBox.DisplayMember = "0";
            this.dlcBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dlcBox.FormattingEnabled = true;
            this.dlcBox.Items.AddRange(new object[] {
            "ОТСУТСТВУЕТ",
            "РАСПАД",
            "ГОРИЗОНТАЛЬ",
            "ВЕРТИКАЛЬ",
            "БОМБА"});
            this.dlcBox.Location = new System.Drawing.Point(478, 78);
            this.dlcBox.Name = "dlcBox";
            this.dlcBox.Size = new System.Drawing.Size(312, 21);
            this.dlcBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дополнение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Цели";
            // 
            // targetsData
            // 
            this.targetsData.AllowUserToAddRows = false;
            this.targetsData.AllowUserToDeleteRows = false;
            this.targetsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.targetsData.Location = new System.Drawing.Point(478, 176);
            this.targetsData.Name = "targetsData";
            this.targetsData.ReadOnly = true;
            this.targetsData.RowHeadersVisible = false;
            this.targetsData.Size = new System.Drawing.Size(312, 190);
            this.targetsData.TabIndex = 7;
            this.targetsData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.targetsData_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(475, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Тип";
            // 
            // addTypeBox
            // 
            this.addTypeBox.DisplayMember = "0";
            this.addTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addTypeBox.FormattingEnabled = true;
            this.addTypeBox.Location = new System.Drawing.Point(478, 394);
            this.addTypeBox.Name = "addTypeBox";
            this.addTypeBox.Size = new System.Drawing.Size(127, 21);
            this.addTypeBox.TabIndex = 8;
            this.addTypeBox.SelectedIndexChanged += new System.EventHandler(this.addTypeBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(611, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Количество";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(717, 392);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(32, 23);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addButton_MouseClick);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(758, 392);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(32, 23);
            this.removeButton.TabIndex = 13;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.removeButton_MouseClick);
            // 
            // addNumberBox
            // 
            this.addNumberBox.Location = new System.Drawing.Point(611, 394);
            this.addNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.addNumberBox.Name = "addNumberBox";
            this.addNumberBox.Size = new System.Drawing.Size(100, 20);
            this.addNumberBox.TabIndex = 14;
            this.addNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ходы";
            // 
            // stepsBox
            // 
            this.stepsBox.Location = new System.Drawing.Point(478, 441);
            this.stepsBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepsBox.Name = "stepsBox";
            this.stepsBox.Size = new System.Drawing.Size(312, 20);
            this.stepsBox.TabIndex = 16;
            this.stepsBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(478, 489);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(145, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.saveButton_MouseClick);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(645, 489);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(145, 23);
            this.openButton.TabIndex = 18;
            this.openButton.Text = "Открыть";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openButton_MouseClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.AddExtension = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(475, 473);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Файл";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(475, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Наложение";
            // 
            // onBox
            // 
            this.onBox.DisplayMember = "0";
            this.onBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.onBox.FormattingEnabled = true;
            this.onBox.Items.AddRange(new object[] {
            "ОТСУТСТВУЕТ",
            "ЛЁД"});
            this.onBox.Location = new System.Drawing.Point(478, 127);
            this.onBox.Name = "onBox";
            this.onBox.Size = new System.Drawing.Size(312, 21);
            this.onBox.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 536);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.onBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.stepsBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addNumberBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addTypeBox);
            this.Controls.Add(this.targetsData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dlcBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LevelEditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dot_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dot_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dot_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.targetsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addNumberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dlcBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView targetsData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox addTypeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.NumericUpDown addNumberBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown stepsBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox onBox;
    }
}

