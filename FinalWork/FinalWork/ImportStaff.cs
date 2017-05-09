using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel;
using ICSharpCode.SharpZipLib;

namespace FinalWork
{
    //Класс для обработки информации о списке сотрудникв кафедры
    //Дописать сравнение списка с списком базы
    class ImportStaff
    {
        private Stream file;
        int fileType;

        private void OpenFile()
        {
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
                        fileType = ofd.FilterIndex;
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
            IExcelDataReader excelData;

            OpenFile();

            if (fileType == 2)                       // xlsx
            {
                excelData = ExcelReaderFactory.CreateOpenXmlReader(file);
            }
            else
            {                                        // xls
                excelData = ExcelReaderFactory.CreateBinaryReader(file);
            }

            DataSet data = excelData.AsDataSet();
            excelData.Dispose();

            return data;
        }
        public DataTable DataProcessing(DBManagement DBM)
        {
            DataTable temp = new DataTable();
            DataTable staffTable = new DataTable();
            DataTable positions = DBM.GetPosition();
            char delimer = ' ';                                     // Разделитель

            temp = LoadData().Tables[1];
            staffTable.Columns.Add("ФИО");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                String[] Substring = temp.Rows[i][0].ToString().Split(delimer);

                if (Substring[0].Equals("ФИО") || Substring[0].Equals("Кафедра") || Substring[0].Equals("Табель") ||
                    Substring[0].Equals("кафедра") || Substring[0].Equals("Руководитель") || Substring[0].Equals("Ответственный") ||
                    Substring[0].Equals("") || Substring[0].Equals("Приложение"))
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < positions.Rows.Count; j++)
                    {
                        if (positions.Rows[j][1].ToString() == temp.Rows[i][1].ToString())
                        {
                            staffTable.Rows.Add(temp.Rows[i][0]);
                            break;
                        }
                    }
                }

            }

            return staffTable;
        }
    }
}
