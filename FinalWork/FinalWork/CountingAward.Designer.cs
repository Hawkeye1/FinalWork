namespace FinalWork
{
    partial class CountingAward
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ImportStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportStaffStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportWorkTimeStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.tempGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ImportStrip
            // 
            this.ImportStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportStaffStrip,
            this.ImportWorkTimeStrip});
            this.ImportStrip.Name = "ImportStrip";
            this.ImportStrip.Size = new System.Drawing.Size(63, 20);
            this.ImportStrip.Text = "Импорт";
            // 
            // ImportStaffStrip
            // 
            this.ImportStaffStrip.Name = "ImportStaffStrip";
            this.ImportStaffStrip.Size = new System.Drawing.Size(232, 22);
            this.ImportStaffStrip.Text = "Импорт списка сотрудников";
            this.ImportStaffStrip.Click += new System.EventHandler(this.ImportStaff_Click);
            // 
            // ImportWorkTimeStrip
            // 
            this.ImportWorkTimeStrip.Name = "ImportWorkTimeStrip";
            this.ImportWorkTimeStrip.Size = new System.Drawing.Size(232, 22);
            this.ImportWorkTimeStrip.Text = "Импорт рабочего времени";
            // 
            // tempGrid
            // 
            this.tempGrid.AllowUserToAddRows = false;
            this.tempGrid.AllowUserToDeleteRows = false;
            this.tempGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tempGrid.Location = new System.Drawing.Point(13, 28);
            this.tempGrid.MinimumSize = new System.Drawing.Size(500, 300);
            this.tempGrid.Name = "tempGrid";
            this.tempGrid.ReadOnly = true;
            this.tempGrid.Size = new System.Drawing.Size(500, 300);
            this.tempGrid.TabIndex = 1;
            // 
            // CountingAward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tempGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "CountingAward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CountingAward";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ImportStrip;
        private System.Windows.Forms.ToolStripMenuItem ImportStaffStrip;
        private System.Windows.Forms.ToolStripMenuItem ImportWorkTimeStrip;
        private System.Windows.Forms.DataGridView tempGrid;
    }
}

