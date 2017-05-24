using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel;
using ICSharpCode.SharpZipLib;

namespace FinalWork
{
    public class ImportStaff : Import 
    {
        public int Employment { get; set; }                                             // тип занятости 0 - совместитель 1 - штатный

        public DataTable DataProcessing(DBManagement DBM, DataTable temp)
        {
            DataTable staffTable = new DataTable();
            DataTable positions = DBM.GetPositions();
            char[] delimer = { ' ', '\n' };                                             // Разделитель
            Boolean match = false;
            Employment = 1;

            staffTable.Columns.Add("ФИО");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                String[] substring = temp.Rows[i][0].ToString().Split(delimer);

                // блок анализа документа на штатность сотрудников в списке
                if (!match)
                {
                    foreach (var str in substring)
                    {
                        if (str.Equals("совместителей"))
                        {
                            match = true;
                            Employment = 0;
                        }
                        else if (str.Equals("ФИО"))
                        {
                            match = true;
                        }
                    }

                    continue;
                }

                if (substring[0].Equals("ФИО") || substring[0].Equals("Кафедра") || substring[0].Equals("Табель") ||
                    substring[0].Equals("кафедра") || substring[0].Equals("Руководитель") || substring[0].Equals("Ответственный") ||
                    substring[0].Equals("") || substring[0].Equals("Приложение"))
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
