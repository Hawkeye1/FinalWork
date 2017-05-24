using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel;
using ICSharpCode.SharpZipLib;

namespace FinalWork
{
    public class ImportWorkTime : Import
    {
        public int Employment { get; set; }                                             // тип занятости 0 - совместитель 1 - штатный

        public DataTable CountingWorkTime(DBManagement DBM, DataTable temp)
        {
            DataTable positions = DBM.GetPositions();
            DataTable e = DBM.GetEmployment();
            char[] delimer = { ' ', '\n', ':' };                                     // Разделитель
            DataTable staffTable = new DataTable();
            staffTable.Columns.Add("ФИО");
            staffTable.Columns.Add("Должность");
            staffTable.Columns.Add("Ставка");
            staffTable.Columns[2].DataType = Type.GetType("System.Double");
            staffTable.Columns.Add("Штатность");
            staffTable.Columns.Add("Часов работы");
            staffTable.Columns[4].DataType = Type.GetType("System.Double");
            staffTable.Columns.Add("Выходных дней");
            staffTable.Columns[5].DataType = Type.GetType("System.Int32");
            staffTable.Columns.Add("Дней в командировке");
            staffTable.Columns[6].DataType = Type.GetType("System.Int32");
            staffTable.Columns.Add("Дней на больничном");
            staffTable.Columns[7].DataType = Type.GetType("System.Int32");
            staffTable.Columns.Add("Тар.коэфф");
            staffTable.Columns[8].DataType = Type.GetType("System.Double");
            

            int daysOff = 0, sickDays = 0, tripDays = 0;
            double workTime = 0, conv = 0;
            Boolean match = false;
            Employment = 1;

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
                            for (int k = 3; k < temp.Columns.Count; k++)
                            {
                                if (temp.Rows[i][k].ToString().Equals("в") || temp.Rows[i][k].ToString().Equals("В"))
                                {
                                    daysOff++;
                                }
                                else if (temp.Rows[i][k].ToString().Equals("к") || temp.Rows[i][k].ToString().Equals("К"))
                                {
                                    tripDays++;
                                }
                                else if (temp.Rows[i][k].ToString().Equals("б") || temp.Rows[i][k].ToString().Equals("Б"))
                                {
                                    sickDays++;
                                }
                                else if (temp.Rows[i][k].ToString().Contains(","))
                                {
                                    workTime += Convert.ToDouble(temp.Rows[i][k].ToString());
                                }
                                else if (temp.Rows[i][k].ToString().Contains(":"))
                                {
                                    String[] nums = temp.Rows[i][k].ToString().Split(delimer);

                                    workTime += Convert.ToDouble(nums[0]);
                                    workTime += Convert.ToDouble(nums[1]) / 60.0;
                                }
                                else if (Double.TryParse(temp.Rows[i][k].ToString(), out conv))
                                {
                                    workTime += conv;
                                }

                            }

                            staffTable.Rows.Add(temp.Rows[i][0], temp.Rows[i][1], temp.Rows[i][2], e.Rows[Employment][1] ,workTime, daysOff, tripDays, sickDays, positions.Rows[j][2]);

                            workTime = 0;
                            daysOff = 0;
                            tripDays = 0;
                            sickDays = 0;
                        }
                    }
                }

            }

            return staffTable;
        }
    }
}
