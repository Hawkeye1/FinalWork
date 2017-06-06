﻿namespace FinalWork
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BlankStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportExportStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.membersDataGridView = new System.Windows.Forms.DataGridView();
            this.memberZedGraphControl = new ZedGraph.ZedGraphControl();
            this.premiumZedGraphControl = new ZedGraph.ZedGraphControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BlankStrip,
            this.ReportExportStrip,
            this.SettingStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BlankStrip
            // 
            this.BlankStrip.Name = "BlankStrip";
            this.BlankStrip.Size = new System.Drawing.Size(51, 20);
            this.BlankStrip.Text = "Отчёт";
            this.BlankStrip.Click += new System.EventHandler(this.BlankStrip_Click);
            // 
            // ReportExportStrip
            // 
            this.ReportExportStrip.Name = "ReportExportStrip";
            this.ReportExportStrip.Size = new System.Drawing.Size(103, 20);
            this.ReportExportStrip.Text = "Экспорт отчёта";
            this.ReportExportStrip.Click += new System.EventHandler(this.ReportExportStrip_Click);
            // 
            // SettingStrip
            // 
            this.SettingStrip.Name = "SettingStrip";
            this.SettingStrip.Size = new System.Drawing.Size(79, 20);
            this.SettingStrip.Text = "Настройки";
            this.SettingStrip.Click += new System.EventHandler(this.SettingStrip_Click);
            // 
            // membersDataGridView
            // 
            this.membersDataGridView.AllowUserToAddRows = false;
            this.membersDataGridView.AllowUserToDeleteRows = false;
            this.membersDataGridView.AllowUserToResizeColumns = false;
            this.membersDataGridView.AllowUserToResizeRows = false;
            this.membersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.membersDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.membersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.membersDataGridView.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.membersDataGridView.Location = new System.Drawing.Point(13, 28);
            this.membersDataGridView.MaximumSize = new System.Drawing.Size(300, 521);
            this.membersDataGridView.MinimumSize = new System.Drawing.Size(300, 521);
            this.membersDataGridView.MultiSelect = false;
            this.membersDataGridView.Name = "membersDataGridView";
            this.membersDataGridView.ReadOnly = true;
            this.membersDataGridView.RowHeadersWidth = 150;
            this.membersDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.membersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.membersDataGridView.Size = new System.Drawing.Size(300, 521);
            this.membersDataGridView.TabIndex = 1;
            // 
            // memberZedGraphControl
            // 
            this.memberZedGraphControl.IsShowPointValues = false;
            this.memberZedGraphControl.Location = new System.Drawing.Point(320, 28);
            this.memberZedGraphControl.Name = "memberZedGraphControl";
            this.memberZedGraphControl.PointValueFormat = "G";
            this.memberZedGraphControl.Size = new System.Drawing.Size(452, 255);
            this.memberZedGraphControl.TabIndex = 2;
            // 
            // premiumZedGraphControl
            // 
            this.premiumZedGraphControl.IsShowPointValues = false;
            this.premiumZedGraphControl.Location = new System.Drawing.Point(320, 294);
            this.premiumZedGraphControl.Name = "premiumZedGraphControl";
            this.premiumZedGraphControl.PointValueFormat = "G";
            this.premiumZedGraphControl.Size = new System.Drawing.Size(452, 255);
            this.premiumZedGraphControl.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.premiumZedGraphControl);
            this.Controls.Add(this.memberZedGraphControl);
            this.Controls.Add(this.membersDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчёт премий";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BlankStrip;
        private System.Windows.Forms.DataGridView membersDataGridView;
        private System.Windows.Forms.ToolStripMenuItem SettingStrip;
        private ZedGraph.ZedGraphControl memberZedGraphControl;
        private ZedGraph.ZedGraphControl premiumZedGraphControl;
        private System.Windows.Forms.ToolStripMenuItem ReportExportStrip;
    }
}

