namespace ShrimpCounter.UI
{
    partial class MsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBox));
            this.lbl_content = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_yes = new AltoControls.AltoButton();
            this.btn_no = new AltoControls.AltoButton();
            this.btn_close = new AltoControls.AltoButton();
            this.SuspendLayout();
            // 
            // lbl_content
            // 
            this.lbl_content.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_content.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_content.ForeColor = System.Drawing.Color.Black;
            this.lbl_content.Location = new System.Drawing.Point(1, 1);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_content.Size = new System.Drawing.Size(582, 147);
            this.lbl_content.TabIndex = 2;
            this.lbl_content.Text = "TEXT";
            this.lbl_content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 148);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(582, 1);
            this.panel1.TabIndex = 3;
            // 
            // btn_yes
            // 
            this.btn_yes.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_yes.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_yes.BackColor = System.Drawing.Color.Transparent;
            this.btn_yes.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_yes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_yes.ForeColor = System.Drawing.Color.White;
            this.btn_yes.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_yes.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_yes.Location = new System.Drawing.Point(262, 155);
            this.btn_yes.Name = "btn_yes";
            this.btn_yes.Radius = 10;
            this.btn_yes.Size = new System.Drawing.Size(98, 36);
            this.btn_yes.Stroke = false;
            this.btn_yes.StrokeColor = System.Drawing.Color.Gray;
            this.btn_yes.TabIndex = 4;
            this.btn_yes.Text = "Yes";
            this.btn_yes.Transparency = false;
            this.btn_yes.Click += new System.EventHandler(this.btn_yes_Click);
            // 
            // btn_no
            // 
            this.btn_no.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_no.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_no.BackColor = System.Drawing.Color.Transparent;
            this.btn_no.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_no.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_no.ForeColor = System.Drawing.Color.White;
            this.btn_no.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_no.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_no.Location = new System.Drawing.Point(366, 155);
            this.btn_no.Name = "btn_no";
            this.btn_no.Radius = 10;
            this.btn_no.Size = new System.Drawing.Size(98, 36);
            this.btn_no.Stroke = false;
            this.btn_no.StrokeColor = System.Drawing.Color.Gray;
            this.btn_no.TabIndex = 5;
            this.btn_no.Text = "No";
            this.btn_no.Transparency = false;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_close
            // 
            this.btn_close.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_close.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_close.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_close.Location = new System.Drawing.Point(470, 155);
            this.btn_close.Name = "btn_close";
            this.btn_close.Radius = 10;
            this.btn_close.Size = new System.Drawing.Size(98, 36);
            this.btn_close.Stroke = false;
            this.btn_close.StrokeColor = System.Drawing.Color.Gray;
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Close";
            this.btn_close.Transparency = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // MsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(584, 195);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_yes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ct_messagebox_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_content;
        private System.Windows.Forms.Panel panel1;
        private AltoControls.AltoButton btn_yes;
        private AltoControls.AltoButton btn_no;
        private AltoControls.AltoButton btn_close;
    }
}