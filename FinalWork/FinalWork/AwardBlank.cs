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
    public partial class AwardBlank : Form
    {
        public CountingAward Main { get; set; }
        
        public AwardBlank(CountingAward f)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(AwardBlank_Closed);
            this.budgetDataGridView.Sorted += Dye;
            this.budgetDataGridView.UserDeletedRow += Dye;
            this.budgetDataGridView.DataSourceChanged += Dye;
            this.paidDataGridView.Sorted += Dye;
            this.paidDataGridView.UserDeletedRow += Dye;
            this.paidDataGridView.DataSourceChanged += Dye;
            Main = f;
        }

        private void Dye(object sender, EventArgs e)
        {
            CheckMembersInDB();
        }

        private void AwardBlank_Closed(object sender, EventArgs e)
        {
            Main.Enabled = true;
        }

        private void AddMembersStrip_Click(object sender, EventArgs e)
        {
            DataTable members = new DataTable();
            members.Reset();
            members = Main.IS.LoadData();
            members = Main.IS.DataProcessing(Main.DBM, members);
            Main.DBM.AddMembers(members);
        }

        private void AddMemberStrip_Click(object sender, EventArgs e)
        {

        }

        private void importWorkTimeStrip_Click(object sender, EventArgs e)
        {
            DataTable members = new DataTable();
            members.Reset();
            members = Main.IWT.LoadData();
            budgetDataGridView.DataSource = Main.IWT.CountingWorkTime(Main.DBM, members);
        }

        private void CheckMembersInDB()
        {
            DataTable members = Main.DBM.GetMembers();
            Boolean match;
            
            for (int i = 0; i < budgetDataGridView.Rows.Count; i++)
            {
                match = false;

                foreach (DataRow member in members.Rows)
                {
                    string s1 = member[1].ToString();
                    string s2 = budgetDataGridView.Rows[i].Cells[0].Value.ToString();

                    if (member[1].ToString().Equals(budgetDataGridView.Rows[i].Cells[0].Value))
                    {
                        match = true;
                        break;
                    }
                }

                if (!match)
                {
                    budgetDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            }
        }
    }
}
