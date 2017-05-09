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
        Form main;

        public Settings(Form f)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Settings_Closed);
            main = f;
        }
        private void Settings_Closed(object sender, EventArgs e)
        {
            main.Enabled = true;
        }
    }
}
