using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlamirMobileCDMA
{
    public partial class restore : Form
    {
        StringBuilder sortOutput;
        public string selectedPath;
        public string startupPath = @System.IO.Directory.GetCurrentDirectory() + @"\libimobiledevice\";

        public restore()
        {
            InitializeComponent();
        }
        public void backup_iOS(string cammond)
        {
            Process cmdProcess;
            cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.Arguments = "/c " + startupPath + cammond;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.Start();

            cmdProcess.BeginOutputReadLine();
            while (!cmdProcess.HasExited)
            {
                Application.DoEvents(); // This keeps your form responsive by processing events
            }


        }

        private void SortOutputHandler(object sendingProcess,DataReceivedEventArgs outLine)
        {

            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new DataReceivedEventHandler(SortOutputHandler), new[] { sendingProcess, outLine }); }
            else
            {                
                richTextBox1.AppendText(Environment.NewLine + outLine.Data);
            }
        }
        public string getInfo(string cammond)
        {
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

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (selectedPath is null)
            {
                MessageBox.Show("الرجاء التاكد من مسار النسخ");
            }
            else
            {
                string UniqueDeviceID = getInfo("ideviceinfo.exe -k UniqueDeviceID");

                backup_iOS("idevicebackup2 restore --full " + selectedPath);

            }
        }


        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            restore_Load(sender, e);
        }


        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    bunifuMetroTextbox1.Text = fbd.SelectedPath;
                    selectedPath = bunifuMetroTextbox1.Text;
                }
            }
        }

        private void restore_Load(object sender, EventArgs e)
        {
            if (getInfo("idevicename").Length > 0)
            {
                panel1.Visible = true;
                bunifuCustomLabel2.Visible = false;

            }
            else
            {
                panel1.Visible = false;
                bunifuCustomLabel2.Visible = true;
            }
        }
    }
}
