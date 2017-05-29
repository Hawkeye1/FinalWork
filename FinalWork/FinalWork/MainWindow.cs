using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

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
        public ZedGraphControl MemberZedGraphControl
        {
            get
            {
                return memberZedGraphControl;
            }
        }
        public ZedGraphControl PremiumZedGraphControl
        {
            get
            {
                return premiumZedGraphControl;
            }
        }
        public Staticstics Stat { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DBM = new DBManagement();
            Op = new Settings("settings.fw");
            IS = new ImportStaff();
            IWT = new ImportWorkTime();
            COHF = new CreatingOdtHtmlFile();
            CPF = new CreatingPdfFiles();
            Stat = new Staticstics();

            InitTable();
            InitDataGridView();
            AddInTable();
            InitZedGraphControls();
            membersDataGridView.SelectionChanged += MembersDataGridView_SelectionChanged;

            Stat.DrawGraphPremium(DBM, PremiumZedGraphControl, Op.Period);
        }

        private void MembersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (membersDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected) > -1)
            {
                Int32 employment = (membersDataGridView.CurrentRow.Cells[1].Value.ToString() == "штатный")? 1: 0;
                Stat.DrawGraphMember(DBM, MemberZedGraphControl, membersDataGridView.CurrentRow.Cells[0].Value.ToString(), employment, Op.Period);
            }
        }

        private void InitZedGraphControls()
        {
            GraphPane mPane, pPane;
            mPane = memberZedGraphControl.GraphPane;
            pPane = premiumZedGraphControl.GraphPane;

            mPane.Title = "Статистика премии сотрудника ...";
            mPane.XAxis.Title = "Дата";
            mPane.YAxis.Title = "BYN";
            pPane.Title = "Статистика премий";
            pPane.XAxis.Title = "Дата";
            pPane.YAxis.Title = "BYN";
        }

        private void InitDataGridView()
        {
            membersDataGridView.DataSource = Members;
            membersDataGridView.RowHeadersVisible = false;
            membersDataGridView.MultiSelect = false;
            membersDataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            membersDataGridView.DefaultCellStyle.SelectionForeColor = Color.DarkBlue;
        }

        private void InitTable()
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
            PremiumBlankWindow AB = new PremiumBlankWindow(this);
            AB.Visible = true;
            this.Enabled = false;
            this.Hide();
        }

        private void SettingStrip_Click(object sender, EventArgs e)
        {
            SettingsWindow S = new SettingsWindow(this);
            S.Visible = true;
            this.Enabled = false;
        }

        private void ReportExportStrip_Click(object sender, EventArgs e)
        {
            ReportExportWindow REW = new ReportExportWindow(this);
            REW.Visible = true;
            this.Enabled = false;
        }
    }
}
