using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPortflio1
{
    public partial class options : Form
    {

        string settings = "5|5|20";

        public options()
        {
            InitializeComponent();
        }

        public string getOptions()
        {
            return settings;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(widthUD.Value >= 0 && heightUD.Value >= 0 && tickUD.Value >= 0)
            {
                settings = widthUD.Value + "|" + heightUD.Value + "|" + tickUD.Value;
            }
        }
    }
}
