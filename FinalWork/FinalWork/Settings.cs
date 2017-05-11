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
        public Form Main { get; private set; }
        public Boolean change { get; private set; }
        public Options Op { get; private set; }

        public Settings(Form f, Options o)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Settings_Closed);
            this.accuracyUpDown.ValueChanged += UpDown_ValueChanged;
            this.timeUpDown.ValueChanged += UpDown_ValueChanged;
            this.saveCheckBox.CheckedChanged += SaveCheckBox_CheckedChanged;
            Main = f;
            Op = o;
            accuracyUpDown.Value = Op.Accuracy;
            timeUpDown.Value = Op.Period;
            saveCheckBox.Checked = Op.SaveCopy;
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
                Op.Accuracy = Convert.ToInt32(accuracyUpDown.Value);
                Op.Period = Convert.ToInt32(timeUpDown.Value);
                Op.SaveCopy = saveCheckBox.Checked;
                Op.SaveChange();

                change = false;
            }
        }
    }
}
