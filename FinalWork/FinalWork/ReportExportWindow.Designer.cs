namespace FinalWork
{
    partial class ReportExportWindow
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
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.reportListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(166, 226);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "Экспорт";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(247, 226);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // reportListBox
            // 
            this.reportListBox.Location = new System.Drawing.Point(13, 13);
            this.reportListBox.Name = "reportListBox";
            this.reportListBox.Size = new System.Drawing.Size(309, 199);
            this.reportListBox.TabIndex = 2;
            // 
            // ReportExportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.reportListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "ReportExportWindow";
            this.Text = "ReportExportWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox reportListBox;
    }
}