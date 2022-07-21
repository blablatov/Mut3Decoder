namespace Mut3Decoder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.carType = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.codingHex = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.itemValues = new System.Windows.Forms.DataGridView();
            this.codingHexNewRich = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.decode2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.carYear = new System.Windows.Forms.TextBox();
            this.carKind = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioTransmission = new System.Windows.Forms.RadioButton();
            this.radioSrsAirBag = new System.Windows.Forms.RadioButton();
            this.radioEtacs = new System.Windows.Forms.RadioButton();
            this.radioMotor = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.diagVer = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Charset = new System.Windows.Forms.TextBox();
            this.InputDiag = new System.Windows.Forms.TextBox();
            this.DiagMut3 = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnAboutRu = new System.Windows.Forms.Button();
            this.ComBoxSkey = new System.Windows.Forms.ComboBox();
            this.LabelSkey = new System.Windows.Forms.Label();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemValues)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // carType
            // 
            this.carType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.carType.Location = new System.Drawing.Point(44, 19);
            this.carType.MaxLength = 4;
            this.carType.Name = "carType";
            this.carType.Size = new System.Drawing.Size(61, 20);
            this.carType.TabIndex = 0;
            this.carType.TextChanged += new System.EventHandler(this.carType_TextChanged);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle1;
            this.grid.Location = new System.Drawing.Point(12, 107);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 30;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(619, 471);
            this.grid.TabIndex = 13;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // codingHex
            // 
            this.codingHex.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codingHex.Location = new System.Drawing.Point(12, 51);
            this.codingHex.Name = "codingHex";
            this.codingHex.Size = new System.Drawing.Size(891, 21);
            this.codingHex.TabIndex = 5;
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(928, 50);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 6;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // itemValues
            // 
            this.itemValues.AllowUserToAddRows = false;
            this.itemValues.AllowUserToDeleteRows = false;
            this.itemValues.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.itemValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemValues.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemValues.Location = new System.Drawing.Point(637, 107);
            this.itemValues.MultiSelect = false;
            this.itemValues.Name = "itemValues";
            this.itemValues.ReadOnly = true;
            this.itemValues.RowHeadersWidth = 30;
            this.itemValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemValues.Size = new System.Drawing.Size(266, 471);
            this.itemValues.TabIndex = 6;
            this.itemValues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemValues_CellContentClick);
            this.itemValues.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemValues_CellDoubleClick);
            // 
            // codingHexNewRich
            // 
            this.codingHexNewRich.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codingHexNewRich.Location = new System.Drawing.Point(12, 77);
            this.codingHexNewRich.Name = "codingHexNewRich";
            this.codingHexNewRich.Size = new System.Drawing.Size(891, 22);
            this.codingHexNewRich.TabIndex = 8;
            this.codingHexNewRich.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(928, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Encode";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // decode2
            // 
            this.decode2.Location = new System.Drawing.Point(928, 77);
            this.decode2.Name = "decode2";
            this.decode2.Size = new System.Drawing.Size(75, 23);
            this.decode2.TabIndex = 10;
            this.decode2.Text = "Decode";
            this.decode2.UseVisualStyleBackColor = true;
            this.decode2.Click += new System.EventHandler(this.decode2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Year";
            // 
            // carYear
            // 
            this.carYear.Location = new System.Drawing.Point(141, 19);
            this.carYear.MaxLength = 4;
            this.carYear.Name = "carYear";
            this.carYear.Size = new System.Drawing.Size(61, 20);
            this.carYear.TabIndex = 1;
            this.carYear.TextChanged += new System.EventHandler(this.carYear_TextChanged);
            // 
            // carKind
            // 
            this.carKind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.carKind.Location = new System.Drawing.Point(236, 19);
            this.carKind.MaxLength = 10;
            this.carKind.Name = "carKind";
            this.carKind.Size = new System.Drawing.Size(100, 20);
            this.carKind.TabIndex = 2;
            this.carKind.TextChanged += new System.EventHandler(this.carKind_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Kind";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioTransmission);
            this.groupBox1.Controls.Add(this.radioSrsAirBag);
            this.groupBox1.Controls.Add(this.radioEtacs);
            this.groupBox1.Controls.Add(this.radioMotor);
            this.groupBox1.Location = new System.Drawing.Point(341, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 41);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ECU";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioTransmission
            // 
            this.radioTransmission.AutoSize = true;
            this.radioTransmission.Location = new System.Drawing.Point(291, 18);
            this.radioTransmission.Name = "radioTransmission";
            this.radioTransmission.Size = new System.Drawing.Size(139, 17);
            this.radioTransmission.TabIndex = 3;
            this.radioTransmission.TabStop = true;
            this.radioTransmission.Text = "AT/CVT/A-MT/TC-SST";
            this.radioTransmission.UseVisualStyleBackColor = true;
            this.radioTransmission.CheckedChanged += new System.EventHandler(this.radioTransmission_CheckedChanged_1);
            // 
            // radioSrsAirBag
            // 
            this.radioSrsAirBag.AutoSize = true;
            this.radioSrsAirBag.Location = new System.Drawing.Point(194, 18);
            this.radioSrsAirBag.Name = "radioSrsAirBag";
            this.radioSrsAirBag.Size = new System.Drawing.Size(93, 17);
            this.radioSrsAirBag.TabIndex = 2;
            this.radioSrsAirBag.TabStop = true;
            this.radioSrsAirBag.Text = "SRS-AIR BAG";
            this.radioSrsAirBag.UseVisualStyleBackColor = true;
            this.radioSrsAirBag.CheckedChanged += new System.EventHandler(this.radioSrsAirBag_CheckedChanged_1);
            // 
            // radioEtacs
            // 
            this.radioEtacs.AutoSize = true;
            this.radioEtacs.Location = new System.Drawing.Point(128, 18);
            this.radioEtacs.Name = "radioEtacs";
            this.radioEtacs.Size = new System.Drawing.Size(60, 17);
            this.radioEtacs.TabIndex = 1;
            this.radioEtacs.TabStop = true;
            this.radioEtacs.Text = "ETACS";
            this.radioEtacs.UseVisualStyleBackColor = true;
            this.radioEtacs.CheckedChanged += new System.EventHandler(this.radioEtacs_CheckedChanged);
            // 
            // radioMotor
            // 
            this.radioMotor.AutoSize = true;
            this.radioMotor.Location = new System.Drawing.Point(11, 18);
            this.radioMotor.Name = "radioMotor";
            this.radioMotor.Size = new System.Drawing.Size(111, 17);
            this.radioMotor.TabIndex = 0;
            this.radioMotor.TabStop = true;
            this.radioMotor.Text = "MPI/GDI/DIESEL";
            this.radioMotor.UseVisualStyleBackColor = true;
            this.radioMotor.CheckedChanged += new System.EventHandler(this.radioMotor_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(775, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Diagversion";
            // 
            // diagVer
            // 
            this.diagVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diagVer.FormatString = "N0";
            this.diagVer.FormattingEnabled = true;
            this.diagVer.Location = new System.Drawing.Point(840, 18);
            this.diagVer.Name = "diagVer";
            this.diagVer.Size = new System.Drawing.Size(63, 21);
            this.diagVer.TabIndex = 4;
            this.diagVer.SelectedIndexChanged += new System.EventHandler(this.diagVer_SelectedIndexChanged);
            this.diagVer.Enter += new System.EventHandler(this.diagVer_Enter);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(928, 217);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 18;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(928, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save UTF-8";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 499);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1014, 22);
            this.statusStrip.TabIndex = 20;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSave2
            // 
            this.btnSave2.Location = new System.Drawing.Point(928, 288);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(75, 23);
            this.btnSave2.TabIndex = 21;
            this.btnSave2.Text = "Save ANSI";
            this.btnSave2.UseVisualStyleBackColor = true;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(908, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Charset";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // Charset
            // 
            this.Charset.Location = new System.Drawing.Point(953, 19);
            this.Charset.Name = "Charset";
            this.Charset.Size = new System.Drawing.Size(50, 20);
            this.Charset.TabIndex = 3;
            // 
            // InputDiag
            // 
            this.InputDiag.Location = new System.Drawing.Point(940, 185);
            this.InputDiag.Name = "InputDiag";
            this.InputDiag.Size = new System.Drawing.Size(63, 20);
            this.InputDiag.TabIndex = 24;
            this.InputDiag.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DiagMut3
            // 
            this.DiagMut3.AutoSize = true;
            this.DiagMut3.Location = new System.Drawing.Point(940, 156);
            this.DiagMut3.Name = "DiagMut3";
            this.DiagMut3.Size = new System.Drawing.Size(63, 26);
            this.DiagMut3.TabIndex = 25;
            this.DiagMut3.Text = "Diagversion\r\n from MUT3";
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(928, 479);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 26;
            this.btnAbout.Text = "About EN";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnAboutRu
            // 
            this.btnAboutRu.Location = new System.Drawing.Point(928, 450);
            this.btnAboutRu.Name = "btnAboutRu";
            this.btnAboutRu.Size = new System.Drawing.Size(75, 23);
            this.btnAboutRu.TabIndex = 27;
            this.btnAboutRu.Text = "About RU";
            this.btnAboutRu.UseVisualStyleBackColor = true;
            this.btnAboutRu.Click += new System.EventHandler(this.btnAboutRu_Click);
            // 
            // ComBoxSkey
            // 
            this.ComBoxSkey.FormattingEnabled = true;
            this.ComBoxSkey.Location = new System.Drawing.Point(926, 341);
            this.ComBoxSkey.Name = "ComBoxSkey";
            this.ComBoxSkey.Size = new System.Drawing.Size(77, 21);
            this.ComBoxSkey.TabIndex = 28;
            this.ComBoxSkey.SelectedIndexChanged += new System.EventHandler(this.ComBoxSkey_SelectedIndexChanged);
            // 
            // LabelSkey
            // 
            this.LabelSkey.AutoSize = true;
            this.LabelSkey.Location = new System.Drawing.Point(925, 325);
            this.LabelSkey.Name = "LabelSkey";
            this.LabelSkey.Size = new System.Drawing.Size(78, 13);
            this.LabelSkey.TabIndex = 29;
            this.LabelSkey.Text = "Versions SKEY";
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(913, 407);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(90, 23);
            this.buttonFind.TabIndex = 30;
            this.buttonFind.Text = "Find data";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(913, 382);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(90, 20);
            this.textBoxFind.TabIndex = 31;
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBoxFind_TextChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnDecode;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 521);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.LabelSkey);
            this.Controls.Add(this.ComBoxSkey);
            this.Controls.Add(this.btnAboutRu);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.DiagMut3);
            this.Controls.Add(this.InputDiag);
            this.Controls.Add(this.Charset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.diagVer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.carKind);
            this.Controls.Add(this.carYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decode2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.codingHexNewRich);
            this.Controls.Add(this.itemValues);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.codingHex);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.carType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1030, 630);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mut3Decoder v5.6";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemValues)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox carType;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox codingHex;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.DataGridView itemValues;
        private System.Windows.Forms.RichTextBox codingHexNewRich;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button decode2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox carYear;
        private System.Windows.Forms.TextBox carKind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioEtacs;
        private System.Windows.Forms.RadioButton radioMotor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox diagVer;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Charset;
        private System.Windows.Forms.RadioButton radioSrsAirBag;
        private System.Windows.Forms.RadioButton radioTransmission;
        private System.Windows.Forms.TextBox InputDiag;
        private System.Windows.Forms.Label DiagMut3;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnAboutRu;
        private System.Windows.Forms.ComboBox ComBoxSkey;
        private System.Windows.Forms.Label LabelSkey;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxFind;
    }
}

