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
        DBManagement DBM;
        Options Op;

        public CountingAward()
        {
            InitializeComponent();
            DBM = new DBManagement();
            Op = new Options("settings.fw");
        }

        private void ImportStaff_Click(object sender, EventArgs e)
        {
            ImportStaff IS = new ImportStaff();

            DataTable data = new DataTable();

            data = IS.DataProcessing(DBM);

            tempGrid.DataSource = data;
        }

        private void BlankStrip_Click(object sender, EventArgs e)
        {
            Form AB = new AwardBlank(this);
            AB.Visible = true;
            this.Enabled = false;
        }
        private void SettingStrip_Click(object sender, EventArgs e)
        {
            Form S = new Settings(this, Op);
            S.Visible = true;
            this.Enabled = false;
        }
    }
}
