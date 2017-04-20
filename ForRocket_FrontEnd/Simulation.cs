using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace ForRocket_FrontEnd
{
  public partial class ControllerForm : Form
  {
    ForRocket_interface ForRocket_interface;

    public ControllerForm()
    {
      InitializeComponent();
    }

    private void Simulation_Load(object sender, EventArgs e)
    {
      if (!Directory.GetCurrentDirectory().EndsWith("bin"))
      {
        Directory.SetCurrentDirectory("./bin");
      }

      check_new.Checked = true;
      check_v4.Checked = false;
      ForRocket_interface = new ForRocket_interface();

      ActiveControl = this.LogoPic;

    }

    // Check ForRocket Ver
    private void check_new_Click(object sender, EventArgs e)
    {
      check_new.Checked = true;
      check_v4.Checked = false;      
      ForRocket_interface = new ForRocket_interface();
    }
    private void check_v4_Click(object sender, EventArgs e)
    {
      check_new.Checked = false;
      check_v4.Checked = true;
      ForRocket_interface = new ForRocket_interface_v4();
    }

    //Structureシート読み出し
    private void button_structure_file_Click(object sender, EventArgs e)
    {
      string file_path = null;
      openFileDialog_structure.InitialDirectory = System.IO.Path.GetFullPath("../");
      openFileDialog_structure.Title = "Select Input Structure Sheet";
      openFileDialog_structure.CheckFileExists = true;
      openFileDialog_structure.CheckPathExists = true;
      if (openFileDialog_structure.ShowDialog() == DialogResult.OK) file_path = System.IO.Path.GetFullPath(openFileDialog_structure.FileName);

      if (File.Exists(file_path))
      {
        textBox_sturucture.Text = file_path;
        XLWorkbook workbook = new XLWorkbook(file_path, XLEventTracking.Disabled);
        IXLWorksheet worksheet = workbook.Worksheet(1);

        ForRocket_interface.structure_read(worksheet);
        
        workbook.Dispose();
      }

    }

    //Engineシート読み出し
    private void button_engine_file_Click(object sender, EventArgs e)
    {
      string file_path = null;
      openFileDialog_Engine.InitialDirectory = System.IO.Path.GetFullPath("../");
      openFileDialog_Engine.Title = "Select Input Engine Sheet";
      openFileDialog_Engine.CheckFileExists = true;
      openFileDialog_Engine.CheckPathExists = true;
      if (openFileDialog_Engine.ShowDialog() == DialogResult.OK) file_path = System.IO.Path.GetFullPath(openFileDialog_Engine.FileName);

      if (File.Exists(file_path))
      {
        textBox_Engine.Text = file_path;
        XLWorkbook workbook = new XLWorkbook(file_path, XLEventTracking.Disabled);
        IXLWorksheet worksheet = workbook.Worksheet(1);

        ForRocket_interface.engine_read(worksheet);              

        workbook.Dispose();
      }


    }

    //空力設計フォーム呼び出し
    private void Button_Aero_Click(object sender, EventArgs e)
    {
      ForRocket_interface.aero_design();
            
    }

    //Enviroment preset
    private void check_noshiro_land_Click(object sender, EventArgs e)
    {
      check_noshiro_land.Checked = true;
      check_noshiro_sea.Checked = false;
      check_taiki_land.Checked = false;
      preset_noshiro_land();
    }
    private void check_noshiro_sea_Click(object sender, EventArgs e)
    {
      check_noshiro_land.Checked = false;
      check_noshiro_sea.Checked = true;
      check_taiki_land.Checked = false;
      preset_noshiro_sea();
    }
    private void check_taiki_land_Click(object sender, EventArgs e)
    {
      check_noshiro_land.Checked = false;
      check_noshiro_sea.Checked = false;
      check_taiki_land.Checked = true;
      preset_taiki_land();
    }
    private void preset_noshiro_land()
    {
      text_Pa.Text = "100.8";
      text_Ta.Text = "25.0";
      reset_rho();
      text_g0.Text = "9.8";
      text_Hw.Text = "5.0";
      text_Wh.Text = "4.5";
      text_Hsepa.Text = "0.0";
      text_elevation.Text = "75.0";
      text_azimuth.Text = "215.0";
      text_LL.Text = "5.0";
    }
    private void preset_noshiro_sea()
    {
      text_Pa.Text = "100.8";
      text_Ta.Text = "20.0";
      reset_rho();
      text_g0.Text = "9.8";
      text_Hw.Text = "5.0";
      text_Wh.Text = "6.0";
      text_Hsepa.Text = "150.0";
      text_elevation.Text = "85.0";
      text_azimuth.Text = "125.0"; ;
      text_LL.Text = "5.0";
    }
    private void preset_taiki_land()
    {
      text_Pa.Text = "100.5";
      text_Ta.Text = "0.0";
      reset_rho();
      text_g0.Text = "9.8";
      text_Hw.Text = "5.0";
      text_Wh.Text = "7.4";
      text_Hsepa.Text = "150.0";
      text_elevation.Text = "85.0";
      text_azimuth.Text = "25.0"; ;
      text_LL.Text = "5.0";
    }
    private void text_Pa_Leave(object sender, EventArgs e)
    {
      reset_rho();
    }
    private void text_Ta_Leave(object sender, EventArgs e)
    {
      reset_rho();
    }
    private void reset_rho()
    {
      text_rho.Text = (float.Parse(text_Pa.Text) * 1000.0 / (287.0 * (float.Parse(text_Ta.Text) + 273.15))).ToString("F3");
    }

    //計算条件
    private void check_log_Click(object sender, EventArgs e)
    {
      check_log.Checked = true;
      check_table.Checked = false;

      textBox_Vw_max.ReadOnly = true;
      textBox_Vw_delta.ReadOnly = true;
      textBox_anglew_max.ReadOnly = true;
      textBox_anglew_delta.ReadOnly = true;
    }
    private void check_table_Click(object sender, EventArgs e)
    {
      check_log.Checked = false;
      check_table.Checked = true;

      textBox_Vw_max.ReadOnly = false;
      textBox_Vw_delta.ReadOnly = false;
      textBox_anglew_max.ReadOnly = false;
      textBox_anglew_delta.ReadOnly = false;
    }

    //Call ForRocket
    private void Button_Simulation_Click(object sender, EventArgs e)
    {
      double[] environment_array = new double[9];
      double[] switch_array = new double[6];
      int log_table_switch = 1;
            
      //Environment Parameter
      environment_array[0] = double.Parse(text_Pa.Text);
      environment_array[1] = double.Parse(text_Ta.Text);
      environment_array[2] = double.Parse(text_g0.Text);
      environment_array[3] = double.Parse(text_Hw.Text);
      environment_array[4] = double.Parse(text_Wh.Text);
      environment_array[5] = double.Parse(text_Hsepa.Text);
      environment_array[6] = double.Parse(text_elevation.Text);
      environment_array[7] = double.Parse(text_azimuth.Text);
      environment_array[8] = double.Parse(text_LL.Text);
      
      //Switch Parameter
      switch_array[0] = double.Parse(textBox_Vw_min.Text);
      switch_array[1] = double.Parse(textBox_Vw_max.Text);
      switch_array[2] = double.Parse(textBox_Vw_delta.Text);
      switch_array[3] = double.Parse(textBox_anglew_min.Text);
      switch_array[4] = double.Parse(textBox_anglew_max.Text);
      switch_array[5] = double.Parse(textBox_anglew_delta.Text);
      
      if (check_log.Checked == true)
      {
        log_table_switch = 0;
      }
      if (check_table.Checked == true)
      {
        log_table_switch = 1;
      }
      ForRocket_interface.export(environment_array, log_table_switch, switch_array);

      ForRocket_interface.call();       

      using (StreamWriter DataFile = new StreamWriter("../result/SimulationConfiguration.out"))
      {
        DataFile.WriteLine("!----------------------------------------------------------!");
        DataFile.WriteLine("!----------------ForRocket-Simulation Result---------------!");
        DataFile.WriteLine("!----------------------------------------------------------!");
        DataFile.WriteLine("Launch Elevation " + text_elevation.Text + "[deg]");
        DataFile.WriteLine("Launch Azimuth " + text_azimuth.Text + "[deg]");
        DataFile.WriteLine("2nd Separation Altitude " + text_Hsepa.Text + "[deg]");

      }

    }
    
    //落下分散プロット呼び出し
    private void Button_LandingRange_Click(object sender, EventArgs e)
    {
      LandingRangeViewer.LandingRangeViewer landingrangeform = new LandingRangeViewer.LandingRangeViewer();
      landingrangeform.Show();
    }

    private void LogoPic_Click(object sender, EventArgs e)
    {
      AboutForRocket info_form = new AboutForRocket();
      info_form.ShowDialog(this);
      info_form.Dispose();
    }
  }
   
  // ForRocket interface
  public class ForRocket_interface
  {
    // ForRocket Rocket Parameter
    ////////////////////////////////
    double l;
    double d;
    double me;
    double lcge;
    double lcgf;
    double lmotor;
    double Is;
    double Ir;
    double lcp;
    double Clp; // Roll減衰モーメント係数
    double Cmq; // Pitch/Yaw減衰モーメント係数
    double CNa;

    double CdS1;
    double CdS2;
    
    double freq;
    double Isp;
    double It;
    double tb;
    double mox;
    double rho_ox;
    double d_tank;
    double d_tank_outlet;
    double l_tank_taper;
    double mfb;
    double mfa;
    double lf;
    double df_out;
    double df_port;
    double mdotf;
    double de;

    double Pa;
    double Ta;
    double rho;
    double g0;
    double Hw;
    double Wh;
    double Hsepa;
    double elevation;
    double azimuth;
    double LL;
    //////////////////////////

    // ForRocket Control
    //////////////////////////
    int switch_log_table; //0:Log / 1:Table
    double Vw_min;
    double Vw_max;
    double Vw_delta;
    double anglew_min;
    double anglew_max;
    double anglew_delta;
    //////////////////////////

    //保持用
    double ms;
    double lcgs;
    double lnose;
    double t_fin;
    double rho_fin;
    double dtail;
    double ltail;

    //Structureシート読み出し
    public virtual void structure_read(IXLWorksheet worksheet)
    {
      l = worksheet.Cell(1, 2).GetDouble();
      d = worksheet.Cell(2, 2).GetDouble();
      ms = worksheet.Cell(3, 2).GetDouble();
      lcgs = worksheet.Cell(4, 2).GetDouble();
      lcgf = worksheet.Cell(5, 2).GetDouble();
      lmotor = worksheet.Cell(6, 2).GetDouble();
      Is = worksheet.Cell(7, 2).GetDouble();
      Ir = worksheet.Cell(8, 2).GetDouble();
      lnose = worksheet.Cell(9, 2).GetDouble();
      t_fin = worksheet.Cell(10, 2).GetDouble();
      rho_fin = worksheet.Cell(11, 2).GetDouble();
      dtail = worksheet.Cell(12, 2).GetDouble();
      ltail = worksheet.Cell(13, 2).GetDouble();
      CdS1 = worksheet.Cell(14, 2).GetDouble();
      CdS2 = worksheet.Cell(15, 2).GetDouble();
    }
    //Engineシート読み出し
    public virtual void engine_read(IXLWorksheet worksheet)
    {
      freq = worksheet.Cell(1, 2).GetDouble();
      Isp = worksheet.Cell(2, 2).GetDouble();
      It = worksheet.Cell(3, 2).GetDouble();
      tb = worksheet.Cell(4, 2).GetDouble();
      mox = worksheet.Cell(5, 2).GetDouble();
      rho_ox = worksheet.Cell(6, 2).GetDouble();
      d_tank = worksheet.Cell(7, 2).GetDouble();
      d_tank_outlet = worksheet.Cell(8, 2).GetDouble();
      l_tank_taper = worksheet.Cell(9, 2).GetDouble();
      mfb = worksheet.Cell(10, 2).GetDouble();
      mfa = worksheet.Cell(11, 2).GetDouble();
      lf = worksheet.Cell(12, 2).GetDouble();
      df_out = worksheet.Cell(13, 2).GetDouble();
      df_port = worksheet.Cell(14, 2).GetDouble();
      mdotf = worksheet.Cell(15, 2).GetDouble();
      de = worksheet.Cell(16, 2).GetDouble();
    }
    //空力設計
    public virtual void aero_design()
    {
      AeroDesign_interface Aero_interface = new AeroDesign_interface();

      double A_tank = 0.25 * d_tank * d_tank * Math.PI;
      double mox_taper = (1.0 / 3.0 * Math.PI * l_tank_taper * 0.5 * (d_tank * d_tank + d_tank * d_tank_outlet + d_tank_outlet * d_tank_outlet)) * rho_ox;
      double lcg_taper = l_tank_taper * (1.0 - ((0.5 * d_tank + 1.5 * d_tank_outlet) / (3.0 * 0.5 * (d_tank + d_tank_outlet))));
      double l_cone = (0.5 * d_tank_outlet * l_tank_taper) / (0.5 * (d_tank - d_tank_outlet));
      double Vol_cone = 1.0 / 3.0 * (0.25 * d_tank_outlet * d_tank_outlet * Math.PI) * l_cone;
      double Vol_ox;
      double l_ox;
      double lcgox;
      if (mox < mox_taper)
      {
        Vol_ox = mox / rho_ox;
        l_ox = Math.Pow(3.0 / Math.PI * Math.Pow(l_cone / (0.5 * d_tank_outlet), 2) * (Vol_cone + Vol_ox), 1.0 / 3.0) - l_cone;
        double d_ox = d_tank_outlet / l_cone * (l_ox + l_cone);
        lcgox = l_tank_taper - (l_ox * (0.5 * d_ox + 1.5 * d_tank_outlet) / (3.0 * 0.5 * (d_ox + d_tank_outlet)));
      }
      else
      {
        Vol_ox = (mox - mox_taper) / rho_ox;
        l_ox = Vol_ox / A_tank;
        lcgox = ((mox - mox_taper) * 0.5 * l_ox + mox_taper * lcg_taper) / mox;
      }

      Aero_interface.l = l;
      Aero_interface.d = d;
      Aero_interface.ms = ms;
      Aero_interface.m = ms + mox;
      Aero_interface.ma = ms - (mfb - mfa);

      double moments = ms * lcgs;
      double momentox = mox * (l - lcgox);
      double momentfb = mfb * (l - lcgf);
      double momentfa = mfa * (l - lcgf);
      Aero_interface.lcg = (moments + momentox) / (ms + mox);
      Aero_interface.lcga = (moments - (momentfb - momentfa)) / (ms + (mfb - mfa));

      Aero_interface.lnose = lnose;
      Aero_interface.t_fin = t_fin;
      Aero_interface.rho_fin = rho_fin;
      Aero_interface.dtail = dtail;
      Aero_interface.ltail = ltail;

      Aero_interface = AeroDesign.AeroDesignForm.call_AeroForm(Aero_interface);

      me = Aero_interface.ms - mfb;
      lcge = ((Aero_interface.ms * Aero_interface.lcgs) - (mfb * (l - lcgf))) / me;
      lcp = Aero_interface.lcp;
      CNa = Aero_interface.CNa;
      Cmq = Aero_interface.Cmq;
      Clp = Aero_interface.Clp;
    }

    //ForRocket inputファイル書き出し
    public virtual void export(double[] environment_array, int sw, double[] switch_array)
    {
      Pa = environment_array[0];
      Ta = environment_array[1];
      rho = Pa * 1000.0 / (287.1 * (Ta * 273.15));
      g0 = environment_array[2];
      Hw = environment_array[3];
      Wh = environment_array[4];
      Hsepa = environment_array[5];
      elevation = environment_array[6];
      azimuth = environment_array[7];
      LL = environment_array[8];

      // rocket_param.inp
      using (StreamWriter DataFile = new StreamWriter("./solver/rocket_param.inp"))
      {
        DataFile.WriteLine(l.ToString());
        DataFile.WriteLine(d.ToString());
        DataFile.WriteLine(me.ToString());
        DataFile.WriteLine(lcge.ToString());
        DataFile.WriteLine(lcgf.ToString());
        DataFile.WriteLine(lmotor.ToString());
        DataFile.WriteLine(Is.ToString());
        DataFile.WriteLine(Ir.ToString());
        DataFile.WriteLine(lcp.ToString());
        DataFile.WriteLine(Clp.ToString());
        DataFile.WriteLine(Cmq.ToString());
        DataFile.WriteLine(CNa.ToString());
        DataFile.WriteLine(0.0.ToString());
        DataFile.WriteLine(CdS1.ToString());
        DataFile.WriteLine(CdS2.ToString());
        DataFile.WriteLine(freq.ToString());
        DataFile.WriteLine(Isp.ToString());
        DataFile.WriteLine(mox.ToString());
        DataFile.WriteLine(rho_ox.ToString());
        DataFile.WriteLine(d_tank.ToString());
        DataFile.WriteLine(d_tank_outlet.ToString());
        DataFile.WriteLine(l_tank_taper.ToString());
        DataFile.WriteLine(mfb.ToString());
        DataFile.WriteLine(mfa.ToString());
        DataFile.WriteLine(lf.ToString());
        DataFile.WriteLine(df_out.ToString());
        DataFile.WriteLine(df_port.ToString());
        DataFile.WriteLine(mdotf.ToString());
        DataFile.WriteLine(Pa.ToString());
        DataFile.WriteLine(Ta.ToString());
        DataFile.WriteLine(g0.ToString());
        DataFile.WriteLine(Hw.ToString());
        DataFile.WriteLine(Wh.ToString());
        DataFile.WriteLine(0.0.ToString());
        DataFile.WriteLine(Hsepa.ToString());
        DataFile.WriteLine(elevation.ToString());
        DataFile.WriteLine(azimuth.ToString());
        DataFile.WriteLine(LL.ToString());
      }

      // switch.inp
      switch_log_table = sw;
      Vw_min = switch_array[0];
      Vw_max = switch_array[1];
      Vw_delta = switch_array[2];
      anglew_min = switch_array[3];
      anglew_max = switch_array[4];
      anglew_delta = switch_array[5];

      if (switch_log_table == 1)
      {
        if (((Vw_max - Vw_min) / Vw_delta) > 56 || ((anglew_max - anglew_min) / anglew_delta) > 56)
        {
          MessageBox.Show("Table出力はデータ数56(7x8)点までのみ対応です！");
        }
      }

      using (StreamWriter DataFile = new StreamWriter("./solver/switch.inp"))
      {
        DataFile.WriteLine(switch_log_table.ToString());
        DataFile.WriteLine(Vw_min.ToString());
        DataFile.WriteLine(Vw_max.ToString());
        DataFile.WriteLine(Vw_delta.ToString());
        DataFile.WriteLine(anglew_min.ToString());
        DataFile.WriteLine(anglew_max.ToString());
        DataFile.WriteLine(anglew_delta.ToString());
      }
            
    }

    // Call ForRocket
    public virtual void call()
    {
      /****************************************************/
      // solverフォルダへ移動
      Directory.SetCurrentDirectory("./solver");
      
      // 計算終了まで待機
      Process p_solve = Process.Start(Path.GetFullPath("./ForRocket.exe"));
      p_solve.WaitForExit();  
      
      Process p_post = Process.Start(Path.GetFullPath("./ForRocketPost.exe"));
      p_post.WaitForExit();

      Directory.SetCurrentDirectory("../");
      // ./binへ移動
      /****************************************************/

      CopyDirectory("./solver/OutputLog", "../result");
      CopyDirectory("./solver/OutputTable", "../result");
    }

    public static void CopyDirectory(string sourceDirName, string destDirName)
    {
      //コピー先のディレクトリがないときは作る
      if (!Directory.Exists(destDirName))
      {
        Directory.CreateDirectory(destDirName);
        //属性もコピー
        File.SetAttributes(destDirName,
            File.GetAttributes(sourceDirName));
      }

      //コピー先のディレクトリ名の末尾に"\"をつける
      if (destDirName[destDirName.Length - 1] !=
              Path.DirectorySeparatorChar)
        destDirName = destDirName + Path.DirectorySeparatorChar;

      //コピー元のディレクトリにあるファイルをコピー
      string[] files = Directory.GetFiles(sourceDirName);
      foreach (string file in files)
        File.Copy(file,
            destDirName + Path.GetFileName(file), true);

      //コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
      string[] dirs = Directory.GetDirectories(sourceDirName);
      foreach (string dir in dirs)
        CopyDirectory(dir, destDirName + Path.GetFileName(dir));
    }
  }

  public class ForRocket_interface_v4 : ForRocket_interface
  {
    // ForRocket Rocket Parameter
    ////////////////////////////////
    double l;
    double d;
    double me;
    double lcge;
    double lcgox;
    double lcgf;
    double ltank;
    double Is;
    double Ir;
    double lcp;
    double Clp; // Roll減衰モーメント係数
    double Cmq; // Pitch/Yaw減衰モーメント係数
    double CNa;

    double CdS1;
    double CdS2;

    double freq;
    double Isp;
    double It;
    double tb;
    double mox;
    double rho_ox;
    double d_tank;
    double d_tank_outlet;
    double l_tank_taper;
    double mfb;
    double mfa;
    double lf;
    double df_out;
    double df_port;
    double mdotox;
    double mdotf;
    double de;

    double Pa;
    double Ta;
    double rho;
    double g0;
    double Hw;
    double Wh;
    double Hsepa;
    double elevation;
    double azimuth;
    double LL;
    //////////////////////////

    // ForRocket Control
    //////////////////////////
    int switch_log_table; //0:Log / 1:Table
    double Vw_min;
    double Vw_max;
    double Vw_delta;
    double anglew_min;
    double anglew_max;
    double anglew_delta;
    //////////////////////////

    //保持用
    double ms;
    double lcgs;
    double lnose;
    double t_fin;
    double rho_fin;
    double dtail;
    double ltail;

    //Structureシート読み出し
    public override void structure_read(IXLWorksheet worksheet)
    {
      l = worksheet.Cell(1, 2).GetDouble();
      d = worksheet.Cell(2, 2).GetDouble();
      ms = worksheet.Cell(3, 2).GetDouble();
      lcgs = worksheet.Cell(4, 2).GetDouble();
      lcgox = worksheet.Cell(5, 2).GetDouble();
      lcgf = worksheet.Cell(6, 2).GetDouble();
      ltank = worksheet.Cell(7, 2).GetDouble();
      Is = worksheet.Cell(8, 2).GetDouble();
      Ir = worksheet.Cell(9, 2).GetDouble();
      lnose = worksheet.Cell(9, 2).GetDouble();
      t_fin = worksheet.Cell(10, 2).GetDouble();
      rho_fin = worksheet.Cell(11, 2).GetDouble();
      dtail = worksheet.Cell(12, 2).GetDouble();
      ltail = worksheet.Cell(13, 2).GetDouble();
      CdS1 = worksheet.Cell(14, 2).GetDouble();
      CdS2 = worksheet.Cell(15, 2).GetDouble();
    }
    //Engineシート読み出し
    public override void engine_read(IXLWorksheet worksheet)
    {
      freq = worksheet.Cell(1, 2).GetDouble();
      de = worksheet.Cell(2, 2).GetDouble();
      Isp = worksheet.Cell(3, 2).GetDouble();
      It = worksheet.Cell(4, 2).GetDouble();
      mox = worksheet.Cell(5, 2).GetDouble();
      mfb = worksheet.Cell(6, 2).GetDouble();
      mfa = worksheet.Cell(7, 2).GetDouble();
      lf = worksheet.Cell(8, 2).GetDouble();
      df_out = worksheet.Cell(9, 2).GetDouble();
      df_port = worksheet.Cell(10, 2).GetDouble();
      mdotox = worksheet.Cell(11, 2).GetDouble();
      mdotf = worksheet.Cell(12, 2).GetDouble();
      tb = worksheet.Cell(13, 2).GetDouble();
    }
    //空力設計
    public override void aero_design()
    {
      AeroDesign_interface parameter = new AeroDesign_interface();

      parameter.ms = ms;
      parameter.m = ms + mox;
      parameter.ma = ms - (mfb - mfa);

      double moments = ms * lcgs;
      double momentox = mox * (l - lcgox);
      double momentfb = mfb * (l - lcgf);
      double momentfa = mfa * (l - lcgf);
      parameter.lcg = (moments + momentox) / (ms + mox);
      parameter.lcga = (moments - (momentfb - momentfa)) / (ms + (mfb - mfa));

      parameter.lnose = lnose;
      parameter.t_fin = t_fin;
      parameter.rho_fin = rho_fin;
      parameter.dtail = dtail;
      parameter.ltail = ltail;

      parameter = AeroDesign.AeroDesignForm.call_AeroForm(parameter);

      me = parameter.ms - mfb;
      lcge = ((parameter.ms * parameter.lcgs) - (mfb * (l - lcgf))) / me;
      lcp = parameter.lcp;
      CNa = parameter.CNa;
      Cmq = parameter.Cmq;
      Clp = parameter.Clp;
    }

    //ForRocket inputファイル書き出し
    public override void export(double[] environment_array, int sw, double[] switch_array)
    {
      Pa = environment_array[0];
      Ta = environment_array[1];
      rho = Pa * 1000.0 / (287.1 * (Ta * 273.15));
      g0 = environment_array[2];
      Hw = environment_array[3];
      Wh = environment_array[4];
      Hsepa = environment_array[5];
      elevation = environment_array[6];
      azimuth = environment_array[7];
      LL = environment_array[8];

      // rocket_param.inp
      using (StreamWriter DataFile = new StreamWriter("./solver/rocket_param.inp"))
      {
        DataFile.WriteLine(l.ToString());
        DataFile.WriteLine(d.ToString());
        DataFile.WriteLine(me.ToString());
        DataFile.WriteLine(lcge.ToString());
        DataFile.WriteLine(lcgox.ToString());
        DataFile.WriteLine(lcgf.ToString());
        DataFile.WriteLine(ltank.ToString());
        DataFile.WriteLine(Is.ToString());
        DataFile.WriteLine(Ir.ToString());
        DataFile.WriteLine(lcp.ToString());
        DataFile.WriteLine(Clp.ToString());
        DataFile.WriteLine(Cmq.ToString());
        DataFile.WriteLine(CNa.ToString());
        DataFile.WriteLine(0.0.ToString());
        DataFile.WriteLine(CdS1.ToString());
        DataFile.WriteLine(CdS2.ToString());
        DataFile.WriteLine(freq.ToString());
        DataFile.WriteLine(de.ToString());
        DataFile.WriteLine(Isp.ToString());
        DataFile.WriteLine(mox.ToString());
        DataFile.WriteLine(mfb.ToString());
        DataFile.WriteLine(mfa.ToString());
        DataFile.WriteLine(lf.ToString());
        DataFile.WriteLine(df_out.ToString());
        DataFile.WriteLine(df_port.ToString());
        DataFile.WriteLine(mdotf.ToString());
        DataFile.WriteLine(Pa.ToString());
        DataFile.WriteLine(Ta.ToString());
        DataFile.WriteLine(g0.ToString());
        DataFile.WriteLine(Hw.ToString());
        DataFile.WriteLine(Wh.ToString());
        DataFile.WriteLine(0.0.ToString());
        DataFile.WriteLine(Hsepa.ToString());
        DataFile.WriteLine(elevation.ToString());
        DataFile.WriteLine(azimuth.ToString());
        DataFile.WriteLine(LL.ToString());
      }

      // switch.inp
      switch_log_table = sw;
      Vw_min = switch_array[0];
      Vw_max = switch_array[1];
      Vw_delta = switch_array[2];
      anglew_min = switch_array[3];
      anglew_max = switch_array[4];
      anglew_delta = switch_array[5];

      if (switch_log_table == 1)
      {
        if (((Vw_max - Vw_min) / Vw_delta) > 56 || ((anglew_max - anglew_min) / anglew_delta) > 56)
        {
          MessageBox.Show("Table出力はデータ数56(7x8)点までのみ対応です！");
        }
      }

      using (StreamWriter DataFile = new StreamWriter("./solver/switch.inp"))
      {
        DataFile.WriteLine(switch_log_table.ToString());
        DataFile.WriteLine(Vw_min.ToString());
        DataFile.WriteLine(Vw_max.ToString());
        DataFile.WriteLine(Vw_delta.ToString());
        DataFile.WriteLine(anglew_min.ToString());
        DataFile.WriteLine(anglew_max.ToString());
        DataFile.WriteLine(anglew_delta.ToString());
      }
    }

    public override void call()
    {
      /****************************************************/
      // solverフォルダへ移動
      Directory.SetCurrentDirectory("./solver");
      
      // 計算終了まで待機
      Process p_solve = Process.Start(Path.GetFullPath("./ForRocket_v4.exe"));
      p_solve.WaitForExit();

      Process p_post = Process.Start(Path.GetFullPath("./ForRocketPost.exe"));
      p_post.WaitForExit();

      Directory.SetCurrentDirectory("../");
      // ./binへ移動
      /****************************************************/

      CopyDirectory("./solver/OutputLog", "../result");
      CopyDirectory("./solver/OutputTable", "../result");
    }
        
  }
  
  //ForRocket interfaceの情報を書き換えずに空力計算へ＆入力の統一
  public class AeroDesign_interface
  {
    public double l { get; set; }
    public double d { get; set; }
    public double ms { get; set; }
    public double m { get; set; }
    public double ma { get; set; }
    public double lcgs { get; set; }
    public double lcg { get; set; }
    public double lcga { get; set; }
    public double lcp { get; set; }
    public double CNa { get; set; }
    public double Cmq { get; set; }
    public double Clp { get; set; }
    public double lnose { get; set; }
    public double t_fin { get; set; }
    public double rho_fin { get; set; }
    public double dtail { get; set; }
    public double ltail { get; set; }
  }

}
