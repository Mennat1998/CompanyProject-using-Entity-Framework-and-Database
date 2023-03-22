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

            var moveid = (from id in EF.Move_Of_Products
                          select id.Move_Of_Products_id);

            foreach (int id in moveid)
            {
                comboBox2.Items.Add(id);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
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
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int moveid = int.Parse(comboBox2.SelectedItem.ToString());
            var movetable = (from id in EF.Move_Of_Products
                             where id.Move_Of_Products_id == moveid
                             select id);

            var idproduct = (from id in EF.Move_Of_Products
                             where id.Move_Of_Products_id == moveid
                             select id.Product_id_FK).FirstOrDefault();

            var productname = (from id in EF.products
                               where id.product_id == idproduct
                               select id.product_name).FirstOrDefault();

            var idsupp = (from id in EF.Move_Of_Products
                          where id.Move_Of_Products_id == moveid
                          select id.supplier_id_Fk).FirstOrDefault();

            var subbname = (from id in EF.suppliers
                            where id.Supp_id == idsupp
                            select id.Supp_name).FirstOrDefault();

            foreach (var item in movetable)
            {
                textBox5.Text = item.from_store_id.ToString();
                textBox6.Text = item.to_store_id.ToString();
                textBox7.Text = productname;
                textBox8.Text = item.quantity_of_product.ToString();
                textBox9.Text = subbname;
                textBox10.Text = item.product_production_date.ToString();
                textBox11.Text = item.product_Expire_date.ToString();
                textBox12.Text = item.DateofMove.ToString();

            }
        }
    }
}
