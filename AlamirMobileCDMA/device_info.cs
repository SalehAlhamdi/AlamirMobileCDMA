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
using System.Text.RegularExpressions;

namespace AlamirMobileCDMA
{
    public partial class device_info : Form
    {
        public string Model_Number;
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
            try
            {
                bunifuCustomLabel2.Visible = false;

                //device name
                string DeviceName = getInfo("ideviceinfo.exe -k DeviceName");

                deviceName_label.Text = DeviceName;


                //device class
                string DeviceClass = getInfo("ideviceinfo.exe -k DeviceClass");

                DeviceClass_label.Text = DeviceClass;



                //device class
                string ModelNumber = getInfo("ideviceinfo.exe -k ModelNumber");
                string Region = getInfo("ideviceinfo.exe -k RegionInfo");

                ModelNumber_label.Text = ModelNumber + Region;
                Model_Number = ModelNumber;


                //device class
                string IMEI = getInfo("ideviceinfo.exe -k InternationalMobileEquipmentIdentity");

                imei_label.Text = IMEI;


                //device class
                string ChipID = getInfo("ideviceinfo.exe -k ChipID");

                ChipID_label.Text = ChipID;


                //device class
                string BasebandVersion = getInfo("ideviceinfo.exe -k BasebandVersion");

                vBaseband_label.Text = BasebandVersion;


                //device class
                string EthernetAddress = getInfo("ideviceinfo.exe -k EthernetAddress");

                EthernetAddress_label.Text = EthernetAddress;


                //device class
                string MLBSerialNumber = getInfo("ideviceinfo.exe -k MLBSerialNumber");

                MLBSerialNumber_label.Text = MLBSerialNumber;


                //device class
                string UniqueDeviceID = getInfo("ideviceinfo.exe -k UniqueDeviceID");

                UDID_label.Text = UniqueDeviceID;



                //device class
                string ProductType = getInfo("ideviceinfo.exe -k ProductType");
                if (ProductType.Contains("iPhone9,4"))
                {
                    ProductType_label.Text = "iPhone 7 Plus";
                }
                else if (ProductType.Contains("iPhone14,3"))
                {
                    ProductType_label.Text = "iPhone 13 Pro Max";
                }
                else if (ProductType.Contains("iPhone12,5"))
                {
                    ProductType_label.Text = "iPhone 11 Pro Max";
                }
                else if (ProductType.Contains("iPhone14,5"))
                {
                    ProductType_label.Text = "iPhone 13";
                }
                else if (ProductType.Contains("iPhone13,4"))
                {
                    ProductType_label.Text = "iPhone 12 Pro Max";
                }
                else if (ProductType.Contains("iPhone13,3"))
                {
                    ProductType_label.Text = "iPhone 12 Pro";
                }
                else if (ProductType.Contains("iPhone14,2"))
                {
                    ProductType_label.Text = "iPhone 13 Pro";
                }
                else if (ProductType.Contains("iPhone12,1"))
                {
                    ProductType_label.Text = "iPhone 11";
                }
                else if (ProductType.Contains("iPhone12,3"))
                {
                    ProductType_label.Text = "iPhone 11 Pro";
                }
                else if (ProductType.Contains("iPhone13,2"))
                {
                    ProductType_label.Text = "iPhone 12";
                }
                else if (ProductType.Contains("iPhone11,2"))
                {
                    ProductType_label.Text = "iPhone XS";
                }
                else if (ProductType.Contains("iPhone11,4"))
                {
                    ProductType_label.Text = "iPhone XS Max (China)";
                }
                else if (ProductType.Contains("iPhone11,8"))
                {
                    ProductType_label.Text = "iPhone XR";
                }
                else if (ProductType.Contains("iPhone10,2"))
                {
                    ProductType_label.Text = "iPhone 8 Plus (Global)";
                }
                else if (ProductType.Contains("iPhone10,3"))
                {
                    ProductType_label.Text = "iPhone X (Global)";
                }
                else if (ProductType.Contains("iPhone10,6"))
                {
                    ProductType_label.Text = "iPhone X (GSM)";
                }
                else if (ProductType.Contains("iPhone11,6"))
                {
                    ProductType_label.Text = "iPhone XS Max";
                }
                else if (ProductType.Contains("iPhone10,1"))
                {
                    ProductType_label.Text = "iPhone 8 (Global)";
                }
                else if (ProductType.Contains("iPhone10,4"))
                {
                    ProductType_label.Text = "iPhone 8 (GSM)";
                }
                else if (ProductType.Contains("iPhone10,5"))
                {
                    ProductType_label.Text = "iPhone 8 Plus (GSM)";
                }
                else if (ProductType.Contains("iPhone9,1"))
                {
                    ProductType_label.Text = "iPhone 7 (Global)";
                }
                else if (ProductType.Contains("iPhone9,2"))
                {
                    ProductType_label.Text = "iPhone 7 Plus (Global)";
                }
                else if (ProductType.Contains("iPhone9,3"))
                {
                    ProductType_label.Text = "iPhone 7 (GSM)";
                }
                else if (ProductType.Contains("iPhone7,1"))
                {
                    ProductType_label.Text = "iPhone 6+";
                }
                else if (ProductType.Contains("iPhone7,2"))
                {
                    ProductType_label.Text = "iPhone 6";
                }
                else if (ProductType.Contains("iPhone8,1"))
                {
                    ProductType_label.Text = "iPhone 6s";
                }
                else if (ProductType.Contains("iPhone8,2"))
                {
                    ProductType_label.Text = "iPhone 6s+";
                }
                else if (ProductType.Contains("iPhone6,2"))
                {
                    ProductType_label.Text = "iPhone 5s (Global)";
                }
                else if (ProductType.Contains("iPhone5,4"))
                {
                    ProductType_label.Text = "iPhone 5c (Global)";
                }
                else if (ProductType.Contains("iPhone5,3"))
                {
                    ProductType_label.Text = "iPhone 5c (GSM)";
                }





                //device class
                string SerialNumber = getInfo("ideviceinfo.exe -k SerialNumber");

                SerialNumber_label.Text = SerialNumber;


                //device class
                string HardwareModel = getInfo("ideviceinfo.exe -k HardwareModel");

                Model_label.Text = HardwareModel;


                //device class
                string DeviceColor = getInfo("ideviceinfo.exe -k DeviceColor");
                if (DeviceColor.Contains("1"))
                {
                    color_label.Text = "اسود";
                }
                else if (DeviceColor.Contains("2"))
                {
                    color_label.Text = "ابيض";
                }
                else if (DeviceColor.Contains("3"))
                {
                    color_label.Text = "ذهبي";
                }
                else if (DeviceColor.Contains("4"))
                {
                    color_label.Text = "ذهبي";
                }
                else if (DeviceColor.Contains("5"))
                {
                    color_label.Text = "اسود";
                }
                else if (DeviceColor.Contains("6"))
                {
                    color_label.Text = "احمر";
                }
                else if (DeviceColor.Contains("7"))
                {
                    color_label.Text = "اصفر";
                }

                else if (DeviceColor.Contains("9"))
                {
                    color_label.Text = "اصفر";
                }


                //device class
                string ProductVersion = getInfo("ideviceinfo.exe -k ProductVersion");

                ProductVersion_label.Text = ProductVersion;


                //device class
                string WiFiAddress = getInfo("ideviceinfo.exe -k WiFiAddress");

                Wifi_label.Text = WiFiAddress;


                //device class
                string CPUArchitecture = getInfo("ideviceinfo.exe -k CPUArchitecture");

                CPU_label.Text = CPUArchitecture;


                //device class
                string ActivationState = getInfo("ideviceinfo.exe -k ActivationState");

                if (ActivationState.Contains("Activated"))
                {
                    ActivationState_label.Text = "منشط";

                }
                else
                {
                    ActivationState_label.Text = "غير منشط";
                }

                //device class
                string Slot = getInfo("ideviceinfo.exe -k BasebandKeyHashInformation");
                //sim1
                int index1 = Slot.IndexOf("SKeyStatus");
                string sim1 = Slot.Substring(index1, 15);
                //sim2
                int index2 = Slot.IndexOf("AKeyStatus");
                string sim2 = Slot.Substring(index2, 15);
                if (sim1.Contains("2") || sim2.Contains("2")) 
                {
                    Slot_label.Text = "شرحتين";
                }
           
                else
                    Slot_label.Text = "شريحة";


                //device class
                string RegionInfo = getInfo("ideviceinfo.exe -k RegionInfo");

                if (RegionInfo.Contains("KH/A"))
                {
                    RegionInfo_label.Text = "كوري";

                }
                else if (RegionInfo.Contains("J"))
                {
                    RegionInfo_label.Text = "ياباني";

                }
                else if (RegionInfo.Contains("ZA/A"))
                {
                    RegionInfo_label.Text = "هون كونق";

                }
                else if (RegionInfo.Contains("AB"))
                {
                    RegionInfo_label.Text = "سعودي";

                }
                else if (RegionInfo.Contains("CH"))
                {
                    RegionInfo_label.Text = "صيني";

                }
                else if (RegionInfo.Contains("LL"))
                {
                    RegionInfo_label.Text = "امريكي";

                }
                else if (RegionInfo.Contains("VC"))
                {
                    RegionInfo_label.Text = "كندي";

                }
                else if (RegionInfo.Contains("Y"))
                {
                    RegionInfo_label.Text = "اسباني";

                }
                else if (RegionInfo.Contains("ZP"))
                {
                    RegionInfo_label.Text = "هون كونق";

                }

                else if (RegionInfo.Contains("RS"))
                {
                    RegionInfo_label.Text = "روسي";

                }
                else if (RegionInfo.Contains("ZA"))
                {
                    RegionInfo_label.Text = "سنقافورة";

                }
                else if (RegionInfo.Contains("MO"))
                {
                    RegionInfo_label.Text = "هون كونق";

                }
                else if (RegionInfo.Contains("CL"))
                {
                    RegionInfo_label.Text = "كندي";

                }
                else if (RegionInfo.Contains("AM"))
                {
                    RegionInfo_label.Text = "امريكي";

                }
                else if (RegionInfo.Contains("FD"))
                {
                    RegionInfo_label.Text = "استرالي";

                }
                else if (RegionInfo.Contains("FB"))
                {
                    RegionInfo_label.Text = "فرنسي";

                }


                //device class
                string BuildVersion = getInfo("ideviceinfo.exe -k BuildVersion");

                BuildVersion_label.Text = BuildVersion;
            }
            catch
            {
                bunifuCircleProgressbar1.Visible = false;
                deviceInfoPanel.Visible = false;
                bunifuCustomLabel2.Visible = true;
                bunifuCustomLabel1.Visible = false;
                //items
                bunifuFlatButton1.Visible = false;
                bunifuFlatButton2.Visible = false;
                bunifuFlatButton3.Visible = false;
                bunifuFlatButton4.Visible = false;
                bunifuFlatButton5.Visible = false;
                bunifuFlatButton6.Visible = false;
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton8.Visible = false;
                bunifuFlatButton9.Visible = false;
                bunifuFlatButton10.Visible = false;
                bunifuFlatButton11.Visible = false;
                bunifuFlatButton12.Visible = true;
                bunifuFlatButton13.Visible = false;
                bunifuFlatButton14.Visible = false;
                bunifuFlatButton15.Visible = false;
                bunifuFlatButton16.Visible = false;
                bunifuFlatButton17.Visible = false;
                bunifuFlatButton18.Visible = false;
                bunifuFlatButton19.Visible = false;
                bunifuFlatButton20.Visible = false;
                bunifuFlatButton21.Visible = false;
                panel2.Visible = false;
                panel1.Visible = false;
                ActivationState_label.Visible = false;
                imei_label.Visible = false;
                EthernetAddress_label.Visible = false;
                deviceName_label.Visible = false;
                DeviceClass_label.Visible = false;
                CPU_label.Visible = false;
                color_label.Visible = false;
                ChipID_label.Visible = false;
                bunifuCustomLabel1.Visible = false;
                BuildVersion_label.Visible = false;
                ActivationState_label.Visible = false;
                ModelNumber_label.Visible = false;
                vBaseband_label.Visible = false;
                MLBSerialNumber_label.Visible = false;
                UDID_label.Visible = false;
                ProductType_label.Visible = false;
                RegionInfo_label.Visible = false;
                SerialNumber_label.Visible = false;
                Model_label.Visible = false;
                ProductVersion_label.Visible = false;
                Wifi_label.Visible = false;
                Slot_label.Visible = false;


            }















        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            deviceInfoPanel.Visible = true;
            bunifuCircleProgressbar1.Value = 0;
            loader_Tick(sender, e);
            device_info_Load(sender,e);

        }

        private void loader_Tick(object sender, EventArgs e)
        {
            
            if (bunifuCircleProgressbar1.Value < 100)
            {
                bunifuCircleProgressbar1.Value++;
            }
            else
            {
                deviceInfoPanel.Visible = false;
            }
        }
    }
}
