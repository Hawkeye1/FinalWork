using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace FinalWork
{
    // Класс взаимодействия с базой данных
    class DBManagement
    {
        SQLiteConnection conn;

        // Получение списка должностей сотрудников кафедры
        public DataTable GetPosition()
        {
            DataSet positonsData = new DataSet();
            positonsData.Reset();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                String command = "SELECT * FROM positions";
             
                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(positonsData);
            }

            return positonsData.Tables[0];
        }
    }
}
