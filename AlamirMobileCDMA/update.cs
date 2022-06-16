using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlamirMobileCDMA
{
    public partial class update : Form
    {
        string selectedPath;
        int count;
        public string startupPath = @System.IO.Directory.GetCurrentDirectory() + @"\libimobiledevice\";

        public update()
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
            proc1.Arguments = "/c " + startupPath + cammond;
            proc1.WindowStyle = ProcessWindowStyle.Normal;
            var proc = Process.Start(proc1);
            proc.WaitForExit();
            return proc.StandardOutput.ReadToEnd();
        }
        public void update_iOS(string cammond)
        {
            var proc1 = new ProcessStartInfo("cmd");
            proc1.UseShellExecute = false;
            proc1.RedirectStandardOutput = true;
            proc1.CreateNoWindow = true;
            proc1.RedirectStandardInput = true;
            proc1.Arguments = "/c " + startupPath + cammond;
            proc1.WindowStyle = ProcessWindowStyle.Normal;
            var proc = Process.Start(proc1);
            proc.WaitForExit();
            richTextBox1.Text += proc.StandardOutput.ReadToEnd();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuCircleProgressbar1.Value < 100)
            {
                bunifuCircleProgressbar1.Value++;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //device name
            string DeviceName = getInfo("idevicename");
            if (DeviceName.Length > 0)
            {
                if (selectedPath is null)
                {
                    MessageBox.Show("يرجى التاكد من صحة مسار الملف");

                }
                else
                {
                    
                    if(withoutData_radioButton.Checked ==true)
                    {
                        bunifuCircleProgressbar1.Value = 0;
                        panel1.Visible = true;
                        string UniqueDeviceID = getInfo("ideviceinfo.exe -k UniqueDeviceID");
                        update_iOS("idevicerestore -e --erase " + selectedPath);
                        bunifuCustomLabel1.Text = "...جاري عمل التحديث تاخذ العملية 20 دقيقة الى ساعة يرجى الانتظار";
                        for (int x = 0; x < 100; x++)
                        {
                            timer1_Tick(sender, e);
                            count++;
                        }
                        if (count == 100)
                        {
                            bunifuFlatButton2.Visible = true;

                        }
                    }
                    else if (saveData_radioButton.Checked==true)
                    {
                        bunifuCircleProgressbar1.Value = 0;
                        panel1.Visible = true;
                        string UniqueDeviceID = getInfo("ideviceinfo.exe -k UniqueDeviceID");
                        update_iOS("idevicerestore " + selectedPath);
                        bunifuCustomLabel1.Text = "...جاري عمل التحديث تاخذ العملية 20 دقيقة الى ساعة يرجى الانتظار";
                        for (int x = 0; x < 100; x++)
                        {
                            timer1_Tick(sender, e);
                            count++;
                        }
                        if (count == 100)
                        {
                            bunifuFlatButton2.Visible = true;

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("يرجى التاكد من توصيل جهاز");
            }
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            bunifuFlatButton2.Visible = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Database files (*.IPSW)|*.IPSW";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedPath = openFileDialog1.FileName;
                //...
            }
            bunifuMetroTextbox1.Text = selectedPath;
        }

  
    }
    
}
