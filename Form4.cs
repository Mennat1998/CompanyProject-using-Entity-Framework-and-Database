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
    public partial class Form4 : Form
    {
        Model1 EF = new Model1();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var suppid = from sp in EF.suppliers
                         select sp.Supp_id;
            foreach (var supp in suppid)
            {
                comboBox1.Items.Add(supp);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox1.Text);
            supplier supp = EF.suppliers.Find(ID);

            if (supp != null)
            {
                textBox1.Text = supp.Supp_id.ToString();
                textBox2.Text = supp.Supp_name;
                textBox3.Text = supp.Supp_Phone;
                textBox4.Text = supp.Supp_Fax;
                textBox5.Text = supp.Supp_email;
                textBox6.Text = supp.Supp_Mobile;
                textBox7.Text = supp.Supp_website;



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            supplier supp = new supplier();
            supp.Supp_id = int.Parse(textBox1.Text);
            supp.Supp_name = textBox2.Text;
            supp.Supp_Phone = textBox3.Text;
            supp.Supp_Fax = textBox4.Text;
            supp.Supp_email = textBox5.Text;
            supp.Supp_Mobile = textBox6.Text;
            supp.Supp_website = textBox7.Text;

            var AvailableID = (from sp in EF.suppliers where sp.Supp_id == supp.Supp_id select sp).FirstOrDefault();
            if (AvailableID == null)
            {
                EF.suppliers.Add(supp);
                EF.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                MessageBox.Show("Inserted");
            }
            else
            {
                MessageBox.Show("Invalid Data, Not inserted");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            supplier supp = (EF.suppliers.Where(s => s.Supp_id == id).Select(s => s)).FirstOrDefault();
            if (supp != null)
            {
                supp.Supp_id = int.Parse(textBox1.Text);
                supp.Supp_name = textBox2.Text;
                supp.Supp_Phone = textBox3.Text;
                supp.Supp_Fax = textBox4.Text;
                supp.Supp_email = textBox5.Text;
                supp.Supp_Mobile = textBox6.Text;
                supp.Supp_website = textBox7.Text;
                EF.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Invalid Data,Not Updated");
            }
        }
    }
}
