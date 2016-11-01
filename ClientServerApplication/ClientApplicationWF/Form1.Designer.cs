namespace ClientApplicationWF
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipAdressCbx = new System.Windows.Forms.ComboBox();
            this.portCbx = new System.Windows.Forms.ComboBox();
            this.connectRbtn = new System.Windows.Forms.RadioButton();
            this.panel = new System.Windows.Forms.Panel();
            this.connectionInfoLvl = new System.Windows.Forms.Label();
            this.doorBtn = new System.Windows.Forms.Button();
            this.roomGpe = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.vSizeCbx = new System.Windows.Forms.ComboBox();
            this.hSizeCbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.infoLbl = new System.Windows.Forms.Label();
            this.addRectBtn = new System.Windows.Forms.Button();
            this.calcBtn = new System.Windows.Forms.Button();
            this.info2Lbl = new System.Windows.Forms.Label();
            this.addPtsBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.loadBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.openMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.roomGpe.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ip Adress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 47);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ipAdressCbx
            // 
            this.ipAdressCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipAdressCbx.FormattingEnabled = true;
            this.ipAdressCbx.Items.AddRange(new object[] {
            "127.0.0.1"});
            this.ipAdressCbx.Location = new System.Drawing.Point(79, 3);
            this.ipAdressCbx.Name = "ipAdressCbx";
            this.ipAdressCbx.Size = new System.Drawing.Size(121, 21);
            this.ipAdressCbx.TabIndex = 2;
            // 
            // portCbx
            // 
            this.portCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portCbx.FormattingEnabled = true;
            this.portCbx.Location = new System.Drawing.Point(79, 50);
            this.portCbx.Name = "portCbx";
            this.portCbx.Size = new System.Drawing.Size(121, 21);
            this.portCbx.TabIndex = 3;
            // 
            // connectRbtn
            // 
            this.connectRbtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.connectRbtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectRbtn.Location = new System.Drawing.Point(206, 3);
            this.connectRbtn.Name = "connectRbtn";
            this.connectRbtn.Size = new System.Drawing.Size(123, 41);
            this.connectRbtn.TabIndex = 4;
            this.connectRbtn.TabStop = true;
            this.connectRbtn.Text = "Connect";
            this.connectRbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connectRbtn.UseVisualStyleBackColor = true;
            this.connectRbtn.Click += new System.EventHandler(this.connectRbtn_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel1.SetColumnSpan(this.panel, 4);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(23, 23);
            this.panel.Name = "panel";
            this.tableLayoutPanel1.SetRowSpan(this.panel, 14);
            this.panel.Size = new System.Drawing.Size(681, 414);
            this.panel.TabIndex = 7;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseClick);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // connectionInfoLvl
            // 
            this.connectionInfoLvl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionInfoLvl.Location = new System.Drawing.Point(206, 47);
            this.connectionInfoLvl.Name = "connectionInfoLvl";
            this.connectionInfoLvl.Size = new System.Drawing.Size(123, 47);
            this.connectionInfoLvl.TabIndex = 7;
            // 
            // doorBtn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.doorBtn, 2);
            this.doorBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doorBtn.Location = new System.Drawing.Point(710, 203);
            this.doorBtn.Name = "doorBtn";
            this.tableLayoutPanel1.SetRowSpan(this.doorBtn, 2);
            this.doorBtn.Size = new System.Drawing.Size(222, 54);
            this.doorBtn.TabIndex = 8;
            this.doorBtn.Text = "Add a door +";
            this.doorBtn.UseVisualStyleBackColor = true;
            this.doorBtn.Click += new System.EventHandler(this.doorBtn_Click);
            // 
            // roomGpe
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.roomGpe, 2);
            this.roomGpe.Controls.Add(this.tableLayoutPanel2);
            this.roomGpe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomGpe.Location = new System.Drawing.Point(710, 83);
            this.roomGpe.Name = "roomGpe";
            this.tableLayoutPanel1.SetRowSpan(this.roomGpe, 4);
            this.roomGpe.Size = new System.Drawing.Size(222, 114);
            this.roomGpe.TabIndex = 7;
            this.roomGpe.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.vSizeCbx, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.hSizeCbx, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(216, 95);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // vSizeCbx
            // 
            this.vSizeCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vSizeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vSizeCbx.FormattingEnabled = true;
            this.vSizeCbx.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.vSizeCbx.Location = new System.Drawing.Point(111, 50);
            this.vSizeCbx.Name = "vSizeCbx";
            this.vSizeCbx.Size = new System.Drawing.Size(102, 21);
            this.vSizeCbx.TabIndex = 4;
            this.vSizeCbx.SelectedIndexChanged += new System.EventHandler(this.vSizeCbx_SelectedIndexChanged);
            // 
            // hSizeCbx
            // 
            this.hSizeCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hSizeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hSizeCbx.FormattingEnabled = true;
            this.hSizeCbx.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.hSizeCbx.Location = new System.Drawing.Point(111, 3);
            this.hSizeCbx.Name = "hSizeCbx";
            this.hSizeCbx.Size = new System.Drawing.Size(102, 21);
            this.hSizeCbx.TabIndex = 2;
            this.hSizeCbx.SelectedIndexChanged += new System.EventHandler(this.hSizeCbx_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 47);
            this.label3.TabIndex = 3;
            this.label3.Text = "Horizontal Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 48);
            this.label4.TabIndex = 5;
            this.label4.Text = "Vertical Size";
            // 
            // infoLbl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.infoLbl, 2);
            this.infoLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLbl.Location = new System.Drawing.Point(710, 260);
            this.infoLbl.Name = "infoLbl";
            this.tableLayoutPanel1.SetRowSpan(this.infoLbl, 2);
            this.infoLbl.Size = new System.Drawing.Size(222, 60);
            this.infoLbl.TabIndex = 6;
            this.infoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addRectBtn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.addRectBtn, 2);
            this.addRectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRectBtn.Location = new System.Drawing.Point(710, 23);
            this.addRectBtn.Name = "addRectBtn";
            this.tableLayoutPanel1.SetRowSpan(this.addRectBtn, 2);
            this.addRectBtn.Size = new System.Drawing.Size(222, 54);
            this.addRectBtn.TabIndex = 0;
            this.addRectBtn.Text = "Add a room +";
            this.addRectBtn.UseVisualStyleBackColor = true;
            this.addRectBtn.Click += new System.EventHandler(this.addRectBtn_Click);
            // 
            // calcBtn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.calcBtn, 2);
            this.calcBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calcBtn.Enabled = false;
            this.calcBtn.Location = new System.Drawing.Point(710, 473);
            this.calcBtn.Name = "calcBtn";
            this.tableLayoutPanel1.SetRowSpan(this.calcBtn, 2);
            this.calcBtn.Size = new System.Drawing.Size(222, 54);
            this.calcBtn.TabIndex = 2;
            this.calcBtn.Text = "Calculate";
            this.calcBtn.UseVisualStyleBackColor = true;
            this.calcBtn.Visible = false;
            this.calcBtn.Click += new System.EventHandler(this.calcBtn_Click);
            // 
            // info2Lbl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.info2Lbl, 2);
            this.info2Lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info2Lbl.Location = new System.Drawing.Point(710, 410);
            this.info2Lbl.Name = "info2Lbl";
            this.tableLayoutPanel1.SetRowSpan(this.info2Lbl, 2);
            this.info2Lbl.Size = new System.Drawing.Size(222, 60);
            this.info2Lbl.TabIndex = 1;
            this.info2Lbl.Text = "You need to connect in order to allow the calculation";
            // 
            // addPtsBtn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.addPtsBtn, 2);
            this.addPtsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addPtsBtn.Location = new System.Drawing.Point(710, 323);
            this.addPtsBtn.Name = "addPtsBtn";
            this.tableLayoutPanel1.SetRowSpan(this.addPtsBtn, 2);
            this.addPtsBtn.Size = new System.Drawing.Size(222, 54);
            this.addPtsBtn.TabIndex = 0;
            this.addPtsBtn.Text = "Add Points +";
            this.addPtsBtn.UseVisualStyleBackColor = true;
            this.addPtsBtn.Click += new System.EventHandler(this.addPtsBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(23, 443);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 4);
            this.groupBox1.Size = new System.Drawing.Size(338, 113);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.connectionInfoLvl, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.ipAdressCbx, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.portCbx, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.connectRbtn, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(332, 94);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.calcBtn, 5, 16);
            this.tableLayoutPanel1.Controls.Add(this.addPtsBtn, 5, 11);
            this.tableLayoutPanel1.Controls.Add(this.info2Lbl, 5, 14);
            this.tableLayoutPanel1.Controls.Add(this.addRectBtn, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.doorBtn, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.roomGpe, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.infoLbl, 5, 9);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.loadBtn, 3, 16);
            this.tableLayoutPanel1.Controls.Add(this.saveBtn, 3, 17);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 19;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 559);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // loadBtn
            // 
            this.loadBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadBtn.Location = new System.Drawing.Point(440, 473);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(191, 24);
            this.loadBtn.TabIndex = 10;
            this.loadBtn.Text = "Load a drawing";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveBtn.Location = new System.Drawing.Point(440, 503);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(191, 24);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Save a drawing";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 559);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Path Finder";
            this.roomGpe.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ipAdressCbx;
        private System.Windows.Forms.ComboBox portCbx;
        private System.Windows.Forms.RadioButton connectRbtn;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button addRectBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox vSizeCbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox hSizeCbx;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.GroupBox roomGpe;
        private System.Windows.Forms.Button doorBtn;
        private System.Windows.Forms.Button addPtsBtn;
        private System.Windows.Forms.Button calcBtn;
        private System.Windows.Forms.Label info2Lbl;
        private System.Windows.Forms.Label connectionInfoLvl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.OpenFileDialog openMapDialog;
        private System.Windows.Forms.SaveFileDialog saveMapDialog;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}

