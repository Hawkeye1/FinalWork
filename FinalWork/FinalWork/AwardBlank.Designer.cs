namespace FinalWork
{
    partial class AwardBlank
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
            this.awardMenuStrip = new System.Windows.Forms.MenuStrip();
            this.importWorkTimeStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AddStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMembersStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMemberStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.budgetDataGridView = new System.Windows.Forms.DataGridView();
            this.paidDataGridView = new System.Windows.Forms.DataGridView();
            this.budgetLabel = new System.Windows.Forms.Label();
            this.paidLabel = new System.Windows.Forms.Label();
            this.budgetTextBox = new System.Windows.Forms.TextBox();
            this.budgetFundLabel = new System.Windows.Forms.Label();
            this.paidFundLabel = new System.Windows.Forms.Label();
            this.paidTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.awardMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.budgetDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paidDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // awardMenuStrip
            // 
            this.awardMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importWorkTimeStrip,
            this.AddStrip});
            this.awardMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.awardMenuStrip.Name = "awardMenuStrip";
            this.awardMenuStrip.Size = new System.Drawing.Size(984, 24);
            this.awardMenuStrip.TabIndex = 0;
            this.awardMenuStrip.Text = "menuStrip1";
            // 
            // importWorkTimeStrip
            // 
            this.importWorkTimeStrip.Name = "importWorkTimeStrip";
            this.importWorkTimeStrip.Size = new System.Drawing.Size(172, 20);
            this.importWorkTimeStrip.Text = "Импорт рабочего  времени";
            this.importWorkTimeStrip.Click += new System.EventHandler(this.importWorkTimeStrip_Click);
            // 
            // AddStrip
            // 
            this.AddStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMembersStrip,
            this.AddMemberStrip});
            this.AddStrip.Name = "AddStrip";
            this.AddStrip.Size = new System.Drawing.Size(173, 20);
            this.AddStrip.Text = "Добавить в базу сотрудника";
            // 
            // AddMembersStrip
            // 
            this.AddMembersStrip.Name = "AddMembersStrip";
            this.AddMembersStrip.Size = new System.Drawing.Size(181, 22);
            this.AddMembersStrip.Text = "Импорт из файла";
            this.AddMembersStrip.Click += new System.EventHandler(this.AddMembersStrip_Click);
            // 
            // AddMemberStrip
            // 
            this.AddMemberStrip.Name = "AddMemberStrip";
            this.AddMemberStrip.Size = new System.Drawing.Size(181, 22);
            this.AddMemberStrip.Text = "Добавить в ручную";
            this.AddMemberStrip.Click += new System.EventHandler(this.AddMemberStrip_Click);
            // 
            // budgetDataGridView
            // 
            this.budgetDataGridView.AllowUserToAddRows = false;
            this.budgetDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.budgetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.budgetDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.budgetDataGridView.Location = new System.Drawing.Point(15, 44);
            this.budgetDataGridView.Name = "budgetDataGridView";
            this.budgetDataGridView.Size = new System.Drawing.Size(800, 400);
            this.budgetDataGridView.TabIndex = 1;
            // 
            // paidDataGridView
            // 
            this.paidDataGridView.AllowUserToAddRows = false;
            this.paidDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.paidDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paidDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.paidDataGridView.Location = new System.Drawing.Point(15, 463);
            this.paidDataGridView.Name = "paidDataGridView";
            this.paidDataGridView.Size = new System.Drawing.Size(800, 166);
            this.paidDataGridView.TabIndex = 2;
            // 
            // budgetLabel
            // 
            this.budgetLabel.AutoSize = true;
            this.budgetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.budgetLabel.Location = new System.Drawing.Point(12, 28);
            this.budgetLabel.Name = "budgetLabel";
            this.budgetLabel.Size = new System.Drawing.Size(125, 13);
            this.budgetLabel.TabIndex = 3;
            this.budgetLabel.Text = "БЮДЖЕТНАЯ ФОРМА";
            // 
            // paidLabel
            // 
            this.paidLabel.AutoSize = true;
            this.paidLabel.Location = new System.Drawing.Point(12, 447);
            this.paidLabel.Name = "paidLabel";
            this.paidLabel.Size = new System.Drawing.Size(105, 13);
            this.paidLabel.TabIndex = 4;
            this.paidLabel.Text = "ПЛАТНАЯ ФОРМА";
            // 
            // budgetTextBox
            // 
            this.budgetTextBox.Location = new System.Drawing.Point(844, 44);
            this.budgetTextBox.MaxLength = 8;
            this.budgetTextBox.Name = "budgetTextBox";
            this.budgetTextBox.Size = new System.Drawing.Size(113, 20);
            this.budgetTextBox.TabIndex = 5;
            // 
            // budgetFundLabel
            // 
            this.budgetFundLabel.AutoSize = true;
            this.budgetFundLabel.Location = new System.Drawing.Point(844, 28);
            this.budgetFundLabel.Name = "budgetFundLabel";
            this.budgetFundLabel.Size = new System.Drawing.Size(47, 13);
            this.budgetFundLabel.TabIndex = 6;
            this.budgetFundLabel.Text = "Бюджет";
            // 
            // paidFundLabel
            // 
            this.paidFundLabel.AutoSize = true;
            this.paidFundLabel.Location = new System.Drawing.Point(847, 71);
            this.paidFundLabel.Name = "paidFundLabel";
            this.paidFundLabel.Size = new System.Drawing.Size(50, 13);
            this.paidFundLabel.TabIndex = 7;
            this.paidFundLabel.Text = "Платное";
            // 
            // paidTextBox
            // 
            this.paidTextBox.Location = new System.Drawing.Point(844, 88);
            this.paidTextBox.MaxLength = 8;
            this.paidTextBox.Name = "paidTextBox";
            this.paidTextBox.Size = new System.Drawing.Size(113, 20);
            this.paidTextBox.TabIndex = 8;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(897, 606);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // AwardBlank
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 641);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.paidTextBox);
            this.Controls.Add(this.paidFundLabel);
            this.Controls.Add(this.budgetFundLabel);
            this.Controls.Add(this.budgetTextBox);
            this.Controls.Add(this.paidLabel);
            this.Controls.Add(this.budgetLabel);
            this.Controls.Add(this.paidDataGridView);
            this.Controls.Add(this.budgetDataGridView);
            this.Controls.Add(this.awardMenuStrip);
            this.MainMenuStrip = this.awardMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "AwardBlank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Бланк премий";
            this.awardMenuStrip.ResumeLayout(false);
            this.awardMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.budgetDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paidDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip awardMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem importWorkTimeStrip;
        private System.Windows.Forms.ToolStripMenuItem AddStrip;
        private System.Windows.Forms.ToolStripMenuItem AddMembersStrip;
        private System.Windows.Forms.ToolStripMenuItem AddMemberStrip;
        private System.Windows.Forms.DataGridView budgetDataGridView;
        private System.Windows.Forms.DataGridView paidDataGridView;
        private System.Windows.Forms.Label budgetLabel;
        private System.Windows.Forms.Label paidLabel;
        private System.Windows.Forms.TextBox budgetTextBox;
        private System.Windows.Forms.Label budgetFundLabel;
        private System.Windows.Forms.Label paidFundLabel;
        private System.Windows.Forms.TextBox paidTextBox;
        private System.Windows.Forms.Button saveButton;
    }
}