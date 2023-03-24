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
