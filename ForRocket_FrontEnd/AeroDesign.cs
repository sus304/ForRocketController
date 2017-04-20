using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace AeroDesign
{
  public partial class AeroDesignForm : Form
  {
    //空力設計フォームの呼び出しラッパー
    static public ForRocket_FrontEnd.AeroDesign_interface call_AeroForm(ForRocket_FrontEnd.AeroDesign_interface Aero_interface)
    {
      AeroDesignForm aerodesign_form = new AeroDesignForm(Aero_interface);
      aerodesign_form.ShowDialog();
      aerodesign_form.Dispose();

      return Aero_interface;
    }

    ForRocket_FrontEnd.AeroDesign_interface Controller_interface;
    Rocket rocket;
    static_stability static_stability;
    dynamic_stability dynamic_stability;
    Plotter Plotter;

    int flag_calc = 0;

    public AeroDesignForm(ForRocket_FrontEnd.AeroDesign_interface Aero_interface)
    {
      InitializeComponent();
      Controller_interface = Aero_interface;
      rocket = new Rocket(Controller_interface);
      static_stability = new static_stability();
      dynamic_stability = new dynamic_stability();
      Plotter = new Plotter();

      flag_calc = 0;
    }

    private void AeroDesignForm_Load(object sender, EventArgs e)
    {
      button_output.Enabled = false;
      
      combo_nose.Items.Add("ダブルコーン");
      combo_nose.Items.Add("オジャイブ");

      text_diameter.Text = rocket.d.ToString("F3");
      text_length.Text = rocket.l.ToString("F3");
      text__lcgs.Text = rocket._lcgs.ToString("F3");
      text__lcg.Text = rocket._lcg.ToString("F3");
      text__lcga.Text = rocket._lcga.ToString("F3");
      text_ms.Text = rocket._ms.ToString("F3");
      text_m.Text = rocket._m.ToString("F3");
      text_ma.Text = rocket._ma.ToString("F3");
      text_lnose.Text = rocket.nose.l.ToString("F3");
      text_dtail.Text = rocket.boattail.d.ToString("F3");
      text_ltail.Text = rocket.boattail.l.ToString("F3");
      text_thick.Text = rocket.fin.thickness.ToString("F3");
      text_rho.Text = rocket.fin.rho.ToString("F3");

      rocketplot.ChartAreas[0].AxisX.Maximum = 4000;
      rocketplot.ChartAreas[0].AxisX.Minimum = 0.0;
      rocketplot.ChartAreas[0].AxisX.Interval = 200;
      rocketplot.ChartAreas[0].AxisY.Maximum = 400;
      rocketplot.ChartAreas[0].AxisY.Minimum = -400;
      rocketplot.ChartAreas[0].AxisY.Interval = 200;

      rocketplot.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
      rocketplot.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
      rocketplot.ChartAreas[0].InnerPlotPosition.Auto = false;
      rocketplot.ChartAreas[0].InnerPlotPosition.Width = 100;
      rocketplot.ChartAreas[0].InnerPlotPosition.Height = 100;
      rocketplot.ChartAreas[0].InnerPlotPosition.X = 0;
      rocketplot.ChartAreas[0].InnerPlotPosition.Y = 0;
      rocketplot.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
      rocketplot.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
      rocketplot.ChartAreas[0].Position.Height = 100;
      rocketplot.ChartAreas[0].Position.Width = 100;
      
    }

    

    //Description
    private void text_diameter_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "機体代表直径";
    }
    private void text_length_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "機体全長　　ノーズ先端からエンドカバー後端まで　　ボートテイルの場合はボートテイル後端まで";
    }
    private void text_lcgs_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "乾燥質量でのノーズ先端からの機体重心位置";
    }
    private void text_lcg_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "全備質量でのノーズ先端からの機体重心位置";
    }
    private void text_lcga_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "燃焼終了時質量でのノーズ先端からの機体重心位置";
    }
    private void text_ms_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "乾燥質量";
    }
    private void text_m_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "全備質量";
    }
    private void text_ma_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "燃焼終了時質量";
    }
    private void text_altitude_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "最高速に達する時点の高度（要シミュレーション）";
    }
    private void combo_nose_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "ノーズ形状";
    }
    private void text_lnose_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "ノーズ長さ　　平坦でないテーパ部";
    }
    private void text_dtail_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "ボートテイル直径";
    }
    private void text_ltail_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "ボートテイル長さ";
    }
    private void text_Xfplus_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "エンドカバーからフィンを機体上部へのオフセット長さ　　オフセットなければ0";
    }
    private void text_Cr_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "フィン機体付け根長さ";
    }
    private void text_Ct_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "フィン端長さ";
    }
    private void text_Cm_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "フィン前縁後退部長さ";
    }
    private void text_span_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "フィン半スパン長";
    }
    private void text_thick_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "フィン厚さ（フラッタ速度）";
    }
    private void text_rho_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "フィン材料密度（フラッタ速度）";
    }
    private void text_young_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "フィン材料ヤング率（フラッタ速度）";
    }
    private void text_poisson_Enter(object sender, EventArgs e)
    {
      DescriptionBar.Text = "フィン材料ポアソン比（フラッタ速度）";
    }

    //update
    private void text_diameter_Leave(object sender, EventArgs e)
    {
      BM.d_body = double.Parse(text_diameter.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_length_Leave(object sender, EventArgs e)
    {
      BM.l_body = double.Parse(text_length.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_lcgs_Leave(object sender, EventArgs e)
    {
      BM.lcgs = double.Parse(text__lcgs.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_lcg_Leave(object sender, EventArgs e)
    {
      BM.lcg = double.Parse(text__lcg.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_lcga_Leave(object sender, EventArgs e)
    {
      BM.lcga = double.Parse(text__lcga.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_ms_Leave(object sender, EventArgs e)
    {
      BM.ms = double.Parse(text_ms.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_m_Leave(object sender, EventArgs e)
    {
      BM.m = double.Parse(text_m.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_ma_Leave(object sender, EventArgs e)
    {
      BM.ma = double.Parse(text_ma.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_altitude_Leave(object sender, EventArgs e)
    {
      BM.fin.Altitude = double.Parse(text_altitude.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }

    private void checkBox_includeFin_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_includeFin.Checked == true)
      {
        BM.flag_include_fins = 1;
      }
      if (checkBox_includeFin.Checked == false)
      {
        BM.flag_include_fins = 0;
      }

      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }

    private void combo_nose_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (combo_nose.SelectedIndex)
      {
        case 0:
          rocket.nose = new DoubleCone(Controller_interface.d, Controller_interface.lnose);
          break;
        case 1:
          rocket.nose = new OgiveCone(Controller_interface.d, Controller_interface.lnose);
          break;

      }

      


        BM.nose.flag_nose = combo_nose.SelectedIndex;
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_lnose_Leave(object sender, EventArgs e)
    {
      BM.nose.l_nose = double.Parse(text_lnose.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }

    private void text_dtail_Leave(object sender, EventArgs e)
    {
      BM.tail.d_tail = double.Parse(text_dtail.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_ltail_Leave(object sender, EventArgs e)
    {
      BM.tail.l_tail = double.Parse(text_ltail.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }

    private void text_Xfplus_Leave(object sender, EventArgs e)
    {
      BM.fin.dX_fin = double.Parse(text_Xfplus.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_Cr_Leave(object sender, EventArgs e)
    {
      BM.fin.Cr = double.Parse(text_Cr.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_Ct_Leave(object sender, EventArgs e)
    {
      BM.fin.Ct = double.Parse(text_Ct.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_Cm_Leave(object sender, EventArgs e)
    {
      BM.fin.Cm = double.Parse(text_Cm.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_span_Leave(object sender, EventArgs e)
    {
      BM.fin.Span = double.Parse(text_span.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_thick_Leave(object sender, EventArgs e)
    {
      BM.fin.thickness = double.Parse(text_thick.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_rho_Leave(object sender, EventArgs e)
    {
      BM.fin.rho_ = double.Parse(text_rho.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_young_Leave(object sender, EventArgs e)
    {
      BM.fin.young = double.Parse(text_young.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
    }
    private void text_poisson_Leave(object sender, EventArgs e)
    {
      BM.fin.poisson = double.Parse(text_poisson.Text);
      if (flag_calc == 1)
      {
        BM.calculation();
        RocketPlot();
      }
      
    }

    //AeroDesign.out読み込み
    private void button_input_Click(object sender, EventArgs e)
    {
      input_read();

      string file_path = null;
      FilereadDialog_Parameter.InitialDirectory = Path.GetFullPath("../result");
      FilereadDialog_Parameter.Title = "inputファイルを選択";
      FilereadDialog_Parameter.CheckFileExists = true;
      FilereadDialog_Parameter.CheckPathExists = true;
      if (FilereadDialog_Parameter.ShowDialog() == DialogResult.OK) file_path = Path.GetFullPath(FilereadDialog_Parameter.FileName);

      if (File.Exists(file_path))
      {
        int i;
        string line;
        string[] array_split;
        string[] array = new string[18];
        using (StreamReader dataFile = new StreamReader(file_path))
        {
          line = dataFile.ReadLine();
          if (line == "!----------------------------------------------------------!")
          {            
            line = dataFile.ReadLine();
            line = dataFile.ReadLine();
            for (i = 0; i <= 17; i++)
            {
              line = dataFile.ReadLine();
              if (line == null) break;
              array_split = line.Split(':');
              array[i] = array_split[1];
            }
                        
            text_Xfplus.Text = array[11];
            text_Cr.Text = array[12];
            text_Ct.Text = array[13];
            text_Cm.Text = array[14];
            text_span.Text = array[15];
            text_thick.Text = array[16];
            text_rho.Text = array[17];
            
          }          
        }
      }
    }


    

    //書き換え可テキストを読み取り
    private void AllRead()
    {
      rocket.d = double.Parse(text_diameter.Text);
      rocket.l = double.Parse(text_length.Text);
      rocket._lcgs = double.Parse(text__lcgs.Text);
      rocket._lcg = double.Parse(text__lcg.Text);
      rocket._lcga = double.Parse(text__lcga.Text);
      rocket._ms = double.Parse(text_ms.Text);
      rocket._m = double.Parse(text_m.Text);
      rocket._ma = double.Parse(text_ma.Text);
      rocket.Altitude = double.Parse(text_altitude.Text);
      rocket.nose.l = double.Parse(text_lnose.Text);
      rocket.boattail.d = double.Parse(text_dtail.Text);
      rocket.boattail.l = double.Parse(text_ltail.Text);
      rocket.fin.dX_fin = double.Parse(text_Xfplus.Text);
      rocket.fin.Cr = double.Parse(text_Cr.Text);
      rocket.fin.Ct = double.Parse(text_Ct.Text);
      rocket.fin.Cm = double.Parse(text_Cm.Text);
      rocket.fin.Span = double.Parse(text_span.Text);
      rocket.fin.thickness = double.Parse(text_thick.Text);
      rocket.fin.rho = double.Parse(text_rho.Text);
      rocket.fin.young = double.Parse(text_young.Text);
      rocket.fin.poisson = double.Parse(text_poisson.Text);
    }

    

    //空力計算
    private void CalcButton_Click(object sender, EventArgs e)
    {
      AllRead();
      BM.calculation();
      RocketPlot();
      flag_calc = 1;
      button_output.Enabled = true;
    }

    private void calculation()
    {
      AllRead();
      static_stability.calculation(rocket);
      dynamic_stability.calculation(rocket);
      rocket.CenterOfGravity(checkBox_includeFin.Checked);
    }

    //ロケットをプロット
    private void RocketPlot()
    {
      int i;

      text_Vf.Text = BM.fin.Vf.ToString("F3");
      text_lcgs.Text = BM.lcgs_.ToString("F3");
      text_lcg.Text = BM.lcg_.ToString("F3");
      text_lcga.Text = BM.lcga_.ToString("F3");
      text_lcp.Text = BM.lcp.ToString("F3");
      text_CNa.Text = BM.CNa.ToString("F3");
      text_Cmq.Text = BM.Cmq.ToString("F3");
      text_Clp.Text = BM.Clp.ToString("F3");
      text_DRs.Text = BM.DRs.ToString("F3");
      text_LRs.Text = BM.LRs.ToString("F3");
      text_DR.Text = BM.DR.ToString("F3");
      text_LR.Text = BM.LR.ToString("F3");
      text_DRa.Text = BM.DRa.ToString("F3");
      text_LRa.Text = BM.LRa.ToString("F3");

      BM.point_set();

      rocketplot.Series.Clear();

      rocketplot.Series.Add("nose");
      rocketplot.Series["nose"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      rocketplot.Series["nose"].Color = Color.Red;
      for (i = 0; i <= 3; i++)
      {
        rocketplot.Series["nose"].Points.AddXY(BM.point_nose[i, 0], BM.point_nose[i, 1]);
      }
      rocketplot.Series.Add("body");
      rocketplot.Series["body"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      rocketplot.Series["body"].Color = Color.Red;
      rocketplot.Series.Add("tail");
      rocketplot.Series["tail"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      rocketplot.Series["tail"].Color = Color.Red;
      rocketplot.Series.Add("fin1");
      rocketplot.Series["fin1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      rocketplot.Series["fin1"].Color = Color.Red;
      rocketplot.Series.Add("fin2");
      rocketplot.Series["fin2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      rocketplot.Series["fin2"].Color = Color.Red;
      rocketplot.Series.Add("fin3");
      rocketplot.Series["fin3"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      rocketplot.Series["fin3"].Color = Color.Red;
      for (i = 0; i <= 4; i++)
      {
        rocketplot.Series["body"].Points.AddXY(BM.point_body[i, 0], BM.point_body[i, 1]);
        rocketplot.Series["tail"].Points.AddXY(BM.point_tail[i, 0], BM.point_tail[i, 1]);
        rocketplot.Series["fin1"].Points.AddXY(BM.point_fin1[i, 0], BM.point_fin1[i, 1]);
        rocketplot.Series["fin2"].Points.AddXY(BM.point_fin2[i, 0], BM.point_fin2[i, 1]);
      }
      rocketplot.Series["fin3"].Points.AddXY(BM.point_fin3[0, 0], BM.point_fin3[0, 1]);
      rocketplot.Series["fin3"].Points.AddXY(BM.point_fin3[1, 0], BM.point_fin3[1, 1]);

      rocketplot.Series.Add("lcg");
      rocketplot.Series["lcg"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
      rocketplot.Series["lcg"].MarkerColor = Color.Black;
      rocketplot.Series["lcg"].Points.AddXY(BM.lcg_, 0.0);
      rocketplot.Series.Add("lcp");
      rocketplot.Series["lcp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
      rocketplot.Series["lcp"].MarkerColor = Color.Red;
      rocketplot.Series["lcp"].Points.AddXY(BM.lcp, 0.0);

      for (i = 0; i <= 7; i++)
      {
        rocketplot.Series[i].IsVisibleInLegend = false;
      }
    }

    //output
    private void button_output_Click(object sender, EventArgs e)
    {
      static_stability.calculation(rocket);
      dynamic_stability.calculation(rocket);
      rocket.CenterOfGravity(checkBox_includeFin.Checked);

      Controller_interface.ms = rocket.ms;
      Controller_interface.lcgs = rocket.lcgs;
      Controller_interface.lcp = rocket.lcp;
      Controller_interface.CNa = rocket.CNa;
      Controller_interface.Cmq = rocket.Cmq;
      Controller_interface.Clp = rocket.Clp;

      using (StreamWriter DataFile = new StreamWriter("../result/AeroDesing.out"))
      {
        DataFile.WriteLine("!----------------------------------------------------------!");
        DataFile.WriteLine("!----------------ForRocket-Aero Design Result--------------!");
        DataFile.WriteLine("!----------------------------------------------------------!");
        DataFile.WriteLine("Body Diameter [mm] :" + text_diameter.Text);
        DataFile.WriteLine("Body Length [mm] :" + text_length.Text);
        DataFile.WriteLine("Dry Center of Gravity [mm] :" + text__lcgs.Text);
        DataFile.WriteLine("All Center of Gravity [mm] :" + text__lcg.Text);
        DataFile.WriteLine("Burn Out Center of Gravity [mm] :" + text__lcga.Text);
        DataFile.WriteLine("Dry Body Mass [kg] :" + text_ms.Text);
        DataFile.WriteLine("All Body Mass [kg] :" + text_m.Text);
        DataFile.WriteLine("Burn Out Body Mass [kg] :" + text_ma.Text);
        DataFile.WriteLine("NoseCone Length [mm] :" + text_lnose.Text);
        DataFile.WriteLine("BoatTail Diameter [mm] :" + text_dtail.Text);
        DataFile.WriteLine("BoatTail Length [mm] :" + text_ltail.Text);
        DataFile.WriteLine("Fin Offset [mm] :" + text_Xfplus.Text);
        DataFile.WriteLine("Fin Root Chord [mm] :" + text_Cr.Text);
        DataFile.WriteLine("Fin Tip Chord [mm] :" + text_Ct.Text);
        DataFile.WriteLine("Fin Leading Chord [mm] :" + text_Cm.Text);
        DataFile.WriteLine("Fin Half Span [mm] :" + text_span.Text);
        DataFile.WriteLine("Fin Thickness [mm] :" + text_thick.Text);
        DataFile.WriteLine("Fin Dencity [m/s^3] :" + text_rho.Text);
        DataFile.WriteLine("Fin Mass [kg] :" + BM.fin.m_fin.ToString());
        DataFile.WriteLine("Fin Center of Gravity [m] :" + (BM.fin.lcg_fin / 1000.0).ToString());
        DataFile.WriteLine("Center of Pressure [m] :" + (double.Parse(text_lcp.Text) / 1000.0).ToString());
        DataFile.WriteLine("Normal Force Coefficient [-] :" + text_CNa.Text);
        DataFile.WriteLine("Pitch Damping Moment Coefficient [-] :" + text_Cmq.Text);
        DataFile.WriteLine("Roll Damping Moment Coefficient [-] :" + text_Clp.Text);
        DataFile.WriteLine("All Diameter Ratio [-] :" + text_DR.Text);
        DataFile.WriteLine("All Length Ratio [-] :" + text_LR.Text);
        DataFile.WriteLine("Burn Out Diameter Ratio [-] :" + text_DRa.Text);
        DataFile.WriteLine("Burn Out Length Ratio [-] :" + text_LRa.Text);
      }

      this.Close();
    }
        
  }

  public class Rocket
  {
    public Nosecone nose;
    public Fin fin;
    public Boattail boattail;

    public double l;
    public double d;
    public double ms;
    public double m;
    public double ma;
    public double lcgs;
    public double lcg;
    public double lcga;
    public double lcp;
    public double CNa;
    public double Cmq;
    public double Clp;

    public double _lcgs, _lcg, _lcga; // 初期保持用重心
    public double _ms, _m, _ma; // 初期保持用質量
    public double Css, Cs, Csa; // 直径比
    public double Fsts, Fst, Fsta; // 全長比

    public double Altitude;

    public Rocket(ForRocket_FrontEnd.AeroDesign_interface parameter)
    {
      l = parameter.l;
      d = parameter.d;
      _ms = parameter.ms;
      _m = parameter.m;
      _ma = parameter.ma;
      _lcgs = parameter.lcgs;
      _lcg = parameter.lcg;
      _lcga = parameter.lcga;
      
      fin = new Fin(parameter.t_fin, parameter.rho_fin);
      boattail = new Boattail(parameter.dtail, parameter.ltail);
    }

    public void CenterOfGravity(bool flag_include_fin)
    {
      if (flag_include_fin)
      {
        lcgs = _lcgs;
        lcg = _lcg;
        lcga = _lcga;
      }
      else
      {
        lcgs = (_lcgs * _ms + fin.lcg_fin * fin.m_fin) / (_ms + fin.m_fin);
        lcg = (_lcg * _m + fin.lcg_fin * fin.m_fin) / (_m + fin.m_fin);
        lcga = (_lcga * _ma + fin.lcg_fin * fin.m_fin) / (_ma + fin.m_fin);
      }
      
      Css = (lcp - lcgs) / d;
      Cs = (lcp - lcg) / d;
      Csa = (lcp - lcga) / d;
      Fsts = (lcp - lcgs) / l * 100.0;
      Fst = (lcp - lcg) / l * 100.0;
      Fsta = (lcp - lcga) / l * 100.0;
    }
  }

  public class Nosecone
  {
    public double l;
    public double LD;
    public double Ccp; // ノーズ形状による圧力中心係数
     
    public double CNa;
    public double lcp;

    public Nosecone(double d_interface, double l_interface)
    {
      l = l_interface;
      LD = l / d_interface;
    }

    public virtual void barrowman_nose()
    {
    }
    
  }

  public class DoubleCone : Nosecone
  {
    public DoubleCone(double d_interface, double l_interface) : base(d_interface, l_interface)
    {
    }

    public override void barrowman_nose()
    {
      Ccp = 2.0 / 3.0;
      CNa = 2.0;
      lcp = l * Ccp;
    }
  }
  public class OgiveCone : Nosecone
  {
    public OgiveCone(double d_interface, double l_interface) : base(d_interface, l_interface)
    {
    }

    public override void barrowman_nose()
    {
      Ccp = 1.0 - ((8.0 * Math.Pow(LD, 2) / 3.0) + (Math.Pow(4.0 * Math.Pow(LD, 2) - 1.0, 2) / 4.0) - (((4.0 * Math.Pow(LD, 2) - 1.0) * Math.Pow(4.0 * Math.Pow(LD, 2) + 1.0, 2) / (16.0 * LD)) * Math.Asin(4.0 * LD / (4.0 * Math.Pow(LD, 2) + 1.0))));
      CNa = 2.0;
      lcp = l * Ccp;
    }    
  }
  
  public class Fin
  {
    public double X_fin; // 先端からフィン先端までの距離
    public double dX_fin; // エンドカバー後端からフィン後端までのかさ増し距離.基本0
    public double Cr;
    public double Ct;
    public double Cm;
    public double Span;
    public double kai;
    public double l; // CrとCtの二分点間の距離
    public double A_fin; // 翼面積
    public double AR; // アスペクト比
    public double ramda; // テーパ比
    public double thickness;
    public double rho;
    public double young, poisson, shear;
    public double m_fin;
    public double lcg_fin;
    
    public double Pa, Cs;
    public double Vf;

    public double CNa_fin; //フィンのみ揚力傾斜
    public double Kfb; //フィン-ボディ干渉係数
    public double CNa; //フィン-ボディ揚力傾斜
    public double lcp;

    public Fin(double t_interface,double rho_interface)
    {
      thickness = t_interface;
      rho = rho_interface;
    }

    public void barrowman_fin(double d_body, double l_body, double l_tail)
    {
      X_fin = l_body - (Cr + l_tail + dX_fin);
      kai = utility.deg2rad(90.0) - Math.Atan2(Span, Cm);
      l = Math.Sqrt(Math.Pow((0.5 * Cr) - (0.5 * Ct), 2) + (Span * Span));
      A_fin = (Cr + Ct) * Span * 0.5 * Math.Pow(10, -6); // m^2
      AR = Math.Pow(Span / 1000.0, 2) / A_fin;
      ramda = Ct / Cr;
      shear = young / (2.0 * (1.0 + poisson));
      m_fin = 4.0 * (rho * 1000.0 * A_fin * (thickness / 1000.0)); // 4枚分
      lcg_fin = X_fin + (Cr - ((Ct * Ct + Cr * Ct + Cr * Cr) / (3.0 * (Cr + Ct))));

      CNa_fin = 4.0 * 4.0 * Math.Pow(Span / d_body, 2) / (1.0 + Math.Sqrt(1.0 + Math.Pow(2.0 * l / (Cr + Ct), 2)));
      Kfb = 1.0 + 0.5 * d_body / (0.5 * d_body + Span);
      CNa = CNa_fin * Kfb;
      lcp = X_fin + (Cm * (Cr + 2.0 * Ct) / (3.0 * (Cr + Ct))) + (Cr + Ct - (Cr * Ct / (Cr + Ct))) / 6.0;
     }

    public void flutter_fin(double Altitude)
    {
      standard_atmosphere atmosphere = new standard_atmosphere();

      Pa = atmosphere.getPressure(Altitude);
      Cs = atmosphere.getSoundofSpeed(Altitude);
      Vf = Cs * Math.Sqrt((shear * Math.Pow(10, 9)) / ((1.337 * Math.Pow(AR, 3) * Pa * (ramda + 1.0)) / (2.0 * (AR + 2.0) * Math.Pow(thickness / Cr, 3))));
    }
    
  }

  public class Boattail
  {
    public double d;
    public double l;
    public double Xtail;

    public double CNa;
    public double lcp;

    public Boattail(double d_interdace, double l_interface)
    {
      d = d_interdace;
      l = l_interface;
    }

    public void barrowman_boattail(double l_body,double d_body)
    {
      Xtail = l_body - l;
      if (d == 0.0 || l == 0.0)
      {
        CNa = 0.0;
        lcp = 0.0;
      }
      else
      {
        CNa = 2.0 * (Math.Pow(d / d_body, 2) - 1.0);
        lcp = Xtail + (l / 3.0) * (1.0 + ((1.0 - (d_body / d)) / (1.0 - Math.Pow(d_body / d, 2))));
      }
    }
  }
  
  public class static_stability
  {
    public void calculation(Rocket rocket)
    {
      Barrowman_Method barroeman = new Barrowman_Method();
      barroeman.barrowman(rocket);
    }
  }

  public class Barrowman_Method
  { 
    public void barrowman(Rocket rocket)
    {
      rocket.nose.barrowman_nose();
      rocket.fin.barrowman_fin(rocket.d, rocket.l, rocket.boattail.l);
      rocket.boattail.barrowman_boattail(rocket.l, rocket.d);
      
      rocket.CNa = rocket.nose.CNa + rocket.fin.CNa + rocket.boattail.CNa;
      rocket.lcp = (rocket.nose.CNa * rocket.nose.lcp + rocket.fin.CNa * rocket.fin.lcp + rocket.boattail.CNa * rocket.boattail.lcp) / rocket.CNa;
            
    }   

  }
  
  public class dynamic_stability
  {    
    public void calculation(Rocket rocket)
    {
      ApparentMass_Method apparentmass = new ApparentMass_Method();
      apparentmass.apparentmass(rocket);
    }
  }

  public class ApparentMass_Method
  {
    public void apparentmass(Rocket rocket)
    {
      rocket.Cmq = 0.5 * (Damping_PitchYaw(rocket.lcg, rocket.l, rocket.nose, rocket.fin, rocket.boattail) + Damping_PitchYaw(rocket.lcga, rocket.l, rocket.nose, rocket.fin, rocket.boattail));
      rocket.Clp = Damping_Roll(rocket.fin.AR);
    }

    private double Damping_PitchYaw(double lcg, double l_body, Nosecone nose, Fin fin, Boattail boattail)
    {
      return -4.0 * ((0.5 * nose.CNa * Math.Pow((nose.lcp - lcg) / l_body, 2)) + (0.5 * fin.CNa * Math.Pow((fin.lcp - lcg) / l_body, 2)) + (0.5 * boattail.CNa * Math.Pow((boattail.lcp - lcg) / l_body, 2)));
    }

    private double Damping_Roll(double AR)
    {
      return -AR / (2.0 * Math.PI);
    }
  }

  public class standard_atmosphere
  {
    double[,] table = new double[101, 3]{ { 0 ,	101325  ,	340.294 }	,
                                          { 100 ,	100129  ,	339.91  }	,
                                          { 200 ,	98945.3 ,	339.526 }	,
                                          { 300 ,	97772.6 ,	339.141 }	,
                                          { 400 ,	96611.1 ,	338.755 }	,
                                          { 500 ,	95460.8 ,	338.37  }	,
                                          { 600 ,	94321.7 ,	337.983 }	,
                                          { 700 ,	93193.6 ,	337.597 }	,
                                          { 800 ,	92076.4 ,	337.21  }	,
                                          { 900 ,	90970.1 ,	336.822 }	,
                                          { 1000  ,	89874.6 ,	336.434 }	,
                                          { 1100  ,	88789.8 ,	336.046 }	,
                                          { 1200  ,	87715.6 ,	335.657 }	,
                                          { 1300  ,	86651.9 ,	335.267 }	,
                                          { 1400  ,	85598.8 ,	334.878 }	,
                                          { 1500  ,	84556 ,	334.487 }	,
                                          { 1600  ,	83523.5 ,	334.097 }	,
                                          { 1700  ,	82501.3 ,	333.705 }	,
                                          { 1800  ,	81489.2 ,	333.314 }	,
                                          { 1900  ,	80487.2 ,	332.922 }	,
                                          { 2000  ,	79495.2 ,	332.529 }	,
                                          { 2100  ,	78513.1 ,	332.136 }	,
                                          { 2200  ,	77540.9 ,	331.743 }	,
                                          { 2300  ,	76578.4 ,	331.349 }	,
                                          { 2400  ,	75625.7 ,	330.954 }	,
                                          { 2500  ,	74682.5 ,	330.56  }	,
                                          { 2600  ,	73748.9 ,	330.164 }	,
                                          { 2700  ,	72824.8 ,	329.768 }	,
                                          { 2800  ,	71910.1 ,	329.372 }	,
                                          { 2900  ,	71004.7 ,	328.975 }	,
                                          { 3000  ,	70108.5 ,	328.578 }	,
                                          { 3100  ,	69221.6 ,	328.18  }	,
                                          { 3200  ,	68343.7 ,	327.782 }	,
                                          { 3300  ,	67474.9 ,	327.383 }	,
                                          { 3400  ,	66615 ,	326.984 }	,
                                          { 3500  ,	65764.1 ,	326.584 }	,
                                          { 3600  ,	64921.9 ,	326.184 }	,
                                          { 3700  ,	64088.6 ,	325.784 }	,
                                          { 3800  ,	63263.9 ,	325.382 }	,
                                          { 3900  ,	62447.8 ,	324.981 }	,
                                          { 4000  ,	61640.2 ,	324.579 }	,
                                          { 4100  ,	60841.2 ,	324.176 }	,
                                          { 4200  ,	60050.5 ,	323.773 }	,
                                          { 4300  ,	59268.2 ,	323.369 }	,
                                          { 4400  ,	58494.2 ,	322.965 }	,
                                          { 4500  ,	57728.3 ,	322.56  }	,
                                          { 4600  ,	56970.6 ,	322.155 }	,
                                          { 4700  ,	56221 ,	321.75  }	,
                                          { 4800  ,	55479.4 ,	321.343 }	,
                                          { 4900  ,	54745.7 ,	320.937 }	,
                                          { 5000  ,	54019.9 ,	320.529 }	,
                                          { 5100  ,	53301.9 ,	320.122 }	,
                                          { 5200  ,	52591.7 ,	319.713 }	,
                                          { 5300  ,	51889.1 ,	319.305 }	,
                                          { 5400  ,	51194.2 ,	318.895 }	,
                                          { 5500  ,	50506.8 ,	318.486 }	,
                                          { 5600  ,	49826.9 ,	318.075 }	,
                                          { 5700  ,	49154.5 ,	317.664 }	,
                                          { 5800  ,	48489.4 ,	317.253 }	,
                                          { 5900  ,	47831.6 ,	316.841 }	,
                                          { 6000  ,	47181 ,	316.428 }	,
                                          { 6100  ,	46537.7 ,	316.015 }	,
                                          { 6200  ,	45901.4 ,	315.602 }	,
                                          { 6300  ,	45272.3 ,	315.188 }	,
                                          { 6400  ,	44650.1 ,	314.773 }	,
                                          { 6500  ,	44034.8 ,	314.358 }	,
                                          { 6600  ,	43426.5 ,	313.942 }	,
                                          { 6700  ,	42825 ,	313.526 }	,
                                          { 6800  ,	42230.2 ,	313.109 }	,
                                          { 6900  ,	41642.2 ,	312.692 }	,
                                          { 7000  ,	41060.7 ,	312.274 }	,
                                          { 7100  ,	40485.9 ,	311.855 }	,
                                          { 7200  ,	39917.6 ,	311.436 }	,
                                          { 7300  ,	39355.8 ,	311.016 }	,
                                          { 7400  ,	38800.4 ,	310.596 }	,
                                          { 7500  ,	38251.4 ,	310.175 }	,
                                          { 7600  ,	37708.7 ,	309.754 }	,
                                          { 7700  ,	37172.2 ,	309.332 }	,
                                          { 7800  ,	36642 ,	308.909 }	,
                                          { 7900  ,	36117.8 ,	308.486 }	,
                                          { 8000  ,	35599.8 ,	308.063 }	,
                                          { 8100  ,	35087.8 ,	307.638 }	,
                                          { 8200  ,	34581.8 ,	307.214 }	,
                                          { 8300  ,	34081.7 ,	306.788 }	,
                                          { 8400  ,	33587.5 ,	306.362 }	,
                                          { 8500  ,	33099 ,	305.935 }	,
                                          { 8600  ,	32616.4 ,	305.508 }	,
                                          { 8700  ,	32139.5 ,	305.08  }	,
                                          { 8800  ,	31668.2 ,	304.652 }	,
                                          { 8900  ,	31202.6 ,	304.223 }	,
                                          { 9000  ,	30742.5 ,	303.793 }	,
                                          { 9100  ,	30287.9 ,	303.363 }	,
                                          { 9200  ,	29838.7 ,	302.932 }	,
                                          { 9300  ,	29395 ,	302.501 }	,
                                          { 9400  ,	28956.7 ,	302.069 }	,
                                          { 9500  ,	28523.6 ,	301.636 }	,
                                          { 9600  ,	28095.8 ,	301.203 }	,
                                          { 9700  ,	27673.2 ,	300.769 }	,
                                          { 9800  ,	27255.8 ,	300.334 }	,
                                          { 9900  ,	26843.5 ,	299.899 }	,
                                          { 10000 ,	26436.3 ,	299.463 } };

    public double getPressure(double Altitude)
    {
      int i;
      double delta;
      double Pressure = 0.0;

      for(i = 0;i <= 100;i++)
      {
        delta = Altitude - table[i, 0];
        if (delta == 0.0)
        {
          Pressure = table[i, 1];
        }
        else if (delta < 0.0)
        {
          Pressure = table[i - 1, 1] + (table[i, 1] - table[i - 1, 1]) * (Altitude - table[i - 1, 0]) / (table[i, 0] - table[i - 1, 0]);
        }
      }

      return Pressure;
    }

    public double getSoundofSpeed(double Altitude)
    {
      int i;
      double delta;
      double Cs = 0.0;

      for (i = 0; i <= 100; i++)
      {
        delta = Altitude - table[i, 0];
        if (delta == 0.0)
        {
          Cs = table[i, 2];
        }
        else if (delta < 0.0)
        {
          Cs = table[i - 1, 2] + (table[i, 2] - table[i - 1, 2]) * (Altitude - table[i - 1, 0]) / (table[i, 0] - table[i - 1, 0]);
        }
      }

      return Cs;
    }

  }

  public class Plotter
  {
    // グラフ用
    public double[,] point_nose = new double[4, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public double[,] point_body = new double[5, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public double[,] point_tail = new double[5, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public double[,] point_fin1 = new double[5, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public double[,] point_fin2 = new double[5, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    public double[,] point_fin3 = new double[2, 2] { { 0, 0 }, { 0, 0 } };
    public void point_set(Rocket rocket)
    {
      point_nose[0, 0] = 0.0; point_nose[0, 1] = 0.0;
      point_nose[1, 0] = rocket.nose.l; point_nose[1, 1] = rocket.d * 0.5;
      point_nose[2, 0] = rocket.nose.l; point_nose[2, 1] = -rocket.d * 0.5;
      point_nose[3, 0] = point_nose[0, 0]; point_nose[3, 1] = point_nose[0, 1];

      point_body[0, 0] = rocket.nose.l; point_body[0, 1] = rocket.d * 0.5;
      point_body[1, 0] = rocket.l - rocket.boattail.l; point_body[1, 1] = rocket.d * 0.5;
      point_body[2, 0] = rocket.l - rocket.boattail.l; point_body[2, 1] = -rocket.d * 0.5;
      point_body[3, 0] = rocket.nose.l; point_body[3, 1] = -rocket.d * 0.5;
      point_body[4, 0] = point_body[0, 0]; point_body[4, 1] = point_body[0, 1];

      point_tail[0, 0] = rocket.l - rocket.boattail.l; point_tail[0, 1] = rocket.d * 0.5;
      point_tail[1, 0] = rocket.l; point_tail[1, 1] = 0.5 * rocket.boattail.d;
      point_tail[2, 0] = rocket.l; point_tail[2, 1] = -0.5 * rocket.boattail.d;
      point_tail[3, 0] = rocket.l - rocket.boattail.l; point_tail[3, 1] = -rocket.d * 0.5;
      point_tail[4, 0] = point_tail[0, 0]; point_tail[4, 1] = point_body[0, 1];

      point_fin1[0, 0] = rocket.fin.X_fin; point_fin1[0, 1] = rocket.d * 0.5;
      point_fin1[1, 0] = rocket.fin.Cr + rocket.fin.X_fin; point_fin1[1, 1] = rocket.fin.Span + rocket.d * 0.5;
      point_fin1[2, 0] = rocket.fin.Cm + rocket.fin.Ct + rocket.fin.X_fin; point_fin1[2, 1] = rocket.fin.Span + rocket.d * 0.5;
      point_fin1[3, 0] = rocket.fin.Cm + rocket.fin.X_fin; point_fin1[3, 1] = rocket.fin.Span + rocket.d * 0.5;
      point_fin1[4, 0] = point_fin1[0, 0]; point_fin1[4, 1] = point_fin1[0, 1];

      point_fin2[0, 0] = point_fin1[0, 0]; point_fin2[0, 1] = -point_fin1[0, 1];
      point_fin2[1, 0] = point_fin1[1, 0]; point_fin2[1, 1] = -point_fin1[1, 1];
      point_fin2[2, 0] = point_fin1[2, 0]; point_fin2[2, 1] = -point_fin1[2, 1];
      point_fin2[3, 0] = point_fin1[3, 0]; point_fin2[3, 1] = -point_fin1[3, 1];
      point_fin2[4, 0] = point_fin2[0, 0]; point_fin2[4, 1] = point_fin2[0, 1];

      point_fin3[0, 0] = point_fin1[0, 0];
      point_fin3[1, 0] = point_fin1[1, 0];
      
    }    
  }

  public static class utility
  {
    public static double deg2rad(double deg)
    {
      return deg * Math.PI / 180.0;
    }

    
  }
}
