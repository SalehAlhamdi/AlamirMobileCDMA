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
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            // Launch browser to facebook...

            System.Diagnostics.Process.Start("https://www.instagram.com/main__zed/");
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            // Launch browser to facebook...

            System.Diagnostics.Process.Start("https://www.facebook.com/saleh.m.alhamdi/");
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            // Launch browser to GitHub...
            System.Diagnostics.Process.Start("https://github.com/SalehAlhamdi");
        }
    }
}
