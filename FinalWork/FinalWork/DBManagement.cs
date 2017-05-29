using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace FinalWork
{
    public class DBManagement
    {
        SQLiteConnection conn;

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

        public DataTable GetStaff()
        {
            DataSet staffData = new DataSet();
            staffData.Reset();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                String command = "SELECT * FROM staff";

                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(staffData);
            }

            return staffData.Tables[0];
        }

        public DataTable GetPluralists()
        {
            DataSet pluralistsData = new DataSet();
            pluralistsData.Reset();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                String command = "SELECT * FROM pluralists";

                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(pluralistsData);
            }

            return pluralistsData.Tables[0];
        }

        public DataTable GetEmployment()
        {
            DataSet employmentData = new DataSet();
            employmentData.Reset();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                String command = "SELECT * FROM employment";

                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(employmentData);
            }

            return employmentData.Tables[0];
        }

        public void AddMember(DataRow row)
        {
            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                var trans = conn.BeginTransaction();

                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "INSERT OR IGNORE INTO members(initials, experience) VALUES (@initials, @experience);";
                cmd.Parameters.AddWithValue("@initials", row[0].ToString());
                cmd.Parameters.AddWithValue("@experience", Convert.ToDouble(row[8].ToString()));
                cmd.ExecuteNonQuery();

                Int32 member_id = 0;
                cmd.Reset();
                cmd.CommandText = "SELECT member_id FROM members WHERE initials = @initials;";
                cmd.Parameters.AddWithValue("@initials", row[0].ToString());
                member_id = Convert.ToInt32(cmd.ExecuteScalar());

                if (row[2].ToString() == "совместитель")
                {
                    cmd.Reset();
                    cmd.CommandText = "INSERT OR IGNORE INTO pluralists(member_id) VALUES (@member_id);";
                    cmd.Parameters.AddWithValue("@member_id", member_id);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.Reset();
                    cmd.CommandText = "INSERT OR IGNORE INTO staff(member_id) VALUES (@member_id);";
                    cmd.Parameters.AddWithValue("@member_id", member_id);
                    cmd.ExecuteNonQuery();
                }

                trans.Commit();
            }
        }

        public void AddMembers(DataTable temp, Int32 employment)
        {
            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                var trans = conn.BeginTransaction();

                foreach (DataRow row in temp.Rows)
                {
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "INSERT OR IGNORE INTO members(initials, experience) VALUES (@initials, @experience);";
                    cmd.Parameters.AddWithValue("@initials", row[0].ToString());
                    cmd.Parameters.AddWithValue("@experience", 1.0);
                    cmd.ExecuteNonQuery();

                    Int32 member_id = 0;
                    cmd.Reset();
                    cmd.CommandText = "SELECT member_id FROM members WHERE initials = @initials;";
                    cmd.Parameters.AddWithValue("@initials", row[0].ToString());
                    member_id = Convert.ToInt32(cmd.ExecuteScalar());

                    if (employment == 0)
                    {
                        cmd.Reset();
                        cmd.CommandText = "INSERT OR IGNORE INTO pluralists(member_id) VALUES (@member_id);";
                        cmd.Parameters.AddWithValue("@member_id", member_id);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.Reset();
                        cmd.CommandText = "INSERT OR IGNORE INTO staff(member_id) VALUES (@member_id);";
                        cmd.Parameters.AddWithValue("@member_id", member_id);
                        cmd.ExecuteNonQuery();
                    }
                }

                trans.Commit();
            }
        }

        public void AddRecords(DataTable[] blanks, Int32 numBlanks)
        {
            DataTable members = GetMembers();
            DataTable positions = GetPositions();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                Int32 report_id = 0;
                Int32 member_id = 0;
                Int32 position_id = 0;
                Int32 record_id = 0;
                Int32 employment_id = 0;

                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "SELECT ifnull(MAX(report_id), 0) FROM report";
                report_id = Convert.ToInt32(cmd.ExecuteScalar());
                report_id =  (report_id == 0) ? 1 : report_id += 1;

                for (int i = 0; i < numBlanks; i++)
                {
                    foreach (DataRow row in blanks[i].Rows)
                    {
                        foreach (DataRow member in members.Rows)
                        {
                            if (row[0].Equals(member[1]))
                            {
                                member_id = Convert.ToInt32(member[0]);
                                break;
                            }
                        }

                        foreach (DataRow position in positions.Rows)
                        {
                            if (row[1].Equals(position[1]))
                            {
                                position_id = Convert.ToInt32(position[0]);
                                break;
                            }
                        }

                        employment_id = (row[2].ToString() == "штатный") ? 1 : 0;

                        if (Convert.ToDouble(row[8].ToString()) != 1.0)
                        {
                            cmd.Reset();
                            cmd.CommandText = "UPDATE members SET experience = @experience WHERE member_id = @member_id;";
                            cmd.Parameters.AddWithValue("@experience", Convert.ToDouble(row[8].ToString()));
                            cmd.Parameters.AddWithValue("@member_id", member_id);
                            cmd.ExecuteNonQuery();
                        }

                        cmd.Reset();
                        cmd.CommandText = "INSERT INTO report(report_id, record_id, member_id, position_id," +
                            "employment_id, work_hours, days_off, trip_days, sick_days, work_rate, CoLP," +
                            "premium_auto, premium_by_hand, correction, premium_total, note, form)" +
                            "VALUES (@report_id, @record_id, @member_id, @position_id," +
                            "@employment_id, @work_hours, @days_off, @trip_days, @sick_days, @work_rate, @CoLP," +
                            "@premium_auto, @premium_by_hand, @correction, @premium_total, @note, @form)";
                        cmd.Parameters.AddWithValue("@report_id", report_id);
                        cmd.Parameters.AddWithValue("@record_id", record_id);
                        cmd.Parameters.AddWithValue("@member_id", member_id);
                        cmd.Parameters.AddWithValue("@position_id", position_id);
                        cmd.Parameters.AddWithValue("@employment_id", employment_id);
                        cmd.Parameters.AddWithValue("@work_hours", Convert.ToDouble(row[3].ToString()));
                        cmd.Parameters.AddWithValue("@days_off", Convert.ToInt32(row[4].ToString()));
                        cmd.Parameters.AddWithValue("@trip_days", Convert.ToInt32(row[5].ToString()));
                        cmd.Parameters.AddWithValue("@sick_days", Convert.ToInt32(row[6].ToString()));
                        cmd.Parameters.AddWithValue("@work_rate", Convert.ToDouble(row[9].ToString()));
                        cmd.Parameters.AddWithValue("@CoLP", Convert.ToDouble(row[10].ToString()));
                        cmd.Parameters.AddWithValue("@premium_auto", Convert.ToDouble(row[13].ToString()));
                        cmd.Parameters.AddWithValue("@premium_by_hand", Convert.ToDouble(row[12].ToString()));
                        cmd.Parameters.AddWithValue("@correction", Convert.ToDouble(row[14].ToString()));
                        cmd.Parameters.AddWithValue("@premium_total", Convert.ToDouble(row[15].ToString()));
                        cmd.Parameters.AddWithValue("@note", row[16].ToString());
                        cmd.Parameters.AddWithValue("@form", i);
                        cmd.ExecuteNonQuery();

                        record_id++;
                    }
                }

                trans.Commit();
            }
        }

        public void AddPremiums(Double[] funds)
        {
            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                var trans = conn.BeginTransaction();

                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "INSERT INTO premiums(budget, paid, paragraph, date)" +
                    "VALUES (@budget, @paid, @paragraph, @date)";
                cmd.Parameters.AddWithValue("@budget", funds[0]);
                cmd.Parameters.AddWithValue("@paid", funds[1]);
                cmd.Parameters.AddWithValue("@paragraph", funds[2]);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("d"));
                cmd.ExecuteNonQuery();

                trans.Commit();
            }
        }

        public void AddArchive()
        {
            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                var trans = conn.BeginTransaction();

                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "INSERT INTO archive(date) VALUES (@date)";
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("g"));
                cmd.ExecuteNonQuery();

                trans.Commit();
            }
        }

        public DataTable GetStaffPluralists()
        {
            DataSet membersData = new DataSet();
            membersData.Reset();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                String command = "select m.initials, \"штатный\" from staff s join members m on s.member_id = m.member_id" +
                     " union select m.initials, \"совместитель\" from pluralists p join members m on p.member_id = m.member_id;";

                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(membersData);
            }

            return membersData.Tables[0];
        }

        public DataTable GetPremiumsStatistics(Int32 limit)
        {
            DataSet premiumsData = new DataSet();
            premiumsData.Reset();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                String command = "select premium_id, budget, paid, paragraph, cast(date as text)" +
                    " from premiums order by premium_id desc limit @limit";

                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                cmd.Parameters.AddWithValue("@limit", limit);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(premiumsData);
            }

            return premiumsData.Tables[0];
        }

        public DataTable GetMemeberStatistics(Int32 name, Int32 employment , Int32 limit)
        {
            DataSet memberData = new DataSet();
            memberData.Reset();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                String command = "select report_id, SUM(premium_total) from report where member_id = @name and " +
                    "employment_id = @employment order by report_id desc limit @limit;";

                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@employment", employment);
                cmd.Parameters.AddWithValue("@limit", limit);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(memberData);
            }

            return memberData.Tables[0];
        }

        public Int32 GetMemberId(String initials)
        {
            Int32 member_id = 0;

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                String command = "select member_id from members where initials = @initials;";

                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                cmd.Parameters.AddWithValue("@initials", initials);
                member_id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return member_id;
        }

        public DateTime GetDate(Int32 archive_id)
        {
            DateTime dateIssue = new DateTime();

            using (conn = new SQLiteConnection("Data Source=department.db; Version=3;"))
            {
                conn.Open();
                String command = "select cast(date as text) from archive where report_id = @archive_id;";

                SQLiteCommand cmd = new SQLiteCommand(command, conn);
                cmd.Parameters.AddWithValue("@archive_id", archive_id);
                dateIssue = Convert.ToDateTime(cmd.ExecuteScalar());
            }

            return dateIssue;
        }
    }
}
