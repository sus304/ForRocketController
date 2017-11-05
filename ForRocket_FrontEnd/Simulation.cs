	using System;
	using System.Diagnostics;
	using System.Windows.Forms;
	using System.IO;
	using ClosedXML.Excel;

	namespace ForRocket_FrontEnd
	{
		public partial class Simulation : Form
		{
			RocketParamter rocket_parameter = new RocketParamter();
			SimulationParameter simulation_parameter = new SimulationParameter();

			public Simulation()
			{
				InitializeComponent();
			}

			private void Simulation_Load(object sender, EventArgs e)
			{
				if (!Directory.GetCurrentDirectory().EndsWith("bin"))
					{
						Directory.SetCurrentDirectory("./bin");
					}

				ActiveControl = this.LogoPic;
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
					rocket_parameter.structure_read_v4(worksheet);
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
					rocket_parameter.engine_read_v4(worksheet);				
					workbook.Dispose();
				}
			}

			//空力設計フォーム呼び出し
			private void Button_Aero_Click(object sender, EventArgs e)
			{
				AeroDesign.AeroDesignForm aerodesignform = new AeroDesign.AeroDesignForm(rocket_parameter);
				aerodesignform.ShowDialog(this);
				aerodesignform.Dispose();
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
				double[] array = new double[9];
				double[] array_sim = new double[6];

				//Rocket Parameter
				array[0] = double.Parse(text_Pa.Text);
				array[1] = double.Parse(text_Ta.Text);
				array[2] = double.Parse(text_g0.Text);
				array[3] = double.Parse(text_Hw.Text);
				array[4] = double.Parse(text_Wh.Text);
				array[5] = double.Parse(text_Hsepa.Text);
				array[6] = double.Parse(text_elevation.Text);
				array[7] = double.Parse(text_azimuth.Text);
				array[8] = double.Parse(text_LL.Text);
				rocket_parameter.Environment_Load(array);

				rocket_parameter.Output_v4();


				//Simulation Parameter
				array_sim[0] = double.Parse(textBox_Vw_min.Text);
				array_sim[1] = double.Parse(textBox_Vw_max.Text);
				array_sim[2] = double.Parse(textBox_Vw_delta.Text);
				array_sim[3] = double.Parse(textBox_anglew_min.Text);
				array_sim[4] = double.Parse(textBox_anglew_max.Text);
				array_sim[5] = double.Parse(textBox_anglew_delta.Text);
				if (check_log.Checked == true)
				{
					simulation_parameter.Output(0, array_sim);
				}
				if (check_table.Checked == true)
				{
					simulation_parameter.Output(1, array_sim);
				}

				/****************************************************/
				//solverフォルダへ移動
				Directory.SetCurrentDirectory("./solver");

				//計算終了まで待機
				Process p_solve = Process.Start(Path.GetFullPath("./ForRocket_v4.exe"));
				p_solve.WaitForExit();
			
				Process p_post = Process.Start(Path.GetFullPath("./ForRocketPost.exe"));
				p_post.WaitForExit();

				Directory.SetCurrentDirectory("../"); // ./binへ移動
				/****************************************************/

				CopyDirectory("./solver/OutputLog", "../result");
				CopyDirectory("./solver/OutputTable", "../result");

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
			public static void CopyDirectory(string sourceDirName, string destDirName)
			{
				//コピー先のディレクトリがないときは作る
				if (!System.IO.Directory.Exists(destDirName))
				{
					System.IO.Directory.CreateDirectory(destDirName);
					//属性もコピー
					System.IO.File.SetAttributes(destDirName, System.IO.File.GetAttributes(sourceDirName));
				}

				//コピー先のディレクトリ名の末尾に"\"をつける
				if (destDirName[destDirName.Length - 1] !=
						System.IO.Path.DirectorySeparatorChar)
					destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;

				//コピー元のディレクトリにあるファイルをコピー
				string[] files = System.IO.Directory.GetFiles(sourceDirName);
				foreach (string file in files)
					System.IO.File.Copy(file, destDirName + System.IO.Path.GetFileName(file), true);

				//コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
				string[] dirs = System.IO.Directory.GetDirectories(sourceDirName);
				foreach (string dir in dirs)
					CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
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

		public class RocketParamter
		{
			public double l;
			public double d;
			public double me;
			public double me_withfin;
			public double lcge;
			public double lcge_withfin;
			public double lcgox; // v4.1 only
			public double lcgf;
			public double ltank; // v4.1 only
			public double Is;
			public double Ir;
			public double lcp;
			public double Clp; // Roll減衰モーメント係数
			public double Cmq; // Pitch/Yaw減衰モーメント係数
			public double CNa;
			
			public double CdS1;
			public double CdS2;
			 
			public double freq;
			public double Isp;
			public double It;
			public double tb;
			public double mox;
			public double mfb;
			public double mfa;
			public double lf;
			public double df_out;
			public double df_port;
			public double mdotox; // v4.1 only
			public double mdotf;
			public double de;
			 
			public double Pa;
			public double Ta;
			public double rho;
			public double g0;
			public double Hw;
			public double Wh;
			public double Hsepa;
			public double elevation;
			public double azimuth;
			public double LL;
			 
			
			//空力用
			public double lnose;
			public double dtail;
			public double ltail;
			public double ms, m, ma;
			public double lcgs, lcg, lcga;

			//Structureシート読み出し
			public void structure_read_v4(IXLWorksheet worksheet)
			{
				l = worksheet.Cell(1, 2).GetDouble();
				d = worksheet.Cell(2, 2).GetDouble();
				me = worksheet.Cell(3, 2).GetDouble();
				lcge = worksheet.Cell(4, 2).GetDouble();
				lcgox = worksheet.Cell(5, 2).GetDouble();
				lcgf = worksheet.Cell(6, 2).GetDouble();
				ltank = worksheet.Cell(7, 2).GetDouble();
				Is = worksheet.Cell(8, 2).GetDouble();
				Ir = worksheet.Cell(9, 2).GetDouble();
				lnose = worksheet.Cell(10, 2).GetDouble();
				dtail = worksheet.Cell(11, 2).GetDouble();
				ltail = worksheet.Cell(12, 2).GetDouble();
				CdS1 = worksheet.Cell(13, 2).GetDouble();
				CdS2 = worksheet.Cell(14, 2).GetDouble();
			}

			//Engineシート読み出し
			public void engine_read_v4(IXLWorksheet worksheet)
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

			public void Environment_Load(double[] array)
			{
				Pa = array[0];
				Ta = array[1];
				rho = Pa * 1000.0 / (287.1 * (Ta * 273.15));
				g0 = array[2];
				Hw = array[3];
				Wh = array[4];
				Hsepa = array[5];
				elevation = array[6];
				azimuth = array[7];
				LL = array[8];

			}

			//ForRocket input書き出し
			public void Output_v4()
			{
				using (StreamWriter DataFile = new StreamWriter("./solver/rocket_param.inp"))
				{
					DataFile.WriteLine(l.ToString());
					DataFile.WriteLine(d.ToString());
					DataFile.WriteLine((me_withfin).ToString());
					DataFile.WriteLine(lcge_withfin.ToString());
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

			}

		}

		public class SimulationParameter
		{
			int switch_log_table; //0:Log / 1:Table
			double Vw_min;
			double Vw_max;
			double Vw_delta;
			double anglew_min;
			double anglew_max;
			double anglew_delta;

			public void Output(int sw, double[] array)
			{
				switch_log_table = sw;
				Vw_min = array[0];
				Vw_max = array[1];
				Vw_delta = array[2];
				anglew_min = array[3];
				anglew_max = array[4];
				anglew_delta = array[5];

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

		}

	}
