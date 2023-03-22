using CompanyProject2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CompanyProject
{
    public partial class Form7 : Form
    {
        Model1 EF = new Model1();
        public Form7()
        {
            InitializeComponent();
        }
        private void Form7_Load_1(object sender, EventArgs e)
        {
            var st = from str in EF.stores
                     select str.store_name;
            foreach (var store in st)
            {
                comboBox1.Items.Add(store);
                comboBox2.Items.Add(store);
            }

            var supplier = from sp in EF.suppliers
                           select sp.Supp_name;
            foreach (var supp in supplier)
            {
                comboBox3.Items.Add(supp);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Move_Of_Products MOF = new Move_Of_Products();
            store_Product newstore_product = new store_Product();
            string fromstorename = comboBox1.SelectedItem.ToString();
            string tostorename = comboBox2.SelectedItem.ToString();
            var storeid1 = (from st in EF.stores where st.store_name == fromstorename select st.store_id).FirstOrDefault();
            var storeid2 = (from st in EF.stores where st.store_name == tostorename select st.store_id).FirstOrDefault();
            int IDproduct = int.Parse(comboBox4.SelectedItem.ToString());


            string suppliername = comboBox3.SelectedItem.ToString();
            var suppid = (from st in EF.suppliers where st.Supp_name == suppliername select st.Supp_id).FirstOrDefault();

            MOF.Move_Of_Products_id = int.Parse(textBox1.Text);
            MOF.from_store_id = storeid1;
            MOF.to_store_id = storeid2;
            MOF.Product_id_FK = IDproduct;
            MOF.supplier_id_Fk = suppid;
            MOF.quantity_of_product = int.Parse(textBox4.Text);
            MOF.product_production_date = DateTime.Parse(textBox2.Text);
            MOF.product_Expire_date = DateTime.Parse(textBox3.Text);
            MOF.DateofMove = DateTime.Now;
            ///// new row stored in store product table
            newstore_product.product_id_FK = IDproduct;
            newstore_product.store_id_FK = storeid2;
            newstore_product.quantity_of_product = int.Parse(textBox4.Text);
            newstore_product.Dateofinsertinstore = DateTime.Now;

            /// update row in store product table after transfere
            var getstore_product = (from sp in EF.store_Product
                                    where sp.store_id_FK == storeid1 && sp.product_id_FK == IDproduct
                                    select sp).FirstOrDefault();

            int id = int.Parse(textBox1.Text);
            var MP = (from m in EF.Move_Of_Products where m.Move_Of_Products_id == MOF.Move_Of_Products_id select m).FirstOrDefault();
            if (MP == null)
            {
                EF.Move_Of_Products.Add(MOF);
                EF.SaveChanges();
                EF.store_Product.Add(newstore_product);
                EF.SaveChanges();
                int quantity = getstore_product.quantity_of_product - int.Parse(textBox4.Text);
                getstore_product.store_id_FK = storeid1;
                getstore_product.product_id_FK = IDproduct;

                getstore_product.quantity_of_product = quantity;

                EF.SaveChanges();
                MessageBox.Show("Transfered");
            }
            else
            {
                MessageBox.Show("Products Can't be Transfer");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int productid = int.Parse(comboBox4.SelectedItem.ToString());
            var productiondate = (from p in EF.products where p.product_id == productid select p.product_production_date).FirstOrDefault();
            var expiredate = (from p in EF.products where p.product_id == productid select p.product_Expire_date).FirstOrDefault();

            textBox2.Text = productiondate.ToString();
            textBox3.Text = expiredate.ToString();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var storename = comboBox1.SelectedItem.ToString();
            var storeid = (from st in EF.stores where st.store_name == storename select st.store_id).FirstOrDefault();
            var stname = from pr in EF.store_Product
                         where pr.store_id_FK == storeid
                         select pr.product_id_FK;

            foreach (var prod in stname)
            {
                comboBox4.Items.Add(prod);
            }
        }
    }
}
