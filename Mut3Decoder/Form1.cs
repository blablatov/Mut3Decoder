using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Mut3Decoder
{
    public partial class Form1 : Form
    {
        Mut3 mut;
        Progress progress;
        string coding;
        string filter;
        int[] favorites = null;
        long LF;
        public int stmp;
        public int skey;
        //public bool indicator;
        public char indicator;

        public Form1(Mut3 mut)
        {
            progress = new Progress();
            this.mut = mut;
            InitializeComponent();
/*
            this.carYear.Text = "2013";
            this.carType.Text = "GF2W";
            this.carKind.Text = "XTSHZL6Z";
            this.codingHex.Text = "001A3380AE0504001C001A66240000A8B7A9B38D180000000845014802083716009B0E1C6D086B792C5035030C28193591041C24953100800016000000000000000000000000";
*/
            grid.Columns.Add("Name", "Name");
            grid.Columns[0].Width = 315;
            grid.Columns.Add("Value", "Value");
            grid.Columns[1].Width = 100;
            grid.Columns.Add("NewValue", "New Value");
            grid.Columns[2].Width = 100;
            grid.Columns.Add("NewValueHex", "hex");
            grid.Columns[3].Width = 30;
            int c = grid.Columns.Add("id", null);
            grid.Columns[c].Width = 30;
            grid.Columns[c].Visible = false;
            

            itemValues.Columns.Add("Value", "Value");
            itemValues.Columns[0].Width = 200;
            itemValues.Columns.Add("hex", null);
            itemValues.Columns[1].Width = 30;

            grid.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.RowHeadersWidth = 54;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showCoding();
        }

        private void loadCar()
        {
            skey = Int32.Parse(ComBoxSkey.Text);
            if (diagVer.Items.Count == 0 && InputDiag.Text == "")
                throw new Exception("Select Diagversion or input own");
                else if (diagVer.Items.Count == 0) loadCar2();
                else if (InputDiag.Text != "") loadCar2();
                else if (radioEtacs.Checked)
                mut.loadEtacs(carYear.Text, carType.Text, carKind.Text, int.Parse(diagVer.Text), skey);
                else if (radioMotor.Checked)
                mut.loadMotor(carYear.Text, carType.Text, carKind.Text, int.Parse(diagVer.Text), skey);
                else if (radioSrsAirBag.Checked)
                mut.loadSrsAirBag(carYear.Text, carType.Text, carKind.Text, int.Parse(diagVer.Text), skey);
                else if (radioTransmission.Checked)
                mut.loadTransmission(carYear.Text, carType.Text, carKind.Text, int.Parse(diagVer.Text), skey);

        }

        private void loadCar2()
        {
            if (radioEtacs.Checked)
                mut.loadEtacs(carYear.Text, carType.Text, carKind.Text, int.Parse(InputDiag.Text), skey);
            else if (radioMotor.Checked)
                mut.loadMotor(carYear.Text, carType.Text, carKind.Text, int.Parse(InputDiag.Text), skey);
            else if (radioSrsAirBag.Checked)
                mut.loadSrsAirBag(carYear.Text, carType.Text, carKind.Text, int.Parse(InputDiag.Text), skey);
            else if (radioTransmission.Checked)
                mut.loadTransmission(carYear.Text, carType.Text, carKind.Text, int.Parse(InputDiag.Text), skey);
            //loadSkeyVers();
        }

        private void showCoding()
        {
            grid.Rows.Clear();
            SqlDataReader reader = mut.readEtacs(skey);
            while (reader.Read())
            {
                int r = grid.Rows.Add();
                grid.Rows[r].HeaderCell.Value = System.Convert.ToString(r + 1);
                grid.Rows[r].Cells[0].Value = reader["NAME"].ToString() + " /// " + reader["NAME_E"].ToString();
                grid.Rows[r].Cells["id"].Value = reader["QUAL_ID"];
            }
            if (this.favorites != null)
            {
                for (int i = 0; i < this.favorites.Length; ++i)
                {
                    if (this.favorites[i] <= grid.Rows.Count)
                    {
                        grid.Rows[this.favorites[i] - 1].Cells[0].Style.BackColor = Color.Aquamarine;
                    }
                }
            }

            reader.Close();
        }

        private void decode(bool compare, String hex)
        {
            progress.progressBar.Maximum = grid.Rows.Count;
            progress.progressBar.Value = 0;

            for (int i = 0; i < grid.Rows.Count; ++i)
            {
                DataGridViewCellCollection cells = grid.Rows[i].Cells;
                //if (i == 56) grid.Rows[i=57].Cells["id"].Value = 236;
                int id = (int)grid.Rows[i].Cells["id"].Value;

                //for (int icnt = 0; icnt > 1; ++icnt);
                    //if (id == 237) --id; //--i;

                Dictionary<String, String> values = mut.getFragValues(id, skey);

                if (i > 0 && !cells["id"].Value.Equals((int)grid.Rows[i - 1].Cells["id"].Value + 1)) {
                    cells["id"].Style.BackColor = Color.Yellow;
                }

                int pos = 0, bit = 0, length = 0;
                mut.getFragProperties(id, ref pos, ref bit, ref length, skey);
               if (id == 357)
                    id = 357;
                if (length == 16)
                    length = 8;
                if (pos == 40)
                    pos = 34;
                String s = hex.Substring(pos * 2, length <= 8 ? 2 : 4);
                UInt16 val = Convert.ToUInt16(s, 16);
                if (bit != 255)
                {
                    int mask = ((1 << length) - 1) << bit;
                    val = (UInt16)(val & mask);
                }
                String sval = val.ToString("X2");
                try
                {
                    cells[2].Value = values[sval];
                }
                catch (Exception)
                {
                    MessageBox.Show("Can't understand value for parameter " + cells[0].Value);
                    cells[2].Value = "N/A";
                    cells[0].Style.BackColor = Color.Red;
                }
                cells[2].Style.BackColor = SystemColors.Window;
                if (!compare)
                {
                    cells[1].Value = cells[2].Value;
                }
                else
                {
                    if (!cells[2].Value.Equals(cells[1].Value))
                    {
                        cells[2].Style.BackColor = Color.Yellow;
                    }
                }
                cells["NewValueHex"].Value = sval;
                progress.progressBar.Increment(1);
                progress.progressBar.Update();
            }
        }

        private bool validateParams()
        {
            statusLabel.Text = filter = "";
            carType.Text = carType.Text.Trim();
            carYear.Text = carYear.Text.Trim();
            carKind.Text = carKind.Text.Trim();

            if (carType.Text.Length == 0)
            {
                MessageBox.Show("Car type is empty");
                carType.Focus();
                return false;
            }
            if (carYear.Text.Length == 0)
            {
                MessageBox.Show("Car year is empty");
                carYear.Focus();
                return false;
            }
            if (carKind.Text.Length == 0)
            {
                MessageBox.Show("Car kind is empty");
                carKind.Focus();
                return false;
            }
            if (!radioEtacs.Checked && !radioMotor.Checked && !radioSrsAirBag.Checked && !radioTransmission.Checked)
            {
                MessageBox.Show("Select ECU type");
                groupBox1.Focus();
                return false;
            }
            return true;
        }

        public string SelectSkey
        {
            get { return ComBoxSkey.Text; }
            set { ComBoxSkey.Text = value; }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (!validateParams())
                return;
            codingHex.Text = codingHex.Text.Trim();
            if (codingHex.Text.Length == 0)
            {
                MessageBox.Show("Specify coding");
                return;
            }
            if (ComBoxSkey.Text == "" || diagVer.Text == "") 
                {
                    MessageBox.Show("Select SKEY and Diagversion");
                }

            try
            {
                loadCar();
                showCoding();
                if (grid.Rows.Count > 1)
                {
                    itemSelected(grid.SelectedRows[0].Index);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            progress.StartPosition = FormStartPosition.Manual;
            progress.Location = new Point(Location.X + Width / 2 - progress.Width / 2, Location.Y + Height / 2 - progress.Height / 2);
            progress.Show();
            decode(false, codingHex.Text);
            progress.Hide();
        }

        private void decode2_Click(object sender, EventArgs e)
        {
            if (!validateParams())
                return;
            if (codingHexNewRich.Text.Length == 0)
            {
                MessageBox.Show("Specify coding");
                return;
            }

            if (codingHexNewRich.Text.Length != codingHex.Text.Length)
            {
                MessageBox.Show("Different length of codings");
                return;
            }
            progress.StartPosition = FormStartPosition.Manual;
            progress.Location = new Point(Location.X + Width / 2 - progress.Width / 2, Location.Y + Height / 2 - progress.Height / 2);
            progress.Show();
            decode(true, codingHexNewRich.Text);
            progress.Hide();
        }

        private void itemSelected(int row)
        {
            itemValues.Rows.Clear();
            DataGridViewCellCollection cells = grid.Rows[row].Cells;
            Object v = cells["id"].Value;
            if (v == null)
                return;
            int id = (int)v;
            Dictionary<String, String> values = mut.getFragValues(id, skey);

            foreach (KeyValuePair<String, String> pair in values)
            {
                int r = itemValues.Rows.Add();
                itemValues.Rows[r].Cells[0].Value = pair.Value;
                itemValues.Rows[r].Cells[1].Value = pair.Key;
                if (pair.Value.Equals(cells[1].Value))
                {
                    itemValues.CurrentCell = itemValues.Rows[r].Cells[0];
                }
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
               //MessageBox.Show("Specify data for search");
                return;
            itemSelected(grid.SelectedRows[0].Index);
        }

        private String makeCoding()
        {
            progress.progressBar.Maximum = grid.Rows.Count;
            progress.progressBar.Value = 0;
            String newHex = String.Empty;
            byte[] hex = new byte[codingHex.Text.Length / 2];
            for (int i = 0; i < hex.Length; ++i)
            {
                String s = codingHex.Text.Substring(i * 2, 2);
                hex[i] = Convert.ToByte(s, 16);
            }

            for (int i = 0; i < grid.Rows.Count - 1; ++i)
            {
                DataGridViewCellCollection cells = grid.Rows[i].Cells;
                int id = (int)cells["id"].Value;
                Dictionary<String, String> values = mut.getFragValues(id, skey);

                int pos = 0, bit = 0, length = 0;
                mut.getFragProperties(id, ref pos, ref bit, ref length, skey);
                if (length == 16)
                    length = 8;
                String q = cells["NewValueHex"].Value.ToString();
                byte b = Convert.ToByte(q, 16);
                if (bit != 255)
                {
                    int mask = ((1 << length) - 1) << bit;
                    hex[pos] &= (byte)~mask;
                    hex[pos] |= (byte)(b & mask);
                }
                else
                    hex[pos] |= (byte)(b);
                progress.progressBar.Increment(1);
                progress.progressBar.Update();
            }

            for (int i = 0; i < hex.Length; ++i)
            {
                newHex += hex[i].ToString("X2");
            }
            return newHex;
        }

        static private void appendRichText(RichTextBox box, Color color, String text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
            }
            box.SelectionLength = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!validateParams())
                return;

            progress.StartPosition = FormStartPosition.Manual;
            progress.Location = new Point(Location.X + Width / 2 - progress.Width / 2, Location.Y + Height / 2 - progress.Height / 2);
            progress.Show();
            String coding = makeCoding();
            progress.Hide();
            if (codingHex.Text.Length != coding.Length)
                return;
            codingHexNewRich.Clear();
            for (int i = 0; i < coding.Length; ++i)
            {
                Color color = coding[i] != codingHex.Text[i] ? Color.Red : SystemColors.WindowText;
                appendRichText(codingHexNewRich, color, coding[i].ToString());
            }
        }

        private void itemValues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = grid.SelectedRows[0].Cells;
            cells["NewValueHex"].Value = itemValues.Rows[e.RowIndex].Cells["hex"].Value;
            cells[2].Value = itemValues.Rows[e.RowIndex].Cells["Value"].Value;
            if (!cells[2].Value.Equals(cells[1].Value))
                cells[2].Style.BackColor = Color.Yellow;
            else
                cells[2].Style.BackColor = SystemColors.Window;
        }

        private void loadDiagVers()
        {
            if (!validateParams())
                return;
            List<String> diags = mut.loadDiagVers(carYear.Text, carType.Text, carKind.Text, indicator);
            diagVer.Items.Clear();
            diagVer.Items.AddRange(diags.ToArray());
            if (diagVer.Items.Count > 0)
                diagVer.SelectedIndex = 0;
        }

        private void diagVer_Enter(object sender, EventArgs e)
        {
            try
            {
                loadDiagVers();
                loadSkeyVers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                carType.Focus();
            }
        }

        private void loadSkeyVers()
        {
            if (!validateParams())
                return;
            List<String> skeys = mut.loadSkeyVers();
            ComBoxSkey.Items.Clear();
            ComBoxSkey.Items.AddRange(skeys.ToArray());
            if (ComBoxSkey.Items.Count > 0)
                ComBoxSkey.SelectedIndex = 0;
        }

        private void verSkey_Enter(object sender, EventArgs e)
        {
            try
            {
                loadSkeyVers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "D:\\Doc\\!out\\Cdgdata";
            dlg.Filter = "KON files (*.kon)|*.kon|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo kfile = new FileInfo(dlg.FileName);
                //FileInfo file = new FileInfo(@"D:\\Doc\\!out\\Cdgdata");
                long LF = kfile.Length;
                if (LF == 1230) this.Charset.Text = "ANSI";
                else this.Charset.Text = "UTF-8";

                coding = System.IO.File.ReadAllText(dlg.FileName, Encoding.UTF8);
                //coding = System.IO.File.ReadAllText(dlg.FileName);

                string config = coding.Substring(49, 14);
                this.carType.Text = config.Substring(0, 4);
                this.carKind.Text = config.Substring(4);
                this.carYear.Text = "20" + coding.Substring(65, 2);
                //this.codingHex.Text = coding.Substring(200, 143);
                this.codingHex.Text = coding.Substring(200, 183);
                //string etacs = coding.Substring(162, 8);
                string etacs = coding.Substring(162, 8);
                //if (etacs.Contains("8637A"))
                if (etacs.Contains("8637A") || etacs.Contains("8637B"))
                {
                    this.radioEtacs.Checked = true;
                    indicator = 'E';
                }
                //else if (etacs.Contains("1860B"))
                else if (etacs.Contains("1860B") || etacs.Contains("1860C") || etacs.Contains("1860D"))
                {
                    this.radioMotor.Checked = true;
                    indicator = 'M';
                }
                else if (etacs.Contains("8635A") || etacs.Contains("8635B"))
                {
                    this.radioSrsAirBag.Checked = true;
                    indicator = 'S';
                }
                else if (etacs.Contains("8631A") || etacs.Contains("8631B"))
                {
                    this.radioTransmission.Checked = true;
                    indicator = 'T';
                }

                if (System.IO.File.Exists("fav\\" + etacs))
                {
                    string[] fav = System.IO.File.ReadAllLines("fav\\" + etacs);
                    loadDiagVers();
                    this.diagVer.Text = fav[0];
                    this.favorites = new int[fav.Length - 1];
                    for (int i = 1; i < fav.Length; ++i)
                    {
                        this.favorites[i - 1] = System.Convert.ToInt32(fav[i]);
                    }
                }
                else
                {
                    this.statusLabel.Text = "Can't load favorites at '" + System.IO.Directory.GetCurrentDirectory() + "\\fav\\" + etacs + "'";
                    this.favorites = null;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.codingHexNewRich.Text.Length == 0)
            {
                MessageBox.Show("Specify coding");
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = "D:\\Doc\\!out\\Cdgdata";
            dlg.Filter = "KON files (*.kon)|*.kon|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string newCodingStr = coding.Replace(this.codingHex.Text, this.codingHexNewRich.Text);
                char[] newCoding = newCodingStr.ToCharArray();
                string crcStr = crc(this.codingHexNewRich.Text);
                for (int i = 0; i < 4; ++i) newCoding[1224 + i] = crcStr[i];
                System.IO.File.WriteAllText(dlg.FileName, new string(newCoding), Encoding.UTF8);
            }
        }

        static private string crc(string inputStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(inputStr);
            for (int i = 0; i <= 0x200; i++)
            {
                if (sb.Length < i)
                    sb.Append(" ");
            }
            inputStr = sb.ToString();
            byte[] str = Encoding.UTF8.GetBytes(inputStr);
            int result = 65535;
            int length = str.Length;
            int CurrentByte = 0;
            int StepByte = 0;

            for (int i = 0; i < length; i++)
            {
                CurrentByte = (int)str[i];
                result ^= CurrentByte;
                StepByte = result;
                for (int j = 0; j < 8; j++)
                {
                    if ((StepByte & 1) == 1)
                    {
                        result = (StepByte >> 1) & 0xFFFF;
                        result ^= 0x8408;
                        StepByte = result;
                    }
                    else
                    {
                        StepByte = (StepByte >> 1) & 0xFFFF;
                        result = StepByte;
                    }
                }
            }
            ushort res = ((ushort)~(short)result);
            return res.ToString("X4");
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                statusLabel.Text = this.filter = "";
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (this.filter.Length > 0) this.filter = this.filter.Remove(this.filter.Length - 1);
            }
            else if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || e.KeyCode == Keys.Space)
            {
                char c = (char)e.KeyValue;
                this.filter += c;
            }
            doFilter();
        }

        private void doFilter()
        {
            if (this.filter.Length > 0) statusLabel.Text = "Filter: " + this.filter.ToLower();
            for (int i = 0; i < grid.Rows.Count; ++i)
            {
                if (this.filter.Length == 0 || grid.Rows[i].Cells[0].Value.ToString().ToUpper().Contains(this.filter))
                {
                    grid.Rows[i].Visible = true;
                    continue;
                }
                grid.Rows[i].Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (this.codingHexNewRich.Text.Length == 0)
            {
                MessageBox.Show("Specify coding");
                btnSave2.Enabled = true;
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = "D:\\Doc\\!out\\Cdgdata";
            dlg.Filter = "KON files (*.kon)|*.kon|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string newCodingStr = coding.Replace(this.codingHex.Text, this.codingHexNewRich.Text);
                char[] newCoding = newCodingStr.ToCharArray();
                string crcStr = crc(this.codingHexNewRich.Text);
                for (int i = 0; i < 4; ++i) newCoding[1224 + i] = crcStr[i];

                System.IO.File.WriteAllText(dlg.FileName, new string(newCoding), Encoding.ASCII);
                //System.IO.File.WriteAllText(dlg.FileName, new string(newCoding), Encoding.UTF8);
            }
        }

        private void itemValues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void carKind_TextChanged(object sender, EventArgs e)
        {

        }

        private void carType_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void carYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Charset_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void radioSrsAirBag_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioMotor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioEtacs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioSrsAirBag_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioTransmission_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioTransmission_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        public string textBox1_TextChanged_1(object sender, EventArgs e)
        {
            return InputDiag.Text;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This programm v5.6 for software PRE17091 of MUT-III (ware tested wiht him).\nIs working to all config-files (.kon) of ECU ETACS, MPI/GDI/DIESEL, SRS-AIR BAG and AT/CVT/A-MT/TC-SST. One can input Diagversion from software MUT-III or select from actual data. Inputed Diagversion has priority over selected from actual data. Also you can select parameter «Versions SKEY» from actual data. Note, it is working, together with Diagversion select from actual data. That is you should select Diagversion from actual data, after that you can select «Versions SKEY». Also realized function of find. \nPatch by Blablatov (vk.com/mitsuparty) \npchupail@gmail.com\t");
            if (btnAbout.DialogResult == DialogResult.OK) { };
        }

        private void btnAboutRu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Эта программа v5.6 для программного обеспечения PRE17091 MUT-III (протестирована с ним).\nРаботает со всеми конфигурационными файлами (.kon) ECU ETACS, MPI/GDI/DIESEL, SRS-AIR BAG и AT/CVT/A-MT/TC-SST. Можно ввести Diagversion из программного обеспечения MUT-III или выбрать из фактических данных. Введенная Diagversion имеет приоритет над выбранными из фактических данных. Также вы можете выбрать параметр «Versions SKEY» из фактических данных. Обратите внимание, что он работает только вместе с выбранным Diagversion из фактических данных. То есть, сначала вы должны выбрать Diagversion из фактических данных, после чего можно будет выбрать «Versions SKEY». Также реализована функция поиска. \nПатч от Blablatov (vk.com/mitsuparty)\npchupail@rambler.ru");
            if (btnAboutRu.DialogResult == DialogResult.OK) { };
        }

        private void diagVer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void skeyId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void skeyId_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        public void ComBoxSkey_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (ComBoxSkey.Text != "")
            {
                skey = Int32.Parse(ComBoxSkey.Text);
            }
        }

       private void buttonFind_Click(object sender, EventArgs e)
        {
            if (textBoxFind.Text == "" | textBoxFind.Text == " ")
            {
                MessageBox.Show("Specify data for search");
                return;
            }
            else
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    grid.Rows[i].Selected = false;
                    for (int j = 0; j < grid.ColumnCount; j++)
                        if (grid.Rows[i].Cells[j].Value != null)
                            if (grid.Rows[i].Cells[j].Value.ToString().Contains(textBoxFind.Text))
                            {
                                DataGridViewCell cell = grid.Rows[i].Cells[j];
                                grid.Rows[i].Selected = true;
                                grid.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                                stmp = i;
                                grid.CurrentCell = cell;
                                break;
                            }
                }
            } 
            //else
                   // MessageBox.Show("Specify data for search");
                   // return;
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    grid.Rows[i].Selected = false;
                    for (int j = 0; j < grid.ColumnCount; j++)
                        if (grid.Rows[i].Cells[j].Value != null)
                            if (grid.Rows[i].Cells[j].Value.ToString().Contains(textBoxFind.Text))
                            {
                                DataGridViewCell cell = grid.Rows[i].Cells[j];
                                grid.Rows[i].Selected = true;
                                grid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                stmp = i;
                                grid.CurrentCell = cell;
                                break;
                            }
                }
        }
    }
}
