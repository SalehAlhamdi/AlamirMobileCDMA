using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

    }
}
