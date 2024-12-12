using MiniHttpd;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;

namespace ShrimpCounter
{
    public partial class Form1 : Form
    {
        HttpWebServer m_server;
        bool m_formClosed;

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_server == null)
                {
                    string startupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    m_server = new HttpWebServer(8888);
                    m_server.Root = new DriveDirectory(startupPath);
                    m_server.Start();
                }
                else
                {
                    if (!m_server.IsRunning)
                    {
                        m_server.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể mở port 8888: \n" + ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_connectPi_Click(object sender, EventArgs e)
        {            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_formClosed = true;
        }

   

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnGetConfigSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            string volume = obj.GetValue("volume").ToString();
            string brightness = obj.GetValue("brightness").ToString();
            string angle = obj.GetValue("angle").ToString();
            string autowork = obj.GetValue("autowork").ToString();
            string playmode = obj.GetValue("playmode").ToString();
            string breathled = obj.GetValue("breathled").ToString();
            string isworking = obj.GetValue("isworking").ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnTurnSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if(code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnPlaySuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnPauseSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnGetCurrentVideoPlayingSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnDeleteVideoSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnUploadVideoSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnRenameVideoSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnResortVideoSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnSetVolumeSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnSetBrightnessSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnSetAngleSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnSetAutoworkSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnSetPlaymodeSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            int code = int.Parse(obj.GetValue("code").ToString());
            if (code == 0) //success
            {

            }
            else //failed
            {

            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnGetVersionSuccess(string response)
        {
            JObject obj = JObject.Parse(response);
            string version = obj.GetValue("version").ToString();
            Console.WriteLine(version);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnUploading(string response)
        {
            JObject obj = JObject.Parse(response);
            string ssid = obj.GetValue("dev").ToString();
            string name = obj.GetValue("name").ToString();
            string percent = obj.GetValue("percent").ToString();            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnGetFans_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            btnPause.Enabled = false;
            btn_upload.Enabled = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;

            btnPlay.Enabled = true;
            btnPause.Enabled = true;
            btn_upload.Enabled = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string ssid = listView1.SelectedItems[0].SubItems[1].Text;
           
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnPause_Click(object sender, EventArgs e)
        {
            string ssid = listView1.SelectedItems[0].SubItems[1].Text;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MP4 file |*.mp4;*.MP4;";
            ofd.ShowDialog();
            if (ofd.FileName == "")
                return;

            string ssid = listView1.SelectedItems[0].SubItems[1].Text;
        }
    }
}
