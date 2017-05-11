namespace FinalWork
{
    partial class Settings
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
            this.cancelButton.Text = "Отмена";
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
            this.accuracyUpDown.Location = new System.Drawing.Point(50, 50);
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
            this.timeUpDown.Location = new System.Drawing.Point(50, 85);
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
            this.saveCheckBox.Location = new System.Drawing.Point(50, 122);
            this.saveCheckBox.Name = "saveCheckBox";
            this.saveCheckBox.Size = new System.Drawing.Size(158, 17);
            this.saveCheckBox.TabIndex = 4;
            this.saveCheckBox.Text = " - сохранять копию отчёта";
            this.saveCheckBox.UseVisualStyleBackColor = true;
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.Location = new System.Drawing.Point(96, 52);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(122, 13);
            this.accuracyLabel.TabIndex = 5;
            this.accuracyLabel.Text = " - точность округления";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(96, 87);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(153, 13);
            this.timeLabel.TabIndex = 6;
            this.timeLabel.Text = " - период вывода статистики";
            // 
            // Settings
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(484, 211);
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
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
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
    }
}