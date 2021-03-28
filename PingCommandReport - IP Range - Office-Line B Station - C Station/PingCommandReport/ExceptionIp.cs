using Ini;
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
    public partial class ExceptionIp : Form
    {
        public ExceptionIp()
        {
            InitializeComponent();
            getinforSave();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to change list ip exception this  Ip ?", "Change list ip ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                saveinforOfProgram(richTextBox1.Text);
                this.Close();
            }
        }


        public void getinforSave()
        {

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\save-ip-exception.ini"; //1

            if (System.IO.File.Exists(filePath))
            {
                IniFile ini = new IniFile(filePath);
                richTextBox1.Text = ini.IniReadValue("ip", "ipexception");
            }
            else
            {

            }
        }

        public void saveinforOfProgram(string richtext)
        {

            string fileLPath = AppDomain.CurrentDomain.BaseDirectory + "\\save-ip-exception.ini";
            IniFile ini = new IniFile(fileLPath);
            ini.IniWriteValue("ip", "ipexception", richtext);
           
        }
    }
}
