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
    public partial class AwardBlank : Form
    {
        Form main;
        
        public AwardBlank(Form f)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(AwardBlank_Closed);
            main = f;
        }

        private void AwardBlank_Closed(object sender, EventArgs e)
        {
            main.Enabled = true;
        } 
    }
}
