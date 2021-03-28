using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingCommandReport
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.Text == "App")
            {
                comboBox2.Items.Add("App Error 1");
                comboBox2.Items.Add("App Error 2");
                comboBox2.Items.Add("App Error 3");
                comboBox2.Items.Add("App Error 4");
            }

            if (comboBox1.Text == "NetWork")
            {
                comboBox2.Items.Add("Network Error 1");
                comboBox2.Items.Add("Network Error 2");
                comboBox2.Items.Add("Network Error 3");
                comboBox2.Items.Add("Network Error 4");
                comboBox2.Items.Add("Network Error 5");
                comboBox2.Items.Add("Network Error 6");
                comboBox2.Items.Add("Network Error 7");
                comboBox2.Items.Add("Network Error 8");
            }

            if (comboBox1.Text == "Other")
            {
               
            }

            if (comboBox1.Text == "ShopFloor")
            {
                comboBox2.Items.Add("ShopFloor Error 1");
                comboBox2.Items.Add("ShopFloor Error 2");
                comboBox2.Items.Add("ShopFloor Error 3");
                comboBox2.Items.Add("ShopFloor Error 4");
                comboBox2.Items.Add("ShopFloor Error 5");
                comboBox2.Items.Add("ShopFloor Error 6");
                comboBox2.Items.Add("ShopFloor Error 7");
                comboBox2.Items.Add("ShopFloor Error 8"); ;
            }

            if (comboBox1.Text == "AllPart")
            {
                comboBox2.Items.Add("AllPart Error 1");
                comboBox2.Items.Add("AllPart Error 2");
                comboBox2.Items.Add("AllPart Error 3");
                comboBox2.Items.Add("AllPart Error 4");
            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            
        }
    }
}
