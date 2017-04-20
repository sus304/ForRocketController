namespace ForRocket_FrontEnd
{
  partial class Simulation
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
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulation));
      this.button_AeroDesign = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.text_Pa = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.text_Hw = new System.Windows.Forms.TextBox();
      this.text_g0 = new System.Windows.Forms.TextBox();
      this.text_rho = new System.Windows.Forms.TextBox();
      this.text_Ta = new System.Windows.Forms.TextBox();
      this.text_LL = new System.Windows.Forms.TextBox();
      this.text_azimuth = new System.Windows.Forms.TextBox();
      this.text_elevation = new System.Windows.Forms.TextBox();
      this.text_Hsepa = new System.Windows.Forms.TextBox();
      this.text_Wh = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.button_Simulation = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.check_taiki_land = new System.Windows.Forms.RadioButton();
      this.check_noshiro_land = new System.Windows.Forms.RadioButton();
      this.check_noshiro_sea = new System.Windows.Forms.RadioButton();
      this.check_v4 = new System.Windows.Forms.RadioButton();
      this.check_new = new System.Windows.Forms.RadioButton();
      this.textBox_Engine = new System.Windows.Forms.TextBox();
      this.textBox_sturucture = new System.Windows.Forms.TextBox();
      this.button_engine_file = new System.Windows.Forms.Button();
      this.button_structure_file = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.openFileDialog_structure = new System.Windows.Forms.OpenFileDialog();
      this.openFileDialog_Engine = new System.Windows.Forms.OpenFileDialog();
      this.button_LandingRange = new System.Windows.Forms.Button();
      this.textBox_Aero = new System.Windows.Forms.TextBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.check_log = new System.Windows.Forms.RadioButton();
      this.check_table = new System.Windows.Forms.RadioButton();
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.textBox_anglew_min = new System.Windows.Forms.TextBox();
      this.textBox_anglew_max = new System.Windows.Forms.TextBox();
      this.textBox_anglew_delta = new System.Windows.Forms.TextBox();
      this.textBox_Vw_min = new System.Windows.Forms.TextBox();
      this.textBox_Vw_max = new System.Windows.Forms.TextBox();
      this.textBox_Vw_delta = new System.Windows.Forms.TextBox();
      this.label19 = new System.Windows.Forms.Label();
      this.LogoPic = new System.Windows.Forms.PictureBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LogoPic)).BeginInit();
      this.SuspendLayout();
      // 
      // button_AeroDesign
      // 
      this.button_AeroDesign.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.button_AeroDesign.Location = new System.Drawing.Point(12, 187);
      this.button_AeroDesign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_AeroDesign.Name = "button_AeroDesign";
      this.button_AeroDesign.Size = new System.Drawing.Size(87, 34);
      this.button_AeroDesign.TabIndex = 0;
      this.button_AeroDesign.TabStop = false;
      this.button_AeroDesign.Text = "Aero Design";
      this.button_AeroDesign.UseVisualStyleBackColor = true;
      this.button_AeroDesign.Click += new System.EventHandler(this.Button_Aero_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(426, 80);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(168, 18);
      this.label1.TabIndex = 1;
      this.label1.Text = "Atmosphere Pressure [kPa]";
      // 
      // text_Pa
      // 
      this.text_Pa.Location = new System.Drawing.Point(596, 77);
      this.text_Pa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_Pa.Name = "text_Pa";
      this.text_Pa.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_Pa.Size = new System.Drawing.Size(80, 25);
      this.text_Pa.TabIndex = 0;
      this.text_Pa.Text = "0.0";
      this.text_Pa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.text_Pa.Leave += new System.EventHandler(this.text_Pa_Leave);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(392, 117);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(202, 18);
      this.label2.TabIndex = 4;
      this.label2.Text = "Atmosphere Temperature [degC]";
      // 
      // text_Hw
      // 
      this.text_Hw.Location = new System.Drawing.Point(596, 227);
      this.text_Hw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_Hw.Name = "text_Hw";
      this.text_Hw.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_Hw.Size = new System.Drawing.Size(80, 25);
      this.text_Hw.TabIndex = 3;
      this.text_Hw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // text_g0
      // 
      this.text_g0.Location = new System.Drawing.Point(596, 190);
      this.text_g0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_g0.Name = "text_g0";
      this.text_g0.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_g0.Size = new System.Drawing.Size(80, 25);
      this.text_g0.TabIndex = 2;
      this.text_g0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // text_rho
      // 
      this.text_rho.Location = new System.Drawing.Point(596, 152);
      this.text_rho.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_rho.Name = "text_rho";
      this.text_rho.ReadOnly = true;
      this.text_rho.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_rho.Size = new System.Drawing.Size(80, 25);
      this.text_rho.TabIndex = 2;
      this.text_rho.TabStop = false;
      this.text_rho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // text_Ta
      // 
      this.text_Ta.Location = new System.Drawing.Point(596, 114);
      this.text_Ta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_Ta.Name = "text_Ta";
      this.text_Ta.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_Ta.Size = new System.Drawing.Size(80, 25);
      this.text_Ta.TabIndex = 1;
      this.text_Ta.Text = "0.0";
      this.text_Ta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.text_Ta.Leave += new System.EventHandler(this.text_Ta_Leave);
      // 
      // text_LL
      // 
      this.text_LL.Location = new System.Drawing.Point(596, 414);
      this.text_LL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_LL.Name = "text_LL";
      this.text_LL.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_LL.Size = new System.Drawing.Size(80, 25);
      this.text_LL.TabIndex = 8;
      this.text_LL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // text_azimuth
      // 
      this.text_azimuth.Location = new System.Drawing.Point(596, 377);
      this.text_azimuth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_azimuth.Name = "text_azimuth";
      this.text_azimuth.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_azimuth.Size = new System.Drawing.Size(80, 25);
      this.text_azimuth.TabIndex = 7;
      this.text_azimuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // text_elevation
      // 
      this.text_elevation.Location = new System.Drawing.Point(596, 340);
      this.text_elevation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_elevation.Name = "text_elevation";
      this.text_elevation.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_elevation.Size = new System.Drawing.Size(80, 25);
      this.text_elevation.TabIndex = 6;
      this.text_elevation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // text_Hsepa
      // 
      this.text_Hsepa.Location = new System.Drawing.Point(596, 302);
      this.text_Hsepa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_Hsepa.Name = "text_Hsepa";
      this.text_Hsepa.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_Hsepa.Size = new System.Drawing.Size(80, 25);
      this.text_Hsepa.TabIndex = 5;
      this.text_Hsepa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // text_Wh
      // 
      this.text_Wh.Location = new System.Drawing.Point(596, 264);
      this.text_Wh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.text_Wh.Name = "text_Wh";
      this.text_Wh.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.text_Wh.Size = new System.Drawing.Size(80, 25);
      this.text_Wh.TabIndex = 4;
      this.text_Wh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(404, 156);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(190, 18);
      this.label3.TabIndex = 14;
      this.label3.Text = "Atmosphere Density [kg/m^3]";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(413, 192);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(181, 18);
      this.label4.TabIndex = 15;
      this.label4.Text = "Gravity Acceleration [m/s^2]";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(438, 417);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(156, 18);
      this.label5.TabIndex = 16;
      this.label5.Text = "Launcher Rail Length [m]";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(503, 380);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(91, 18);
      this.label6.TabIndex = 17;
      this.label6.Text = "Azimuth [deg]";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(498, 343);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(96, 18);
      this.label7.TabIndex = 18;
      this.label7.Text = "Elevation [deg]";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(423, 306);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(171, 18);
      this.label8.TabIndex = 19;
      this.label8.Text = "2nd Separation Altitude [m]";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(473, 267);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(121, 18);
      this.label9.TabIndex = 20;
      this.label9.Text = "Wind Coefficient [-]";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(398, 229);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(196, 18);
      this.label10.TabIndex = 21;
      this.label10.Text = "Wind Measurement Altitude [m]";
      // 
      // button_Simulation
      // 
      this.button_Simulation.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.button_Simulation.Location = new System.Drawing.Point(12, 246);
      this.button_Simulation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_Simulation.Name = "button_Simulation";
      this.button_Simulation.Size = new System.Drawing.Size(287, 108);
      this.button_Simulation.TabIndex = 22;
      this.button_Simulation.TabStop = false;
      this.button_Simulation.Text = "Start Simulation\r\n(Call ForRocket)";
      this.button_Simulation.UseVisualStyleBackColor = true;
      this.button_Simulation.Click += new System.EventHandler(this.Button_Simulation_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.check_taiki_land);
      this.groupBox1.Controls.Add(this.check_noshiro_land);
      this.groupBox1.Controls.Add(this.check_noshiro_sea);
      this.groupBox1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.groupBox1.Location = new System.Drawing.Point(333, 13);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Size = new System.Drawing.Size(343, 56);
      this.groupBox1.TabIndex = 23;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Preset";
      // 
      // check_taiki_land
      // 
      this.check_taiki_land.AutoSize = true;
      this.check_taiki_land.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.check_taiki_land.Location = new System.Drawing.Point(252, 23);
      this.check_taiki_land.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.check_taiki_land.Name = "check_taiki_land";
      this.check_taiki_land.Size = new System.Drawing.Size(85, 22);
      this.check_taiki_land.TabIndex = 33;
      this.check_taiki_land.Text = "Taiki Land";
      this.check_taiki_land.UseVisualStyleBackColor = true;
      this.check_taiki_land.Click += new System.EventHandler(this.check_taiki_land_Click);
      // 
      // check_noshiro_land
      // 
      this.check_noshiro_land.AutoSize = true;
      this.check_noshiro_land.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.check_noshiro_land.Location = new System.Drawing.Point(22, 23);
      this.check_noshiro_land.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.check_noshiro_land.Name = "check_noshiro_land";
      this.check_noshiro_land.Size = new System.Drawing.Size(102, 22);
      this.check_noshiro_land.TabIndex = 31;
      this.check_noshiro_land.Text = "Noshiro Land";
      this.check_noshiro_land.UseVisualStyleBackColor = true;
      this.check_noshiro_land.Click += new System.EventHandler(this.check_noshiro_land_Click);
      // 
      // check_noshiro_sea
      // 
      this.check_noshiro_sea.AutoSize = true;
      this.check_noshiro_sea.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.check_noshiro_sea.Location = new System.Drawing.Point(141, 23);
      this.check_noshiro_sea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.check_noshiro_sea.Name = "check_noshiro_sea";
      this.check_noshiro_sea.Size = new System.Drawing.Size(96, 22);
      this.check_noshiro_sea.TabIndex = 32;
      this.check_noshiro_sea.Text = "Noshiro Sea";
      this.check_noshiro_sea.UseVisualStyleBackColor = true;
      this.check_noshiro_sea.Click += new System.EventHandler(this.check_noshiro_sea_Click);
      // 
      // check_v4
      // 
      this.check_v4.AutoSize = true;
      this.check_v4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.check_v4.Location = new System.Drawing.Point(15, 23);
      this.check_v4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.check_v4.Name = "check_v4";
      this.check_v4.Size = new System.Drawing.Size(249, 24);
      this.check_v4.TabIndex = 30;
      this.check_v4.Text = "v4.1 (Use HyperTEK Oxidizer Tank)";
      this.check_v4.UseVisualStyleBackColor = true;
      this.check_v4.Click += new System.EventHandler(this.check_v4_Click);
      // 
      // check_new
      // 
      this.check_new.AutoSize = true;
      this.check_new.Checked = true;
      this.check_new.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.check_new.Location = new System.Drawing.Point(15, 47);
      this.check_new.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.check_new.Name = "check_new";
      this.check_new.Size = new System.Drawing.Size(90, 24);
      this.check_new.TabIndex = 29;
      this.check_new.TabStop = true;
      this.check_new.Text = "v5 or new";
      this.check_new.UseVisualStyleBackColor = true;
      this.check_new.Click += new System.EventHandler(this.check_new_Click);
      // 
      // textBox_Engine
      // 
      this.textBox_Engine.Location = new System.Drawing.Point(105, 146);
      this.textBox_Engine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_Engine.Name = "textBox_Engine";
      this.textBox_Engine.ReadOnly = true;
      this.textBox_Engine.Size = new System.Drawing.Size(194, 25);
      this.textBox_Engine.TabIndex = 27;
      this.textBox_Engine.TabStop = false;
      // 
      // textBox_sturucture
      // 
      this.textBox_sturucture.Location = new System.Drawing.Point(105, 105);
      this.textBox_sturucture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_sturucture.Name = "textBox_sturucture";
      this.textBox_sturucture.ReadOnly = true;
      this.textBox_sturucture.Size = new System.Drawing.Size(194, 25);
      this.textBox_sturucture.TabIndex = 26;
      this.textBox_sturucture.TabStop = false;
      // 
      // button_engine_file
      // 
      this.button_engine_file.Location = new System.Drawing.Point(12, 141);
      this.button_engine_file.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_engine_file.Name = "button_engine_file";
      this.button_engine_file.Size = new System.Drawing.Size(87, 34);
      this.button_engine_file.TabIndex = 25;
      this.button_engine_file.TabStop = false;
      this.button_engine_file.Text = "Engine";
      this.button_engine_file.UseVisualStyleBackColor = true;
      this.button_engine_file.Click += new System.EventHandler(this.button_engine_file_Click);
      // 
      // button_structure_file
      // 
      this.button_structure_file.Location = new System.Drawing.Point(12, 100);
      this.button_structure_file.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_structure_file.Name = "button_structure_file";
      this.button_structure_file.Size = new System.Drawing.Size(87, 34);
      this.button_structure_file.TabIndex = 24;
      this.button_structure_file.TabStop = false;
      this.button_structure_file.Text = "Structure";
      this.button_structure_file.UseVisualStyleBackColor = true;
      this.button_structure_file.Click += new System.EventHandler(this.button_structure_file_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.check_new);
      this.groupBox2.Controls.Add(this.check_v4);
      this.groupBox2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.groupBox2.Location = new System.Drawing.Point(12, 13);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox2.Size = new System.Drawing.Size(287, 79);
      this.groupBox2.TabIndex = 24;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "ForRocket Ver";
      // 
      // openFileDialog_structure
      // 
      this.openFileDialog_structure.FileName = "Structure.xlsx";
      // 
      // openFileDialog_Engine
      // 
      this.openFileDialog_Engine.FileName = "Engine.xlsx";
      // 
      // button_LandingRange
      // 
      this.button_LandingRange.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.button_LandingRange.Location = new System.Drawing.Point(12, 362);
      this.button_LandingRange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_LandingRange.Name = "button_LandingRange";
      this.button_LandingRange.Size = new System.Drawing.Size(287, 108);
      this.button_LandingRange.TabIndex = 28;
      this.button_LandingRange.TabStop = false;
      this.button_LandingRange.Text = "Landing Range Plot";
      this.button_LandingRange.UseVisualStyleBackColor = true;
      this.button_LandingRange.Click += new System.EventHandler(this.Button_LandingRange_Click);
      // 
      // textBox_Aero
      // 
      this.textBox_Aero.Location = new System.Drawing.Point(105, 192);
      this.textBox_Aero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_Aero.Name = "textBox_Aero";
      this.textBox_Aero.ReadOnly = true;
      this.textBox_Aero.Size = new System.Drawing.Size(194, 25);
      this.textBox_Aero.TabIndex = 30;
      this.textBox_Aero.TabStop = false;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.check_log);
      this.groupBox3.Controls.Add(this.check_table);
      this.groupBox3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.groupBox3.Location = new System.Drawing.Point(712, 13);
      this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox3.Size = new System.Drawing.Size(277, 56);
      this.groupBox3.TabIndex = 54;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Switch Output Format Log/Table";
      // 
      // check_log
      // 
      this.check_log.AutoSize = true;
      this.check_log.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.check_log.Location = new System.Drawing.Point(72, 26);
      this.check_log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.check_log.Name = "check_log";
      this.check_log.Size = new System.Drawing.Size(47, 22);
      this.check_log.TabIndex = 31;
      this.check_log.Text = "Log";
      this.check_log.UseVisualStyleBackColor = true;
      this.check_log.Click += new System.EventHandler(this.check_log_Click);
      // 
      // check_table
      // 
      this.check_table.AutoSize = true;
      this.check_table.Checked = true;
      this.check_table.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.check_table.Location = new System.Drawing.Point(197, 26);
      this.check_table.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.check_table.Name = "check_table";
      this.check_table.Size = new System.Drawing.Size(57, 22);
      this.check_table.TabIndex = 32;
      this.check_table.TabStop = true;
      this.check_table.Text = "Table";
      this.check_table.UseVisualStyleBackColor = true;
      this.check_table.Click += new System.EventHandler(this.check_table_Click);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(750, 158);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(155, 18);
      this.label11.TabIndex = 53;
      this.label11.Text = "Wind Velocity Step [m/s]";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(703, 195);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(202, 18);
      this.label12.TabIndex = 52;
      this.label12.Text = "Wind Direction Lower Limit [deg]";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(704, 233);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(201, 18);
      this.label13.TabIndex = 51;
      this.label13.Text = "Wind Direction Upper Limit [deg]";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(746, 272);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(159, 18);
      this.label14.TabIndex = 50;
      this.label14.Text = "Wind Direction Step [deg]";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(715, 122);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(190, 18);
      this.label17.TabIndex = 47;
      this.label17.Text = "Wind Velcity Upper Limit [m/s]";
      // 
      // textBox_anglew_min
      // 
      this.textBox_anglew_min.Location = new System.Drawing.Point(909, 192);
      this.textBox_anglew_min.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_anglew_min.Name = "textBox_anglew_min";
      this.textBox_anglew_min.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.textBox_anglew_min.Size = new System.Drawing.Size(80, 25);
      this.textBox_anglew_min.TabIndex = 12;
      this.textBox_anglew_min.Text = "0.0";
      this.textBox_anglew_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBox_anglew_max
      // 
      this.textBox_anglew_max.Location = new System.Drawing.Point(909, 230);
      this.textBox_anglew_max.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_anglew_max.Name = "textBox_anglew_max";
      this.textBox_anglew_max.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.textBox_anglew_max.Size = new System.Drawing.Size(80, 25);
      this.textBox_anglew_max.TabIndex = 13;
      this.textBox_anglew_max.Text = "360.0";
      this.textBox_anglew_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBox_anglew_delta
      // 
      this.textBox_anglew_delta.Location = new System.Drawing.Point(909, 268);
      this.textBox_anglew_delta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_anglew_delta.Name = "textBox_anglew_delta";
      this.textBox_anglew_delta.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.textBox_anglew_delta.Size = new System.Drawing.Size(80, 25);
      this.textBox_anglew_delta.TabIndex = 14;
      this.textBox_anglew_delta.Text = "45.0";
      this.textBox_anglew_delta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBox_Vw_min
      // 
      this.textBox_Vw_min.Location = new System.Drawing.Point(909, 80);
      this.textBox_Vw_min.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_Vw_min.Name = "textBox_Vw_min";
      this.textBox_Vw_min.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.textBox_Vw_min.Size = new System.Drawing.Size(80, 25);
      this.textBox_Vw_min.TabIndex = 9;
      this.textBox_Vw_min.Text = "1.0";
      this.textBox_Vw_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBox_Vw_max
      // 
      this.textBox_Vw_max.Location = new System.Drawing.Point(909, 118);
      this.textBox_Vw_max.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_Vw_max.Name = "textBox_Vw_max";
      this.textBox_Vw_max.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.textBox_Vw_max.Size = new System.Drawing.Size(80, 25);
      this.textBox_Vw_max.TabIndex = 10;
      this.textBox_Vw_max.Text = "7.0";
      this.textBox_Vw_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBox_Vw_delta
      // 
      this.textBox_Vw_delta.Location = new System.Drawing.Point(909, 155);
      this.textBox_Vw_delta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_Vw_delta.Name = "textBox_Vw_delta";
      this.textBox_Vw_delta.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.textBox_Vw_delta.Size = new System.Drawing.Size(80, 25);
      this.textBox_Vw_delta.TabIndex = 11;
      this.textBox_Vw_delta.Text = "1.0";
      this.textBox_Vw_delta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Location = new System.Drawing.Point(714, 83);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(191, 18);
      this.label19.TabIndex = 39;
      this.label19.Text = "Wind Velcity Lower Limit [m/s]\r\n";
      // 
      // LogoPic
      // 
      this.LogoPic.Image = global::ForRocket_FrontEnd.Properties.Resources.ForRocket_Logo;
      this.LogoPic.Location = new System.Drawing.Point(725, 400);
      this.LogoPic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.LogoPic.Name = "LogoPic";
      this.LogoPic.Size = new System.Drawing.Size(271, 76);
      this.LogoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.LogoPic.TabIndex = 29;
      this.LogoPic.TabStop = false;
      this.LogoPic.Click += new System.EventHandler(this.LogoPic_Click);
      // 
      // Simulation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1001, 482);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.textBox_Aero);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.LogoPic);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.button_LandingRange);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.textBox_Engine);
      this.Controls.Add(this.textBox_sturucture);
      this.Controls.Add(this.button_engine_file);
      this.Controls.Add(this.label17);
      this.Controls.Add(this.button_structure_file);
      this.Controls.Add(this.textBox_anglew_min);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.textBox_anglew_max);
      this.Controls.Add(this.button_Simulation);
      this.Controls.Add(this.textBox_anglew_delta);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.textBox_Vw_min);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.textBox_Vw_max);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.textBox_Vw_delta);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label19);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.text_Wh);
      this.Controls.Add(this.text_Hsepa);
      this.Controls.Add(this.text_elevation);
      this.Controls.Add(this.text_azimuth);
      this.Controls.Add(this.text_LL);
      this.Controls.Add(this.text_Ta);
      this.Controls.Add(this.text_rho);
      this.Controls.Add(this.text_g0);
      this.Controls.Add(this.text_Hw);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.text_Pa);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button_AeroDesign);
      this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.Name = "Simulation";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.Text = "ForRocket Controller";
      this.Load += new System.EventHandler(this.Simulation_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LogoPic)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button_AeroDesign;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox text_Pa;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox text_Hw;
    private System.Windows.Forms.TextBox text_g0;
    private System.Windows.Forms.TextBox text_rho;
    private System.Windows.Forms.TextBox text_Ta;
    private System.Windows.Forms.TextBox text_LL;
    private System.Windows.Forms.TextBox text_azimuth;
    private System.Windows.Forms.TextBox text_elevation;
    private System.Windows.Forms.TextBox text_Hsepa;
    private System.Windows.Forms.TextBox text_Wh;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button button_Simulation;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton check_v4;
    private System.Windows.Forms.RadioButton check_new;
    private System.Windows.Forms.TextBox textBox_Engine;
    private System.Windows.Forms.TextBox textBox_sturucture;
    private System.Windows.Forms.Button button_engine_file;
    private System.Windows.Forms.Button button_structure_file;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.OpenFileDialog openFileDialog_structure;
    private System.Windows.Forms.OpenFileDialog openFileDialog_Engine;
    private System.Windows.Forms.Button button_LandingRange;
    private System.Windows.Forms.PictureBox LogoPic;
    private System.Windows.Forms.TextBox textBox_Aero;
    private System.Windows.Forms.RadioButton check_noshiro_land;
    private System.Windows.Forms.RadioButton check_noshiro_sea;
    private System.Windows.Forms.RadioButton check_taiki_land;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.RadioButton check_log;
    private System.Windows.Forms.RadioButton check_table;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.TextBox textBox_anglew_min;
    private System.Windows.Forms.TextBox textBox_anglew_max;
    private System.Windows.Forms.TextBox textBox_anglew_delta;
    private System.Windows.Forms.TextBox textBox_Vw_min;
    private System.Windows.Forms.TextBox textBox_Vw_max;
    private System.Windows.Forms.TextBox textBox_Vw_delta;
    private System.Windows.Forms.Label label19;
  }
}