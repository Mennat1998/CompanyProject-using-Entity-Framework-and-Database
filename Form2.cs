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
    public partial class Form2 : Form
    {
        Model1 EF = new Model1();
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load_1(object sender, EventArgs e)
        {

            var storeId = from str in EF.stores
                          select str.store_id;
            foreach (var store in storeId)
            {
                comboBox1.Items.Add(store);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            store str = new store();
            str.store_id = int.Parse(textBox1.Text);
            str.store_name = textBox2.Text;
            str.store_Address = textBox3.Text;
            str.store_Manager = textBox4.Text;
            var AvailableID = (from st in EF.stores where st.store_id == str.store_id select st).FirstOrDefault();
            if (AvailableID == null)
            {
                EF.stores.Add(str);
                EF.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                MessageBox.Show("Inserted");
            }
            else
            {
                MessageBox.Show("Invalid Data, Not inserted");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            store str = (EF.stores.Where(s => s.store_id == id).Select(s => s)).FirstOrDefault();
            if (str != null)
            {

                str.store_name = textBox2.Text;
                str.store_Address = textBox3.Text;
                str.store_Manager = textBox4.Text;
                EF.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Invalid Data,Not Updated");
            }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox1.Text);
            store str = EF.stores.Find(ID);
            if (str != null)
            {
                textBox1.Text = str.store_id.ToString();
                textBox2.Text = str.store_name;
                textBox3.Text = str.store_Address;
                textBox4.Text = str.store_Manager;

            }
        }
    }
}

