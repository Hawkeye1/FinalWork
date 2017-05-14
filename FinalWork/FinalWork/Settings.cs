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
    public partial class Settings : Form
    {
        public CountingAward Main { get;  set; }
        public Boolean change { get;  set; }

        public Settings(CountingAward f)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Settings_Closed);
            this.accuracyUpDown.ValueChanged += UpDown_ValueChanged;
            this.timeUpDown.ValueChanged += UpDown_ValueChanged;
            this.saveCheckBox.CheckedChanged += SaveCheckBox_CheckedChanged;
            Main = f;
            accuracyUpDown.Value = Main.Op.Accuracy;
            timeUpDown.Value = Main.Op.Period;
            saveCheckBox.Checked = Main.Op.SaveCopy;
            change = false;
        }

        private void SaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (change == false)
            {
                change = true;
            }
        }
        private void Settings_Closed(object sender, EventArgs e)
        {
            Main.Enabled = true;
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
               Main.Op.SaveChange();

               change = false;
            }
        }
    }
}
