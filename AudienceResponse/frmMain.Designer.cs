namespace AudienceResponse
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblUserID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSeatRowNo = new System.Windows.Forms.TextBox();
            this.btnLoadSenior = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.dgvparticipants = new System.Windows.Forms.DataGridView();
            this.SeatRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserCardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Initials = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SysID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qst1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pbAddNew = new System.Windows.Forms.PictureBox();
            this.pbClear = new System.Windows.Forms.PictureBox();
            this.pbLogOut = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvparticipants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(12, 5);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(799, 62);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUserID.TextChanged += new System.EventHandler(this.lblCardID_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSeatRowNo);
            this.panel1.Controls.Add(this.btnLoadSenior);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnLoadAll);
            this.panel1.Controls.Add(this.lblUserID);
            this.panel1.Controls.Add(this.pbAddNew);
            this.panel1.Controls.Add(this.pbClear);
            this.panel1.Controls.Add(this.pbLogOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 70);
            this.panel1.TabIndex = 3;
            // 
            // txtSeatRowNo
            // 
            this.txtSeatRowNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeatRowNo.Location = new System.Drawing.Point(187, 5);
            this.txtSeatRowNo.Name = "txtSeatRowNo";
            this.txtSeatRowNo.Size = new System.Drawing.Size(115, 20);
            this.txtSeatRowNo.TabIndex = 4;
            // 
            // btnLoadSenior
            // 
            this.btnLoadSenior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadSenior.Enabled = false;
            this.btnLoadSenior.Location = new System.Drawing.Point(3, 3);
            this.btnLoadSenior.Name = "btnLoadSenior";
            this.btnLoadSenior.Size = new System.Drawing.Size(86, 62);
            this.btnLoadSenior.TabIndex = 3;
            this.btnLoadSenior.Text = "Load Senior Participants";
            this.btnLoadSenior.UseVisualStyleBackColor = true;
            this.btnLoadSenior.Click += new System.EventHandler(this.btnLoadSenior_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(308, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 62);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search By Row No";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadAll.Location = new System.Drawing.Point(95, 3);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(86, 62);
            this.btnLoadAll.TabIndex = 3;
            this.btnLoadAll.Text = "Load All Participants";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblQuestion);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 94);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.ForeColor = System.Drawing.Color.Red;
            this.lblQuestion.Location = new System.Drawing.Point(6, 16);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(0, 25);
            this.lblQuestion.TabIndex = 0;
            // 
            // dgvparticipants
            // 
            this.dgvparticipants.AllowUserToAddRows = false;
            this.dgvparticipants.AllowUserToDeleteRows = false;
            this.dgvparticipants.AllowUserToResizeRows = false;
            this.dgvparticipants.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvparticipants.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvparticipants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvparticipants.ColumnHeadersHeight = 45;
            this.dgvparticipants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeatRowNo,
            this.UserCardID,
            this.Rank,
            this.Initials,
            this.Name2,
            this.Titles,
            this.CountryName,
            this.Select,
            this.SysID,
            this.Flag,
            this.qst,
            this.qst1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvparticipants.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvparticipants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvparticipants.GridColor = System.Drawing.SystemColors.Control;
            this.dgvparticipants.Location = new System.Drawing.Point(0, 0);
            this.dgvparticipants.Name = "dgvparticipants";
            this.dgvparticipants.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvparticipants.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvparticipants.RowTemplate.Height = 40;
            this.dgvparticipants.Size = new System.Drawing.Size(1020, 270);
            this.dgvparticipants.TabIndex = 3;
            this.dgvparticipants.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvparticipants_CellClick);
            this.dgvparticipants.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvparticipants_CellMouseEnter);
            this.dgvparticipants.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvparticipants_CellMouseLeave);
            this.dgvparticipants.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvparticipants_CellMouseMove);
            this.dgvparticipants.MouseHover += new System.EventHandler(this.dgvparticipants_MouseHover);
            // 
            // SeatRowNo
            // 
            this.SeatRowNo.DataPropertyName = "SeatRowNo";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.SeatRowNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.SeatRowNo.HeaderText = "Seat Row No";
            this.SeatRowNo.Name = "SeatRowNo";
            // 
            // UserCardID
            // 
            this.UserCardID.DataPropertyName = "CardID";
            this.UserCardID.HeaderText = "Card ID";
            this.UserCardID.Name = "UserCardID";
            this.UserCardID.Visible = false;
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "ShortName";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            // 
            // Initials
            // 
            this.Initials.DataPropertyName = "Initials";
            this.Initials.HeaderText = "Initials";
            this.Initials.Name = "Initials";
            this.Initials.Visible = false;
            // 
            // Name2
            // 
            this.Name2.DataPropertyName = "Name";
            this.Name2.HeaderText = "Name";
            this.Name2.Name = "Name2";
            this.Name2.ToolTipText = "tyui";
            // 
            // Titles
            // 
            this.Titles.DataPropertyName = "Titles";
            this.Titles.HeaderText = "Titles";
            this.Titles.Name = "Titles";
            // 
            // CountryName
            // 
            this.CountryName.DataPropertyName = "CountryName";
            this.CountryName.HeaderText = "Country Name";
            this.CountryName.Name = "CountryName";
            this.CountryName.Width = 150;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 75;
            // 
            // SysID
            // 
            this.SysID.DataPropertyName = "SysID";
            this.SysID.HeaderText = "SystemID";
            this.SysID.Name = "SysID";
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "Flag";
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            // 
            // qst
            // 
            this.qst.DataPropertyName = "qst";
            this.qst.HeaderText = "qst";
            this.qst.Name = "qst";
            this.qst.Visible = false;
            // 
            // qst1
            // 
            this.qst1.HeaderText = "View Qustion";
            this.qst1.Name = "qst1";
            this.qst1.Text = "";
            // 
            // pbAddNew
            // 
            this.pbAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAddNew.Image = global::AudienceResponse.Properties.Resources.AddNew;
            this.pbAddNew.Location = new System.Drawing.Point(813, 5);
            this.pbAddNew.Name = "pbAddNew";
            this.pbAddNew.Size = new System.Drawing.Size(61, 62);
            this.pbAddNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddNew.TabIndex = 1;
            this.pbAddNew.TabStop = false;
            this.pbAddNew.Click += new System.EventHandler(this.pbAddNew_Click);
            this.pbAddNew.MouseLeave += new System.EventHandler(this.pbAddNew_MouseLeave);
            this.pbAddNew.MouseHover += new System.EventHandler(this.pbAddNew_MouseHover);
            // 
            // pbClear
            // 
            this.pbClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClear.BackColor = System.Drawing.Color.Transparent;
            this.pbClear.Image = ((System.Drawing.Image)(resources.GetObject("pbClear.Image")));
            this.pbClear.Location = new System.Drawing.Point(880, 5);
            this.pbClear.Name = "pbClear";
            this.pbClear.Size = new System.Drawing.Size(61, 62);
            this.pbClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClear.TabIndex = 1;
            this.pbClear.TabStop = false;
            this.pbClear.Click += new System.EventHandler(this.pbClear_Click);
            this.pbClear.MouseLeave += new System.EventHandler(this.pbClear_MouseLeave);
            this.pbClear.MouseHover += new System.EventHandler(this.pbClear_MouseHover);
            // 
            // pbLogOut
            // 
            this.pbLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogOut.Image = global::AudienceResponse.Properties.Resources.logOut;
            this.pbLogOut.Location = new System.Drawing.Point(947, 5);
            this.pbLogOut.Name = "pbLogOut";
            this.pbLogOut.Size = new System.Drawing.Size(61, 62);
            this.pbLogOut.TabIndex = 1;
            this.pbLogOut.TabStop = false;
            this.pbLogOut.Click += new System.EventHandler(this.pbLogOut_Click);
            this.pbLogOut.MouseLeave += new System.EventHandler(this.pbLogOut_MouseLeave);
            this.pbLogOut.MouseHover += new System.EventHandler(this.pbLogOut_MouseHover);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 434);
            this.Controls.Add(this.dgvparticipants);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvparticipants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbLogOut;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbClear;
        private System.Windows.Forms.PictureBox pbAddNew;
        private System.Windows.Forms.Button btnLoadSenior;
        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.TextBox txtSeatRowNo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserCardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Initials;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titles;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
        private System.Windows.Forms.DataGridViewButtonColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn SysID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn qst;
        private System.Windows.Forms.DataGridViewButtonColumn qst1;
        public System.Windows.Forms.DataGridView dgvparticipants;
    }
}

