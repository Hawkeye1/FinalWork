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
    public partial class CountingAward : Form
    {
        public DBManagement DBM { get; set; }
        public Options Op { get; set; }
        public ImportStaff IS { get; set; }
        public ImportWorkTime IWT { get; set; }

        public CountingAward()
        {
            InitializeComponent();
            DBM = new DBManagement();
            Op = new Options("settings.fw");
            IS = new ImportStaff();
            IWT = new ImportWorkTime();
        }

        private void BlankStrip_Click(object sender, EventArgs e)
        {
            Form AB = new AwardBlank(this);
            AB.Visible = true;
            this.Enabled = false;
        }
        private void SettingStrip_Click(object sender, EventArgs e)
        {
            Form S = new Settings(this);
            S.Visible = true;
            this.Enabled = false;
        }
    }
}
