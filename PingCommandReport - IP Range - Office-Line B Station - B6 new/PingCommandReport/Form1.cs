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
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            getinforSave();
        }

        private void saveinfor_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to change list ip exception this  Ip ?", "Change list ip ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {

                saveinforOfProgram(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString(), textBox9.Text.ToString(), textBox10.Text.ToString(), textBox11.Text.ToString(), textBox12.Text.ToString(), textBox13.Text.ToString(), textBox14.Text.ToString(), textBox15.Text.ToString(), textBox16.Text.ToString(), textBox17.Text.ToString(), textBox18.Text.ToString());
            }
        }



        public void getinforSave()
        {

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\saveexception.txt"; //1

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
                textBox9.Text = lines[8].ToString();
                textBox10.Text = lines[9].ToString();
                textBox11.Text = lines[10].ToString();
                textBox12.Text = lines[11].ToString();
                textBox13.Text = lines[12].ToString();
                textBox14.Text = lines[13].ToString();
                textBox15.Text = lines[14].ToString();
                textBox16.Text = lines[15].ToString();
                textBox17.Text = lines[16].ToString();
                textBox18.Text = lines[17].ToString();
            }
            else
            {
               
            }
        }

        public void saveinforOfProgram(string exb03, string exb04, string exb05, string exb06, string exbn3f1, string exbn3f2, string exbn3f3, string exc02, string exc03, string exb03line, string exb04line, string exb05line, string exb06line, string exbn3f1line, string exbn3f2line, string exbn3f3line, string exc02line, string exc03line)
        {

            string fileLPath = AppDomain.CurrentDomain.BaseDirectory + "\\saveexception.txt";
            string[] lines = new string[18];
            lines[0] = exb03;
            lines[1] = exb04;
            lines[2] = exb05;
            lines[3] = exb06;
            lines[4] = exbn3f1;
            lines[5] = exbn3f2;
            lines[6] = exbn3f3;
            lines[7] = exc02;
            lines[8] = exc03;
            lines[9] = exb03line;
            lines[10] = exb04line;
            lines[11] = exb05line;
            lines[12] = exb06line;
            lines[13] = exbn3f1line;
            lines[14] = exbn3f2line;
            lines[15] = exbn3f3line;
            lines[16] = exc02line;
            lines[17] = exc03line;

            System.IO.File.WriteAllLines(fileLPath, lines);
        }
    }
}
