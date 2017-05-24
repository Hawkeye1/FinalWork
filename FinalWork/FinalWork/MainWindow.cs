using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalWork
{
    public partial class MainWindow : Form
    {
        public DBManagement DBM { get; set; }
        public Settings Op { get; set; }
        public ImportStaff IS { get; set; }
        public ImportWorkTime IWT { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DBM = new DBManagement();
            Op = new Settings("settings.fw");
            IS = new ImportStaff();
            IWT = new ImportWorkTime();
        }

        private void BlankStrip_Click(object sender, EventArgs e)
        {
            Form AB = new PremiumBlankWindow(this);
            AB.Visible = true;
            this.Enabled = false;
        }
        private void SettingStrip_Click(object sender, EventArgs e)
        {
            Form S = new SettingsWindow(this);
            S.Visible = true;
            this.Enabled = false;
        }
    }
}
