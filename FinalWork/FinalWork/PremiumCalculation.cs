using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinalWork
{
    public class PremiumCalculation
    {

        // 7 -
        // 8 -
        // 9 -
        // 10 - 
        public void Calculation(PremiumBlankWindow PBW)
        {
            Double k = 0;
            Double BYNperK = 0;
            Double issuedAuto = 0;
            Double issudeByHand = 0;
            Double correction = 0;

            for (int i = 0; i < PBW.BlankDataGridView.Rows.Count; i++)
            {
                // пересчет - К для каждого сотрудника в списке
                PBW.BlankDataGridView.Rows[i].Cells[11].Value = Math.Round(Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[10].Value) *
                    Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[9].Value) * Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[8].Value) *
                    Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[7].Value), 2, MidpointRounding.AwayFromZero);

                k += Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[11].Value);
            }

            if (k != 0)
            {
                BYNperK = Convert.ToDouble(PBW.AutoFundTextBox.Text) / k;

                for (int i = 0; i < PBW.BlankDataGridView.Rows.Count; i++)
                {
                    

                    PBW.BlankDataGridView.Rows[i].Cells[13].Value =
                        Math.Round(BYNperK * (Double)PBW.BlankDataGridView.Rows[i].Cells[11].Value, PBW.Main.Op.Accuracy - 2, MidpointRounding.AwayFromZero);
                    PBW.BlankDataGridView.Rows[i].Cells[15].Value = Math.Round(Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[12].Value) +
                        Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[13].Value) + Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[14].Value),
                        PBW.Main.Op.Accuracy, MidpointRounding.AwayFromZero);

                    issudeByHand += Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[12].Value);
                    issuedAuto += Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[13].Value);
                    correction += Convert.ToDouble(PBW.BlankDataGridView.Rows[i].Cells[14].Value);
                }

                PBW.LeftByHandFundTextBox.Text = Math.Round((Convert.ToDouble(PBW.ByHandFundTextBox.Text) - issudeByHand), PBW.Main.Op.Accuracy, MidpointRounding.AwayFromZero).ToString();
                PBW.LeftAutoFundTextBox.Text = Math.Round((Convert.ToDouble(PBW.AutoFundTextBox.Text) - issuedAuto - correction), PBW.Main.Op.Accuracy, MidpointRounding.AwayFromZero).ToString();
            }
        }
    }
}
