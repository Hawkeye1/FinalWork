using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalWork
{
    public partial class ReportExportWindow : Form
    {
        public MainWindow Main { get; set; }
        public DataTable ArchiveData { get; set; }

        public ReportExportWindow(MainWindow Main)
        {
            InitializeComponent();
            this.Main = Main;
            this.FormClosed += ReportExportWindow_FormClosed;

            InitListBox();
        }

        private void ReportExportWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main.Enabled = true;
            Main.Show();
        }

        private void InitListBox()
        {
            ArchiveData = Main.DBM.GetArchive();

            foreach (DataRow row in ArchiveData.Rows)
            {
                reportListBox.Items.Add(row[1].ToString());
            }
        }

        private void ExportInFile(String filePath, Int32 fileIndex)
        {
            Int32 report_id = 0;
            Double[] funds = { 0.0, 0.0, 0.0 };

            foreach (DataRow row in ArchiveData.Rows)
            {
                if (reportListBox.SelectedItem.ToString() == row[1].ToString())
                {
                    report_id = Convert.ToInt32(row[0].ToString());
                    break;
                }
            }

            DataTable table = Main.DBM.GetReportInfo(report_id);
            DataTable[] forms = new DataTable[3];

            table.Columns[0].ColumnName = "ФИО";
            forms[0] = table.Clone();
            forms[1] = table.Clone();
            forms[2] = table.Clone();

            foreach (DataRow row in table.Rows)
            {
                forms[Convert.ToInt32(row[3].ToString())].Rows.Add(row.ItemArray);
            }

            for (int i = 0; i < 3; i++)
            {
                funds[i] = Main.DBM.GetFundSum(report_id, i);
            }

            Int32[] indexes = { 0, 1, 2 };
            Main.COHF.CreateOdtHtmlFile(false, forms, funds, fileIndex, filePath, indexes, Convert.ToDateTime(ArchiveData.Rows[report_id - 1][1].ToString()));
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (reportListBox.SelectedIndex != -1)
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = "odt file (*.odt)|*.odt|html file (*.html)|*.html|pdf file (*.pdf)|*.pdf";
                SFD.InitialDirectory = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
                SFD.SupportMultiDottedExtensions = false;
                SFD.FilterIndex = 1;

                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    ExportInFile(SFD.FileName, SFD.FilterIndex);                       
                }

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
