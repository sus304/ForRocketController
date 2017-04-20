using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LandingRangeViewer
{
  public partial class LandingRangeViewer : Form
  {
    LandingRange landingrange = new LandingRange();
    int flag_LaunchPoint = 999;
    int flag_LandingStatus = 0;

    public LandingRangeViewer()
    {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      LaunchPoint_combo.Items.Add("Noshiro_Asauchi_Land");
      LaunchPoint_combo.Items.Add("Noshiro_Ochiai_Sea_3km");
      LaunchPoint_combo.Items.Add("Noshiro_Ochiai_Sea_4.5km");
      LaunchPoint_combo.Items.Add("Taiki_Land");

      LandingStatus_combo.Items.Add("Hard");
      LandingStatus_combo.Items.Add("Soft");

      //色指定
      Graph_Range.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
      Graph_Range.BorderlineColor = Color.Black;
      //グラフminmaxの指定=>射点に合わせて変えるのでここのはあまり意味なし
      Graph_Range.ChartAreas[0].AxisX.Minimum = -4000.0;
      Graph_Range.ChartAreas[0].AxisX.Maximum = 4000.0;
      Graph_Range.ChartAreas[0].AxisX.Interval = 100.0;
      Graph_Range.ChartAreas[0].AxisY.Minimum = -4000.0;
      Graph_Range.ChartAreas[0].AxisY.Maximum = 4000.0;
      Graph_Range.ChartAreas[0].AxisY.Interval = 100.0;
      //サイズ指定
      Graph_Range.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
      Graph_Range.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
      Graph_Range.ChartAreas[0].InnerPlotPosition.Auto = false;
      Graph_Range.ChartAreas[0].InnerPlotPosition.Width = 100;
      Graph_Range.ChartAreas[0].InnerPlotPosition.Height = 100;
      Graph_Range.ChartAreas[0].InnerPlotPosition.X = 0;
      Graph_Range.ChartAreas[0].InnerPlotPosition.Y = 0;
      Graph_Range.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
      Graph_Range.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
      Graph_Range.ChartAreas[0].Position.Height = 100;
      Graph_Range.ChartAreas[0].Position.Width = 100;

      textBox_ResultDirectory.Text = System.IO.Path.GetFullPath("../result");
    }

    //LandingRangeファイルのRead
    private void LRopen_button_Click(object sender, EventArgs e)
    {
      string file_path = null;
      int i;

      LandingRangeFile.InitialDirectory = System.IO.Path.GetFullPath("../result");
      LandingRangeFile.Title = "Select Landing Range File";
      LandingRangeFile.CheckFileExists = true;
      LandingRangeFile.CheckPathExists = true;
      if (LandingRangeFile.ShowDialog() == DialogResult.OK) file_path = System.IO.Path.GetFullPath(LandingRangeFile.FileName);

      if (file_path != null)
      {
        System.IO.StreamReader dataFile;
        string line;
        string[] linearray;
        file_textbox.Text = file_path;
        dataFile = new System.IO.StreamReader(file_path);
        for (i = 0; i <= 55; i++)
        {
          line = dataFile.ReadLine();
          if (line == null) break;
          linearray = line.Split(',');
          landingrange.setValue(i, linearray);
        }
        dataFile.Close();
        Plot(flag_LandingStatus);
      }
    }

    //射点選択イベント
    //画像は正方形であること
    private void LaunchPoint_combo_SelectedIndexChanged(object sender, EventArgs e)
    {
      flag_LaunchPoint = LaunchPoint_combo.SelectedIndex;

      switch (flag_LaunchPoint)
      {
        case 0:
          NoshiroLand3rd();
          break;
        case 1:
          NoshiroSea3km();
          break;
        case 2:
          NoshiroSea45km();
          break;
        case 3:
          TaikiLand();
          break;
      }
    }

    //能代陸.第3鉱滓堆積場
    public void NoshiroLand3rd()
    {
      double PixelScale;
      double ScaleFactor, ScaleFactor_;
      int[] launchpoint = new int[2];

      launchpoint[0] = 256;
      launchpoint[1] = 366;
      ScaleFactor = 100.0 / 58.0; // m/px

      Graph_Range.BackImage = "NoshiroLand";
      Graph_Range.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;

      //Width =>グラフminmaxの指定
      PixelScale = (double)Graph_Range.Size.Width / (double)ForRocket_FrontEnd.Properties.Resources.NoshiroLand.Width;
      ScaleFactor_ = ScaleFactor / PixelScale;
      Graph_Range.ChartAreas[0].AxisX.Minimum = -(double)launchpoint[0] * PixelScale * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisX.Maximum = ((ForRocket_FrontEnd.Properties.Resources.NoshiroLand.Width * PixelScale) - ((double)launchpoint[0] * PixelScale)) * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisX.Interval = 50.0;
      //Height =>グラフminmaxの指定
      PixelScale = (double)Graph_Range.Size.Height / (double)ForRocket_FrontEnd.Properties.Resources.NoshiroLand.Height;
      ScaleFactor_ = ScaleFactor / PixelScale;
      Graph_Range.ChartAreas[0].AxisY.Minimum = -((ForRocket_FrontEnd.Properties.Resources.NoshiroLand.Height * PixelScale) - ((double)launchpoint[1] * PixelScale)) * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisY.Maximum = (double)launchpoint[1] * PixelScale * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisY.Interval = 50.0;

    }

    //能代海.保安円3.0km
    public void NoshiroSea3km()
    {
      double PixelScale;
      double ScaleFactor, ScaleFactor_;
      int[] launchpoint = new int[2];

      launchpoint[0] = 890;
      launchpoint[1] = 655;
      ScaleFactor = 500.0 / 129.0; // m/px

      Graph_Range.BackImage = "_3km";
      Graph_Range.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;

      //Width =>グラフminmaxの指定
      PixelScale = (double)Graph_Range.Size.Width / (double)ForRocket_FrontEnd.Properties.Resources._3km.Width;
      ScaleFactor_ = ScaleFactor / PixelScale;
      Graph_Range.ChartAreas[0].AxisX.Minimum = -(double)launchpoint[0] * PixelScale * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisX.Maximum = ((ForRocket_FrontEnd.Properties.Resources._3km.Width * PixelScale) - ((double)launchpoint[0] * PixelScale)) * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisX.Interval = 200.0;
      //Height =>グラフminmaxの指定
      PixelScale = (double)Graph_Range.Size.Height / (double)ForRocket_FrontEnd.Properties.Resources._3km.Height;
      ScaleFactor_ = ScaleFactor / PixelScale;
      Graph_Range.ChartAreas[0].AxisY.Minimum = -((ForRocket_FrontEnd.Properties.Resources._3km.Height * PixelScale) - ((double)launchpoint[1] * PixelScale)) * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisY.Maximum = (double)launchpoint[1] * PixelScale * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisY.Interval = 200.0;


    }

    //能代海.保安円4.5km
    public void NoshiroSea45km()
    {
      double PixelScale;
      double ScaleFactor,ScaleFactor_;
      int[] launchpoint = new int[2];

      launchpoint[0] = 900;
      launchpoint[1] = 658;
      ScaleFactor = 1000.0 / 84.0; // m/px

      Graph_Range.BackImage = "_4_5km";
      Graph_Range.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;

      //Width =>グラフminmaxの指定
      PixelScale = (double)Graph_Range.Size.Width / (double)ForRocket_FrontEnd.Properties.Resources._4_5km.Width;
      ScaleFactor_ = ScaleFactor / PixelScale;
      Graph_Range.ChartAreas[0].AxisX.Minimum = -(double)launchpoint[0] * PixelScale * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisX.Maximum = ((ForRocket_FrontEnd.Properties.Resources._4_5km.Width * PixelScale) - ((double)launchpoint[0] * PixelScale)) * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisX.Interval = 200.0;
      //Height =>グラフminmaxの指定
      PixelScale = (double)Graph_Range.Size.Height / (double)ForRocket_FrontEnd.Properties.Resources._4_5km.Height;
      ScaleFactor_ = ScaleFactor / PixelScale;
      Graph_Range.ChartAreas[0].AxisY.Minimum = -((ForRocket_FrontEnd.Properties.Resources._4_5km.Height * PixelScale) - ((double)launchpoint[1] * PixelScale)) * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisY.Maximum = (double)launchpoint[1] * PixelScale * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisY.Interval = 200.0;


    }

    //大樹陸
    public void TaikiLand()
    {
      double PixelScale;
      double ScaleFactor, ScaleFactor_;
      int[] launchpoint = new int[2];

      launchpoint[0] = 208;
      launchpoint[1] = 483;
      ScaleFactor = 200.0 / 70.0; // m/px

      Graph_Range.BackImage = "Taiki_Land";
      Graph_Range.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;

      //Width =>グラフminmaxの指定
      PixelScale = (double)Graph_Range.Size.Width / (double)ForRocket_FrontEnd.Properties.Resources.Taiki_Land.Width;
      ScaleFactor_ = ScaleFactor / PixelScale;
      Graph_Range.ChartAreas[0].AxisX.Minimum = -(double)launchpoint[0] * PixelScale * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisX.Maximum = ((ForRocket_FrontEnd.Properties.Resources.Taiki_Land.Width * PixelScale) - ((double)launchpoint[0] * PixelScale)) * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisX.Interval = 50.0;
      //Height =>グラフminmaxの指定
      PixelScale = (double)Graph_Range.Size.Height / (double)ForRocket_FrontEnd.Properties.Resources.Taiki_Land.Height;
      ScaleFactor_ = ScaleFactor / PixelScale;
      Graph_Range.ChartAreas[0].AxisY.Minimum = -((ForRocket_FrontEnd.Properties.Resources.Taiki_Land.Height * PixelScale) - ((double)launchpoint[1] * PixelScale)) * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisY.Maximum = (double)launchpoint[1] * PixelScale * ScaleFactor_;
      Graph_Range.ChartAreas[0].AxisY.Interval = 50.0;

    }

    //着地選択イベント
    private void LandingStatus_combo_SelectedIndexChanged(object sender, EventArgs e)
    {
      flag_LandingStatus = LandingStatus_combo.SelectedIndex;
      Plot(flag_LandingStatus);
    }

    //分散プロット
    public void Plot(int flag_landingstatus)
    {
      int i, k;
      int landingstatus_x = 0, landingstatus_y = 1;
      double[] pos = new double[2];
      Graph_Range.Series.Clear();
      Graph_Range.Series.Add("1m/s");
      Graph_Range.Series.Add("2m/s");
      Graph_Range.Series.Add("3m/s");
      Graph_Range.Series.Add("4m/s");
      Graph_Range.Series.Add("5m/s");
      Graph_Range.Series.Add("6m/s");
      Graph_Range.Series.Add("7m/s");

      if (flag_landingstatus == 0)
      {
        landingstatus_x = 0;
        landingstatus_y = 1;
      }
      if (flag_landingstatus == 1)
      {
        landingstatus_x = 2;
        landingstatus_y = 3;
      }

      for (i = 0; i <= 55; i++)
      {
        k = (int)Math.Floor((double)i / 8.0);
        if (i % 8 == 0)
        {
          Graph_Range.Series[k].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
          Graph_Range.Series[k].Color = Color.Orange;

          if (i != 0)
          {
            pos = landingrange.getValue(i - 8, landingstatus_x, landingstatus_y);
            Graph_Range.Series[k-1].Points.AddXY(pos[0], pos[1]);
          }
        }

        pos = landingrange.getValue(i, landingstatus_x, landingstatus_y);
        Graph_Range.Series[k].Points.AddXY(pos[0], pos[1]);
      }
      pos = landingrange.getValue(i - 8, landingstatus_x, landingstatus_y);
      Graph_Range.Series[6].Points.AddXY(pos[0], pos[1]);

      for (i = 0; i <= 6; i++)
      {
        Graph_Range.Series[i].IsVisibleInLegend = false;
      }

      return;
    }

    //分散画像保存
    private void button_save_Click(object sender, EventArgs e)
    {
      string filename;
      Bitmap bmp = new Bitmap(Graph_Range.Width, Graph_Range.Height);
      Graph_Range.DrawToBitmap(bmp, new Rectangle(0, 0, Graph_Range.Width, Graph_Range.Height));
      filename = System.IO.Path.GetFullPath("../result") + "/" + LaunchPoint_combo.SelectedItem.ToString() + "_" + LandingStatus_combo.SelectedItem.ToString() + ".png";
      bmp.Save(filename);
      bmp.Dispose();
    }

    //result directory edit
    private void button_result_edit_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog edit_ResultDirectory = new FolderBrowserDialog();
      edit_ResultDirectory.Description = "Select Result Directory";
      edit_ResultDirectory.RootFolder = Environment.SpecialFolder.Desktop;
      edit_ResultDirectory.SelectedPath = "";
      edit_ResultDirectory.ShowNewFolderButton = true;

      if (edit_ResultDirectory.ShowDialog(this) == DialogResult.OK)
      {
        textBox_ResultDirectory.Text = edit_ResultDirectory.SelectedPath;
      }
    }
    private string max_value(System.IO.StreamReader dataFile)
    {
      int i, j;
      int count;
      string line;
      string[] linearray;
      double[] linevalue;
      double max;
      max = 0.0;

      for (i = 0; i <= 7; i++)
      {
        line = dataFile.ReadLine();
        if (line == null) break;
        linearray = line.Split(',');
        count = linearray.Length;
        linevalue = new double[count];
        for (j = 0; j <= count-1; j++)
        {
          linevalue[j] = double.Parse(linearray[j]);
        }
        if (linevalue.Max() > max)
        {
          max = linevalue.Max();
        }
      }

      return max.ToString("F3");
    }
    private void checkBox_Altitude_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_Altitude.Checked == true)
      {
        string file_path = textBox_ResultDirectory.Text;
        file_path = file_path + "/Max_Altitude.csv";
        if (file_path != null && System.IO.File.Exists(file_path))
        {
          System.IO.StreamReader dataFile;
          dataFile = new System.IO.StreamReader(file_path);
          textBox_Altitude.Text = max_value(dataFile);
          dataFile.Close();
        }
      }
      else
      {
        textBox_Altitude.Text = "";
      }
    }
    private void checkBox_Va_max_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_Va_max.Checked == true)
      {
        string file_path = textBox_ResultDirectory.Text;
        file_path = file_path + "/Va_max.csv";
        if (file_path != null && System.IO.File.Exists(file_path))
        {
          System.IO.StreamReader dataFile;
          dataFile = new System.IO.StreamReader(file_path);
          textBox_Va_max.Text = max_value(dataFile);
          dataFile.Close();
        }
      }
      else
      {
        textBox_Va_max.Text = "";
      }
    }
    private void checkBox_Mach_max_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_Mach_max.Checked == true)
      {
        string file_path = textBox_ResultDirectory.Text;
        file_path = file_path + "/Mach_max.csv";
        if (file_path != null && System.IO.File.Exists(file_path))
        {
          System.IO.StreamReader dataFile;
          dataFile = new System.IO.StreamReader(file_path);
          textBox_Mach_max.Text = max_value(dataFile);
          dataFile.Close();
        }
      }
      else
      {
        textBox_Mach_max.Text = "";
      }
    }
    private void checkBox_Va_top_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_Va_top.Checked == true)
      {
        string file_path = textBox_ResultDirectory.Text;
        file_path = file_path + "/Va_top.csv";
        if (file_path != null && System.IO.File.Exists(file_path))
        {
          System.IO.StreamReader dataFile;
          dataFile = new System.IO.StreamReader(file_path);
          textBox_Va_top.Text = max_value(dataFile);
          dataFile.Close();
        }
      }
      else
      {
        textBox_Va_top.Text = "";
      }
    }
    private void checkBox_Vlc_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_Vlc.Checked == true)
      {
        string file_path = textBox_ResultDirectory.Text;
        file_path = file_path + "/LaunchClear_Velocity.csv";
        if (file_path != null && System.IO.File.Exists(file_path))
        {
          System.IO.StreamReader dataFile;
          dataFile = new System.IO.StreamReader(file_path);
          textBox_Vlc.Text = max_value(dataFile);
          dataFile.Close();
        }
      }
      else
      {
        textBox_Vlc.Text = "";
      }
    }
    private void checkBox_Acclc_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_Acclc.Checked == true)
      {
        string file_path = textBox_ResultDirectory.Text;
        file_path = file_path + "/LaunchClear_Acceleration.csv";
        if (file_path != null && System.IO.File.Exists(file_path))
        {
          System.IO.StreamReader dataFile;
          dataFile = new System.IO.StreamReader(file_path);
          textBox_Acclc.Text = max_value(dataFile);
          dataFile.Close();
        }
      }
      else
      {
        textBox_Acclc.Text = "";
      }
    }
  }

  //落下地点を保持するクラス
  class LandingRange
  {
    double[,] range = new double[56,4];

    public void setValue(int index, string[] array)
    {
      int i;

      for (i = 0; i <= 3; i++)
      {
        range[index, i] = double.Parse(array[i]);
      }

      return;
    }

    public double[] getValue(int index,int i, int j)
    {
      double[] pos = new double[2];
      pos[0] = range[index, i];
      pos[1] = range[index, j];
      

      return pos;
    }

    
  }
}
