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
    public partial class ChangeInforSendAlert : Form
    {
        public ChangeInforSendAlert()
        {
            InitializeComponent();
            getinforsave();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to change infor receive alert ?", "Change Infor Receive Alert  ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\saveinfor.txt";
                saveinforOfProgram(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString(), textBox10.Text.ToString(), textBox9.Text.ToString(), textBox11.Text.ToString(), textBox12.Text.ToString());
                Main main = new Main();
                main.getinforSave();
                this.Close();
                 Main form1 = new Main();
                form1.getinforSave();

            }
            else
            {
            }
        }


        public void getinforsave()
        {

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\saveinfor.txt";

            string[] lines;

            if (System.IO.File.Exists(filePath))
            {
                lines = System.IO.File.ReadAllLines(filePath);
                textBox1.Text = lines[0].ToString();
                textBox2.Text = lines[1].ToString();
                textBox3.Text = lines[2].ToString();
                textBox4.Text = lines[3].ToString();
                textBox5.Text = lines[4].ToString();
                textBox6.Text = lines[5].ToString();
                textBox7.Text = lines[6].ToString();
                textBox8.Text = lines[7].ToString();
                textBox10.Text = lines[8].ToString();
                textBox9.Text = lines[9].ToString();
                textBox11.Text = lines[10].ToString();
                textBox12.Text = lines[11].ToString();

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
            }
        }

        public void saveinforOfProgram(string listmailsend, string listfriendsendhalo, string listroomsendhalo, string b04, string b05, string b06, string bn3, string c02,string c03roku, string c03nic, string c03ui, string b03)
        {
            string fileLPath = AppDomain.CurrentDomain.BaseDirectory + "\\saveinfor.txt";

            string[] lines = new string[12];
            lines[0] = listmailsend;
            lines[1] = listfriendsendhalo;
            lines[2] = listroomsendhalo;
            lines[3] = b04;
            lines[4] = b05;
            lines[5] = b06;
            lines[6] = bn3;
            lines[7] = c02;
            lines[8] = c03roku;
            lines[9] = c03nic;
            lines[10] = c03ui;
            lines[11] = b03;
            System.IO.File.WriteAllLines(fileLPath, lines);
        }

    }
}
