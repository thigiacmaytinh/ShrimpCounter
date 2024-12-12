using ShrimpCounter.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;


namespace ShrimpCounter
{
    public partial class FormSession : Form
    {
        Session m_currentSession;
        static FormSession m_instance;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormSession()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormSession GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormSession();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormSession_Load(object sender, EventArgs e)
        {
            chk_showImage.Checked = TGMTregistry.GetInstance().ReadBool("showImage");
            chk_minScore.Checked = TGMTregistry.GetInstance().ReadBool("chk_minScore");
            txt_minScore.TextBoxText = TGMTregistry.GetInstance().ReadFloat("txt_minScore").ToString();
            chk_exportFullpath.Checked = TGMTregistry.GetInstance().ReadBool("exportFullpath");

            dateTimePicker1.TextBoxText = DateTime.Now;
            dateTimePicker2.TextBoxText = DateTime.Now;

            TGMTform.SetDoubleBuffer(dataGridView1, true);

            LoadSessionList();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintError(string msg)
        {
            lblMessage.Text = msg;
            lblMessage.ForeColor = Color.Red;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintSuccess(string msg)
        {
            lblMessage.Text = msg;
            lblMessage.ForeColor = Color.Green;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void LoadSessionList()
        {
            PrintError("");

            if (workerLoad.IsBusy)
                return;

            dataGridView1.Rows.Clear();
            workerLoad.RunWorkerAsync();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_search_Click(object sender, EventArgs e)
        {
            LoadSessionList();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //FormDetail form = new FormDetail(m_currentSession);
            //form.ShowDialog();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {           
            int rowIndex = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex < 0)
            {
                TGMTform.UnselectDatagridview(dataGridView1);
                return;
            }

            if(rd_newest.Checked)
            {
                rowIndex = dataGridView1.Rows.Count - rowIndex - 1;
            }


            m_currentSession = SessionMgr.Sessions[rowIndex];          
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_plate_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadSessionList();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_showImage_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("showImage", chk_showImage.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_exportFullpath_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("exportFullpath", chk_exportFullpath.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rd_newest_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            LoadSessionList();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rd_oldest_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            LoadSessionList();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_minScore_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("chk_minScore", chk_minScore.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_minScore_TextBoxTextChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("txt_minScore", txt_minScore.TextBoxText);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();


            this.Invoke(new Action(() =>
            {
                DateTime fromDate = dateTimePicker1.TextBoxText;
                fromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 0, 0, 0);



                DateTime toDate = dateTimePicker2.TextBoxText;
                toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);

                float score = 0.0f;
                if (chk_minScore.Checked)
                    score = float.Parse(txt_minScore.TextBoxText);


                bool oldest = rd_oldest.Checked;
                bool showImage = chk_showImage.Checked;

                SessionMgr.LoadSessions(fromDate, toDate, txt_search.TextBoxText, score);
                


                for (int i = 0; i < SessionMgr.Sessions.Count; i++)
                {
                    Session s = SessionMgr.Sessions[i];
                    DataGridViewRow row = s.ToDataGridViewRow(showImage);    

                    if (oldest)
                    {
                        rows.Add(row);
                    }
                    else
                    {
                        rows.Insert(0, row);
                    }
                }

            }));

            e.Result = rows;
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<DataGridViewRow> rows = (List<DataGridViewRow>)e.Result;


            dataGridView1.Rows.AddRange(rows.ToArray());
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            if (SessionMgr.Sessions.Count > 0)
            {
                PrintSuccess(String.Format("Tìm thấy {0} ảnh", SessionMgr.Sessions.Count));
                TGMTform.UnselectDatagridview(dataGridView1);
            }
            else
            {
                PrintError("Không tìm thấy lịch sử");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (workerExport.IsBusy)
                return;

            workerExport.RunWorkerAsync();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
            //    string fileName = "danh_sach_anh.xlsx";

            //    if (File.Exists(fileName))
            //        File.Delete(fileName);

            //    TGMTexcel excel = new TGMTexcel(fileName);
            //    excel.AddSheet("Danh sach");


            //    string[] headers = new string[] { "STT", "Biển số", "Alphanumeric", "Giờ vào", "Score", "CameraID", "Ảnh" };
            //    excel.AddRow(0, 1, headers);

            //    bool fullPath = chk_exportFullpath.Checked;

            //    for (int i = 0; i < SessionMgr.Sessions.Count; i++)
            //    {
            //        Session s = SessionMgr.Sessions[i];
            //        excel.AddRow(0, i + 2, s.ToArray(i + 1, fullPath));
            //    }



            //    for (int i = 1; i <= headers.Length; i++)
            //    {
            //        excel.SetAutoFitContent(0, i);
            //        excel.SetFormat(0, 1, i, Color.White, Color.Black, true);
            //    }

            //    excel.DrawTable(0, 1, 1, SessionMgr.Sessions.Count + 1, headers.Length);


            //    excel.Save();
            //    e.Result = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Có thể file excel đang mở, vui lòng kiểm tra lại", "Save file thất bại", MessageBoxButtons.OK);
            //    e.Result = false;
            //}
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool success = (bool)e.Result;
            if (success)
            {
                if (MessageBox.Show("Bạn có muốn mở file excel?", "Save thành công", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("danh_sach_bien_so.xlsx");
                }
            }
            else
            {
                PrintError("Xuất excel thất bại");
            }
            
        }
    }
}
