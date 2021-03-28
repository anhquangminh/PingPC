using System.Diagnostics;
using System.Windows.Forms;

namespace PingCommandReport
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);


            string filePath = System.IO.Directory.GetCurrentDirectory() + "\\saveinfor2.txt"; //1

            string[] lines;

            if (System.IO.File.Exists(filePath))
            {
                lines = System.IO.File.ReadAllLines(filePath);

                string checkautoopen = lines[0].ToString();
                if (checkautoopen == "yes")
                {
                    string path = System.IO.Directory.GetCurrentDirectory() + @"\PingCommandReport.exe";
                    Process.Start(path);
                }
                else
                {
                    foreach (var items in Process.GetProcessesByName("PingCommandReport"))
                    {
                        items.Kill();
                       // break;
                    }
                }

            }
            else
            {
                              
            }         

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setExceptionIpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timersenddaily = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tbc03uiline = new System.Windows.Forms.TextBox();
            this.tbbn3f3line = new System.Windows.Forms.TextBox();
            this.tbbn3f2line = new System.Windows.Forms.TextBox();
            this.tbc02line = new System.Windows.Forms.TextBox();
            this.tbbn3f1line = new System.Windows.Forms.TextBox();
            this.tbb06line = new System.Windows.Forms.TextBox();
            this.tbb05line = new System.Windows.Forms.TextBox();
            this.tbb04line = new System.Windows.Forms.TextBox();
            this.tbb03line = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tbc03uioffice = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbbn3f3office = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbbn3f2office = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbb03office = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbc02office = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbbn3f1office = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbb06office = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbb05office = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbb04office = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.setUpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartProgramToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // restartProgramToolStripMenuItem
            // 
            this.restartProgramToolStripMenuItem.Name = "restartProgramToolStripMenuItem";
            this.restartProgramToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.restartProgramToolStripMenuItem.Text = "Restart Program";
            this.restartProgramToolStripMenuItem.Click += new System.EventHandler(this.restartProgramToolStripMenuItem_Click);
            // 
            // setUpToolStripMenuItem
            // 
            this.setUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setExceptionIpToolStripMenuItem});
            this.setUpToolStripMenuItem.Name = "setUpToolStripMenuItem";
            this.setUpToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.setUpToolStripMenuItem.Text = "SetUp";
            // 
            // setExceptionIpToolStripMenuItem
            // 
            this.setExceptionIpToolStripMenuItem.Name = "setExceptionIpToolStripMenuItem";
            this.setExceptionIpToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.setExceptionIpToolStripMenuItem.Text = "Set Exception Ip";
            this.setExceptionIpToolStripMenuItem.Click += new System.EventHandler(this.setExceptionIpToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 15000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 600000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timersenddaily
            // 
            this.timersenddaily.Enabled = true;
            this.timersenddaily.Interval = 30000;
            this.timersenddaily.Tick += new System.EventHandler(this.timersenddaily_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.tbc03uiline);
            this.groupBox1.Controls.Add(this.tbbn3f3line);
            this.groupBox1.Controls.Add(this.tbbn3f2line);
            this.groupBox1.Controls.Add(this.tbc02line);
            this.groupBox1.Controls.Add(this.tbbn3f1line);
            this.groupBox1.Controls.Add(this.tbb06line);
            this.groupBox1.Controls.Add(this.tbb05line);
            this.groupBox1.Controls.Add(this.tbb04line);
            this.groupBox1.Controls.Add(this.tbb03line);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox27);
            this.groupBox1.Controls.Add(this.textBox26);
            this.groupBox1.Controls.Add(this.textBox25);
            this.groupBox1.Controls.Add(this.textBox24);
            this.groupBox1.Controls.Add(this.textBox23);
            this.groupBox1.Controls.Add(this.textBox22);
            this.groupBox1.Controls.Add(this.textBox21);
            this.groupBox1.Controls.Add(this.textBox20);
            this.groupBox1.Controls.Add(this.textBox19);
            this.groupBox1.Controls.Add(this.textBox18);
            this.groupBox1.Controls.Add(this.textBox17);
            this.groupBox1.Controls.Add(this.textBox16);
            this.groupBox1.Controls.Add(this.textBox15);
            this.groupBox1.Controls.Add(this.textBox14);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.tbc03uioffice);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tbbn3f3office);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.tbbn3f2office);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbb03office);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbc02office);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbbn3f1office);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbb06office);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbb05office);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbb04office);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(892, 136);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ip Range";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(141, 1346);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(27, 13);
            this.label44.TabIndex = 100;
            this.label44.Text = "Line";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(141, 1327);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(35, 13);
            this.label45.TabIndex = 99;
            this.label45.Text = "Office";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(140, 1184);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(27, 13);
            this.label42.TabIndex = 98;
            this.label42.Text = "Line";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(140, 1165);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(35, 13);
            this.label43.TabIndex = 97;
            this.label43.Text = "Office";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(142, 1112);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(27, 13);
            this.label40.TabIndex = 96;
            this.label40.Text = "Line";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(142, 1093);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(35, 13);
            this.label41.TabIndex = 95;
            this.label41.Text = "Office";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(142, 1272);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(27, 13);
            this.label38.TabIndex = 94;
            this.label38.Text = "Line";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(142, 1253);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(35, 13);
            this.label39.TabIndex = 93;
            this.label39.Text = "Office";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(141, 1033);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(27, 13);
            this.label36.TabIndex = 92;
            this.label36.Text = "Line";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(141, 1014);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(35, 13);
            this.label37.TabIndex = 91;
            this.label37.Text = "Office";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(141, 950);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(27, 13);
            this.label34.TabIndex = 90;
            this.label34.Text = "Line";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(141, 931);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(35, 13);
            this.label35.TabIndex = 89;
            this.label35.Text = "Office";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(141, 867);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(27, 13);
            this.label32.TabIndex = 88;
            this.label32.Text = "Line";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(141, 848);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 13);
            this.label33.TabIndex = 87;
            this.label33.Text = "Office";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(141, 789);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(27, 13);
            this.label30.TabIndex = 86;
            this.label30.Text = "Line";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(141, 770);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 13);
            this.label31.TabIndex = 85;
            this.label31.Text = "Office";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(101, 58);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 13);
            this.label29.TabIndex = 84;
            this.label29.Text = "Line";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(101, 39);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 13);
            this.label28.TabIndex = 83;
            this.label28.Text = "Office";
            // 
            // tbc03uiline
            // 
            this.tbc03uiline.Location = new System.Drawing.Point(182, 1349);
            this.tbc03uiline.Name = "tbc03uiline";
            this.tbc03uiline.Size = new System.Drawing.Size(727, 20);
            this.tbc03uiline.TabIndex = 82;
            // 
            // tbbn3f3line
            // 
            this.tbbn3f3line.Location = new System.Drawing.Point(181, 1183);
            this.tbbn3f3line.Name = "tbbn3f3line";
            this.tbbn3f3line.Size = new System.Drawing.Size(727, 20);
            this.tbbn3f3line.TabIndex = 81;
            // 
            // tbbn3f2line
            // 
            this.tbbn3f2line.Location = new System.Drawing.Point(182, 1111);
            this.tbbn3f2line.Name = "tbbn3f2line";
            this.tbbn3f2line.Size = new System.Drawing.Size(727, 20);
            this.tbbn3f2line.TabIndex = 80;
            // 
            // tbc02line
            // 
            this.tbc02line.Location = new System.Drawing.Point(183, 1272);
            this.tbc02line.Name = "tbc02line";
            this.tbc02line.Size = new System.Drawing.Size(727, 20);
            this.tbc02line.TabIndex = 79;
            // 
            // tbbn3f1line
            // 
            this.tbbn3f1line.Location = new System.Drawing.Point(182, 1033);
            this.tbbn3f1line.Name = "tbbn3f1line";
            this.tbbn3f1line.Size = new System.Drawing.Size(727, 20);
            this.tbbn3f1line.TabIndex = 78;
            // 
            // tbb06line
            // 
            this.tbb06line.Location = new System.Drawing.Point(182, 950);
            this.tbb06line.Name = "tbb06line";
            this.tbb06line.Size = new System.Drawing.Size(727, 20);
            this.tbb06line.TabIndex = 77;
            // 
            // tbb05line
            // 
            this.tbb05line.Location = new System.Drawing.Point(182, 866);
            this.tbb05line.Name = "tbb05line";
            this.tbb05line.Size = new System.Drawing.Size(727, 20);
            this.tbb05line.TabIndex = 76;
            // 
            // tbb04line
            // 
            this.tbb04line.Location = new System.Drawing.Point(182, 791);
            this.tbb04line.Name = "tbb04line";
            this.tbb04line.Size = new System.Drawing.Size(727, 20);
            this.tbb04line.TabIndex = 75;
            // 
            // tbb03line
            // 
            this.tbb03line.Location = new System.Drawing.Point(141, 57);
            this.tbb03line.Name = "tbb03line";
            this.tbb03line.ReadOnly = true;
            this.tbb03line.Size = new System.Drawing.Size(727, 20);
            this.tbb03line.TabIndex = 74;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(614, 1372);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(41, 13);
            this.label27.TabIndex = 73;
            this.label27.Text = "Name :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(612, 1206);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 13);
            this.label26.TabIndex = 72;
            this.label26.Text = "Name :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(614, 1132);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 71;
            this.label25.Text = "Name :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(615, 1297);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 70;
            this.label24.Text = "Name :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(615, 1056);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 13);
            this.label23.TabIndex = 69;
            this.label23.Text = "Name :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(615, 975);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 68;
            this.label22.Text = "Name :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(615, 889);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 67;
            this.label21.Text = "Name :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(615, 812);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 66;
            this.label20.Text = "Name :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(184, 1372);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 65;
            this.label19.Text = "ID Card :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(183, 1208);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 64;
            this.label17.Text = "ID Card :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(184, 1134);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 63;
            this.label15.Text = "ID Card :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(185, 1296);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "ID Card :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(184, 1056);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "ID Card :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(186, 976);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "ID Card :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(182, 893);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "ID Card :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 815);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "ID Card :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(575, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Name :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "ID Card :";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(661, 1370);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(248, 20);
            this.textBox27.TabIndex = 55;
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(239, 1370);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(199, 20);
            this.textBox26.TabIndex = 54;
            this.textBox26.Text = "V0971958";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(660, 1204);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(248, 20);
            this.textBox25.TabIndex = 53;
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(237, 1204);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(199, 20);
            this.textBox24.TabIndex = 52;
            this.textBox24.Text = "V0959573";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(661, 1132);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(248, 20);
            this.textBox23.TabIndex = 51;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(239, 1131);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(199, 20);
            this.textBox22.TabIndex = 50;
            this.textBox22.Text = "V0959107";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(662, 1294);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(248, 20);
            this.textBox21.TabIndex = 49;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(240, 1293);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(199, 20);
            this.textBox20.TabIndex = 48;
            this.textBox20.Text = "V0950290";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(662, 1054);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(247, 20);
            this.textBox19.TabIndex = 47;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(240, 1054);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(199, 20);
            this.textBox18.TabIndex = 46;
            this.textBox18.Text = "V0958191";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(662, 972);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(247, 20);
            this.textBox17.TabIndex = 45;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(240, 972);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(199, 20);
            this.textBox16.TabIndex = 44;
            this.textBox16.Text = "V0977064";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(662, 887);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(247, 20);
            this.textBox15.TabIndex = 43;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(240, 889);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(199, 20);
            this.textBox14.TabIndex = 42;
            this.textBox14.Text = "V0960852";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(662, 812);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(247, 20);
            this.textBox13.TabIndex = 41;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(240, 812);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(199, 20);
            this.textBox12.TabIndex = 40;
            this.textBox12.Text = "V0956424";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(622, 79);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(247, 20);
            this.textBox11.TabIndex = 39;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(195, 80);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(199, 20);
            this.textBox10.TabIndex = 38;
            // 
            // tbc03uioffice
            // 
            this.tbc03uioffice.Location = new System.Drawing.Point(182, 1327);
            this.tbc03uioffice.Name = "tbc03uioffice";
            this.tbc03uioffice.Size = new System.Drawing.Size(727, 20);
            this.tbc03uioffice.TabIndex = 35;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(44, 1340);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 20);
            this.label18.TabIndex = 34;
            this.label18.Text = "C03";
            // 
            // tbbn3f3office
            // 
            this.tbbn3f3office.Location = new System.Drawing.Point(181, 1162);
            this.tbbn3f3office.Name = "tbbn3f3office";
            this.tbbn3f3office.Size = new System.Drawing.Size(727, 20);
            this.tbbn3f3office.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(43, 1176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 20);
            this.label16.TabIndex = 30;
            this.label16.Text = "BN3 - 3F";
            // 
            // tbbn3f2office
            // 
            this.tbbn3f2office.Location = new System.Drawing.Point(182, 1090);
            this.tbbn3f2office.Name = "tbbn3f2office";
            this.tbbn3f2office.Size = new System.Drawing.Size(727, 20);
            this.tbbn3f2office.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(43, 1103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "BN3 - 2F";
            // 
            // tbb03office
            // 
            this.tbb03office.Location = new System.Drawing.Point(141, 36);
            this.tbb03office.Name = "tbb03office";
            this.tbb03office.ReadOnly = true;
            this.tbb03office.Size = new System.Drawing.Size(727, 20);
            this.tbb03office.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(6, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "B03";
            // 
            // tbc02office
            // 
            this.tbc02office.Location = new System.Drawing.Point(182, 1250);
            this.tbc02office.Name = "tbc02office";
            this.tbc02office.Size = new System.Drawing.Size(727, 20);
            this.tbc02office.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(43, 1270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "C02";
            // 
            // tbbn3f1office
            // 
            this.tbbn3f1office.Location = new System.Drawing.Point(182, 1011);
            this.tbbn3f1office.Name = "tbbn3f1office";
            this.tbbn3f1office.Size = new System.Drawing.Size(727, 20);
            this.tbbn3f1office.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(42, 1024);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "BN3 -1F";
            // 
            // tbb06office
            // 
            this.tbb06office.Location = new System.Drawing.Point(182, 928);
            this.tbb06office.Name = "tbb06office";
            this.tbb06office.Size = new System.Drawing.Size(727, 20);
            this.tbb06office.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(42, 941);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "B06";
            // 
            // tbb05office
            // 
            this.tbb05office.Location = new System.Drawing.Point(182, 845);
            this.tbb05office.Name = "tbb05office";
            this.tbb05office.Size = new System.Drawing.Size(727, 20);
            this.tbb05office.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(44, 853);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "B05";
            // 
            // tbb04office
            // 
            this.tbb04office.Location = new System.Drawing.Point(182, 770);
            this.tbb04office.Name = "tbb04office";
            this.tbb04office.Size = new System.Drawing.Size(727, 20);
            this.tbb04office.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(42, 781);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "B04";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(287, 11);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(0, 13);
            this.label46.TabIndex = 12;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(542, 9);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(0, 13);
            this.label47.TabIndex = 13;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(413, 9);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(9, 13);
            this.label48.TabIndex = 14;
            this.label48.Text = "|";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(818, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 15;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 170);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Find IP B03";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartProgramToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private Timer timersenddaily;
        private GroupBox groupBox1;
        private TextBox tbc02office;
        private Label label5;
        private TextBox tbbn3f1office;
        private Label label4;
        private TextBox tbb06office;
        private Label label3;
        private TextBox tbb05office;
        private Label label2;
        private TextBox tbb04office;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox tbc03uioffice;
        private Label label18;
        private TextBox tbbn3f3office;
        private Label label16;
        private TextBox tbbn3f2office;
        private Label label14;
        private TextBox tbb03office;
        private Label label12;
        private Label label27;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label17;
        private Label label15;
        private Label label13;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox textBox27;
        private TextBox textBox26;
        private TextBox textBox25;
        private TextBox textBox24;
        private TextBox textBox23;
        private TextBox textBox22;
        private TextBox textBox21;
        private TextBox textBox20;
        private TextBox textBox19;
        private TextBox textBox18;
        private TextBox textBox17;
        private TextBox textBox16;
        private TextBox textBox15;
        private TextBox textBox14;
        private TextBox textBox13;
        private TextBox textBox12;
        private TextBox textBox11;
        private TextBox textBox10;
        private TextBox tbc03uiline;
        private TextBox tbbn3f3line;
        private TextBox tbbn3f2line;
        private TextBox tbc02line;
        private TextBox tbbn3f1line;
        private TextBox tbb06line;
        private TextBox tbb05line;
        private TextBox tbb04line;
        private TextBox tbb03line;
        private Label label44;
        private Label label45;
        private Label label42;
        private Label label43;
        private Label label40;
        private Label label41;
        private Label label38;
        private Label label39;
        private Label label36;
        private Label label37;
        private Label label34;
        private Label label35;
        private Label label32;
        private Label label33;
        private Label label30;
        private Label label31;
        private Label label29;
        private Label label28;
        private Label label46;
        private Label label47;
        private Label label48;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem setExceptionIpToolStripMenuItem;
        private TextBox textBox1;
    }
}