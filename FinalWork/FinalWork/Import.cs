using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel;
using ICSharpCode.SharpZipLib;

namespace FinalWork
{
    public class Import
    {
        public Stream ExcelFile { get; set; }
        public int FileType { get; set; }

        public DataTable LoadData()
        {
            IExcelDataReader excelData;
            DataSet data = new DataSet();
            data.Tables.Add();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((ExcelFile = ofd.OpenFile()) != null)
                    {
                        FileType = ofd.FilterIndex;
                    }

                    if (FileType == 2)                       // xlsx
                    {
                        excelData = ExcelReaderFactory.CreateOpenXmlReader(ExcelFile);
                    }
                    else
                    {                                        // xls
                        excelData = ExcelReaderFactory.CreateBinaryReader(ExcelFile);
                    }

                    data = excelData.AsDataSet();
                    excelData.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return data.Tables[0];
        }
    }
}
