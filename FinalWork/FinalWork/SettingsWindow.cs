using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalWork
{
    public partial class SettingsWindow : Form
    {
        public MainWindow Main { get;  set; }
        public Boolean change { get;  set; }

        public SettingsWindow(MainWindow f)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Settings_Closed);
            this.accuracyUpDown.ValueChanged += UpDown_ValueChanged;
            this.timeUpDown.ValueChanged += UpDown_ValueChanged;
            this.saveCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            this.workTimeCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            this.daysOffCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            this.tripDaysCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            this.sickDaysCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            this.tariffFactorСheckBox.CheckedChanged += CheckBox_CheckedChanged;
            this.workRateCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            this.kCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            Main = f;
            accuracyUpDown.Value = Main.Op.Accuracy;
            timeUpDown.Value = Main.Op.Period;
            saveCheckBox.Checked = Main.Op.SaveCopy;
            workTimeCheckBox.Checked = Main.Op.ColumnsVisible[0];
            daysOffCheckBox.Checked = Main.Op.ColumnsVisible[1];
            tripDaysCheckBox.Checked = Main.Op.ColumnsVisible[2];
            sickDaysCheckBox.Checked = Main.Op.ColumnsVisible[3];
            tariffFactorСheckBox.Checked = Main.Op.ColumnsVisible[4];
            workRateCheckBox.Checked = Main.Op.ColumnsVisible[5];
            kCheckBox.Checked = Main.Op.ColumnsVisible[6];
            change = false;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (change == false)
            {
                change = true;
            }
        }
        private void Settings_Closed(object sender, EventArgs e)
        {
            Main.Enabled = true;
            Main.Show();
        }
        private void UpDown_ValueChanged(object sender, EventArgs e)
        {
            if (change == false)
            {
                change = true;
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (change)
            {
                if (MessageBox.Show("Изменения не будут сохранены", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            if (change == true)
            {
               Main.Op.Accuracy = Convert.ToInt32(accuracyUpDown.Value);
               Main.Op.Period = Convert.ToInt32(timeUpDown.Value);
               Main.Op.SaveCopy = saveCheckBox.Checked;
               Main.Op.ColumnsVisible[0] = workTimeCheckBox.Checked;
               Main.Op.ColumnsVisible[1] = daysOffCheckBox.Checked;
               Main.Op.ColumnsVisible[2] = tripDaysCheckBox.Checked;
               Main.Op.ColumnsVisible[3] = sickDaysCheckBox.Checked;
               Main.Op.ColumnsVisible[4] = tariffFactorСheckBox.Checked;
               Main.Op.ColumnsVisible[5] = workRateCheckBox.Checked;
               Main.Op.ColumnsVisible[6] = kCheckBox.Checked;
               Main.Op.SaveChange();

               change = false;
            }
        }
    }
}
