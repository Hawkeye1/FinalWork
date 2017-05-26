using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalWork
{
    public partial class PremiumBlankWindow : Form
    {
        const int FORMCOUNT = 3;                                        // Кол-во форм премий

        public MainWindow Main { get; set; }
        public int Step { get; set; }
        public DataTable[] Blanks { get; set; }
        public Double[] TotalFund { get; set; }
        public Double[] AutoFund { get; set; }
        public Boolean[] Duplicated { get; set; }
        public Boolean[] NoRecordnDB { get; set; }
        public Boolean[] BalanceAuto { get; set; }
        public Boolean[] BalanceByHand { get; set; }
        public DataGridView BlankDataGridView
        {
            get { return blankDataGridView; }
        }
        
        public PremiumBlankWindow(MainWindow f)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(AwardBlank_Closed);
            Main = f;
            Step = 0;
            //
            // DataGridView - Initialize
            InitBlanks();
            blankDataGridView.DataSource = Blanks[0];
            InitDataGridView();
            blankDataGridView.KeyDown += BlankDataGridView_KeyDown;
            blankDataGridView.DataSourceChanged += BlankDataGridView_DataSourceChanged;
            blankDataGridView.Sorted += BlankDataGridView_Sorted;
            blankDataGridView.CellEndEdit += BlankDataGridView_CellEndEdit;
            blankDataGridView.DataError += BlankDataGridView_DataError;
            blankDataGridView.AutoResizeColumns();
            blankDataGridView.AutoResizeRows();
            //
            // TextBoxes - Initialize
            totalFundTextBox.KeyPress += InputDouble;
            autoFundTextBox.KeyPress += InputDouble;
            totalFundTextBox.Text = TotalFund[0].ToString();
            autoFundTextBox.Text = AutoFund[0].ToString();
            totalFundTextBox.Leave += TotalFundTextBox_Leave;
            autoFundTextBox.Leave += AutoFundTextBox_Leave;
            leftByHandFundTextBox.TextChanged += LeftByHandFundTextBox_TextChanged;
            leftAutoFundTextBox.TextChanged += LeftAutoFundTextBox_TextChanged;
        }

        private void BlankDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Неверный тип данных!\n Ожидаемый тип: " + blankDataGridView.CurrentCell.ValueType.ToString(), "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BlankDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                blankDataGridView.CurrentRow.Selected = false;
            }
        }

        private void LeftAutoFundTextBox_TextChanged(object sender, EventArgs e)
        {
            if (leftAutoFundTextBox.Text != "")
            {
                if (leftAutoFundTextBox.Text == "0")
                {
                    leftAutoFundTextBox.BackColor = Color.LightGreen;
                    BalanceAuto[Step] = true;
                }
                else
                {
                    leftAutoFundTextBox.BackColor = Color.LightCoral;
                    BalanceAuto[Step] = false;
                }
            }
        }

        private void LeftByHandFundTextBox_TextChanged(object sender, EventArgs e)
        {
            if (leftByHandFundTextBox.Text != "")
            {
                if (leftByHandFundTextBox.Text == "0")
                {
                    leftByHandFundTextBox.BackColor = Color.LightGreen;
                    BalanceByHand[Step] = true;
                }
                else
                {
                    leftByHandFundTextBox.BackColor = Color.LightCoral;
                    BalanceByHand[Step] = false;
                }
            }
        }

        private void InitDataGridView()
        {
            blankDataGridView.MultiSelect = false;
            blankDataGridView.RowHeadersVisible = false;

            blankDataGridView.Columns[0].ReadOnly = true;
            blankDataGridView.Columns[1].ReadOnly = true;
            blankDataGridView.Columns[2].ReadOnly = true;
            blankDataGridView.Columns[3].ReadOnly = true;
            blankDataGridView.Columns[4].ReadOnly = true;
            blankDataGridView.Columns[5].ReadOnly = true;
            blankDataGridView.Columns[6].ReadOnly = true;
            blankDataGridView.Columns[7].ReadOnly = true;
            blankDataGridView.Columns[9].ReadOnly = true;
            blankDataGridView.Columns[11].ReadOnly = true;
            blankDataGridView.Columns[13].ReadOnly = true;
            blankDataGridView.Columns[15].ReadOnly = true;

            blankDataGridView.Columns[3].Visible = Main.Op.ColumnsVisible[0];
            blankDataGridView.Columns[4].Visible = Main.Op.ColumnsVisible[1];
            blankDataGridView.Columns[5].Visible = Main.Op.ColumnsVisible[2];
            blankDataGridView.Columns[6].Visible = Main.Op.ColumnsVisible[3];
            blankDataGridView.Columns[7].Visible = Main.Op.ColumnsVisible[4];
            blankDataGridView.Columns[9].Visible = Main.Op.ColumnsVisible[5];
            blankDataGridView.Columns[11].Visible = Main.Op.ColumnsVisible[6];
        }

        private void BlankDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            PremiumsAutoCount();
        }

        private void BlankDataGridView_Sorted(object sender, EventArgs e)
        {
            CheckMembersInDB((DataGridView)sender);
            MarkMembers();
        }

        public void PremiumsAutoCount()
        {
            Double k = 0;
            Double BYNperK = 0;
            Double issuedAuto = 0;
            Double issudeByHand = 0;
            Double correction = 0;

            for (int i = 0; i < blankDataGridView.Rows.Count; i++)
            {
                // пересчет - К для каждого сотрудника в списке
                blankDataGridView.Rows[i].Cells[11].Value = Math.Round(Convert.ToDouble(blankDataGridView.Rows[i].Cells[10].Value) *
                    Convert.ToDouble(blankDataGridView.Rows[i].Cells[9].Value) * Convert.ToDouble(blankDataGridView.Rows[i].Cells[8].Value) *
                    Convert.ToDouble(blankDataGridView.Rows[i].Cells[7].Value), 2, MidpointRounding.AwayFromZero);

                k += Convert.ToDouble(blankDataGridView.Rows[i].Cells[11].Value);
            }

            if (k != 0)
            {
                BYNperK = Convert.ToDouble(autoFundTextBox.Text) / k;

                for (int i = 0; i < blankDataGridView.Rows.Count; i++)
                {
                    blankDataGridView.Rows[i].Cells[13].Value =
                        Math.Round(BYNperK * (Double)blankDataGridView.Rows[i].Cells[11].Value, Main.Op.Accuracy - 2, MidpointRounding.AwayFromZero);
                    blankDataGridView.Rows[i].Cells[15].Value = Math.Round(Convert.ToDouble(blankDataGridView.Rows[i].Cells[12].Value) +
                        Convert.ToDouble(blankDataGridView.Rows[i].Cells[13].Value) + Convert.ToDouble(blankDataGridView.Rows[i].Cells[14].Value), 
                        Main.Op.Accuracy, MidpointRounding.AwayFromZero);

                    issudeByHand += Convert.ToDouble(blankDataGridView.Rows[i].Cells[12].Value);
                    issuedAuto += Convert.ToDouble(blankDataGridView.Rows[i].Cells[13].Value);
                    correction += Convert.ToDouble(blankDataGridView.Rows[i].Cells[14].Value);
                }

                leftByHandFundTextBox.Text = Math.Round((Convert.ToDouble(byHandFundTextBox.Text) - issudeByHand), Main.Op.Accuracy, MidpointRounding.AwayFromZero).ToString();
                leftAutoFundTextBox.Text = Math.Round((Convert.ToDouble(autoFundTextBox.Text) - issuedAuto - correction), Main.Op.Accuracy, MidpointRounding.AwayFromZero).ToString();
            }
        }

        private void AutoFundTextBox_Leave(object sender, EventArgs e)
        {
            double num;
            TextBox tb = (TextBox)sender;

            if (tb.Text != "")
            {
                if (!Double.TryParse(tb.Text, out num))
                {
                    MessageBox.Show("Неверный формат числа!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    num = Math.Round(num, Main.Op.Accuracy, MidpointRounding.AwayFromZero);
                    tb.Text = num.ToString();

                    if (Convert.ToDouble(totalFundTextBox.Text) < Convert.ToDouble(autoFundTextBox.Text))
                    {
                        MessageBox.Show("Сумма для автоматического расспределения не может быть больше общей суммы", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        autoFundTextBox.Text = totalFundTextBox.Text;
                    }

                    byHandFundTextBox.Text = (Convert.ToDouble(totalFundTextBox.Text) - Convert.ToDouble(autoFundTextBox.Text)).ToString();
                    PremiumsAutoCount();
                }
            }
        }

        private void TotalFundTextBox_Leave(object sender, EventArgs e)
        {
            double num;
            TextBox tb = (TextBox)sender;

            if (tb.Text != "")
            {
                if (!Double.TryParse(tb.Text, out num))
                {
                    MessageBox.Show("Неверный формат числа!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    num = Math.Round(num, Main.Op.Accuracy, MidpointRounding.AwayFromZero);
                    tb.Text = num.ToString();

                    if (Convert.ToDouble(totalFundTextBox.Text) < Convert.ToDouble(autoFundTextBox.Text))
                    {
                        MessageBox.Show("Сумма для автоматического расспределения не может быть больше общей суммы", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        autoFundTextBox.Text = totalFundTextBox.Text;
                    }

                    byHandFundTextBox.Text = (Convert.ToDouble(totalFundTextBox.Text) - Convert.ToDouble(autoFundTextBox.Text)).ToString();
                    PremiumsAutoCount();
                }
            }
        }

        private void InputDouble(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            else if (tb.Text != "" && Char.IsDigit(tb.Text[0]) && e.KeyChar == ',' && tb.Text.ToString().Contains(','))
            {
                e.Handled = true;
            }
        }

        private void InitBlanks()
        {
            Blanks = new DataTable[FORMCOUNT];
            TotalFund = new Double[FORMCOUNT];
            AutoFund = new Double[FORMCOUNT];
            Duplicated = new Boolean[FORMCOUNT];
            NoRecordnDB = new Boolean[FORMCOUNT];
            BalanceAuto = new Boolean[FORMCOUNT];
            BalanceByHand = new Boolean[FORMCOUNT];

            for (int i = 0; i < FORMCOUNT; i++)
            {
                Blanks[i] = InitTable();
                TotalFund[i] = 0.0;
                AutoFund[i] = 0.0;
                BalanceByHand[i] = true;
                BalanceAuto[i] = true;
            }
        }

        private void BlankDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            blankDataGridView.AutoResizeColumns();
            blankDataGridView.AutoResizeRows();
            CheckMembersInDB((DataGridView)sender);
            MarkMembers();
        }

        private DataTable InitTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ФИО");
            table.Columns.Add("Должность");
            table.Columns.Add("Штатность");
            table.Columns.Add("Часов\nработы");
            table.Columns[3].DataType = Type.GetType("System.Double");
            table.Columns[3].DefaultValue = 0;
            table.Columns.Add("Выходных\nдней");
            table.Columns[4].DataType = Type.GetType("System.Int32");
            table.Columns[4].DefaultValue = 0;
            table.Columns.Add("Дней в\nкомандировке");
            table.Columns[5].DataType = Type.GetType("System.Int32");
            table.Columns[5].DefaultValue = 0;
            table.Columns.Add("Дней на\nбольничном");
            table.Columns[6].DataType = Type.GetType("System.Int32");
            table.Columns[6].DefaultValue = 0;
            table.Columns.Add("Тар.коэфф");
            table.Columns[7].DataType = Type.GetType("System.Double");
            table.Columns.Add("Стаж");
            table.Columns[8].DataType = Type.GetType("System.Double");
            table.Columns[8].DefaultValue = 1;
            table.Columns.Add("Ставка");
            table.Columns[9].DataType = Type.GetType("System.Double");
            table.Columns.Add("КТУ (авт.)");
            table.Columns[10].DataType = Type.GetType("System.Double");
            table.Columns[10].DefaultValue = 1;
            table.Columns.Add("(К)");
            table.Columns[11].DataType = Type.GetType("System.Double");
            table.Columns.Add("Выдать\n(вручн.)");
            table.Columns[12].DataType = Type.GetType("System.Double");
            table.Columns[12].DefaultValue = 0;
            table.Columns.Add("Выдать\n(авт.)");
            table.Columns[13].DataType = Type.GetType("System.Double");
            table.Columns[13].DefaultValue = 0;
            table.Columns.Add("Коррекция");
            table.Columns[14].DataType = Type.GetType("System.Double");
            table.Columns[14].DefaultValue = 0;
            table.Columns.Add("Итого");
            table.Columns[15].DataType = Type.GetType("System.Double");
            table.Columns[15].DefaultValue = 0;
            table.Columns.Add("Примечания");

            return table;
        }

        private void AwardBlank_Closed(object sender, EventArgs e)
        {
            Main.Enabled = true;
            Main.Show();
        }

        private void AddMembersStrip_Click(object sender, EventArgs e)
        {
            DataTable members = new DataTable();
            members.Reset();
            members = Main.IS.LoadData();
            members = Main.IS.DataProcessing(Main.DBM, members);
            Main.DBM.AddMembers(members, Main.IS.Employment);
            CheckMembersInDB(blankDataGridView);
            MarkMembers();
        }

        private void AddMemberStrip_Click(object sender, EventArgs e)
        {
            if (blankDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected) > -1)
            {
                DataTable table = (DataTable)blankDataGridView.DataSource;
                DataRow row = table.Rows[blankDataGridView.CurrentRow.Index];
                Main.DBM.AddMember(row);
                blankDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;
                CheckMembersInDB(blankDataGridView);
            }
        }

        public void CheckMembersInDB(DataGridView DGV)
        {
            DataTable members = Main.DBM.GetMembers();
            DataTable staff = Main.DBM.GetStaff();
            DataTable pluralists = Main.DBM.GetPluralists();
            Boolean match;
            NoRecordnDB[Step] = false;

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                match = false;

                foreach (DataRow member in members.Rows)
                {
                    if (member[1].ToString().Equals(DGV.Rows[i].Cells[0].Value))
                    {
                        DGV.Rows[i].Cells[8].Value = Convert.ToDouble(member[2].ToString());

                        if (DGV.Rows[i].Cells[2].Value.Equals("штатный"))
                        {
                            foreach (DataRow row in staff.Rows)
                            {
                                if (row[1].Equals(member[0]))
                                {
                                    match = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow row in pluralists.Rows)
                            {
                                if (row[1].Equals(member[0]))
                                {
                                    match = true;
                                    break;
                                }
                            }
                        }

                        break;
                    }
                }

                if (!match)
                {
                    DGV.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                    NoRecordnDB[Step] = true;
                }
            }
        }

        public void MarkMembers()
        {
            Duplicated[Step] = false;

            for (int i = 0; i < blankDataGridView.Rows.Count; i++)
            {
                if (blankDataGridView.Rows[i].DefaultCellStyle.BackColor != Color.OrangeRed)
                {
                    if (blankDataGridView.Rows[i].DefaultCellStyle.BackColor != Color.Cyan)
                    {
                        if (Convert.ToInt32(blankDataGridView.Rows[i].Cells[5].Value) != 0 && 
                            Convert.ToInt32(blankDataGridView.Rows[i].Cells[6].Value) != 0)
                        {
                            blankDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                        }
                        else if (Convert.ToInt32(blankDataGridView.Rows[i].Cells[5].Value) != 0)
                        {
                            blankDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else if (Convert.ToInt32(blankDataGridView.Rows[i].Cells[6].Value) != 0)
                        {
                            blankDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.MediumVioletRed;
                        }

                        for (int j = i + 1; j < blankDataGridView.Rows.Count; j++)
                        {
                            if (blankDataGridView.Rows[i].Cells[0].Value.Equals(blankDataGridView.Rows[j].Cells[0].Value))
                            {
                                blankDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
                                blankDataGridView.Rows[j].DefaultCellStyle.BackColor = Color.Cyan;
                                Duplicated[Step] = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void ImportWorkTimeStrip_Click(object sender, EventArgs e)
        {
            DataTable members = new DataTable();
            members.Reset();
            members = Main.IWT.LoadData();
            members = Main.IWT.CountingWorkTime(Main.DBM, members);
            AddInForm(members, blankDataGridView);
            blankDataGridView.AutoResizeColumns();
            blankDataGridView.AutoResizeRows();
            blankDataGridView.ClearSelection();
            CheckMembersInDB(blankDataGridView);
            MarkMembers();
            PremiumsAutoCount();
        }

        public void AddInForm(DataTable temp, DataGridView DGV)
        {
            Boolean match;
            Int32 formId1 = 1, formId2 = 2;
            DataTable table = (DataTable)DGV.DataSource;
            DataTable addMembers = table.Clone();
            
            if (Step == 1)
            {
                formId1 = 0;
                formId2 = 2;
            }
            else if (Step == 2)
            {
                formId1 = 0;
                formId2 = 1;
            }

            foreach (DataRow row in temp.Rows)
            {
                match = false;
                // проверка есть ли данный человек в DataGridView
                foreach (DataRow source in table.Rows)
                {
                    if (source[0].Equals(row[0]) && source[2].Equals(row[2]))
                    {
                        match = true;
                        break;
                    }
                }
                // проверка есть ли есть данный человек в других формах
                if (!match)
                {
                    foreach (DataRow source in Blanks[formId1].Rows)
                    {
                        if (source[0].Equals(row[0]) && source[2].Equals(row[2]))
                        {
                            match = true;
                            break;
                        }
                    }
                }

                if (!match)
                {
                    foreach (DataRow source in Blanks[formId2].Rows)
                    {
                        if (source[0].Equals(row[0]) && source[2].Equals(row[2]))
                        {
                            match = true;
                            break;
                        }
                    }
                }
                // добавление человека в форму
                if (!match)
                {
                    DataRow dr = addMembers.NewRow();

                    dr[0] = row[0];
                    dr[1] = row[1];
                    dr[2] = row[3];
                    dr[3] = row[4];
                    dr[4] = row[5];
                    dr[5] = row[6];
                    dr[6] = row[7];
                    dr[7] = row[8];
                    dr[8] = 1.0;
                    dr[9] = row[2];
                    dr[10] = 1.0;
                    dr[11] = Math.Round(Convert.ToDouble(dr[7]) * Convert.ToDouble(dr[8]) * Convert.ToDouble(dr[9]) * Convert.ToDouble(dr[10]), 3);

                    addMembers.Rows.Add(dr);
                }

            }

            table.Merge(addMembers);
        }

        private void AddInFormStrip_Click(object sender, EventArgs e)
        {
            AddUserWindow AUW = new AddUserWindow(this);
            AUW.Visible = true;
            this.Enabled = false;
        }

        private void DeleteRowStrip_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Warning", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (blankDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected) > -1)
                {
                    if (blankDataGridView.CurrentRow.DefaultCellStyle.BackColor == Color.Cyan)
                    {
                        for (int i = 0; i < blankDataGridView.Rows.Count; i++)
                        {
                            if (blankDataGridView.CurrentRow.Cells[0].Value.Equals(blankDataGridView.Rows[i].Cells[0].Value) &&
                                (i != blankDataGridView.CurrentRow.Index))
                            {
                                blankDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                            }
                        }
                    }

                    blankDataGridView.Rows.RemoveAt(blankDataGridView.CurrentRow.Index);
                    PremiumsAutoCount();
                }
            }
        }

        private void ChangeStep()
        {
            String[] BlankName = {"БЮДЖЕТНАЯ ФОРМА" ,"ПЛАТНАЯ ФОРМА" , "§54" };
            String[] FundName = { "Бюджет", "Платное", "§54" };

            if (Step == 0)
            {
                backButton.Enabled = false;
            }
            else if (Step == 1)
            {
                backButton.Enabled = true;
            }

            if (Step == (FORMCOUNT - 2))
            {
                nextSaveButton.Text = "Далее";
            }
            else if (Step == (FORMCOUNT - 1))
            {
                nextSaveButton.Text = "Сохранить";
            }

            blankNameLabel.Text = BlankName[Step];
            totalFundLabel.Text = FundName[Step];
            blankDataGridView.DataSource = Blanks[Step];

            totalFundTextBox.Text = TotalFund[Step].ToString();
            autoFundTextBox.Text = AutoFund[Step].ToString();
            byHandFundTextBox.Text = (TotalFund[Step] - AutoFund[Step]).ToString();

            leftByHandFundTextBox.Text = "0";
            leftAutoFundTextBox.Text = "0";
            PremiumsAutoCount();
            blankDataGridView.ClearSelection();
        }

        private void nextSaveButton_Click(object sender, EventArgs e)
        {
            if (Step != (FORMCOUNT - 1))
            {
                Blanks[Step] = blankDataGridView.DataSource as DataTable;
                TotalFund[Step] = Convert.ToDouble(totalFundTextBox.Text);
                AutoFund[Step] = Convert.ToDouble(autoFundTextBox.Text);
                Step++;
                ChangeStep();
                PremiumsAutoCount();
            }
            else
            {
                if (NoRecordnDB.Contains(true))
                {
                    MessageBox.Show("Не все сотрудники есть в базе!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Duplicated.Contains(true))
                {
                    MessageBox.Show("Есть дублирующиеся сотрудники!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (BalanceAuto.Contains(false) || BalanceByHand.Contains(false))
                {
                    MessageBox.Show("Не сходится баланс!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Вы уверены что хотите завершить расчет?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (Blanks[0].Rows.Count != 0 || Blanks[1].Rows.Count != 0 || Blanks[2].Rows.Count != 0)
                        {
                            TotalFund[2] = Convert.ToDouble(totalFundTextBox.Text);
                            Blanks[2] = blankDataGridView.DataSource as DataTable;

                            Main.DBM.AddRecords(Blanks, FORMCOUNT);
                            Main.DBM.AddPremiums(TotalFund);
                            Main.DBM.AddArchive();

                            SaveFileDialog SFD = new SaveFileDialog();
                            SFD.Filter = "odt file (*.odt)|*.odt|html file (*.html)|*.html|pdf file (*.pdf)|*.pdf";
                            SFD.InitialDirectory = Directory.GetCurrentDirectory();
                            SFD.SupportMultiDottedExtensions = false;
                            SFD.FilterIndex = 1;

                            if (SFD.ShowDialog() == DialogResult.OK)
                            {
                                if (SFD.FilterIndex != 3)
                                {
                                    Main.COHF.CreateOdtHtmlFile(Main.Op.SaveCopy, Blanks, TotalFund, SFD.FilterIndex, SFD.FileName);
                                }
                                else
                                {
                                    MessageBox.Show("Временно не доступно", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }

                        this.Close();
                    }
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (Step != 0)
            {
                Blanks[Step] = (DataTable)blankDataGridView.DataSource;
                TotalFund[Step] = Convert.ToDouble(totalFundTextBox.Text);
                AutoFund[Step] = Convert.ToDouble(autoFundTextBox.Text);
                Step--;
                ChangeStep();
                PremiumsAutoCount();
            }
        }
    }
}
