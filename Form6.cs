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
    public partial class Form6 : Form
    {
        Model1 EF = new Model1();
        public Form6()
        {
            InitializeComponent();
        }



        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("Export");
            comboBox2.Items.Add("Import");

            var st = from str in EF.stores
                     select str.store_name;
            foreach (var store in st)
            {
                comboBox1.Items.Add(store);
            }

            var supplier = from sp in EF.suppliers
                           select sp.Supp_name;
            foreach (var supp in supplier)
            {
                comboBox3.Items.Add(supp);
            }
            var perm_id = from perm in EF.permissions
                          select perm.permission_id;
            foreach (var perm in perm_id)
            {
                comboBox5.Items.Add(perm);
            }


        }

        private void button1_Click(object sender, EventArgs e) // insert permission 
        {

            permission per = new permission();
            permission_product perproduct = new permission_product();
            store_Product store_Product = new store_Product();
            var date = DateTime.Parse(textBox2.Text);

            per.permission_id = int.Parse(textBox8.Text);
            per.permission_TYPE = comboBox2.SelectedItem.ToString();
            per.permission_date = date;
            string storename = comboBox1.SelectedItem.ToString();
            var storeid = (from st in EF.stores where st.store_name == storename select st.store_id).FirstOrDefault();
            per.store_id_FK = storeid;
            string suppliername = comboBox3.SelectedItem.ToString();
            var suppid = (from st in EF.suppliers where st.Supp_name == suppliername select st.Supp_id).FirstOrDefault();
            per.Supp_id_FK = suppid;

            string productname = comboBox4.SelectedItem.ToString();
            int productid = (from pi in EF.products where pi.product_name == productname select pi.product_id).FirstOrDefault();


            if (per.permission_TYPE == "Import")
            {
                perproduct.permission_id_FK = int.Parse(textBox8.Text);
                perproduct.Product_id_FK = productid;
                perproduct.quantity_of_product = int.Parse(textBox4.Text);
                store_Product.quantity_of_product = int.Parse(textBox4.Text);
                store_Product.product_id_FK = productid;
                store_Product.store_id_FK = storeid;
                store_Product.Dateofinsertinstore = date;


            }
            else if (per.permission_TYPE == "Export")
            {
                perproduct.permission_id_FK = int.Parse(textBox8.Text);
                perproduct.Product_id_FK = int.Parse(comboBox4.SelectedItem.ToString());
                perproduct.quantity_of_product = int.Parse(textBox4.Text);

            }

            var AvailableID = (from pr in EF.permissions where pr.permission_id == per.permission_id select pr).FirstOrDefault();
            if (AvailableID == null && per.permission_TYPE == "Import")
            {
                EF.permissions.Add(per);
                EF.SaveChanges();
                EF.permission_product.Add(perproduct);
                EF.SaveChanges();
                EF.store_Product.Add(store_Product);
                EF.SaveChanges();
                textBox8.Text = textBox2.Text = textBox4.Text = textBox7.Text = textBox6.Text = "";
                MessageBox.Show("Imported");
            }
            else if (AvailableID == null && per.permission_TYPE == "Export")
            {

                int pr = int.Parse(comboBox4.SelectedItem.ToString());
                var qof = (from s in EF.store_Product
                           where s.store_id_FK == storeid && s.product_id_FK == pr
                           select s).FirstOrDefault();
                if (qof.quantity_of_product >= int.Parse(textBox4.Text))
                {
                    EF.permissions.Add(per);
                    EF.SaveChanges();
                    EF.permission_product.Add(perproduct);
                    EF.SaveChanges();
                    int result = qof.quantity_of_product - int.Parse(textBox4.Text);
                    qof.store_id_FK = storeid;
                    qof.product_id_FK = pr;
                    qof.quantity_of_product = result;
                    EF.SaveChanges();
                    MessageBox.Show(" Exported");
                }
                else { MessageBox.Show("cant be exported Exported"); }

            }
            else
            {
                MessageBox.Show("Invalid Data, Not inserted");
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productname = comboBox4.SelectedItem.ToString();
            textBox6.Text = (from pi in EF.products where pi.product_name == productname select pi.product_production_date).FirstOrDefault().ToString();

            textBox7.Text = (from pi in EF.products where pi.product_name == productname select pi.product_Expire_date).FirstOrDefault().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox5.SelectedItem.ToString());
            permission perm = (EF.permissions.Where(p => p.permission_id == id).Select(p => p)).FirstOrDefault();
            var idofproduct = (EF.permission_product.Where(p => p.permission_id_FK == id).Select(p => p.Product_id_FK)).FirstOrDefault();
            permission_product permpro = (EF.permission_product.Where(p => p.permission_id_FK == id).Select(p => p)).FirstOrDefault();
            if (perm != null)

            {
                perm.permission_date = DateTime.Parse(textBox2.Text);
                string suppliername = comboBox3.SelectedItem.ToString();
                var suppid = (from st in EF.suppliers where st.Supp_name == suppliername select st.Supp_id).FirstOrDefault();
                perm.Supp_id_FK = suppid;
                EF.SaveChanges();
                textBox2.Text = textBox4.Text = textBox6.Text = textBox7.Text = "";
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Invalid Data,Not Updated");
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox5.SelectedItem.ToString());
            permission perm = EF.permissions.Find(ID);

            if (perm != null)
            {

                textBox8.Text = perm.permission_id.ToString();
                int storeid = (int)perm.store_id_FK;
                comboBox1.SelectedItem = (from st in EF.stores where st.store_id == storeid select st.store_name).FirstOrDefault();
                comboBox2.SelectedItem = perm.permission_TYPE;
                textBox2.Text = perm.permission_date.ToString();
                int suppid = (int)perm.Supp_id_FK;
                comboBox3.SelectedItem = (from so in EF.suppliers where so.Supp_id == suppid select so.Supp_name).FirstOrDefault();
                var productquantity = (from pq in EF.permission_product where pq.permission_id_FK == perm.permission_id select pq.quantity_of_product).FirstOrDefault();
                textBox4.Text = productquantity.ToString();

                int productid = (from pq in EF.permission_product where pq.permission_id_FK == perm.permission_id select pq.Product_id_FK).FirstOrDefault();
                var productname = (from p in EF.products where p.product_id == productid select p.product_name).FirstOrDefault();

                var productiondate = (from p in EF.products where p.product_id == productid select p.product_production_date).FirstOrDefault();
                var expiredate = (from p in EF.products where p.product_id == productid select p.product_Expire_date).FirstOrDefault();

                comboBox4.Text = productname.ToString();
                textBox6.Text = productiondate.ToString();
                textBox7.Text = expiredate.ToString();
                textBox8.Enabled = false;
                textBox7.Enabled = false;
                textBox6.Enabled = false;
                textBox4.Enabled = false;
                textBox2.Enabled = false;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
                comboBox2.Enabled = false;


            }
        }

       

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Import")
            {
                var pro = from pr in EF.products
                          select pr.product_name;

                foreach (var prod in pro)
                {
                    comboBox4.Items.Add(prod);
                }
            }
            else
            {
                string storename = comboBox1.SelectedItem.ToString();
                var storeid = (from st in EF.stores where st.store_name == storename select st.store_id).FirstOrDefault();

                var productinstore = (from stpr in EF.store_Product
                                      where stpr.store_id_FK == storeid
                                      select stpr.product_id_FK);


                foreach (var prod in productinstore)  /// id not name of product 
                {
                    comboBox4.Items.Add(prod);
                }

            }
        }
    }
}
