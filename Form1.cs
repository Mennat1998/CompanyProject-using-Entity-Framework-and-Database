using CompanyProject2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 store =new Form2();
            store.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 prodcut = new Form3();
            prodcut.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 supplier = new Form4();
            supplier.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 customer = new Form5();
            customer.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 permission = new Form6();
            permission.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 transfere= new Form7();
            transfere.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 reports= new Form8();
            reports.ShowDialog();
        }
    }
}

