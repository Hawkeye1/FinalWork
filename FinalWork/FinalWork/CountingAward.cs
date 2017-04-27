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
        public CountingAward()
        {
            InitializeComponent();
        }

        private void ImportStaff_Click(object sender, EventArgs e)
        {
            ImportStaff IS = new ImportStaff();

            DataSet data = new DataSet();

            data = IS.LoadData();

            tempGrid.DataSource = data.Tables[0];
        }

    }
}
