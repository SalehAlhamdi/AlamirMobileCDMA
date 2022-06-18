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

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string devicename = getInfo("idevicename");
            if (devicename.Length>0)
            {

                if (selectedPath is null)
                {
                    MessageBox.Show("يرجى التاكد من صحة مسار الملف");

                }
                else
                {
                    string imei = getInfo("ideviceinfo -k InternationalMobileEquipmentIdentity");
                    string ProductVersion = getInfo("ideviceinfo -k ProductVersion");
                    string CarrierBundleInfoArray = getInfo("ideviceinfo -k CarrierBundleInfoArray");

                    if (CarrierBundleInfoArray.Length > 0)
                    {
                        int index = CarrierBundleInfoArray.IndexOf("IntegratedCircuitCardIdentity");
                        string ICCID = CarrierBundleInfoArray.Substring(index + 30, 20);
                        ICCID_label.Text = ICCID;

                    }

                    string SerialNumber = getInfo("ideviceinfo -k SerialNumber");
                    string RegionInfo = getInfo("ideviceinfo -k RegionInfo");
                    string ActivationState = getInfo("ideviceinfo -k ActivationState");
                    string ProductType = getInfo("ideviceinfo -k ProductType");
                    active_label.Text = ActivationState;
                    active_label.ForeColor = Color.Black;
                    imei_label.Text = imei;
                    IOSVer_label.Text = ProductVersion;
                    Sn_label.Text = SerialNumber;
                    region_label.Text = RegionInfo;
                    product_label.Text = ProductType;

                    if (ProductType.Contains("iPhone9,4"))
                    {
                        model_label.Text = "iPhone 7 Plus";
                    }
                    else if (ProductType.Contains("iPhone14,3"))
                    {
                        model_label.Text = "iPhone 13 Pro Max";
                    }
                    else if (ProductType.Contains("iPhone12,5"))
                    {
                        model_label.Text = "iPhone 11 Pro Max";
                    }
                    else if (ProductType.Contains("iPhone14,5"))
                    {
                        model_label.Text = "iPhone 13";
                    }
                    else if (ProductType.Contains("iPhone13,4"))
                    {
                        model_label.Text = "iPhone 12 Pro Max";
                    }
                    else if (ProductType.Contains("iPhone13,3"))
                    {
                        model_label.Text = "iPhone 12 Pro";
                    }
                    else if (ProductType.Contains("iPhone14,2"))
                    {
                        model_label.Text = "iPhone 13 Pro";
                    }
                    else if (ProductType.Contains("iPhone12,1"))
                    {
                        model_label.Text = "iPhone 11";
                    }
                    else if (ProductType.Contains("iPhone12,3"))
                    {
                        model_label.Text = "iPhone 11 Pro";
                    }
                    else if (ProductType.Contains("iPhone13,2"))
                    {
                        model_label.Text = "iPhone 12";
                    }
                    else if (ProductType.Contains("iPhone11,2"))
                    {
                        model_label.Text = "iPhone XS";
                    }
                    else if (ProductType.Contains("iPhone11,4"))
                    {
                        model_label.Text = "iPhone XS Max (China)";
                    }
                    else if (ProductType.Contains("iPhone11,8"))
                    {
                        model_label.Text = "iPhone XR";
                    }
                    else if (ProductType.Contains("iPhone10,2"))
                    {
                        model_label.Text = "iPhone 8 Plus (Global)";
                    }
                    else if (ProductType.Contains("iPhone10,3"))
                    {
                        model_label.Text = "iPhone X (Global)";
                    }
                    else if (ProductType.Contains("iPhone10,6"))
                    {
                        model_label.Text = "iPhone X (GSM)";
                    }
                    else if (ProductType.Contains("iPhone11,6"))
                    {
                        model_label.Text = "iPhone XS Max";
                    }
                    else if (ProductType.Contains("iPhone10,1"))
                    {
                        model_label.Text = "iPhone 8 (Global)";
                    }
                    else if (ProductType.Contains("iPhone10,4"))
                    {
                        model_label.Text = "iPhone 8 (GSM)";
                    }
                    else if (ProductType.Contains("iPhone10,5"))
                    {
                        model_label.Text = "iPhone 8 Plus (GSM)";
                    }
                    else if (ProductType.Contains("iPhone9,1"))
                    {
                        model_label.Text = "iPhone 7 (Global)";
                    }
                    else if (ProductType.Contains("iPhone9,2"))
                    {
                        model_label.Text = "iPhone 7 Plus (Global)";
                    }
                    else if (ProductType.Contains("iPhone9,3"))
                    {
                        model_label.Text = "iPhone 7 (GSM)";
                    }
                    else if (ProductType.Contains("iPhone7,1"))
                    {
                        model_label.Text = "iPhone 6+";
                    }
                    else if (ProductType.Contains("iPhone7,2"))
                    {
                        model_label.Text = "iPhone 6";
                    }
                    else if (ProductType.Contains("iPhone8,1"))
                    {
                        model_label.Text = "iPhone 6s";
                    }
                    else if (ProductType.Contains("iPhone8,2"))
                    {
                        model_label.Text = "iPhone 6s+";
                    }
                    else if (ProductType.Contains("iPhone6,2"))
                    {
                        model_label.Text = "iPhone 5s (Global)";
                    }
                    else if (ProductType.Contains("iPhone5,4"))
                    {
                        model_label.Text = "iPhone 5c (Global)";
                    }
                    else if (ProductType.Contains("iPhone5,3"))
                    {
                        model_label.Text = "iPhone 5c (GSM)";
                    }

                    if (withoutData_radioButton.Checked == true)
                    {
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
                    else if (saveData_radioButton.Checked == true)
                    {
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
                MessageBox.Show("الرجاء التاكد من توصيل الجهاز");
            }
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
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
