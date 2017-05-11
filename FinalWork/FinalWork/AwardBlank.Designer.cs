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
            this.importWortkTimeStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.awardMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // awardMenuStrip
            // 
            this.awardMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importWortkTimeStrip});
            this.awardMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.awardMenuStrip.Name = "awardMenuStrip";
            this.awardMenuStrip.Size = new System.Drawing.Size(584, 24);
            this.awardMenuStrip.TabIndex = 0;
            this.awardMenuStrip.Text = "menuStrip1";
            // 
            // importWortkTimeStrip
            // 
            this.importWortkTimeStrip.Name = "importWortkTimeStrip";
            this.importWortkTimeStrip.Size = new System.Drawing.Size(172, 20);
            this.importWortkTimeStrip.Text = "Импорт рабочего  времени";
            // 
            // AwardBlank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.awardMenuStrip);
            this.MainMenuStrip = this.awardMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "AwardBlank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AwardBlank";
            this.awardMenuStrip.ResumeLayout(false);
            this.awardMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip awardMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem importWortkTimeStrip;
    }
}