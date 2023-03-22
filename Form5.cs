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
    public partial class Form5 : Form
    {
        Model1 EF = new Model1();
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer cust = new customer();
            cust.Cust_id = int.Parse(textBox1.Text);
            cust.Cust_name = textBox2.Text;
            cust.Cust_Phone = textBox3.Text;
            cust.Cust_Fax = textBox4.Text;
            cust.Cust_email = textBox5.Text;
            cust.Cust_Mobile = textBox6.Text;
            cust.Cust_website = textBox7.Text;

            var AvailableID = (from cs in EF.customers where cs.Cust_id == cust.Cust_id select cs).FirstOrDefault();
            if (AvailableID == null)
            {
                EF.customers.Add(cust);
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
            customer cust = (EF.customers.Where(c => c.Cust_id == id).Select(c => c)).FirstOrDefault();

            if (cust != null)
            {
                cust.Cust_id = int.Parse(textBox1.Text);
                cust.Cust_name = textBox2.Text;
                cust.Cust_Phone = textBox3.Text;
                cust.Cust_Fax = textBox4.Text;
                cust.Cust_email = textBox5.Text;
                cust.Cust_Mobile = textBox6.Text;
                cust.Cust_website = textBox7.Text;
                EF.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Invalid Data,Not Updated");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox1.Text);
            customer cust = EF.customers.Find(ID);

            if (cust != null)
            {
                textBox1.Text = cust.Cust_id.ToString();
                textBox2.Text = cust.Cust_name;
                textBox3.Text = cust.Cust_Phone;
                textBox4.Text = cust.Cust_Fax;
                textBox5.Text = cust.Cust_email;
                textBox6.Text = cust.Cust_Mobile;
                textBox7.Text = cust.Cust_website;



            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            var custm = from cs in EF.customers
                        select cs.Cust_id;
            foreach (var cust in custm)
            {
                comboBox1.Items.Add(cust);
            }
        }
    }
}
