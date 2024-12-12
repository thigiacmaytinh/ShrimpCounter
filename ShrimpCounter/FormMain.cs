using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;
using TGMT;
using QRCoder;
using System.IO;
using MiniHttpd;
using System.Reflection;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Security.Policy;
using System.Drawing.Imaging;
using System.Threading;
using ShrimpCounter.SQL;
using System.Net.NetworkInformation;

namespace ShrimpCounter
{
    public partial class FormMain : Form
    {
        HttpWebServer m_server;
        static FormMain m_instance;
        Button currentButton;
        Form activeForm;
        string qrcodeText = "lehoanghung";

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormMain()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormMain GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormMain();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_Load(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().Init("ShrimpCouter");

            Program.port = TGMTregistry.GetInstance().ReadInt("txt_Port", Program.port);

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            string version = TGMTutil.GetVersion();

            this.Text += " " + version;

#if DEBUG
            this.Text += " (Debug)";
#endif
           lbl_version.Text = version;

            CreateTodayDir();

            try
            {
                if (m_server == null)
                {
                    string startupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    m_server = new HttpWebServer(Program.port);
                    m_server.Root = new DriveDirectory(startupPath);
                    m_server.RequestReceived += M_server_RequestReceived;
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
                throw new Exception("Không thể mở port" + Program.port + ": \n" + ex.Message);
            }

            string localIP = GetLocalIPAddress();

            if (localIP != null)
            {
                qrcodeText = "http://" + localIP + ":" + Program.port.ToString();
            }

            renderQRCode();
            StartProgressbar();
        }        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.segmentor = new YOLOv8Segmentor(".\\weights\\shrimp-seg.onnx", ".\\weights\\shrimp.names");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            

            //Segmented result = Program.segmentor.Segment("D:\\Project\\GitHub\\shrimp-segmentation\\datasets\\shrimp\\test\\images\\2023-12-07_09_31_33_-2669-_white-prawn_input_jpeg_jpg.rf.ed66be31add8a4099118d858380b418b.jpg");
            //pictureBox1.Image = result.bitmap;

            StopProgressbar();

            TGMTsqlite.GetInstance().LoadDatabase("db.sqlite3");

            string childform = TGMTregistry.GetInstance().ReadString("childform");
            if (childform == "" || childform == "FormImage")
                btnImage.PerformClick();
            else if (childform == "FormWebcam")
                btnWebcam.PerformClick();
            else if (childform == "FormFolder")
                btnFolder.PerformClick();
            else if (childform == "FormRealtime")
                btn_realtime.PerformClick();
            else
                btnImage.PerformClick();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void renderQRCode()
        {
            QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.H;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcodeText, eccLevel);
            QRCode qrCode = new QRCode(qrCodeData);

            int iconSize = 15;
            int cellSize = 20;
            int padding = 6;

            picQR.Image = qrCode.GetGraphic(cellSize, Color.Black, Color.White, null, iconSize, padding);
            lbl_url.Text = qrcodeText;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //static string GetLocalIPAddress()
        //{
        //    var host = Dns.GetHostEntry(Dns.GetHostName());
        //    foreach (var ip in host.AddressList)
        //    {
        //        if (ip.AddressFamily == AddressFamily.InterNetwork)
        //        {
        //            return ip.ToString();
        //        }
        //    }
        //    throw new Exception("No network adapters with an IPv4 address in the system!");
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static string GetLocalIPAddress()
        {
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Check for operational network interfaces that are not loopback or virtual.
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    networkInterface.Description.IndexOf("Virtual", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    var ipProperties = networkInterface.GetIPProperties();
                    var unicastAddresses = ipProperties.UnicastAddresses;

                    foreach (UnicastIPAddressInformation unicastAddress in unicastAddresses)
                    {
                        if (unicastAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return unicastAddress.Address.ToString();
                        }
                    }
                }
            }

            throw new InvalidOperationException("No active network adapters with an IPv4 address were found.");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnWebcam_Click(object sender, EventArgs e)
        {
            //OpenChildForm(FormWebcam.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnImage_Click(object sender, EventArgs e)
        {
            //OpenChildForm(FormImage.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnFolder_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormSession.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_ipCamera_Click(object sender, EventArgs e)
        {
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_realtime_Click(object sender, EventArgs e)
        {
            //OpenChildForm(FormRealtime.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormSettings.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;

            timerClear.Stop();
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;
            timerClear.Stop();
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;
            timerClear.Stop();
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
            }

            ActiveButton(btnSender);

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            TGMTregistry.GetInstance().SaveValue("childform", childForm.Name);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;

                    Color color = SelectThemeColor(currentButton);
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Color SelectThemeColor(Button btn)
        {
            int index = FindIndexOfBtn(btn);
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        int FindIndexOfBtn(Button btn)
        {
            int index = -1;
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    index++;
                    if ((Button)ctrl == btn)
                    {
                        return index;
                    }
                }
            }

            return index;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StartProgressbar()
        {
            timerProgressbar.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopProgressbar()
        {
            timerProgressbar.Stop();
            progressBar1.Value = progressBar1.Minimum;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
            progressBar1.Value += 1;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(activeForm != null)
                activeForm.Close();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lbl_url_Click(object sender, EventArgs e)
        {
            string url = lbl_url.Text;

            // Copy the label's text to the clipboard
            Clipboard.SetText(url);
            MessageBox.Show("Text copied to clipboard!");

            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void M_server_RequestReceived(object sender, RequestEventArgs e)
        {
            if (e.Request.Method == "GET")
            {
                OnGETrequest(sender, e);
            }
            else
            {
                OnPOSTrequest(sender, e);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnGETrequest(object sender, RequestEventArgs e)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnPOSTrequest(object sender, RequestEventArgs e)
        {
            string data = Encoding.UTF8.GetString((e.Request.PostData).ToArray());
            string[] pairs = data.Split('&');
            Dictionary<string, string> fields = new Dictionary<string, string>();

            
            foreach (string p in pairs)
            {
                string[] splited = p.Split('=');
                if (splited.Length >= 2)
                {
                    if(splited[0] == "imageBase64")
                    {
                        DateTime now = DateTime.Now;
                        string rand = TGMTutil.RandomString(5);
                        string filePath = GenFilePath(now, false, rand);
                        string rawFilePath = GenFilePath(now, true, rand);


                        Bitmap bmp = (Bitmap)TGMTimage.Base64ToImage(splited[1]);
                        Bitmap bmpRaw = (Bitmap)TGMTimage.Base64ToImage(splited[1]);

                        using (Bitmap bitmap = new Bitmap(bmpRaw))
                        {
                            bitmap.Save(rawFilePath, ImageFormat.Jpeg);
                        }

                        this.Invoke(new MethodInvoker(delegate
                        {
                            pictureBox1.Image = bmpRaw;
                            PrintMessage(rawFilePath);
                        }));

                        Segmented result = ShrimpYolo.Count(bmp);
                        result.bitmap.Save(filePath, ImageFormat.Jpeg);

                        this.Invoke(new MethodInvoker(delegate
                        {
                            pictureBox1.Image = result.bitmap;
                            lbl_NumObject.Text = result.count.ToString();
                            PrintMessage(filePath);
                        }));

                        //string resultStr = "";

                        //foreach (Polygon po in result.polygons)
                        //{
                        //    resultStr += (po.classID.ToString() + "\t" + po.className + "\t" + po.confident.ToString());
                        //}

                        Session s = new Session();
                        s.imagePath = filePath;
                        s.timeCreate = now;
                        s.total = result.count;
                        s.Insert();
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GenFilePath(DateTime now, bool isRaw, string rand)
        {
            string dirPath = String.Format(@"{0}\{1}\{2}\{3}\", Program.saveDir, now.Year, now.ToString("MM"), now.ToString("dd"));
            string filePath = dirPath + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            filePath += rand + (isRaw ? "" : "_draw") + ".jpg";
            return filePath;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void CreateTodayDir(int deltaHour = 0)
        {
            DateTime now = DateTime.Now;
            if (deltaHour > 0)
                now = now.AddHours(deltaHour);

            string dirName = String.Format(@"{0}\", Program.saveDir);

            Directory.CreateDirectory(dirName);
            Directory.CreateDirectory(String.Format(@"{0}\{1}\", Program.saveDir, now.Year));
            Directory.CreateDirectory(String.Format(@"{0}\{1}\{2}\", Program.saveDir, now.Year, now.ToString("MM")));
            Directory.CreateDirectory(String.Format(@"{0}\{1}\{2}\{3}\", Program.saveDir, now.Year, now.ToString("MM"), now.ToString("dd")));
            
        }
    }
}