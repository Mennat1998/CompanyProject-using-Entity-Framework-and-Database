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
    public partial class Form12 : Form
    {
        Model1 EF = new Model1();
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            var moveid = (from id in EF.Move_Of_Products
                          select id.Move_Of_Products_id);

            foreach (int id in moveid)
            {
                comboBox2.Items.Add(id);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int moveid = int.Parse(comboBox2.SelectedItem.ToString());
            var movetable = (from id in EF.Move_Of_Products
                             where id.Move_Of_Products_id == moveid
                             select id);
            var table = (from id in EF.Move_Of_Products
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

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();
            listView5.Items.Clear();
            listView6.Items.Clear();
            listView7.Items.Clear();
            listView8.Items.Clear();
            var table = (from id in EF.Move_Of_Products
                         select id);
            if (!textBox2.Text.Equals("") && !textBox1.Text.Equals(""))
            {
                foreach (var i in table)
                {
                    DateTime fromdate = DateTime.Parse(textBox2.Text);
                    DateTime todate = DateTime.Parse(textBox1.Text);
                    if (i.DateofMove > fromdate && i.DateofMove < todate)
                    {
                        listView1.Items.Add(i.from_store_id.ToString());
                        listView2.Items.Add(i.to_store_id.ToString());
                        listView3.Items.Add(i.Product_id_FK.ToString());
                        listView4.Items.Add(i.quantity_of_product.ToString());
                        listView5.Items.Add(i.supplier_id_Fk.ToString());
                        listView6.Items.Add(i.product_production_date.ToString());
                        listView7.Items.Add(i.product_Expire_date.ToString());
                        listView8.Items.Add(i.DateofMove.ToString());
                    }
                }
            }
        }
    }
    }
