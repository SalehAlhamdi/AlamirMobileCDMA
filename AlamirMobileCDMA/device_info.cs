using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AlamirMobileCDMA
{
    public partial class device_info : Form
    {
        public string startupPath = @System.IO.Directory.GetCurrentDirectory() + @"\libimobiledevice\";

        public device_info()
        {
            InitializeComponent();
        }

        public string getInfo(string cammond)
        {
            var proc1 = new ProcessStartInfo("cmd");
            proc1.UseShellExecute = false;
            proc1.RedirectStandardOutput = true;
            proc1.CreateNoWindow = true;
            proc1.RedirectStandardInput = true;
            proc1.Arguments = "/c " + startupPath+cammond;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            var proc = Process.Start(proc1);
            return proc.StandardOutput.ReadToEnd();
        }

        private void device_info_Load(object sender, EventArgs e)
        {
            //serial number
            string s_command=getInfo("ideviceinfo.exe");
            int s_index = s_command.IndexOf("ChipSerialNo")+14;
            string serial = s_command.Substring(s_index,16 );
            bunifuMetroTextbox2.Text = serial;

            //Activation State
            string active_command = getInfo("ideviceinfo.exe");
            int active_index =16;
            string active= active_command.Substring(active_index, 9);
            bunifuMetroTextbox3.Text = active;

        }
    }
}
