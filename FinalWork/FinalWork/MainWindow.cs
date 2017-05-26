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
        public CreatingOdtHtmlFile COHF { get; set; }
        public CreatingPdfFiles CPF { get; set; }
        public DataTable Members {get; set;}

        public MainWindow()
        {
            InitializeComponent();
            DBM = new DBManagement();
            Op = new Settings("settings.fw");
            IS = new ImportStaff();
            IWT = new ImportWorkTime();
            COHF = new CreatingOdtHtmlFile();
            CPF = new CreatingPdfFiles(); 

            IninTable();
            InitDatGridView();
            AddInTable();
        }

        private void InitDatGridView()
        {
            membersDataGridView.DataSource = Members;
            membersDataGridView.RowHeadersVisible = false;
        }

        private void IninTable()
        {
            Members = new DataTable();

            Members.Columns.Add("ФИО");
            Members.Columns.Add("Штатность");
        }

        public void AddInTable()
        {
            DataTable table = DBM.GetStaffPluralists();
            Members.Clear();

            foreach(DataRow row in table.Rows)
            {
                DataRow dr = Members.NewRow();

                dr[0] = row[0];
                dr[1] = row[1];

                Members.Rows.Add(dr);
            }
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
