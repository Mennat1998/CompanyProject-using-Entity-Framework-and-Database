using CompanyProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProject2
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 report1= new Form9();
            report1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 report2 = new Form10();
            report2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form11 report3 = new Form11();
            report3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 report4 = new Form12();
            report4.ShowDialog();
        }
    }
}
