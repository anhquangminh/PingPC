using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Data;
using System.Data.OracleClient;
using Microsoft.Win32;
using System.Net.Sockets;
using Ini;
using System.Diagnostics;

namespace PingCommandReport
{
    public partial class Main : Form
    {

        OracleConnection strCon = new OracleConnection();
        private WebRequest request;
        private Stream dataStream;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        SqlConnection strConnect = new SqlConnection();
        public int threadcout = 0;

        public string[] arrayNameSmo;
        public bool issend = true;
        public string[] arrayNameSmo2;
        public string listIpError = "";
        public string listIPPingOk = "";
        public string listmailsend = "";
        public string roomsendhalo = "";
        public string listfriendsendhalo = "";
        public string strCn = "server=10.224.81.131,3000;uid=sa;database=findip;password=foxconn168!!;";
        public string strCn2 = "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS =(PROTOCOL = TCP)(HOST = 10.224.81.41)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = VNCPEAP)));User Id=AP2;Password=NSDAP2LOGPD0522;";
        public string strdbisc = "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS =(PROTOCOL = TCP)(HOST =10.134.171.33)(PORT = 1527)))(CONNECT_DATA = (SERVICE_NAME = ISCODB)));User Id=PC;Password=iscpc169!!!!";
        public string listexception = "";
        public string b03ex = "";
        public string b04ex = "";
        public string b05ex = "";
        public string b06ex = "";
        public string bn3f1ex = "";
        public string bn3f2ex = "";
        public string bn3f3ex = "";
        public string c02ex = "";
        public string c03ex = "";
        public string b03exline = "";
        public string b04exline = "";
        public string b05exline = "";
        public string b06exline = "";
        public string bn3f1exline = "";
        public string bn3f2exline = "";
        public string bn3f3exline = "";
        public string c02exline = "";
        public string c03exline = "";
        public Main()
        {
            InitializeComponent();
            RegisterInStartup();
            RegistryKey start = Registry.LocalMachine;
            RegistryKey cardServiceName, networkKey;
            string networkcardKey = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards";
            string serviceKey = "SYSTEM\\CurrentControlSet\\Services\\";
            string networkcardKeyName, deviceName, deviceServiceName, serviceName;

            RegistryKey serviceNames = start.OpenSubKey(networkcardKey);
            if (serviceNames == null)
            {
                //Console.WriteLine("Bad registry key");
                return;
            }

            string[] networkCards = serviceNames.GetSubKeyNames();
            serviceNames.Close();

            foreach (string keyName in networkCards)
            {
                networkcardKeyName = networkcardKey + "\\" + keyName;
                cardServiceName = start.OpenSubKey(networkcardKeyName);
                if (cardServiceName == null)
                {
                    //Console.WriteLine("Bad registry key: {0}", networkcardKeyName);
                    return;
                }
                deviceServiceName = (string)cardServiceName.GetValue("ServiceName");
                deviceName = (string)cardServiceName.GetValue("Description");
                //Console.WriteLine("\nNetwork card: {0}", deviceName);
            }

            
            //run only process
            if (Process.GetProcessesByName("PingCommandReport").Length > 1)
            {
                int a = Process.GetProcessesByName("PingCommandReport").Length;
                var process = Process.GetProcessesByName("PingCommandReport");
                process[a].Kill();
            }
            //save log start and colse
            var aa = Process.GetCurrentProcess().StartTime;
            if (aa != null)
            {
                string filePath1 = AppDomain.CurrentDomain.BaseDirectory + "\\log-start-close.ini";
                IniFile ini = new IniFile(filePath1);
                ini.IniWriteValue("Log", "Start", aa.ToString());
            }
            //disable task manager
            //RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            //key.SetValue("DisableTaskMgr", 1);
            start.Close();
        }


        public static bool checktelnet(string ip)
        {
            TcpClient tc = null;
            try
            {
                tc = new TcpClient(ip, 135);
                // If we get here, port is open
                //Console.WriteLine("oke" + ip);
                return true;
            }
            catch (SocketException se)
            {
                // If we get here, port is not open, or host is not reachable
                //Console.WriteLine("not oke" + ip);
                return false;
            }
            finally
            {
                if (tc != null)
                {
                    tc.Close();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerIP p2 = new ManagerIP();
            p2.Show();
        }


        public void rundaily()
        {

            checkallipstation();
            //Console.WriteLine("check daily  ==============================================================!");
            issend = true;
            lineChanger("true", 13);
        }


        private void Main_Load(object sender, EventArgs e)
        { 
            getinforSave();
            getinforexception();
        }

        public void deletedata()
        {
            DialogResult result = MessageBox.Show("Do you want to reset database ?", "Reset database !  ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                // string sql_send = "DELETE FROM SMOALERT where SMO_NAME ='c'";
                //string sql_send = "DELETE FROM iprangeisc where datetime < '2020-04-08 23:55' ";
                string sql_send = "DELETE FROM iprangeisc where datetime > '2020-05-16 00:00' and datetime < '2020-05-16 23:00' ";
                SqlConnection con = new SqlConnection(strCn);
                SqlCommand cmd = new SqlCommand(sql_send, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //Console.WriteLine("SMOAMLERTDB Successfully");
                    MessageBox.Show("Delete Successfully !");
                }
                catch (SqlException ex)
                {
                    //Console.WriteLine("Error Generated. Details: " + ex.ToString());
                    MessageBox.Show("Delete not  Successfully ! ");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
            }
        }

        public void insertdatasql(string stationname, string ipaddress,string idcard,string name, string datetime, string station)
        {
            
            string sql_send = "Insert into iprangeisc";
            sql_send += " (stationname,ipaddress,idcard,name,datetime,station)";
            sql_send += " Values ('" + stationname + "', '" + ipaddress + "','" + idcard + "','" + name + "','" + datetime + "','" + station + "')";

            SqlConnection con = new SqlConnection(strCn);
            SqlCommand cmd = new SqlCommand(sql_send, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            
            
        }

        public void getdatafromtextfile()
        {

            string fileLPath = AppDomain.CurrentDomain.BaseDirectory + "\\listip.txt";

            if (File.Exists(fileLPath))
            {
                string text = System.IO.File.ReadAllText(fileLPath);

                var list = text.Split('\n');
                arrayNameSmo2 = list;
                //listIpGridView.DataSource = arrayNameSmo2;

                // int[] numbersArrary = list.Split('\r').Select(n => Convert.ToInt32(n)).ToArray();

                int n2 = list.Length;

            }
            else
            {

            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //lbllasttimecheck.Text = " Last time calculation : " + time;
        }

        static int sum(int[] arr, int n)
        {

            int sum = 0; // initialize sum 

            // Iterate through all elements and  
            // add them to sum 
            for (int i = 0; i < n; i++)
                sum += arr[i];

            return sum;
        }


        public void getinforexception()
        {
            string filePath2 = AppDomain.CurrentDomain.BaseDirectory + "\\save-ip-exception.ini"; //1

            if (System.IO.File.Exists(filePath2))
            {
                IniFile ini = new IniFile(filePath2);
                listexception = ini.IniReadValue("ip", "ipexception");

            }
        }

        public void getinforSave()
        {

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\edit-ip-range.ini"; //1
            IniFile ini = new IniFile(filePath);
            tbb03office.Text = ini.IniReadValue("b03", "office");
            tbb03line.Text = ini.IniReadValue("b03", "line");
            textBox11.Text = ini.IniReadValue("b03", "name");
            textBox10.Text = ini.IniReadValue("b03", "id");
            string[] lines;

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath);

                listmailsend = lines[0].ToString();
                if (listmailsend == "" || listmailsend == null)
                {
                    listmailsend = "kevin.dw.wu";
                }

                roomsendhalo = lines[2].ToString();
                if (roomsendhalo == "" || roomsendhalo == null)
                {
                    roomsendhalo = "";
                }

                listfriendsendhalo = lines[1].ToString();
                if (listfriendsendhalo == "" || listfriendsendhalo == null)
                {
                    listfriendsendhalo = "V0934062";
                }

                string check = ini.IniReadValue("send", "issend");
                if (check.ToString() == "true")
                {
                    issend = true;
                }
                else
                {
                    issend = false;
                }

            }
            else
            {
                listmailsend = "kevin.dw.wu";
                roomsendhalo = "Room_05583af309";
                listfriendsendhalo = "V0934062";
            }
        }


        static void lineChanger(string newText, int line_to_edit)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "edit-ip-range.ini"; //1
            IniFile ini = new IniFile(filePath);
            ini.IniWriteValue("send", "issend", newText);
            //string fileLPath = AppDomain.CurrentDomain.BaseDirectory + "\\edit-ip-range.txt";
            //string[] arrLine = File.ReadAllLines(fileLPath);
            //arrLine[line_to_edit - 1] = newText;
            //System.IO.File.WriteAllLines(fileLPath, arrLine);
        }

 
        private void Analysispinghostoffice(int aa, string[] arraylistping, string iprange, string station, string idcard, string name)
        {
            //Console.WriteLine("Start Analysis Ping ==============");
            if (arraylistping.Length > 0)
            {
                string listIpError = "";
                string listIPPingOk = "";
                for (int i = 0; i < arraylistping.Length; i++)
                {
                    if (PingHost(arraylistping[i].ToString()))
                    {
                        listIPPingOk = listIPPingOk + " , " + arraylistping[i].ToString();
                        //Console.WriteLine("Ping Ip OK !============== Thread " + aa);

                        string date2 = "2020/01/02 13:46:44";
                        string datetimenow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        if (checktelnet(arraylistping[i].ToString()) == true)
                        {
                           
                            ////Console.WriteLine("Insert to database office");
                            insertdatasql(station, arraylistping[i], idcard, name, datetimenow, "Office");

                        }
                        else
                        {
                            Console.WriteLine("IP : " + arraylistping[i].ToString() + " : Check ip is Ip Phone");

                        }

                    }
                    else
                    {
                        listIpError = listIpError + " , " + arraylistping[i].ToString();
                        ////Console.WriteLine("Ping IP Not OK !=============Thread " + aa);
                    }

                }
                //logerrorhistory(listIpError, listIPPingOk, iprange);
                //Console.WriteLine("Start log history !==============");
            }

        }

        private void RegisterInStartup()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("PingCommandReport", Application.ExecutablePath);
        }

        private void Analysispinghostline(int aa, string[] arraylistping, string iprange, string station, string idcard, string name)
        {
            
            ////Console.WriteLine("Start Analysis Ping ==============");
            if (arraylistping.Length > 0)
            {
                string listIpError = "";
                string listIPPingOk = "";
                for (int i = 0; i < arraylistping.Length; i++)
                {
                    if (PingHost(arraylistping[i].ToString()))
                    {
                        listIPPingOk = listIPPingOk + " , " + arraylistping[i].ToString();
                        //////Console.WriteLine("Ping Ip OK !============== Thread " + aa);
                        string date2 = "2020/01/02 13:46:44";
                        string datetimenow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                       

                        if (checktelnet(arraylistping[i].ToString()) == true)
                        {
                            ////Console.WriteLine("Insert to database office");
                            insertdatasql(station, arraylistping[i], idcard, name, datetimenow, "Line");

                        }
                        else
                        {
                            Console.WriteLine("IP : " + arraylistping[i].ToString() + " : Check ip is Ip Phone");

                        }
                    }
                    else
                    {
                        listIpError = listIpError + " , " + arraylistping[i].ToString();
                        ////Console.WriteLine("Ping IP Not OK !=============Thread " + aa);
                    }

                }
                //logerrorhistory(listIpError, listIPPingOk, iprange);
                ////Console.WriteLine("Start log history !==============");
            }
            

        }

        public void SendToHalo(string user, string ToUser, string ToGroup, String mesage, string confirm)
        {
            try
            {
                string url = "http://10.224.81.89/haloportal/api/haloauthen?senderid=" + user;
                request = WebRequest.Create(url);
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                string Status = ((HttpWebResponse)response).StatusDescription;
                // Get the stream containing all content returned by the requested server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content fully up to the end.
                string responseFromServer = reader.ReadToEnd();

                var data = (JObject)JsonConvert.DeserializeObject(responseFromServer);
                string ticket = data["data"]["ticket"].Value<string>();
                HaloAPIandQRcode.HaloApi halo = new HaloAPIandQRcode.HaloApi(true);
                //string ticket1 = halo.takeTicketString("appteam", "foxconn168!!");

                // string result = halo.sendtextCallback(ticket, ToUser, ToGroup, mesage, confirm, "Confirm");

                string result2 = halo.sendtextmessage(ticket, ToUser, ToGroup, mesage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            ManagerIP f2 = new ManagerIP();
            f2.Show();
        }

        public void sendmailhelp(string mail_to, string mail_cc, string mail_content)
        {
            OracleConnection conn99 = new OracleConnection(strCn2);
            conn99.Open();
            OracleCommand cmd99 = new OracleCommand();
            cmd99.Connection = conn99;

            string mail_id = DateTime.Now.ToString("yyyyMMddHHmmss");
            string sql_send = "Insert into MES4.R_MAIL_T";
            sql_send += " (MAIL_ID, MAIL_TO, MAIL_CC, MAIL_SUBJECT,MAIL_SEQUENCE, MAIL_CONTENT, MAIL_DATE, MAIL_FLAG, MAIL_PROGRAM)";
            sql_send += " Values ('" + mail_id + "', '" + mail_to + "', '" + mail_cc + "', 'SMO Report Error', '0', '" + mail_content + "',sysdate, '0', 'Alarm ESD')";

            cmd99.CommandText = sql_send;
            int rowsUpdated = cmd99.ExecuteNonQuery();
            conn99.Dispose();
        }

        private void pingUrl(String linklurl)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(linklurl, 1000);
                MessageBox.Show(reply.Status.ToString());
            }
            catch (Exception except)
            {
                MessageBox.Show("Error");
            }
        }

        //vuongnd new function
        public string[] getarraylistip(string iprange)
        {
            string[] listiprange;
            List<string> strings = new List<string>();

            int index = iprange.IndexOf('.', iprange.IndexOf('.') + 2);
            int chamindex = iprange.LastIndexOf(".");
            int truindex = iprange.IndexOf("-");


            string ipadress = iprange.Substring(0, chamindex);
            string xx = iprange.Substring(chamindex + 1, (truindex - chamindex) - 1);
            string yy = iprange.Substring(truindex + 1);

            int x = Int32.Parse(xx);
            int y = Int32.Parse(yy);
            if (x < y)
            {
               
                int i = x;
                while (i <= y & i >= x)
                {
                    string textinput = ipadress + "." + i.ToString();
                    strings.Add(textinput);
                    i++;
                }
            }
            ////Console.WriteLine(strings);

            listiprange = strings.ToArray();
               
            return listiprange;
        }

        public string[] getlistiprangefromdb(string iprange)
        {
            string[] listiprange;
            listiprange = new string[] { };
            var myList = new List<string>();


            int index = iprange.IndexOf('.', iprange.IndexOf('.') + 2);
            int chamindex = iprange.LastIndexOf(".");
            int truindex = iprange.IndexOf("-");


            string ipadress2 = iprange.Substring(0, chamindex) + "%";
            string ipadress = ipadress2.Replace('.','-');
            using (OracleConnection con = new OracleConnection(strdbisc))
            {
                try
                {
                    con.Open();

                   // select DISTINCT username from  MES1.C_PC_CONTROL_T WHERE username like '%10-224-132-58%'

                    //string sql = "SELECT IPADDRESS FROM MES1.SYSTEM_INFORMATION WHERE IPADDRESS LIKE'" + ipadress + "'";

                    string sql = "select DISTINCT username from  MES1.C_PC_CONTROL_T WHERE username like'" + ipadress + "'";

                    OracleCommand cmd = new OracleCommand(sql, con);

                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var ip = dr[0].ToString().Replace('-', '.');
                            myList.Add(ip);
                        }
                    }
                    Console.WriteLine(myList);
                    // close and dispose the objects
                    dr.Close();
                    dr.Dispose();
                    cmd.Dispose();
                    con.Close();
                    con.Dispose();

                }
                catch (OracleException ex) // catches only Oracle errors
                {
                    MessageBox.Show("The database is unavailable.");
                }
            }

            listiprange = myList.ToArray();

            return listiprange;
        }


        public static bool PingHost(string ip)
        {
            bool pingable = false;
            Ping pinger = null;
            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(ip);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                //null
            }
            finally
            {
                if (pinger != null) pinger.Dispose();
            }
            return pingable;
        }

        public void logerrorhistory(string error, string listpingok, string iprange)
        {
            using (StreamWriter w = File.AppendText("logfile.txt"))
            {

                string datetime = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss");

                w.WriteLine( "List Ip Range " + iprange + "=======================================================================================================");
                w.WriteLine("=");
                w.WriteLine(datetime + " : " + "The list of ping addresses no connection: " + error);
                w.WriteLine("=");
                w.WriteLine(datetime + " : " + "List of connected ping addresses : " + listpingok);
                w.WriteLine("=");
                w.WriteLine("=======================================================================================================");
            }
        }


        public void logerrorhistory2(string ip)
        {
            using (StreamWriter w = File.AppendText("logfile.txt"))
            {

                string datetime = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss");
                w.WriteLine(datetime + " : " + "ip phone: " + ip);
                w.WriteLine("=");
                w.WriteLine("\n");
            }
        }

        public void loghistory(string error)
        {
            using (StreamWriter w = File.AppendText("logfile.txt"))
            {

                string datetime = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss");

                w.WriteLine("=======================================================================================================");
                w.WriteLine("=");
                w.WriteLine(datetime + " : " + "The Unresponsive connections : " + error);
                w.WriteLine("=");
                w.WriteLine("=======================================================================================================");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void changeInforSendAlertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeInforSendAlert p2 = new ChangeInforSendAlert();
            p2.ShowDialog();
        }

        private void addMoreAddressPingCmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerIP p2 = new ManagerIP();
            p2.ShowDialog();
        }

        private void resetDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetDatabase p2 = new ResetDatabase();
            p2.ShowDialog();
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contacts p2 = new Contacts();
            p2.ShowDialog();
        }

        private void aboutUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About p2 = new About();
            p2.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void restartProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

            String path2 = System.IO.Directory.GetCurrentDirectory() + @"\PingCommandReport.exe";
            System.Diagnostics.Process.Start(path2);
        }

        private void onAutomaticOpenAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Do you want to change infor ?", "Change Infor Automatic Open App  ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                saveisautomaticopen("yes");
            }
            else
            {
            }
        }

        private void offAutomaticOpenAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to change infor  ?", "Change Infor Automatic Open App  ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                saveisautomaticopen("no");
               
            }
            else
            {
            }
        }


        public void saveisautomaticopen(string isopen)
        {

            string filePath = System.IO.Directory.GetCurrentDirectory() + "\\edit-ip-range.txt"; //1

            string[] lines = new string[9];

            if (System.IO.File.Exists(filePath))
            {
                lines[9] = isopen;
                System.IO.File.WriteAllLines(filePath, lines);
            }
            else
            {
            }
        }

        private void timersenddaily_Tick(object sender, EventArgs e)
        {
            
            ////Console.WriteLine("check send infor daily  !!!!!!!");
            //Time when method needs to be called
            var DailyTime = "01:30:00";
            var timeParts = DailyTime.Split(new char[1] { ':' });

            var dateNow = DateTime.Now;
            var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
                       int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
            ////Console.WriteLine("Time now is:" + dateNow.ToString());
            if (dateNow > date)
            {
                ////Console.WriteLine("====================== dateNow > date ============");
                ////Console.WriteLine("issend is :" + issend.ToString());
                label47.Text = "Check Scanner at : " + dateNow.ToString();
                if (issend == false)
                {
                    rundaily();
                    label46.Text = "Scanner at : " + dateNow.ToString();
                }
            }
            else
            {
                
                issend = false;
                ////Console.WriteLine("issend is :" + issend.ToString());
                lineChanger("false", 13);
                ////Console.WriteLine("dont't send ");
                label47.Text = "Check Scanner at : " + dateNow.ToString();
            }
            
        }

  

        public void checkallipstation()
        {
            //B03
            if (tbb03office.Text.ToString() != "")
            {
                var strarray = tbb03office.Text.ToString().Split(',');
                if (strarray.Length > 0)
                {
                    for (int i = 0; i < strarray.Length-1; i++)
                    {
                        if (strarray[i] != "")
                        {
                             var listipisc = getlistiprangefromdb(strarray[i]);
                            //var listipisc = new string[] { "aaaa","dfdfdfd" };


                            var listipproduct = getarraylistip(strarray[i]);
                            var listipnotfound = listipproduct.Except(listipisc).ToArray();
                            string[] listapscanner = new string[] { "" };
                            if (listexception != "")
                            {
                                string[] listex = new string[] { "" };
                                listex = listexception.Split(',');
                                listapscanner = listipnotfound.Except(listex).ToArray();
                            }
                            else
                            {
                                listapscanner = listipnotfound.ToArray();
                            }
                            threadcout = threadcout + 1;
                            Thread Thd_Analysis = new Thread(() => Analysispinghostoffice(threadcout, listapscanner, strarray[i], "B03", textBox10.Text.ToString(), textBox11.Text.ToString()));
                            Thd_Analysis.Start();
                        }
         
                    }
                }
            }

            if (tbb03line.Text.ToString() != "")
            {
                var strarray = tbb03line.Text.ToString().Split(',');
                if (strarray.Length > 0)
                {
                    for (int i = 0; i < strarray.Length - 1; i++)
                    {
                        if (strarray[i] != "")
                        {
                            var listipisc = getlistiprangefromdb(strarray[i]);
                            var listipproduct = getarraylistip(strarray[i]);
                            var listipnotfound = listipproduct.Except(listipisc).ToArray();

                            string[] listapscanner = new string[] { "" };
                            if (listexception != "")
                            {
                                string[] listex = new string[] { "" };
                                listex = listexception.Split(',');
                                listapscanner = listipnotfound.Except(listex).ToArray();

                            }
                            else
                            {
                                listapscanner = listipnotfound.ToArray();
                            }

                            threadcout = threadcout + 1;
                            Thread Thd_Analysis = new Thread(() => Analysispinghostline(threadcout, listapscanner, strarray[i ], "B03", textBox10.Text.ToString(), textBox11.Text.ToString()));
                            Thd_Analysis.Start();
                        }

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fileLPath = AppDomain.CurrentDomain.BaseDirectory + "\\logfile.txt";

            if (File.Exists(fileLPath))
            {
                System.Diagnostics.Process.Start(fileLPath);

            }
            else
            {
                MessageBox.Show("Log File not Exits");
            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            string sql_send = "Insert into save2";
            sql_send += " (field1,field2)";
            sql_send += " Values (' aaaa', ' bbbb')";

            SqlConnection con = new SqlConnection(strCn);
            SqlCommand cmd = new SqlCommand(sql_send, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                ////Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException ex)
            {
                ////Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void setExceptionIpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1 p2 = new Form1();
            //p2.ShowDialog();

            ExceptionIp p2 = new ExceptionIp();
            p2.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            deletedata();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            checkallipstation();
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBox1.Text == "1111")
            {
                //RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                //key.SetValue("DisableTaskMgr", 0);
                DateTime now = DateTime.Now;
                string filePath1 = AppDomain.CurrentDomain.BaseDirectory + "\\log-start-close.ini";
                IniFile ini = new IniFile(filePath1);
                ini.IniWriteValue("Log", "End", now.ToString());
                e.Cancel = false;

            }
            else
            {
                DialogResult res = MessageBox.Show("You do not have permission to turn off the program", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
