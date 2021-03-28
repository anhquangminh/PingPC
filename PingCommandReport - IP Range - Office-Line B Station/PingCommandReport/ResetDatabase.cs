using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PingCommandReport
{
    public partial class ResetDatabase : Form
    {
        SqlConnection strConnect = new SqlConnection();
        public string strCn = "server=10.224.81.64;uid=userbh1;database=TestIp;password=tungdepzai13@#;";
        public ResetDatabase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "312")
            {
                DialogResult result = MessageBox.Show("Do you want to reset database ?", "Reset database !  ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    string sql_send = "DELETE FROM CheckingIP";

                    SqlConnection con = new SqlConnection(strCn);
                    SqlCommand cmd = new SqlCommand(sql_send, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Records Inserted Successfully");
                        MessageBox.Show("Delete Successfully !");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error Generated. Details: " + e.ToString());
                        MessageBox.Show("Delete not  Successfully ! ");
                    }
                    finally
                    {
                        con.Close();
                        //Console.ReadKey();
                    }
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Wrong Password ! Please try again !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
