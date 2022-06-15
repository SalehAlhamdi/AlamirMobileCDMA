using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlamirMobileCDMA
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        public string getInfo(string cammond)
        {
            string startupPath = @System.IO.Directory.GetCurrentDirectory() + @"\libimobiledevice\";
            var proc1 = new ProcessStartInfo("cmd");
            proc1.UseShellExecute = false;
            proc1.RedirectStandardOutput = true;
            proc1.CreateNoWindow = true;
            proc1.RedirectStandardInput = true;
            proc1.Arguments = "/c " + startupPath + cammond;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            var proc = Process.Start(proc1);
            return proc.StandardOutput.ReadToEnd();
        }
        public void loadform(object Form)
        {
            if (this.main_panel.Controls.Count > 1)
            {
                this.main_panel.Controls.RemoveAt(1);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.main_panel.Controls.Add(f);
            this.main_panel.Tag = f;
            f.Show();
         

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            loadform(new dashboard());
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            loadform(new device_info());
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            loadform(new scan_device());
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            loadform(new active_cdma());
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            loadform(new about());
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            loadform(new dashboard());


        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            loadform(new dashboard());

        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadform(new dashboard());
            //Check if device connected
            string checkConnectedDevice = getInfo("ideviceinfo.exe -k DeviceName");

            if (checkConnectedDevice.Contains("ERROR: No device found!"))
            {
                bunifuCustomLabel2.Text = "الجهاز غير متصل";
            }
            else
            {
                bunifuCustomLabel2.Text = "الجهاز متصل";
            }
        }
    }
}
