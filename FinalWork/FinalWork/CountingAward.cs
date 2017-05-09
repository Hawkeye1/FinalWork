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

        public CountingAward()
        {
            InitializeComponent();
        }

        private void ImportStaff_Click(object sender, EventArgs e)
        {
            ImportStaff IS = new ImportStaff();
            DBM = new DBManagement();

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
            Form S = new Settings(this);
            S.Visible = true;
            this.Enabled = false;
        }
    }
}
