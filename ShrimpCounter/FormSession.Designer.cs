namespace ShrimpCounter
{
    partial class FormSession
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSession));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.dateTimePicker1 = new System.Windows.Forms.RibbonDatetime();
            this.dateTimePicker2 = new System.Windows.Forms.RibbonDatetime();
            this.txt_search = new System.Windows.Forms.RibbonTextBox();
            this.ribbonItemGroup1 = new System.Windows.Forms.RibbonItemGroup();
            this.rd_newest = new System.Windows.Forms.RibbonCheckBox();
            this.rd_oldest = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonItemGroup3 = new System.Windows.Forms.RibbonItemGroup();
            this.chk_minScore = new System.Windows.Forms.RibbonCheckBox();
            this.txt_minScore = new System.Windows.Forms.RibbonTextBox();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.btn_search = new System.Windows.Forms.RibbonButton();
            this.ribbonCheckBox1 = new System.Windows.Forms.RibbonCheckBox();
            this.btn_export = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.chk_showImage = new System.Windows.Forms.RibbonCheckBox();
            this.chk_exportFullpath = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonDatetime1 = new System.Windows.Forms.RibbonDatetime();
            this.ribbonDescriptionMenuItem1 = new System.Windows.Forms.RibbonDescriptionMenuItem();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.workerLoad = new System.ComponentModel.BackgroundWorker();
            this.workerExport = new System.ComponentModel.BackgroundWorker();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column8});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 176);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1107, 347);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1107, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 2;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.Enabled = false;
            this.ribbon1.QuickAccessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Size = new System.Drawing.Size(1107, 176);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabSpacing = 3;
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "Lượt xe";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.dateTimePicker1);
            this.ribbonPanel1.Items.Add(this.dateTimePicker2);
            this.ribbonPanel1.Items.Add(this.txt_search);
            this.ribbonPanel1.Items.Add(this.ribbonItemGroup1);
            this.ribbonPanel1.Items.Add(this.ribbonSeparator1);
            this.ribbonPanel1.Items.Add(this.ribbonItemGroup3);
            this.ribbonPanel1.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel1.Items.Add(this.btn_search);
            this.ribbonPanel1.Items.Add(this.btn_export);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Tìm kiếm";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.FormatString = "dd/MM/yyyy";
            this.dateTimePicker1.LabelWidth = 60;
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Text = "Từ ngày:";
            this.dateTimePicker1.TextBoxText = new System.DateTime(((long)(0)));
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.FormatString = "dd/MM/yyyy";
            this.dateTimePicker2.LabelWidth = 60;
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Text = "Đến ngày:";
            this.dateTimePicker2.TextBoxText = new System.DateTime(((long)(0)));
            // 
            // txt_search
            // 
            this.txt_search.Name = "txt_search";
            this.txt_search.Text = "Biển số";
            this.txt_search.TextBoxText = "";
            this.txt_search.TextBoxWidth = 200;
            this.txt_search.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_plate_TextBoxKeyDown);
            // 
            // ribbonItemGroup1
            // 
            this.ribbonItemGroup1.Items.Add(this.rd_newest);
            this.ribbonItemGroup1.Items.Add(this.rd_oldest);
            this.ribbonItemGroup1.Name = "ribbonItemGroup1";
            // 
            // rd_newest
            // 
            this.rd_newest.Checked = true;
            this.rd_newest.CheckedGroup = "order_by";
            this.rd_newest.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rd_newest.Name = "rd_newest";
            this.rd_newest.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.rd_newest.Text = "Mới nhất trước";
            this.rd_newest.CheckBoxCheckChanged += new System.EventHandler(this.rd_newest_CheckBoxCheckChanged);
            // 
            // rd_oldest
            // 
            this.rd_oldest.CheckedGroup = "order_by";
            this.rd_oldest.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rd_oldest.Name = "rd_oldest";
            this.rd_oldest.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.rd_oldest.Text = "Cũ nhất trước";
            this.rd_oldest.CheckBoxCheckChanged += new System.EventHandler(this.rd_oldest_CheckBoxCheckChanged);
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // ribbonItemGroup3
            // 
            this.ribbonItemGroup3.Items.Add(this.chk_minScore);
            this.ribbonItemGroup3.Items.Add(this.txt_minScore);
            this.ribbonItemGroup3.Name = "ribbonItemGroup3";
            // 
            // chk_minScore
            // 
            this.chk_minScore.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.chk_minScore.Name = "chk_minScore";
            this.chk_minScore.Text = "Score tối thiểu";
            this.chk_minScore.CheckBoxCheckChanged += new System.EventHandler(this.chk_minScore_CheckBoxCheckChanged);
            // 
            // txt_minScore
            // 
            this.txt_minScore.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.txt_minScore.Name = "txt_minScore";
            this.txt_minScore.TextBoxText = "";
            this.txt_minScore.TextBoxWidth = 50;
            this.txt_minScore.TextBoxTextChanged += new System.EventHandler(this.txt_minScore_TextBoxTextChanged);
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.Name = "ribbonSeparator2";
            // 
            // btn_search
            // 
            this.btn_search.DropDownItems.Add(this.ribbonCheckBox1);
            this.btn_search.Image = global::ShrimpCounter.Properties.Resources.find32;
            this.btn_search.LargeImage = global::ShrimpCounter.Properties.Resources.find32;
            this.btn_search.MinimumSize = new System.Drawing.Size(60, 0);
            this.btn_search.Name = "btn_search";
            this.btn_search.SmallImage = ((System.Drawing.Image)(resources.GetObject("btn_search.SmallImage")));
            this.btn_search.Text = "Tìm kiếm";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // ribbonCheckBox1
            // 
            this.ribbonCheckBox1.Name = "ribbonCheckBox1";
            this.ribbonCheckBox1.Text = "ribbonCheckBox1";
            // 
            // btn_export
            // 
            this.btn_export.Image = ((System.Drawing.Image)(resources.GetObject("btn_export.Image")));
            this.btn_export.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_export.LargeImage")));
            this.btn_export.MinimumSize = new System.Drawing.Size(65, 0);
            this.btn_export.Name = "btn_export";
            this.btn_export.SmallImage = ((System.Drawing.Image)(resources.GetObject("btn_export.SmallImage")));
            this.btn_export.Text = "Xuất excel";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.chk_showImage);
            this.ribbonPanel2.Items.Add(this.chk_exportFullpath);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Option";
            // 
            // chk_showImage
            // 
            this.chk_showImage.Name = "chk_showImage";
            this.chk_showImage.Text = "Hiển thị ảnh";
            this.chk_showImage.ToolTip = "Không hiển thị ảnh sẽ hiển thị nhanh hơn";
            this.chk_showImage.CheckBoxCheckChanged += new System.EventHandler(this.chk_showImage_CheckBoxCheckChanged);
            // 
            // chk_exportFullpath
            // 
            this.chk_exportFullpath.Name = "chk_exportFullpath";
            this.chk_exportFullpath.Text = "Export full path";
            this.chk_exportFullpath.CheckBoxCheckChanged += new System.EventHandler(this.chk_exportFullpath_CheckBoxCheckChanged);
            // 
            // ribbonDatetime1
            // 
            this.ribbonDatetime1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ribbonDatetime1.FormatString = "dd/MM/yyyy";
            this.ribbonDatetime1.Name = "ribbonDatetime1";
            this.ribbonDatetime1.Text = "Từ ngày";
            this.ribbonDatetime1.TextBoxText = new System.DateTime(2024, 3, 17, 15, 8, 0, 373);
            // 
            // ribbonDescriptionMenuItem1
            // 
            this.ribbonDescriptionMenuItem1.DescriptionBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ribbonDescriptionMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonDescriptionMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.Image")));
            this.ribbonDescriptionMenuItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.LargeImage")));
            this.ribbonDescriptionMenuItem1.Name = "ribbonDescriptionMenuItem1";
            this.ribbonDescriptionMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.SmallImage")));
            this.ribbonDescriptionMenuItem1.Text = "ribbonDescriptionMenuItem1";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::ShrimpCounter.Properties.Resources.find32;
            this.ribbonButton2.LargeImage = global::ShrimpCounter.Properties.Resources.find32;
            this.ribbonButton2.MaximumSize = new System.Drawing.Size(200, 0);
            this.ribbonButton2.MinimumSize = new System.Drawing.Size(80, 0);
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Tìm kiếm";
            this.ribbonButton2.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::ShrimpCounter.Properties.Resources.find32;
            this.ribbonButton1.LargeImage = global::ShrimpCounter.Properties.Resources.find32;
            this.ribbonButton1.MaximumSize = new System.Drawing.Size(200, 0);
            this.ribbonButton1.MinimumSize = new System.Drawing.Size(80, 0);
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Tìm kiếm";
            this.ribbonButton1.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            // 
            // workerLoad
            // 
            this.workerLoad.WorkerReportsProgress = true;
            this.workerLoad.WorkerSupportsCancellation = true;
            this.workerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerLoad_DoWork);
            this.workerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerLoad_RunWorkerCompleted);
            // 
            // workerExport
            // 
            this.workerExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerExport_DoWork);
            this.workerExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerExport_RunWorkerCompleted);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Thời gian chụp";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tổng";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Hình ảnh";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column8.Width = 300;
            // 
            // FormSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 545);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormSession";
            this.Text = "Tìm kiếm lượt xe";
            this.Load += new System.EventHandler(this.FormSession_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTextBox txt_search;
        private System.Windows.Forms.RibbonDatetime dateTimePicker1;
        private System.Windows.Forms.RibbonDatetime ribbonDatetime1;
        private System.Windows.Forms.RibbonDatetime dateTimePicker2;
        private System.Windows.Forms.RibbonDescriptionMenuItem ribbonDescriptionMenuItem1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonCheckBox chk_showImage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.RibbonButton btn_search;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBox1;
        private System.Windows.Forms.RibbonItemGroup ribbonItemGroup1;
        private System.Windows.Forms.RibbonCheckBox rd_newest;
        private System.Windows.Forms.RibbonCheckBox rd_oldest;
        private System.Windows.Forms.RibbonItemGroup ribbonItemGroup3;
        private System.Windows.Forms.RibbonCheckBox chk_minScore;
        private System.Windows.Forms.RibbonTextBox txt_minScore;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.ComponentModel.BackgroundWorker workerLoad;
        private System.Windows.Forms.RibbonButton btn_export;
        private System.Windows.Forms.RibbonCheckBox chk_exportFullpath;
        private System.ComponentModel.BackgroundWorker workerExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column8;
    }
}