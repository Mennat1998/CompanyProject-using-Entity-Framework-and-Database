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
    public partial class Form9 : Form
    {
        Model1 EF = new Model1();
        public Form9()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            string selectedstore = comboBox1.SelectedItem.ToString();
            int selectedstoreid = (from st in EF.stores where st.store_name == selectedstore select st.store_id).FirstOrDefault();
            var stro = (from st in EF.stores where st.store_name == selectedstore select st);

            foreach (var s in stro)
            {
                textBox1.Text = s.store_id.ToString();
                textBox2.Text = s.store_name;
                textBox3.Text = s.store_Address;
                textBox4.Text = s.store_Manager;
            }

         /*   var permissiondate = (from prdt in EF.permissions
                                  where prdt.store_id_FK == selectedstoreid
                                  select prdt);



            foreach (var perm in permissiondate)
            {
                listView3.Items.Add(perm.permission_date.ToString());
            }

            */
            var product = (from id in EF.store_Product
                           where id.store_id_FK == selectedstoreid
                           select id);

            foreach (var id in product)
            {
                listView1.Items.Add(id.product_id_FK.ToString());
                listView2.Items.Add(id.quantity_of_product.ToString());
                listView3.Items.Add(id.Dateofinsertinstore.ToString());
            }


        }

        private void Form9_Load_1(object sender, EventArgs e)
        {
            var storesincompany = from st in EF.stores select st.store_name;
            foreach (var st in storesincompany)
            {

                comboBox1.Items.Add(st);
            }
        }
    }
}
