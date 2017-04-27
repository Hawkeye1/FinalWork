using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel;
using ICSharpCode.SharpZipLib;

namespace FinalWork
{
    //Класс для обработки информации о списке сотрудникв кафедры
    //Пока что без учёта принадлежности к кафедре
    class ImportStaff
    {
        private Stream file;

        
        public void OpenFile(out int type)  // 1 - xls, 2 - xlsx
        {
            type = 0;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((file = ofd.OpenFile()) != null)
                    {
                        type = ofd.FilterIndex;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public DataSet LoadData()
        {
            int type;
            IExcelDataReader excelData;

            OpenFile(out type);

            if (type == 2)                      // xlsx
            {
                excelData = ExcelReaderFactory.CreateOpenXmlReader(file);
            }
            else
            {                                   // xls
                excelData = ExcelReaderFactory.CreateOpenXmlReader(file);
            }

            DataSet data = excelData.AsDataSet();

            return data;
        }
    }
}
