using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace FinalWork
{
    // Класс взаимодействия с базой данных
    public class DBManagement
    {
        SQLiteConnection conn;

        // Получение списка должностей сотрудников кафедры
        public DataTable GetPositions()
        {
            DataSet positonsData = new DataSet();
            positonsData.Reset();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                String command = "SELECT * FROM positions";
             
                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(positonsData);
            }

            return positonsData.Tables[0];
        }
        public DataTable GetMembers()
        {
            DataSet membersData = new DataSet();
            membersData.Reset();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                String command = "SELECT * FROM members";

                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(membersData);
            }

            return membersData.Tables[0];
        }
        public void AddMember()
        {

        }
        public void AddMembers(DataTable temp)
        {
            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                var trans = conn.BeginTransaction();

                foreach (DataRow m in temp.Rows)
                {
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "INSERT OR IGNORE INTO members(initials) VALUES (@initials);";
                    cmd.Parameters.AddWithValue("@initials", m[0].ToString());
                    cmd.ExecuteNonQuery();
                }

                trans.Commit();
            }
        }
    }
}
