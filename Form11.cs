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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CompanyProject
{
    public partial class Form11 : Form
    {
        Model1 EF = new Model1();
        public Form11()
        {
            InitializeComponent();
        }




        private void Form11_Load_1(object sender, EventArgs e)
        {
            var products = from pro in EF.products select pro;
            foreach (var i in products)
            {
                comboBox1.Items.Add(i.product_name);
            }

            var productstore = from prosto in EF.store_Product select prosto;
            foreach (var i in productstore)
            {
                listView1.Items.Add(i.product_id_FK.ToString());
                listView2.Items.Add(i.store_id_FK.ToString());
                listView3.Items.Add(i.Dateofinsertinstore.ToString());
            }
            var dateproductstore = from prosto in EF.store_Product select prosto.Dateofinsertinstore;
            foreach(var i in dateproductstore)
            {
                var today = DateTime.Now;
                var diffOfDates = today.Subtract((DateTime)i);
                var month = diffOfDates.Days;

                listView4.Items.Add(month.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var products = (from pro in EF.products
                            where pro.product_name == comboBox1.SelectedItem.ToString()
                            select pro).FirstOrDefault();

            textBox1.Text = products.product_production_date.ToString();
            textBox2.Text = products.product_Expire_date.ToString();

            DateTime Dateofproduction = products.product_production_date;
            DateTime Dateofexpired = products.product_Expire_date;

            var diffOfDates = Dateofexpired - Dateofproduction;
            var month = (diffOfDates.Days) / (365 / 12);
            textBox3.Text = month.ToString();
        }
    }
}
