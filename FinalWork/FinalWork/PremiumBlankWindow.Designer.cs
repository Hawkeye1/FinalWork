namespace FinalWork
{
    partial class PremiumBlankWindow
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
            this.premiumMenuStrip = new System.Windows.Forms.MenuStrip();
            this.ImportWorkTimeStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AddInDBStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMembersStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMemberStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AddInFormStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRowStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.nextSaveButton = new System.Windows.Forms.Button();
            this.blankDataGridView = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.blankNameLabel = new System.Windows.Forms.Label();
            this.totalFundLabel = new System.Windows.Forms.Label();
            this.totalFundTextBox = new System.Windows.Forms.TextBox();
            this.autoFundLabel = new System.Windows.Forms.Label();
            this.autoFundTextBox = new System.Windows.Forms.TextBox();
            this.leftAutoFundLabel = new System.Windows.Forms.Label();
            this.leftAutoFundTextBox = new System.Windows.Forms.TextBox();
            this.byHandFundLabel = new System.Windows.Forms.Label();
            this.byHandFundTextBox = new System.Windows.Forms.TextBox();
            this.leftByHandFundLabel = new System.Windows.Forms.Label();
            this.leftByHandFundTextBox = new System.Windows.Forms.TextBox();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.infoLabel4 = new System.Windows.Forms.Label();
            this.infoLabel5 = new System.Windows.Forms.Label();
            this.premiumMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blankDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // premiumMenuStrip
            // 
            this.premiumMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportWorkTimeStrip,
            this.AddInDBStrip,
            this.AddInFormStrip,
            this.DeleteRowStrip});
            this.premiumMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.premiumMenuStrip.Name = "premiumMenuStrip";
            this.premiumMenuStrip.Size = new System.Drawing.Size(984, 24);
            this.premiumMenuStrip.TabIndex = 0;
            this.premiumMenuStrip.Text = "menuStrip1";
            // 
            // ImportWorkTimeStrip
            // 
            this.ImportWorkTimeStrip.Name = "ImportWorkTimeStrip";
            this.ImportWorkTimeStrip.Size = new System.Drawing.Size(169, 20);
            this.ImportWorkTimeStrip.Text = "Импорт рабочего времени";
            this.ImportWorkTimeStrip.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.ImportWorkTimeStrip.Click += new System.EventHandler(this.ImportWorkTimeStrip_Click);
            // 
            // AddInDBStrip
            // 
            this.AddInDBStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMembersStrip,
            this.AddMemberStrip});
            this.AddInDBStrip.Name = "AddInDBStrip";
            this.AddInDBStrip.Size = new System.Drawing.Size(173, 20);
            this.AddInDBStrip.Text = "Добавить cотрудника в базу";
            // 
            // AddMembersStrip
            // 
            this.AddMembersStrip.Name = "AddMembersStrip";
            this.AddMembersStrip.Size = new System.Drawing.Size(185, 22);
            this.AddMembersStrip.Text = "Импорт из файла";
            this.AddMembersStrip.Click += new System.EventHandler(this.AddMembersStrip_Click);
            // 
            // AddMemberStrip
            // 
            this.AddMemberStrip.Name = "AddMemberStrip";
            this.AddMemberStrip.Size = new System.Drawing.Size(185, 22);
            this.AddMemberStrip.Text = "Добавить из формы";
            this.AddMemberStrip.Click += new System.EventHandler(this.AddMemberStrip_Click);
            // 
            // AddInFormStrip
            // 
            this.AddInFormStrip.Name = "AddInFormStrip";
            this.AddInFormStrip.Size = new System.Drawing.Size(187, 20);
            this.AddInFormStrip.Text = "Добавить сотрудника в форму";
            this.AddInFormStrip.Click += new System.EventHandler(this.AddInFormStrip_Click);
            // 
            // DeleteRowStrip
            // 
            this.DeleteRowStrip.Name = "DeleteRowStrip";
            this.DeleteRowStrip.Size = new System.Drawing.Size(103, 20);
            this.DeleteRowStrip.Text = "Удалить строку";
            this.DeleteRowStrip.Click += new System.EventHandler(this.DeleteRowStrip_Click);
            // 
            // nextSaveButton
            // 
            this.nextSaveButton.Location = new System.Drawing.Point(897, 606);
            this.nextSaveButton.Name = "nextSaveButton";
            this.nextSaveButton.Size = new System.Drawing.Size(75, 23);
            this.nextSaveButton.TabIndex = 9;
            this.nextSaveButton.Text = "Далее";
            this.nextSaveButton.UseVisualStyleBackColor = true;
            this.nextSaveButton.Click += new System.EventHandler(this.nextSaveButton_Click);
            // 
            // blankDataGridView
            // 
            this.blankDataGridView.AllowUserToAddRows = false;
            this.blankDataGridView.AllowUserToDeleteRows = false;
            this.blankDataGridView.AllowUserToResizeRows = false;
            this.blankDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.blankDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blankDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.blankDataGridView.Location = new System.Drawing.Point(13, 45);
            this.blankDataGridView.Name = "blankDataGridView";
            this.blankDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.blankDataGridView.Size = new System.Drawing.Size(800, 500);
            this.blankDataGridView.TabIndex = 10;
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Location = new System.Drawing.Point(816, 606);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // blankNameLabel
            // 
            this.blankNameLabel.AutoSize = true;
            this.blankNameLabel.Location = new System.Drawing.Point(13, 26);
            this.blankNameLabel.Name = "blankNameLabel";
            this.blankNameLabel.Size = new System.Drawing.Size(125, 13);
            this.blankNameLabel.TabIndex = 12;
            this.blankNameLabel.Text = "БЮДЖЕТНАЯ ФОРМА";
            // 
            // totalFundLabel
            // 
            this.totalFundLabel.AutoSize = true;
            this.totalFundLabel.Location = new System.Drawing.Point(830, 26);
            this.totalFundLabel.Name = "totalFundLabel";
            this.totalFundLabel.Size = new System.Drawing.Size(47, 13);
            this.totalFundLabel.TabIndex = 13;
            this.totalFundLabel.Text = "Бюджет";
            // 
            // totalFundTextBox
            // 
            this.totalFundTextBox.Location = new System.Drawing.Point(833, 45);
            this.totalFundTextBox.MaxLength = 12;
            this.totalFundTextBox.Name = "totalFundTextBox";
            this.totalFundTextBox.Size = new System.Drawing.Size(112, 20);
            this.totalFundTextBox.TabIndex = 14;
            // 
            // autoFundLabel
            // 
            this.autoFundLabel.AutoSize = true;
            this.autoFundLabel.Location = new System.Drawing.Point(830, 68);
            this.autoFundLabel.Name = "autoFundLabel";
            this.autoFundLabel.Size = new System.Drawing.Size(109, 13);
            this.autoFundLabel.TabIndex = 15;
            this.autoFundLabel.Text = "Авт. распределение";
            // 
            // autoFundTextBox
            // 
            this.autoFundTextBox.Location = new System.Drawing.Point(833, 85);
            this.autoFundTextBox.MaxLength = 12;
            this.autoFundTextBox.Name = "autoFundTextBox";
            this.autoFundTextBox.Size = new System.Drawing.Size(112, 20);
            this.autoFundTextBox.TabIndex = 16;
            // 
            // leftAutoFundLabel
            // 
            this.leftAutoFundLabel.AutoSize = true;
            this.leftAutoFundLabel.Location = new System.Drawing.Point(830, 108);
            this.leftAutoFundLabel.Name = "leftAutoFundLabel";
            this.leftAutoFundLabel.Size = new System.Drawing.Size(116, 13);
            this.leftAutoFundLabel.TabIndex = 17;
            this.leftAutoFundLabel.Text = "Остаток от авт. расп.";
            // 
            // leftAutoFundTextBox
            // 
            this.leftAutoFundTextBox.Enabled = false;
            this.leftAutoFundTextBox.Location = new System.Drawing.Point(833, 125);
            this.leftAutoFundTextBox.MaxLength = 12;
            this.leftAutoFundTextBox.Name = "leftAutoFundTextBox";
            this.leftAutoFundTextBox.Size = new System.Drawing.Size(112, 20);
            this.leftAutoFundTextBox.TabIndex = 18;
            // 
            // byHandFundLabel
            // 
            this.byHandFundLabel.AutoSize = true;
            this.byHandFundLabel.Location = new System.Drawing.Point(830, 148);
            this.byHandFundLabel.Name = "byHandFundLabel";
            this.byHandFundLabel.Size = new System.Drawing.Size(123, 13);
            this.byHandFundLabel.TabIndex = 19;
            this.byHandFundLabel.Text = "Ручное распределение";
            // 
            // byHandFundTextBox
            // 
            this.byHandFundTextBox.Enabled = false;
            this.byHandFundTextBox.Location = new System.Drawing.Point(833, 164);
            this.byHandFundTextBox.MaxLength = 12;
            this.byHandFundTextBox.Name = "byHandFundTextBox";
            this.byHandFundTextBox.Size = new System.Drawing.Size(112, 20);
            this.byHandFundTextBox.TabIndex = 20;
            this.byHandFundTextBox.Text = "0";
            // 
            // leftByHandFundLabel
            // 
            this.leftByHandFundLabel.AutoSize = true;
            this.leftByHandFundLabel.Location = new System.Drawing.Point(830, 187);
            this.leftByHandFundLabel.Name = "leftByHandFundLabel";
            this.leftByHandFundLabel.Size = new System.Drawing.Size(115, 13);
            this.leftByHandFundLabel.TabIndex = 21;
            this.leftByHandFundLabel.Text = "Остаток от руч. расп.";
            // 
            // leftByHandFundTextBox
            // 
            this.leftByHandFundTextBox.Enabled = false;
            this.leftByHandFundTextBox.Location = new System.Drawing.Point(833, 203);
            this.leftByHandFundTextBox.MaxLength = 12;
            this.leftByHandFundTextBox.Name = "leftByHandFundTextBox";
            this.leftByHandFundTextBox.Size = new System.Drawing.Size(113, 20);
            this.leftByHandFundTextBox.TabIndex = 22;
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.infoLabel2.Location = new System.Drawing.Point(13, 564);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(258, 13);
            this.infoLabel2.TabIndex = 23;
            this.infoLabel2.Text = "Дублируется сотрудник (штатный/совместитель)";
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.BackColor = System.Drawing.Color.OrangeRed;
            this.infoLabel1.Location = new System.Drawing.Point(13, 548);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(151, 13);
            this.infoLabel1.TabIndex = 24;
            this.infoLabel1.Text = "Сотрудник отсутствует в БД";
            // 
            // infoLabel3
            // 
            this.infoLabel3.AutoSize = true;
            this.infoLabel3.BackColor = System.Drawing.Color.Green;
            this.infoLabel3.Location = new System.Drawing.Point(13, 580);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(290, 13);
            this.infoLabel3.TabIndex = 25;
            this.infoLabel3.Text = "Сотрудник находился на больничном и в командировке";
            // 
            // infoLabel4
            // 
            this.infoLabel4.AutoSize = true;
            this.infoLabel4.BackColor = System.Drawing.Color.DarkOrange;
            this.infoLabel4.Location = new System.Drawing.Point(13, 596);
            this.infoLabel4.Name = "infoLabel4";
            this.infoLabel4.Size = new System.Drawing.Size(202, 13);
            this.infoLabel4.TabIndex = 26;
            this.infoLabel4.Text = "Сотрудник находился в командировке";
            // 
            // infoLabel5
            // 
            this.infoLabel5.AutoSize = true;
            this.infoLabel5.BackColor = System.Drawing.Color.MediumOrchid;
            this.infoLabel5.Location = new System.Drawing.Point(13, 612);
            this.infoLabel5.Name = "infoLabel5";
            this.infoLabel5.Size = new System.Drawing.Size(195, 13);
            this.infoLabel5.TabIndex = 27;
            this.infoLabel5.Text = "Сотрудник находился на больничном";
            // 
            // PremiumBlankWindow
            // 
            this.AcceptButton = this.nextSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 641);
            this.Controls.Add(this.infoLabel5);
            this.Controls.Add(this.infoLabel4);
            this.Controls.Add(this.infoLabel3);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.infoLabel2);
            this.Controls.Add(this.leftByHandFundTextBox);
            this.Controls.Add(this.leftByHandFundLabel);
            this.Controls.Add(this.byHandFundTextBox);
            this.Controls.Add(this.byHandFundLabel);
            this.Controls.Add(this.leftAutoFundTextBox);
            this.Controls.Add(this.leftAutoFundLabel);
            this.Controls.Add(this.autoFundTextBox);
            this.Controls.Add(this.autoFundLabel);
            this.Controls.Add(this.totalFundTextBox);
            this.Controls.Add(this.totalFundLabel);
            this.Controls.Add(this.blankNameLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.blankDataGridView);
            this.Controls.Add(this.nextSaveButton);
            this.Controls.Add(this.premiumMenuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.premiumMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "PremiumBlankWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Бланк премий";
            this.premiumMenuStrip.ResumeLayout(false);
            this.premiumMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blankDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip premiumMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ImportWorkTimeStrip;
        private System.Windows.Forms.ToolStripMenuItem AddInDBStrip;
        private System.Windows.Forms.ToolStripMenuItem AddMembersStrip;
        private System.Windows.Forms.ToolStripMenuItem AddMemberStrip;
        private System.Windows.Forms.Button nextSaveButton;
        private System.Windows.Forms.ToolStripMenuItem AddInFormStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteRowStrip;
        private System.Windows.Forms.DataGridView blankDataGridView;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label blankNameLabel;
        private System.Windows.Forms.Label totalFundLabel;
        private System.Windows.Forms.TextBox totalFundTextBox;
        private System.Windows.Forms.Label autoFundLabel;
        private System.Windows.Forms.TextBox autoFundTextBox;
        private System.Windows.Forms.Label leftAutoFundLabel;
        private System.Windows.Forms.TextBox leftAutoFundTextBox;
        private System.Windows.Forms.Label byHandFundLabel;
        private System.Windows.Forms.TextBox byHandFundTextBox;
        private System.Windows.Forms.Label leftByHandFundLabel;
        private System.Windows.Forms.TextBox leftByHandFundTextBox;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.Label infoLabel4;
        private System.Windows.Forms.Label infoLabel5;
    }
}