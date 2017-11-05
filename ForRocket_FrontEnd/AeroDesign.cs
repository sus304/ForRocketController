using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace AeroDesign
{
	public partial class AeroDesignForm : Form
	{
		BarrowmanMethod BM = new BarrowmanMethod();
		ForRocket_FrontEnd.RocketParamter rocket;
		int flag_calc = 0;

		public AeroDesignForm(ForRocket_FrontEnd.RocketParamter rocket_parameter)
		{
			InitializeComponent();
			button_output.Enabled = false;
			flag_calc = 0;

			rocket = rocket_parameter;
			rocket.ms = rocket.me + rocket.mfb;
			rocket.m = rocket.me + rocket.mfb + rocket.mox;
			rocket.ma = rocket.me + rocket.mfa;
			rocket.lcgs = (rocket.me * rocket.lcge + rocket.mfb * (rocket.l - rocket.lcgf)) / (rocket.ms);
			rocket.lcg = (rocket.me * rocket.lcge + rocket.mfb * (rocket.l - rocket.lcgf) + rocket.mox * (rocket.l - rocket.lcgox)) / (rocket.m);
			rocket.lcga = (rocket.me * rocket.lcge + rocket.mfa * (rocket.l - rocket.lcgf)) / (rocket.ma);
			text_diameter.Text = (rocket.d*1000.0).ToString("F3");
			text_length.Text = (rocket.l * 1000.0).ToString("F3");
			text_lcgs.Text = (rocket.lcgs * 1000.0).ToString("F3");
			text_lcg.Text = (rocket.lcg * 1000.0).ToString("F3");
			text_lcga.Text = (rocket.lcga * 1000.0).ToString("F3");
			text_ms.Text = rocket.ms.ToString("F3");
			text_m.Text = rocket.m.ToString("F3");
			text_ma.Text = rocket.ma.ToString("F3");
			text_lnose.Text = rocket.lnose.ToString("F3");
			text_dtail.Text = rocket.dtail.ToString("F3");
			text_ltail.Text = rocket.ltail.ToString("F3");

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			combo_nose.Items.Add("ダブルコーン");
			combo_nose.Items.Add("オジャイブ");

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
			BM.lcgs = double.Parse(text_lcgs.Text);
			if (flag_calc == 1)
			{
				BM.calculation();
				RocketPlot();
			}
		}
		private void text_lcg_Leave(object sender, EventArgs e)
		{
			BM.lcg = double.Parse(text_lcg.Text);
			if (flag_calc == 1)
			{
				BM.calculation();
				RocketPlot();
			}
		}
		private void text_lcga_Leave(object sender, EventArgs e)
		{
			BM.lcga = double.Parse(text_lcga.Text);
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

		//全テキストを読み取り
		private void AllRead()
		{
			BM.d_body = double.Parse(text_diameter.Text);
			BM.l_body = double.Parse(text_length.Text);
			BM.lcgs = double.Parse(text_lcgs.Text);
			BM.lcg = double.Parse(text_lcg.Text);
			BM.lcga = double.Parse(text_lcga.Text);
			BM.ms = double.Parse(text_ms.Text);
			BM.m = double.Parse(text_m.Text);
			BM.ma = double.Parse(text_ma.Text);
			BM.fin.Altitude = double.Parse(text_altitude.Text);
			BM.nose.flag_nose = combo_nose.SelectedIndex;
			BM.nose.l_nose = double.Parse(text_lnose.Text);
			BM.tail.d_tail = double.Parse(text_dtail.Text);
			BM.tail.l_tail = double.Parse(text_ltail.Text);
			BM.fin.dX_fin = double.Parse(text_Xfplus.Text);
			BM.fin.Cr = double.Parse(text_Cr.Text);
			BM.fin.Ct = double.Parse(text_Ct.Text);
			BM.fin.Cm = double.Parse(text_Cm.Text);
			BM.fin.Span = double.Parse(text_span.Text);
			BM.fin.thickness = double.Parse(text_thick.Text);
			BM.fin.rho = double.Parse(text_rho.Text);
			BM.fin.young = double.Parse(text_young.Text);
			BM.fin.poisson = double.Parse(text_poisson.Text);
		}

		//ロケットをプロット
		private void RocketPlot()
		{
			int i;

			text_Vf.Text = BM.fin.Vf.ToString("F3");
			text_lcgs_.Text = BM.lcgs_.ToString("F3");
			text_lcg_.Text = BM.lcg_.ToString("F3");
			text_lcga_.Text = BM.lcga_.ToString("F3");
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

			for(i = 0; i <= 7;i++)
			{
				rocketplot.Series[i].IsVisibleInLegend = false;
			}
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
    
		//output
		private void button_output_Click(object sender, EventArgs e)
		{
			rocket.me_withfin = rocket.me + BM.fin.m_fin;
			rocket.lcge_withfin = (rocket.me * rocket.lcge + BM.fin.m_fin * BM.fin.lcg_fin) / (rocket.me + BM.fin.m_fin);
			rocket.lcp = double.Parse(text_lcp.Text) / 1000.0;
			rocket.CNa = double.Parse(text_CNa.Text);
			rocket.Cmq = double.Parse(text_Cmq.Text);
			rocket.Clp = double.Parse(text_Clp.Text);

			using (StreamWriter DataFile = new StreamWriter("../result/AeroDesing.out"))
			{
				DataFile.WriteLine("!----------------------------------------------------------!");
				DataFile.WriteLine("!----------------ForRocket-Aero Design Result--------------!");
				DataFile.WriteLine("!----------------------------------------------------------!");
				DataFile.WriteLine("Body Diameter [mm] :" + text_diameter.Text);
				DataFile.WriteLine("Body Length [mm] :" + text_length.Text);
				DataFile.WriteLine("Dry Center of Gravity [mm] :" + text_lcgs.Text);
				DataFile.WriteLine("All Center of Gravity [mm] :" + text_lcg.Text);
				DataFile.WriteLine("Burn Out Center of Gravity [mm] :" + text_lcga.Text);
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
		}    
	}


	//
	// Personal Class
	//

	public class Nosecone
	{
		public int flag_nose;
		public double l_nose;
		public double LD_nose;
		public double Ccp_nose; // ノーズ形状による圧力中心係数

		public double CNa;
		public double A22;
		public double lcp;

		public void pre_calc_nose(double d_body)
		{
			LD_nose = l_nose / d_body;
			if (flag_nose == 0)
			{
				Ccp_nose = 2.0 / 3.0;
			}
			else if (flag_nose == 1)
			{
				Ccp_nose = 1.0 - ((8.0 * Math.Pow(LD_nose, 2) / 3.0) + (Math.Pow(4.0 * Math.Pow(LD_nose, 2) - 1.0, 2) / 4.0) - (((4.0 * Math.Pow(LD_nose, 2) - 1.0) * Math.Pow(4.0 * Math.Pow(LD_nose, 2) + 1.0, 2) / (16.0 * LD_nose)) * Math.Asin(4.0 * LD_nose / (4.0 * Math.Pow(LD_nose, 2) + 1.0))));
			}
			CNa = 2.0;
			A22 = 0.5 * CNa;
			lcp = l_nose * Ccp_nose;
		}
	}

	public class Fin
	{
		public standard_atmosphere atmosphere = new standard_atmosphere();

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
		public double rho_; // 読み込み用
		public double rho; // 計算用
		public double young, poisson, shear;
		public double m_fin;
		public double lcg_fin;

		public double Altitude;
		public double Pa, Cs;
		public double Vf;

		public double CNa_fin;
		public double Kfb;
		public double CNa;
		public double A22;
		public double lcp;

		public void pre_calc_fin(double l_body, double l_tail, double d_body)
		{
			X_fin = l_body - (Cr + l_tail + dX_fin);
			kai = utility.deg2rad(90.0) - Math.Atan2(Span, Cm);
			l = Math.Sqrt(Math.Pow((0.5 * Cr) - (0.5 * Ct), 2) + (Span * Span));
			A_fin = (Cr + Ct) * Span * 0.5 * Math.Pow(10, -6); // m^2
			AR = Math.Pow(Span / 1000.0, 2) / A_fin;
			ramda = Ct / Cr;
			rho = rho_ * 1000.0; // kg/m^3
			shear = young / (2.0 * (1.0 + poisson));
			m_fin = 4.0 * (rho * A_fin * (thickness / 1000.0)); // 4枚分
			lcg_fin = X_fin + (Cr - ((Ct * Ct + Cr * Ct + Cr * Cr) / (3.0 * (Cr + Ct))));

			CNa_fin = 4.0 * 4.0 * Math.Pow(Span / d_body, 2) / (1.0 + Math.Sqrt(1.0 + Math.Pow(2.0 * l / (Cr + Ct), 2)));
			Kfb = 1.0 + 0.5 * d_body / (0.5 * d_body + Span);
			CNa = CNa_fin * Kfb;
			A22 = 0.5 * CNa;
			lcp = X_fin + (Cm * (Cr + 2.0 * Ct) / (3.0 * (Cr + Ct))) + (Cr + Ct - (Cr * Ct / (Cr + Ct))) / 6.0;

			Pa = atmosphere.getPressure(Altitude);
			Cs = atmosphere.getSoundofSpeed(Altitude);
			Vf = Cs * Math.Sqrt((shear * Math.Pow(10, 9)) / ((1.337 * Math.Pow(AR, 3) * Pa * (ramda + 1.0)) / (2.0 * (AR + 2.0) * Math.Pow(thickness / Cr, 3))));
		}

		// グラフ用
		public double[,] point = new double[5, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
		public void point_set(int index, double valueX, double valueY)
		{
			if (index >= 1 && index <= 3)
			{
			point[index, 0] = valueX;
			point[index, 1] = valueY;
			}
		}
		public double getX(int index)
		{
			return point[index, 0];
		}
		public double getY(int index)
		{
			return point[index, 1];
		}
		public double maxpoint()
		{
			int i, j;
			double max = 0.0;
			for (i = 0; i <= 4; i++)
			{
				for (j = 0; i <= 4; i++)
				{
					if (point[i, j] > max)
					{
					max = point[i, j];
					}
				}
			}
			return max;
		}
	}

	public class Boattail
	{
		public double d_tail = 0.0;
		public double l_tail = 0.0;
		public double X_tail;

		public double CNa;
		public double A22;
		public double lcp;

		public void pre_calc_tail(double l_body,double d_body)
		{
			X_tail = l_body - l_tail;
			if (d_tail == 0.0 || l_tail == 0.0)
			{
				CNa = 0.0;
				lcp = 0.0;
			}
			else
			{
				CNa = 2.0 * (Math.Pow(d_tail / d_body, 2) - 1.0);
				lcp = X_tail + (l_tail / 3.0) * (1.0 + ((1.0 - (d_body / d_tail)) / (1.0 - Math.Pow(d_body / d_tail, 2))));
			}
			A22 = 0.5 * CNa;
		}
	}

	public class BarrowmanMethod
	{
		public Nosecone nose = new Nosecone();
		public Fin fin = new Fin();
		public Boattail tail = new Boattail();
    

		public double d_body, r_body;
		public double l_body;
		public double LD_body; // L/D

		public double lcgs, lcg, lcga; // フィンなしの重心
		public double lcgs_, lcg_, lcga_; // フィン込の重心

		public double me, ms, m, ma;

		public double lcp;
		public double A22;
		public double CNa;
		public double Clp; // Roll減衰モーメント係数
		public double Cmq; // Pitch/Yaw減衰モーメント係数

		public double DRs, DR, DRa; // 直径比
		public double LRs, LR, LRa; // 全長比

		public int flag_include_fins; // Already include Fin


		public void calculation()
		{
			pre_calc_body();
			nose.pre_calc_nose(d_body);
			fin.pre_calc_fin(l_body, tail.l_tail, d_body);
			tail.pre_calc_tail(l_body, d_body);
      
			if (flag_include_fins == 1)
			{
				lcgs_ = lcgs;
				lcg_ = lcg;
				lcga_ = lcga;
			}
			else
			{
				lcgs_ = (lcgs * ms + fin.lcg_fin * fin.m_fin) / (ms + fin.m_fin);
				lcg_ = (lcg * m + fin.lcg_fin * fin.m_fin) / (m + fin.m_fin);
				lcga_ = (lcga * ma + fin.lcg_fin * fin.m_fin) / (ma + fin.m_fin);
			}

			CNa = nose.CNa + fin.CNa + tail.CNa;
			A22 = 0.5 * CNa;
			lcp = (nose.CNa * nose.lcp + fin.CNa * fin.lcp + tail.CNa * tail.lcp) / CNa;
			Clp = Damping_Roll(fin.AR);
			Cmq = (Damping_PitchYaw(lcg_) + Damping_PitchYaw(lcga_)) / 2.0;

			DRs = (lcp - lcgs_) / d_body;
			DR = (lcp - lcg_) / d_body;
			DRa = (lcp - lcga_) / d_body;
			LRs = (lcp - lcgs_) / l_body * 100.0;
			LR = (lcp - lcg_) / l_body * 100.0;
			LRa = (lcp - lcga_) / l_body * 100.0;
		}

		public void pre_calc_body()
		{
			r_body = 0.5 * d_body;
			LD_body = l_body / d_body;
		}
    
		public double Damping_PitchYaw(double lcgd)
		{
			double Cmq;
			Cmq = -4.0 * ((nose.A22 * Math.Pow((nose.lcp - lcgd) / l_body, 2)) + (fin.A22 * Math.Pow((fin.lcp - lcgd) / l_body, 2)) + (tail.A22 * Math.Pow((tail.lcp - lcgd) / l_body, 2)));
			return Cmq;
		}

		public double Damping_Roll(double AR)
		{
			double Clp;
			Clp = -AR / (2.0 * Math.PI);
			return Clp;
		}


		// グラフ用
		public double[,] point_nose = new double[4, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
		public double[,] point_body = new double[5, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
		public double[,] point_tail = new double[5, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
		public double[,] point_fin1 = new double[5, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
		public double[,] point_fin2 = new double[5, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
		public double[,] point_fin3 = new double[2, 2] { { 0, 0 }, { 0, 0 } };
		public void point_set()
		{
			fin.point_set(1, fin.Cr, 0.0);
			fin.point_set(2, fin.Cm + fin.Ct, fin.Span);
			fin.point_set(3, fin.Cm, fin.Span);

			point_nose[0, 0] = 0.0;              point_nose[0, 1] = 0.0;
			point_nose[1, 0] = nose.l_nose;      point_nose[1, 1] = r_body;
			point_nose[2, 0] = nose.l_nose;      point_nose[2, 1] = -r_body;
			point_nose[3, 0] = point_nose[0, 0]; point_nose[3, 1] = point_nose[0, 1];

			point_body[0, 0] = nose.l_nose;          point_body[0, 1] = r_body;
			point_body[1, 0] = l_body - tail.l_tail; point_body[1, 1] = r_body;
			point_body[2, 0] = l_body - tail.l_tail; point_body[2, 1] = -r_body;
			point_body[3, 0] = nose.l_nose;          point_body[3, 1] = -r_body;
			point_body[4, 0] = point_body[0, 0];     point_body[4, 1] = point_body[0, 1];

			point_tail[0, 0] = l_body - tail.l_tail; point_tail[0, 1] = r_body;
			point_tail[1, 0] = l_body;               point_tail[1, 1] = 0.5 * tail.d_tail;
			point_tail[2, 0] = l_body;               point_tail[2, 1] = -0.5 * tail.d_tail;
			point_tail[3, 0] = l_body - tail.l_tail; point_tail[3, 1] = -r_body;
			point_tail[4, 0] = point_tail[0, 0];     point_tail[4, 1] = point_body[0, 1];

			point_fin1[0, 0] = fin.point[0, 0] + fin.X_fin; point_fin1[0, 1] = fin.point[0, 1] + r_body;
			point_fin1[1, 0] = fin.point[1, 0] + fin.X_fin; point_fin1[1, 1] = fin.point[1, 1] + r_body;
			point_fin1[2, 0] = fin.point[2, 0] + fin.X_fin; point_fin1[2, 1] = fin.point[2, 1] + r_body;
			point_fin1[3, 0] = fin.point[3, 0] + fin.X_fin; point_fin1[3, 1] = fin.point[3, 1] + r_body;
			point_fin1[4, 0] = point_fin1[0, 0];            point_fin1[4, 1] = point_fin1[0, 1];

			point_fin2[0, 0] = point_fin1[0, 0]; point_fin2[0, 1] = -point_fin1[0, 1];
			point_fin2[1, 0] = point_fin1[1, 0]; point_fin2[1, 1] = -point_fin1[1, 1];
			point_fin2[2, 0] = point_fin1[2, 0]; point_fin2[2, 1] = -point_fin1[2, 1];
			point_fin2[3, 0] = point_fin1[3, 0]; point_fin2[3, 1] = -point_fin1[3, 1];
			point_fin2[4, 0] = point_fin2[0, 0]; point_fin2[4, 1] = point_fin2[0, 1];

			point_fin3[0, 0] = point_fin1[0, 0];
			point_fin3[1, 0] = point_fin1[1, 0];


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

	public static class utility
	{
		public static double deg2rad(double deg)
		{
			return deg * Math.PI / 180.0;
		}    
	}
}
