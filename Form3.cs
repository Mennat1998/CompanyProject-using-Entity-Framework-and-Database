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
    public partial class Form3 : Form
    {
        Model1 EF = new Model1();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //add
        {

            product pro = new product();
            pro.product_id = int.Parse(textBox1.Text);
            pro.product_name = textBox2.Text;
            pro.product_production_date = DateTime.Parse(textBox3.Text);
            pro.product_Expire_date = DateTime.Parse(textBox4.Text);
            pro.validationperiod = (DateTime.Parse(textBox4.Text) - DateTime.Parse(textBox3.Text)).Days / (365 / 12);

            var AvailableID = (from pr in EF.products where pr.product_id == pro.product_id select pr).FirstOrDefault();
            if (AvailableID == null)
            {
                EF.products.Add(pro);
                EF.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                MessageBox.Show("Inserted");
            }
            else
            {
                MessageBox.Show("Invalid Data, Not inserted");
            }
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            int id = int.Parse(textBox1.Text);
            product pro = (EF.products.Where(p => p.product_id == id).Select(p => p)).FirstOrDefault();
            if (pro != null)
            {

                pro.product_name = textBox2.Text;
                pro.product_production_date = DateTime.Parse(textBox3.Text);
                pro.product_Expire_date = DateTime.Parse(textBox4.Text);
                pro.validationperiod = (DateTime.Parse(textBox4.Text) - DateTime.Parse(textBox3.Text)).Days / (365 / 12);
                EF.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
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
            product pro = EF.products.Find(ID);
            if (pro != null)
            {
                textBox1.Text = pro.product_id.ToString();
                textBox2.Text = pro.product_name;
                textBox3.Text = pro.product_production_date.ToString();
                textBox4.Text = pro.product_Expire_date.ToString();


            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var productid = from pro in EF.products
                            select pro.product_id;
            foreach (var product in productid)
            {
                comboBox1.Items.Add(product);
            }
        }
    }
}
