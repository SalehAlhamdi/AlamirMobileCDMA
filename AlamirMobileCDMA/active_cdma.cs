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
        public string p_path;
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
                        if (comboBox1.SelectedText == "12")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1AWHhXaQl3KKhwuXWn3Josz_lv_u4KHc9", startupPath + @"\12.ipcc");
                                path = startupPath + @"\12.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                        else if (comboBox1.SelectedText == "13")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1ZPj8SHyYWEAC9o7J4MXrKy2CWTHZX8RZ", startupPath + @"\13.ipcc");
                                    path = startupPath + @"\13.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "14.0.1" || comboBox1.SelectedText == "14.0")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1vqsPhmGQiFonZke18k4Y-kB2_kvsTUrg", startupPath + @"\14.0.1.ipcc");
                                    path = startupPath + @"\14.0.1.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "14.2"|| comboBox1.SelectedText == "14.1")
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile("https://drive.google.com/uc?export=download&id=1fRRo7HmzF1lskKrw3FJgMqKzFrBCbEHs", startupPath + @"\14.2.ipcc");
                                        path = startupPath + @"\14.2.ipcc";
                                        cdma_Process(path, sender, e);
                                    }

                                    for (int x = 0; x < 100; x++)
                                    {
                                        timer1_Tick(sender, e);
                                    }
                                }
                        else if (comboBox1.SelectedText == "14.3")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1DOjE9VYlJ37MMschIFF3-6EgStUCWKr9", startupPath + @"\14.3.ipcc");
                                    path = startupPath + @"\14.3.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "14.4")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1lY9L6MyUlYVhBvSfZRDCe5Efz7GEnczs", startupPath + @"\14.4.ipcc");
                                    path = startupPath + @"\14.4.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "14.4.1")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1lY9L6MyUlYVhBvSfZRDCe5Efz7GEnczs", startupPath + @"\14.4.1.ipcc");
                                    path = startupPath + @"\14.4.1.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "14.4.2")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=10Wi4U8NOrjyotb90ywBPHWEmcGYf6XSD", startupPath + @"\14.4.2.ipcc");
                                    path = startupPath + @"\14.4.2.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "14.5" || comboBox1.SelectedText=="14.5.1")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1k6LidjiT-HgwfhKAr3Z1ZHac_8RCY9Cd", startupPath + @"\14.5.ipcc");
                                path = startupPath + @"\14.5.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                        else if (comboBox1.SelectedText == "14.6")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1u2euXTbxueQ8jiG4xR18_TzKX1qgkrlb", startupPath + @"\14.6.ipcc");
                                path = startupPath + @"\14.6.ipcc";
                                cdma_Process(path, sender, e);
                            }
                        
                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "14.6.1")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1u2euXTbxueQ8jiG4xR18_TzKX1qgkrlb", startupPath + @"\14.6.1.ipcc");
                                path = startupPath + @"\14.6.1.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                        else if (comboBox1.SelectedText == "14.7")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1Ic0szEmta9k_RutgQVq-p45aGzHFOnDV", startupPath + @"\14.7.ipcc");
                                path = startupPath + @"\14.7.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                        else if (comboBox1.SelectedText == "14.7.1")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1Ic0szEmta9k_RutgQVq-p45aGzHFOnDV", startupPath + @"\14.7.1.ipcc");
                                    path = startupPath + @"\14.7.1.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "14.8")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1RChalCPmNEfq0kkgRduQ9FfrBY8YHUHS", startupPath + @"\14.8.ipcc");
                                    path = startupPath + @"\14.8.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "14.8.1")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1RChalCPmNEfq0kkgRduQ9FfrBY8YHUHS", startupPath + @"\14.8.1.ipcc");
                                    path = startupPath + @"\14.8.1.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "15.0")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1b-5h9R75XFo8eCbRii8V24FOIDhOGSKx", startupPath + @"\15.0.ipcc");
                                    path = startupPath + @"\15.0.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "15.0.1")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1m3CwaaCYzW_kRFBg_0laEBw9TO5XeHiZ", startupPath + @"\15.0.1.ipcc");
                                path = startupPath + @"\15.0.1.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                        else if (comboBox1.SelectedText == "15.0.2")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1m3CwaaCYzW_kRFBg_0laEBw9TO5XeHiZ", startupPath + @"\15.0.2.ipcc");
                                path = startupPath + @"\15.0.2.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                        else if (comboBox1.SelectedText == "15.1")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=18U-EhOTgoFWEU5oJHhgFS_PVXTB1J2w7", startupPath + @"\15.1.ipcc");
                                    path = startupPath + @"\15.1.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }

                        else if (comboBox1.SelectedText == "15.1.1")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=11-5Yuoel60UZkxVfplgO6ujsMGgTA3CT", startupPath + @"\15.1.1.ipcc");
                                    path = startupPath + @"\15.1.1.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                
                        else if (comboBox1.SelectedText == "15.2")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1MuDf-ufhDRZH_V7P40H2LeO8iB2kcq43", startupPath + @"\15.2.ipcc");
                                path = startupPath + @"\15.2.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }

                        else if (comboBox1.SelectedText == "15.2.1")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1MuDf-ufhDRZH_V7P40H2LeO8iB2kcq43", startupPath + @"\15.2.1.ipcc");
                                path = startupPath + @"\15.2.1.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                    else if (comboBox1.SelectedText == "15.3")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1IDadOnsqXvujKFaIiE2xFh0YObbOP6ZV", startupPath + @"\15.3.ipcc");
                                path = startupPath + @"\15.3.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                
                        else if (comboBox1.SelectedText == "15.3.1")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1VALqi3cwUFXG9ykzDo70QzwfpC9FVOIO", startupPath + @"\15.3.1.ipcc");
                                path = startupPath + @"\15.3.1.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                        else if (comboBox1.SelectedText == "15.4")
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile("https://drive.google.com/uc?export=download&id=1mdKzz9T1MxKXzlWK-cshBn3NV66wqFTo", startupPath + @"\15.4.ipcc");
                                        path = startupPath + @"\15.4.ipcc";
                                        cdma_Process(path, sender, e);
                                    }

                                    for (int x = 0; x < 100; x++)
                                    {
                                        timer1_Tick(sender, e);
                                    }
                                }
                        else if (comboBox1.SelectedText == "15.4.1")
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile("https://drive.google.com/uc?export=download&id=1Dc-LoaFEbmZXuM1WxV7njgSjcyrHe5K5", startupPath + @"\15.4.1.ipcc");
                                path = startupPath + @"\15.4.1.ipcc";
                                cdma_Process(path, sender, e);
                            }

                            for (int x = 0; x < 100; x++)
                            {
                                timer1_Tick(sender, e);
                            }
                        }
                        else if (comboBox1.SelectedText == "15.5")
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile("https://drive.google.com/uc?export=download&id=1Vm2EOxdhuThVAPhPr1zDhqEXD-dlcSeQ", startupPath + @"\15.5.ipcc");
                                    path = startupPath + @"\15.5.ipcc";
                                    cdma_Process(path, sender, e);
                                }

                                for (int x = 0; x < 100; x++)
                                {
                                    timer1_Tick(sender, e);
                                }
                            }
                        else if (comboBox1.SelectedText == "15.6")
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile("https://drive.google.com/uc?export=download&id=1zOCZKZIFzKy4fFpxnxd2FzIDl9x5jlBh", startupPath + @"\15.6.ipcc");
                                        path = startupPath + @"\15.6.ipcc";
                                        cdma_Process(path, sender, e);
                                    }

                                    for (int x = 0; x < 100; x++)
                                    {
                                        timer1_Tick(sender, e);
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

        public void cdma_Process(string path, object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                MessageBox.Show("تم تحميل الملف");
                p_path = path;
                string ios_ver = getInfo("ideviceinfo -k ProductVersion");
                bunifuProgressBar1.Value = 0;
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

                if (CarrierBundleInfoArray.Length>0)
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

        }
    }
}
