namespace ShrimpCounter
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGetFans = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lblCountFan = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.numIndex = new System.Windows.Forms.NumericUpDown();
            this.lblSocket = new System.Windows.Forms.Label();
            this.btnReconnecBoard = new System.Windows.Forms.Button();
            this.btn_connectPi = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 381);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(960, 167);
            this.textBox1.TabIndex = 0;
            // 
            // btnGetFans
            // 
            this.btnGetFans.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetFans.Location = new System.Drawing.Point(119, 28);
            this.btnGetFans.Name = "btnGetFans";
            this.btnGetFans.Size = new System.Drawing.Size(88, 61);
            this.btnGetFans.TabIndex = 1;
            this.btnGetFans.Text = "Lấy danh sách quạt";
            this.btnGetFans.UseVisualStyleBackColor = true;
            this.btnGetFans.Click += new System.EventHandler(this.btnGetFans_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 208);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(960, 173);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 117;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SSID";
            this.columnHeader2.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IsArr";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "isSlave";
            this.columnHeader4.Width = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số lượng quạt:";
            // 
            // lblCountFan
            // 
            this.lblCountFan.AutoSize = true;
            this.lblCountFan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountFan.Location = new System.Drawing.Point(129, 147);
            this.lblCountFan.Name = "lblCountFan";
            this.lblCountFan.Size = new System.Drawing.Size(17, 19);
            this.lblCountFan.TabIndex = 5;
            this.lblCountFan.Text = "0";
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(227, 28);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(88, 61);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(333, 28);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(88, 61);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // numIndex
            // 
            this.numIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numIndex.Location = new System.Drawing.Point(200, 143);
            this.numIndex.Name = "numIndex";
            this.numIndex.Size = new System.Drawing.Size(68, 23);
            this.numIndex.TabIndex = 8;
            // 
            // lblSocket
            // 
            this.lblSocket.AutoSize = true;
            this.lblSocket.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocket.Location = new System.Drawing.Point(652, 116);
            this.lblSocket.Name = "lblSocket";
            this.lblSocket.Size = new System.Drawing.Size(58, 19);
            this.lblSocket.TabIndex = 9;
            this.lblSocket.Text = "Arduino";
            // 
            // btnReconnecBoard
            // 
            this.btnReconnecBoard.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReconnecBoard.Location = new System.Drawing.Point(639, 28);
            this.btnReconnecBoard.Name = "btnReconnecBoard";
            this.btnReconnecBoard.Size = new System.Drawing.Size(88, 61);
            this.btnReconnecBoard.TabIndex = 10;
            this.btnReconnecBoard.Text = "Connect board";
            this.btnReconnecBoard.UseVisualStyleBackColor = true;
            // 
            // btn_connectPi
            // 
            this.btn_connectPi.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connectPi.Location = new System.Drawing.Point(12, 28);
            this.btn_connectPi.Name = "btn_connectPi";
            this.btn_connectPi.Size = new System.Drawing.Size(88, 61);
            this.btn_connectPi.TabIndex = 11;
            this.btn_connectPi.Text = "Connect NanoPi";
            this.btn_connectPi.UseVisualStyleBackColor = true;
            this.btn_connectPi.Click += new System.EventHandler(this.btn_connectPi_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Enabled = false;
            this.btn_upload.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_upload.Location = new System.Drawing.Point(440, 28);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(88, 61);
            this.btn_upload.TabIndex = 12;
            this.btn_upload.Text = "Upload video";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 548);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.btn_connectPi);
            this.Controls.Add(this.btnReconnecBoard);
            this.Controls.Add(this.lblSocket);
            this.Controls.Add(this.numIndex);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblCountFan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnGetFans);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Điều khiển quạt 3D";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGetFans;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCountFan;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.NumericUpDown numIndex;
        private System.Windows.Forms.Label lblSocket;
        private System.Windows.Forms.Button btnReconnecBoard;
        private System.Windows.Forms.Button btn_connectPi;
        private System.Windows.Forms.Button btn_upload;
    }
}

