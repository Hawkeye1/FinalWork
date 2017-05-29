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
    public partial class AddPersonWindow : Form
    {
        public PremiumBlankWindow PBW { get; set; }
        public DataTable Members { get; set; }

        public AddPersonWindow(PremiumBlankWindow temp)
        {
            InitializeComponent();
            PBW = temp;
            this.FormClosed += AddUserWindow_FormClosed;
            Members = new DataTable();
        }

        private void AddUserWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            PBW.Enabled = true;
            PBW.Show();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DataTable addMembers = Members.Clone();

            DataView dv = Members.DefaultView;
            dv.Sort = "[ФИО] ASC";
            Members = dv.ToTable();

            foreach (Int32 num in memberСheckedListBox.CheckedIndices)
            {
                addMembers.ImportRow(Members.Rows[num]);
            }

            PBW.AddInForm(addMembers, PBW.BlankDataGridView);
            PBW.CheckMembersInDB(PBW.BlankDataGridView);
            PBW.MarkMembers();
            PBW.BlankDataGridView.AutoResizeColumns();
            PBW.BlankDataGridView.AutoResizeRows();
            PBW.BlankDataGridView.ClearSelection();
            PBW.PC.Calculation(PBW);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            Members = PBW.Main.IWT.LoadData();
            Members = PBW.Main.IWT.CountingWorkTime(PBW.Main.DBM, Members);
            FillCheckedList();
        }

        private void FillCheckedList()
        {
            memberСheckedListBox.Items.Clear();

            foreach (DataRow row in Members.Rows)
            {
                memberСheckedListBox.Items.Add(row[0].ToString());
            }
        }
    }
}
