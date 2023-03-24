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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CompanyProject
{
    public partial class Form10 : Form
    {
        Model1 EF = new Model1();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load_1(object sender, EventArgs e)
        {
            var productsincompany = from pr in EF.products select pr.product_name;
            foreach (var st in productsincompany)
            {

                comboBox1.Items.Add(st);
            }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();
            listView5.Items.Clear();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";

            string selectedproduct = comboBox1.SelectedItem.ToString();
            int selectedproductid = (from st in EF.products where st.product_name == selectedproduct select st.product_id).FirstOrDefault();
            var pro = (from st in EF.products where st.product_name == selectedproduct select st);
            foreach (var s in pro)
            {
                textBox1.Text = s.product_id.ToString();
                textBox2.Text = s.product_name;
                textBox3.Text = s.product_production_date.ToString();
                textBox4.Text = s.product_Expire_date.ToString();
            }

            var product = (from id in EF.store_Product
                           where id.product_id_FK == selectedproductid
                           select id);

            foreach (var id in product)
            {
                listView1.Items.Add(id.store_id_FK.ToString());
                listView2.Items.Add(id.quantity_of_product.ToString());
                listView3.Items.Add(id.Dateofinsertinstore.ToString());
                if (!textBox5.Text.Equals("") && !textBox6.Text.Equals(""))
                {
                    DateTime fromdate = DateTime.Parse(textBox5.Text);
                    DateTime todate = DateTime.Parse(textBox6.Text);
                    if (id.Dateofinsertinstore > fromdate && id.Dateofinsertinstore < todate)
                    {
                        listView5.Items.Add(id.store_id_FK.ToString());
                        listView4.Items.Add(id.quantity_of_product.ToString());
                    }
                }
            }
        }

           
    }
}
