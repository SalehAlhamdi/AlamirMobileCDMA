using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlamirMobileCDMA
{
    public partial class active_cdma : Form
    {
        public string startupPath = @System.IO.Directory.GetCurrentDirectory() + @"\libimobiledevice\";
        public int count;
        string selectedFileName;
        public active_cdma()
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
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            var proc = Process.Start(proc1);
            return proc.StandardOutput.ReadToEnd();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bunifuFlatButton2.Visible = false;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Database files (*.IPCC)|*.IPCC";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFileName = openFileDialog1.FileName;
                //...
            }
            bunifuMetroTextbox1.Text = selectedFileName;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuFlatButton2.Visible = false;

            if (bunifuCheckbox1.Checked)

            {
                if (selectedFileName is null)
                {
                    MessageBox.Show("يرجى التاكد من مسار الملف");

                }
                else
                {
                    string checkDevice = getInfo("idevicename");

                    if (checkDevice.Length > 0)
                    {
                        string ios_ver = getInfo("ideviceinfo -k ProductVersion");
                        if (ios_ver.Contains("15"))
                        {
                            DialogResult checkSIM = MessageBox.Show("يرجى عدم تركيب اي شريحة لانه يسبب تعليق الجهاز", "الشريحة", MessageBoxButtons.YesNo);
                            if (checkSIM == DialogResult.Yes)
                            {
                                getInfo("ideviceinstaller -i " + selectedFileName);
                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                    count++;
                                }
                                if (count == 100)
                                {
                                    bunifuFlatButton2.Visible = true;

                                }
                                DialogResult checkRestart = MessageBox.Show("هل تريد اعادة تشغيل الهاتف", "اعادة التشغيل", MessageBoxButtons.YesNo);
                                if (checkSIM == DialogResult.Yes)
                                {
                                    getInfo("idevicediagnostics restart");

                                }
                                else
                                {
                                    bunifuCustomLabel1.Text = "لم يتم اعادة التشغيل الهاتف";
                                    bunifuCustomLabel1.Visible = true;
                                }

                                bunifuFlatButton2.Visible = true;
                                bunifuCustomLabel1.Visible = false;
                            }
                            else if (checkSIM == DialogResult.No)
                            {
                                bunifuCustomLabel1.Text = "توقفت العملية";
                                bunifuCustomLabel1.Visible = true;
                                bunifuFlatButton2.Visible = false;


                            }
                        }
                        else
                        {
                            getInfo("ideviceinstaller -i " + selectedFileName);
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
                    else
                    {
                        MessageBox.Show("يرجى التاكد من الجهاز متصل");
                        bunifuCustomLabel1.Text = "توقفت العملية";
                        bunifuCustomLabel1.Visible = true;
                        bunifuFlatButton2.Visible = false;


                    }

                }

            }
            else
            {
                    string checkDevice = getInfo("idevicename");
                    if (checkDevice.Length > 0)
                    {


                        string path;
                        //downloading files for IPCC
                        if (bunifuCheckbox1.Checked.ToString() == "14.6")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFileAsync(
                                    // Param1 = Link of file
                                    new System.Uri("https://drive.google.com/uc?export=download&id=1u2euXTbxueQ8jiG4xR18_TzKX1qgkrlb"),
                                      // Param2 = Path to save
                                      path = startupPath + @"\14,6.ipcc"
                                     );
                            }
                            cdma_Process(path, sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("يرجى التاكد من الجهاز متصل");
                        bunifuCustomLabel1.Text = "توقفت العملية";
                        bunifuCustomLabel1.Visible = true;
                        bunifuFlatButton2.Visible = false;

                    }


            }



        }

        public void cdma_Process(string path, object sender, EventArgs e)
        {
            if (File.Exists(path))
            {

                string ios_ver = getInfo("ideviceinfo -k ProductVersion");
                if (ios_ver.Contains("15"))
                {
                    DialogResult checkSIM = MessageBox.Show("يرجى عدم تركيب اي شريحة لانه يسبب تعليق الجهاز", "الشريحة", MessageBoxButtons.YesNo);
                    if (checkSIM == DialogResult.Yes)
                    {
                        getInfo("ideviceinstaller -i " + path);
                        for (int x = 0; x < 100; x++)
                        {
                            timer1_Tick(sender, e);
                            count++;
                        }
                        if (count == 100)
                        {
                            bunifuFlatButton2.Visible = true;

                        }
                        DialogResult checkRestart = MessageBox.Show("هل تريد اعادة تشغيل الهاتف", "اعادة التشغيل", MessageBoxButtons.YesNo);
                        if (checkSIM == DialogResult.Yes)
                        {
                            getInfo("idevicediagnostics restart");
                            File.Delete(path);

                        }
                        else
                        {
                            bunifuCustomLabel1.Text = "لم يتم اعادة التشغيل الهاتف";
                            bunifuCustomLabel1.Visible = true;
                            File.Delete(path);
                        }

                        bunifuFlatButton2.Visible = true;
                        bunifuCustomLabel1.Visible = false;
                    }
                    else if (checkSIM == DialogResult.No)
                    {
                        bunifuCustomLabel1.Text = "توقفت العملية";
                        bunifuCustomLabel1.Visible = true;
                        bunifuFlatButton2.Visible = false;


                    }
                }
                else
                {
                    getInfo("ideviceinstaller -i " + path);
                    for (int x = 0; x < 100; x++)
                    {
                        timer1_Tick(sender, e);
                        count++;
                    }
                    if (count == 100)
                    {
                        bunifuFlatButton2.Visible = true;
                        File.Delete(path);


                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < 100)
            {
                bunifuProgressBar1.Value++;
            }

    
        }

        private void active_cdma_Load(object sender, EventArgs e)
        {
            bunifuCheckbox1_OnChange(sender,e);
            active_label.Visible = false;
            imei_label.Visible = false;
            IOSVer_label.Visible = false;
            Sn_label.Visible = false;
            ICCID_label.Visible = false;
            region_label.Visible = false;
            product_label.Visible = false;
            model_label.Visible = false;
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked == true)
            {
                bunifuMetroTextbox1.Visible = true;
                bunifuFlatButton3.Visible = true;
            }
            else
            {
                bunifuMetroTextbox1.Visible = false;
                bunifuFlatButton3.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string checkDevice = getInfo("idevicename");
            if (checkDevice.Length > 0)
            {
                string imei = getInfo("ideviceinfo -k InternationalMobileEquipmentIdentity");
                string ProductVersion = getInfo("ideviceinfo -k ProductVersion");
                string CarrierBundleInfoArray = getInfo("ideviceinfo -k CarrierBundleInfoArray");
                int index = CarrierBundleInfoArray.IndexOf("IntegratedCircuitCardIdentity");
                string ICCID = CarrierBundleInfoArray.Substring(index+30, 20);
                string SerialNumber = getInfo("ideviceinfo -k SerialNumber");
                string RegionInfo = getInfo("ideviceinfo -k RegionInfo");
                string ActivationState = getInfo("ideviceinfo -k ActivationState");
                string ProductType = getInfo("ideviceinfo -k ProductType");
                active_label.Text = ActivationState;
                active_label.ForeColor = Color.Black;
                imei_label.Text = imei;
                IOSVer_label.Text = ProductVersion;
                Sn_label.Text = SerialNumber;
                ICCID_label.Text = ICCID;
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
                active_label.Visible = true;
                imei_label.Visible = true;
                IOSVer_label.Visible = true;
                Sn_label.Visible = true;
                ICCID_label.Visible = true;
                region_label.Visible = true;
                product_label.Visible = true;
                model_label.Visible = true;
            }
            else
            {
                MessageBox.Show("!الرجاء التاكد من توصيل الجهاز");
            }
            
        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {
            bunifuProgressBar1.Value = e.ProgressPercentage;

        }
    }
}
