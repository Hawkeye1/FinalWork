using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ZedGraph;

namespace FinalWork
{
    public class Staticstics
    {
        public void DrawGraphMember(DBManagement DBM, ZedGraphControl ZGC, String initials, Int32 employment, Int32 limit)
        {
            Int32 member_id = DBM.GetMemberId(initials);
            DataTable memberData = DBM.GetMemeberStatistics(member_id, employment, limit);

            Double[] premiumValue = new Double[memberData.Rows.Count];
            String[] date = new String[memberData.Rows.Count];

            if (!memberData.Rows[0][1].Equals(DBNull.Value))
            {
                for (int i = 0; i < memberData.Rows.Count; i++)
                {
                    premiumValue[i] = Convert.ToDouble(memberData.Rows[i][1]);
                    date[i] = DBM.GetDate(Convert.ToInt32(memberData.Rows[i][0])).ToString("dd.MM.yyyy");
                }
            }

            GraphPane pane = ZGC.GraphPane;
            pane.CurveList.Clear();
            pane.GraphItemList.Clear();

            date.Reverse();
            premiumValue.Reverse();
            BarItem curve = pane.AddBar("", null, premiumValue, Color.CornflowerBlue);
            curve.Bar.Fill.Type = FillType.Solid;
            curve.Bar.Border.IsVisible = false;
            for (int i = 0; i < curve.Points.Count; i++)
            {
                TextItem ti = new TextItem(curve.Points[i].Y.ToString(), (float)curve.Points[i].X, (float)curve.Points[i].Y/2);
                ti.FontSpec.Border.IsVisible = false;
                ti.FontSpec.Fill.Type = FillType.None;
                ti.FontSpec.Size = 16;
                ti.FontSpec.IsBold = true;
                pane.GraphItemList.Add(ti);
            }

            pane.MinBarGap = 0.0f;
            pane.XAxis.Type = AxisType.Text;
            pane.XAxis.TextLabels = date;
            pane.Title = "Статистика премии сотрудника " + initials;

            ZGC.AxisChange();
            ZGC.Invalidate();
        }

        public void DrawGraphPremium(DBManagement DBM, ZedGraphControl ZGC, Int32 limit)
        {
            DataTable premiumData = DBM.GetPremiumsStatistics(limit);
            Double[] budgetValue = new Double[premiumData.Rows.Count];
            Double[] paidValue = new Double[premiumData.Rows.Count];
            Double[] paragraphValue = new Double[premiumData.Rows.Count];
            String[] date = new String[premiumData.Rows.Count];

            if (!premiumData.Rows[0][1].Equals(DBNull.Value))
            {
                for (int i = 0; i < premiumData.Rows.Count; i++)
                {
                    budgetValue[i] = Convert.ToDouble(premiumData.Rows[i][1]);
                    paidValue[i] = Convert.ToDouble(premiumData.Rows[i][2]);
                    paragraphValue[i] = Convert.ToDouble(premiumData.Rows[i][3]);
                    DateTime dt = Convert.ToDateTime(premiumData.Rows[i][4]);
                    date[i] = dt.ToString("dd.MM.yyyy");
                }
            }

            GraphPane pane = ZGC.GraphPane;
            pane.CurveList.Clear();
            pane.GraphItemList.Clear();

            BarItem budget = pane.AddBar("Бюджет", null, budgetValue, Color.OrangeRed);
            BarItem paid = pane.AddBar("Платное", null, paidValue, Color.LightBlue);
            BarItem paragraph = pane.AddBar("§54", null, paragraphValue, Color.LightGreen);
            budget.Bar.Fill.Type = FillType.Solid;
            paid.Bar.Fill.Type = FillType.Solid;
            paragraph.Bar.Fill.Type = FillType.Solid;
            for (int i = 0; i < budget.Points.Count; i++)
            {
                TextItem tiB = new TextItem(budget.Points[i].Y.ToString(), (float)budget.Points[i].X - 0.25f, (float)budget.Points[i].Y / 5);
                tiB.FontSpec.Border.IsVisible = false;
                tiB.FontSpec.Fill.Type = FillType.None;
                tiB.FontSpec.Size = 16;
                tiB.FontSpec.IsBold = true;
                tiB.FontSpec.Angle = -90;
                pane.GraphItemList.Add(tiB);
                TextItem tiPaid = new TextItem(paid.Points[i].Y.ToString(), (float)paid.Points[i].X, (float)paid.Points[i].Y / 5);
                tiPaid.FontSpec.Border.IsVisible = false;
                tiPaid.FontSpec.Fill.Type = FillType.None;
                tiPaid.FontSpec.Size = 16;
                tiPaid.FontSpec.IsBold = true;
                tiPaid.FontSpec.Angle = -90;
                pane.GraphItemList.Add(tiPaid);
                TextItem tiPara = new TextItem(paragraph.Points[i].Y.ToString(), (float)paragraph.Points[i].X + 0.25f, (float)paragraph.Points[i].Y / 5);
                tiPara.FontSpec.Border.IsVisible = false;
                tiPara.FontSpec.Fill.Type = FillType.None;
                tiPara.FontSpec.Size = 16;
                tiPara.FontSpec.IsBold = true;
                tiPara.FontSpec.Angle = -90;
                pane.GraphItemList.Add(tiPara);
            }

            pane.XAxis.Type = AxisType.Text;
            pane.XAxis.TextLabels = date;
            pane.MinBarGap = 0.0f;
            pane.MinClusterGap = 1.0f;
            pane.YAxis.Type = AxisType.Log;
            pane.YAxis.Min = 1.0f;
            pane.Legend.FontSpec.Size = 14;

            ZGC.AxisChange();
            ZGC.Invalidate();
        }
    }
}
