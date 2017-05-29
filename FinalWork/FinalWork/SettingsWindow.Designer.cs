namespace FinalWork
{
    partial class SettingsWindow
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.accuracyUpDown = new System.Windows.Forms.NumericUpDown();
            this.timeUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveCheckBox = new System.Windows.Forms.CheckBox();
            this.accuracyLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.columnsNameLabel = new System.Windows.Forms.Label();
            this.workTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.daysOffCheckBox = new System.Windows.Forms.CheckBox();
            this.tripDaysCheckBox = new System.Windows.Forms.CheckBox();
            this.sickDaysCheckBox = new System.Windows.Forms.CheckBox();
            this.tariffFactorСheckBox = new System.Windows.Forms.CheckBox();
            this.workRateCheckBox = new System.Windows.Forms.CheckBox();
            this.kCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(397, 176);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Выход";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(316, 176);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Сохранить";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // accuracyUpDown
            // 
            this.accuracyUpDown.Location = new System.Drawing.Point(50, 12);
            this.accuracyUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.accuracyUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.accuracyUpDown.Name = "accuracyUpDown";
            this.accuracyUpDown.Size = new System.Drawing.Size(40, 20);
            this.accuracyUpDown.TabIndex = 2;
            // 
            // timeUpDown
            // 
            this.timeUpDown.Increment = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.timeUpDown.Location = new System.Drawing.Point(50, 38);
            this.timeUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.timeUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.timeUpDown.Name = "timeUpDown";
            this.timeUpDown.Size = new System.Drawing.Size(40, 20);
            this.timeUpDown.TabIndex = 3;
            this.timeUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // saveCheckBox
            // 
            this.saveCheckBox.AutoSize = true;
            this.saveCheckBox.Location = new System.Drawing.Point(50, 64);
            this.saveCheckBox.Name = "saveCheckBox";
            this.saveCheckBox.Size = new System.Drawing.Size(158, 17);
            this.saveCheckBox.TabIndex = 4;
            this.saveCheckBox.Text = " - сохранять копию отчёта";
            this.saveCheckBox.UseVisualStyleBackColor = true;
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.Location = new System.Drawing.Point(96, 14);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(122, 13);
            this.accuracyLabel.TabIndex = 5;
            this.accuracyLabel.Text = " - точность округления";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(96, 40);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(153, 13);
            this.timeLabel.TabIndex = 6;
            this.timeLabel.Text = " - период вывода статистики";
            // 
            // columnsNameLabel
            // 
            this.columnsNameLabel.AutoSize = true;
            this.columnsNameLabel.Location = new System.Drawing.Point(50, 88);
            this.columnsNameLabel.Name = "columnsNameLabel";
            this.columnsNameLabel.Size = new System.Drawing.Size(281, 13);
            this.columnsNameLabel.TabIndex = 7;
            this.columnsNameLabel.Text = "Включить дополнительные колонки в бланке премий:";
            // 
            // workTimeCheckBox
            // 
            this.workTimeCheckBox.AutoSize = true;
            this.workTimeCheckBox.Location = new System.Drawing.Point(12, 105);
            this.workTimeCheckBox.Name = "workTimeCheckBox";
            this.workTimeCheckBox.Size = new System.Drawing.Size(94, 17);
            this.workTimeCheckBox.TabIndex = 8;
            this.workTimeCheckBox.Text = "Часы работы";
            this.workTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // daysOffCheckBox
            // 
            this.daysOffCheckBox.AutoSize = true;
            this.daysOffCheckBox.Location = new System.Drawing.Point(112, 105);
            this.daysOffCheckBox.Name = "daysOffCheckBox";
            this.daysOffCheckBox.Size = new System.Drawing.Size(99, 17);
            this.daysOffCheckBox.TabIndex = 9;
            this.daysOffCheckBox.Text = "Выходные дни";
            this.daysOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // tripDaysCheckBox
            // 
            this.tripDaysCheckBox.AutoSize = true;
            this.tripDaysCheckBox.Location = new System.Drawing.Point(217, 105);
            this.tripDaysCheckBox.Name = "tripDaysCheckBox";
            this.tripDaysCheckBox.Size = new System.Drawing.Size(141, 17);
            this.tripDaysCheckBox.TabIndex = 10;
            this.tripDaysCheckBox.Text = "Командировочные дни";
            this.tripDaysCheckBox.UseVisualStyleBackColor = true;
            // 
            // sickDaysCheckBox
            // 
            this.sickDaysCheckBox.AutoSize = true;
            this.sickDaysCheckBox.Location = new System.Drawing.Point(364, 105);
            this.sickDaysCheckBox.Name = "sickDaysCheckBox";
            this.sickDaysCheckBox.Size = new System.Drawing.Size(109, 17);
            this.sickDaysCheckBox.TabIndex = 11;
            this.sickDaysCheckBox.Text = "Больничные дни";
            this.sickDaysCheckBox.UseVisualStyleBackColor = true;
            // 
            // tariffFactorСheckBox
            // 
            this.tariffFactorСheckBox.AutoSize = true;
            this.tariffFactorСheckBox.Location = new System.Drawing.Point(12, 129);
            this.tariffFactorСheckBox.Name = "tariffFactorСheckBox";
            this.tariffFactorСheckBox.Size = new System.Drawing.Size(88, 17);
            this.tariffFactorСheckBox.TabIndex = 12;
            this.tariffFactorСheckBox.Text = "Тар. коэфф.";
            this.tariffFactorСheckBox.UseVisualStyleBackColor = true;
            // 
            // workRateCheckBox
            // 
            this.workRateCheckBox.AutoSize = true;
            this.workRateCheckBox.Location = new System.Drawing.Point(112, 128);
            this.workRateCheckBox.Name = "workRateCheckBox";
            this.workRateCheckBox.Size = new System.Drawing.Size(62, 17);
            this.workRateCheckBox.TabIndex = 13;
            this.workRateCheckBox.Text = "Ставка";
            this.workRateCheckBox.UseVisualStyleBackColor = true;
            // 
            // kCheckBox
            // 
            this.kCheckBox.AutoSize = true;
            this.kCheckBox.Location = new System.Drawing.Point(217, 129);
            this.kCheckBox.Name = "kCheckBox";
            this.kCheckBox.Size = new System.Drawing.Size(39, 17);
            this.kCheckBox.TabIndex = 14;
            this.kCheckBox.Text = "(K)";
            this.kCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsWindow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.kCheckBox);
            this.Controls.Add(this.workRateCheckBox);
            this.Controls.Add(this.tariffFactorСheckBox);
            this.Controls.Add(this.sickDaysCheckBox);
            this.Controls.Add(this.tripDaysCheckBox);
            this.Controls.Add(this.daysOffCheckBox);
            this.Controls.Add(this.workTimeCheckBox);
            this.Controls.Add(this.columnsNameLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.accuracyLabel);
            this.Controls.Add(this.saveCheckBox);
            this.Controls.Add(this.timeUpDown);
            this.Controls.Add(this.accuracyUpDown);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.accuracyUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown accuracyUpDown;
        private System.Windows.Forms.NumericUpDown timeUpDown;
        private System.Windows.Forms.CheckBox saveCheckBox;
        private System.Windows.Forms.Label accuracyLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label columnsNameLabel;
        private System.Windows.Forms.CheckBox workTimeCheckBox;
        private System.Windows.Forms.CheckBox daysOffCheckBox;
        private System.Windows.Forms.CheckBox tripDaysCheckBox;
        private System.Windows.Forms.CheckBox sickDaysCheckBox;
        private System.Windows.Forms.CheckBox tariffFactorСheckBox;
        private System.Windows.Forms.CheckBox workRateCheckBox;
        private System.Windows.Forms.CheckBox kCheckBox;
    }
}