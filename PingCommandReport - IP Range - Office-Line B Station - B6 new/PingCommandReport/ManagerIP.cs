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
    public partial class ManagerIP : Form
    {
        SqlConnection strConnect = new SqlConnection();
        public string strCn = "server=10.224.81.64;uid=userbh1;database=TestIp;password=tungdepzai13@#;";
        Main obj = (Main)Application.OpenForms["Main"];
        public ManagerIP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != ""  & textBox6.Text != "" & textBox7.Text != "")
            {

                int x = Int32.Parse(textBox6.Text);
                int y = Int32.Parse(textBox7.Text);
                if (x < y)
                {
                    int i = x;
                    bool checkok = false;
                    while (i <= y & i >= x)
                    {
                        Console.WriteLine(i);
                        string ip = textBox2.Text.ToString() +i.ToString();
                        
                        string sql_send = "Insert into CheckingIP";
                        sql_send += " (NameIP,IP,Email,Room_ID,Status)";
                        sql_send += " Values ('" + textBox1.Text + "', '" + ip + "', '" + textBox3.Text + "', '" + textBox4.Text + " ', 'Checking')";


                        SqlConnection con = new SqlConnection(strCn);
                        SqlCommand cmd = new SqlCommand(sql_send, con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Records Inserted Successfully");
                           // MessageBox.Show("Insert Successfully !" );
                            checkok = true;
                           
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Error Generated. Details: " + e.ToString());
                            MessageBox.Show("IP address already exists ");
                            checkok = false;
                        }
                        finally
                        {
                            con.Close();
                        }
                        i++;
                    }

                    if (checkok == true)
                    {
                        MessageBox.Show("Insert Successfully !");
                    }
                    else
                    {
                        MessageBox.Show("Insert Error !");
                    }
                }
                
            }
            else
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please input name of IP Adress !");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please input IP Adress !");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please input Email !");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Please input RoomID !");
            }
            else
            {
                string sql_send = "Insert into CheckingIP";
                sql_send += " (NameIP,IP,Email,Room_ID,Status)";
                sql_send += " Values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + " ', 'Checking')";


                SqlConnection con = new SqlConnection(strCn);
                SqlCommand cmd = new SqlCommand(sql_send, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Inserted Successfully");
                    MessageBox.Show("Insert Successfully !");
                  // obj.feeddata();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                    MessageBox.Show("IP address already exists ");
                }
                finally
                {
                    con.Close();
                    //Console.ReadKey();
                }
                // this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete this  Ip ?", "Delete Ip  ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {

                if (textBox2.Text != "" & textBox6.Text != "" & textBox7.Text != "")
                {

                    int x = Int32.Parse(textBox6.Text);
                    int y = Int32.Parse(textBox7.Text);
                    if (x < y)
                    {
                        int i = x;
                        bool checkok = false;
                        while (i <= y & i >= x)
                        {
                            Console.WriteLine(i);
                            string ip =textBox2.Text.ToString() +  i.ToString();
                            Console.WriteLine(ip);
                            string sql_send = "DELETE FROM CheckingIP where IP='" + ip + "'";
                            
                            SqlConnection con = new SqlConnection(strCn);
                            SqlCommand cmd = new SqlCommand(sql_send, con);
                            try
                            {
                                con.Open();
                                cmd.ExecuteNonQuery();
                                Console.WriteLine("Delete  Successfully");
                               
                                checkok = true;
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine("Error Generated. Details: " + e.ToString());
                                //MessageBox.Show("IP address already exists ");
                                checkok = false;
                            }
                            finally
                            {
                                con.Close();
                                //Console.ReadKey();
                            }
                            
                            i++;
                        }
                        if (checkok == true)
                        {
                            MessageBox.Show("Delete Successfully !");
                        }
                        else
                        {
                            MessageBox.Show("Delete Failed !");
                        }
                    }

                }
                else
                if (textBox2.Text != "")
                {
                    string sql_send = "DELETE FROM CheckingIP where IP='" + textBox2.Text.ToString() + "'";

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
                        MessageBox.Show("Error ! ");
                    }
                    finally
                    {
                        con.Close();
                        //Console.ReadKey();
                    }


                }
                else
                {
                    Console.WriteLine("can not run");
                    MessageBox.Show("Can not run . Please try again !");
                }
            }
            else
            {
            }
        }
    }
}
