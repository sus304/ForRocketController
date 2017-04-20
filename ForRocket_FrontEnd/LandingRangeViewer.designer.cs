namespace LandingRangeViewer
{
  partial class LandingRangeViewer
  {
    /// <summary>
    /// 必要なデザイナー変数です。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 使用中のリソースをすべてクリーンアップします。
    /// </summary>
    /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows フォーム デザイナーで生成されたコード

    /// <summary>
    /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
    /// コード エディターで変更しないでください。
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingRangeViewer));
      this.Graph_Range = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.LRopen_button = new System.Windows.Forms.Button();
      this.LandingRangeFile = new System.Windows.Forms.OpenFileDialog();
      this.LaunchPoint_combo = new System.Windows.Forms.ComboBox();
      this.LandingStatus_combo = new System.Windows.Forms.ComboBox();
      this.file_textbox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.button_save = new System.Windows.Forms.Button();
      this.openFileDialog_result = new System.Windows.Forms.OpenFileDialog();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.checkBox_Acclc = new System.Windows.Forms.CheckBox();
      this.textBox_Acclc = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.checkBox_Vlc = new System.Windows.Forms.CheckBox();
      this.textBox_Vlc = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.checkBox_Va_top = new System.Windows.Forms.CheckBox();
      this.textBox_Va_top = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.checkBox_Mach_max = new System.Windows.Forms.CheckBox();
      this.textBox_Mach_max = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.checkBox_Va_max = new System.Windows.Forms.CheckBox();
      this.textBox_Va_max = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.checkBox_Altitude = new System.Windows.Forms.CheckBox();
      this.textBox_Altitude = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.button_result_edit = new System.Windows.Forms.Button();
      this.textBox_ResultDirectory = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.Graph_Range)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // Graph_Range
      // 
      this.Graph_Range.BackColor = System.Drawing.Color.Transparent;
      this.Graph_Range.BorderlineColor = System.Drawing.Color.Black;
      this.Graph_Range.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
      chartArea1.BackColor = System.Drawing.Color.Transparent;
      chartArea1.Name = "ChartArea1";
      this.Graph_Range.ChartAreas.Add(chartArea1);
      legend1.BackColor = System.Drawing.Color.Transparent;
      legend1.Name = "Legend1";
      this.Graph_Range.Legends.Add(legend1);
      this.Graph_Range.Location = new System.Drawing.Point(467, 13);
      this.Graph_Range.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Graph_Range.Name = "Graph_Range";
      this.Graph_Range.Size = new System.Drawing.Size(675, 675);
      this.Graph_Range.TabIndex = 0;
      this.Graph_Range.Text = "chart1";
      // 
      // LRopen_button
      // 
      this.LRopen_button.Location = new System.Drawing.Point(18, 28);
      this.LRopen_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.LRopen_button.Name = "LRopen_button";
      this.LRopen_button.Size = new System.Drawing.Size(87, 34);
      this.LRopen_button.TabIndex = 1;
      this.LRopen_button.Text = "Open";
      this.LRopen_button.UseVisualStyleBackColor = true;
      this.LRopen_button.Click += new System.EventHandler(this.LRopen_button_Click);
      // 
      // LandingRangeFile
      // 
      this.LandingRangeFile.FileName = "Landing_Range_v2.csv";
      // 
      // LaunchPoint_combo
      // 
      this.LaunchPoint_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.LaunchPoint_combo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.LaunchPoint_combo.FormattingEnabled = true;
      this.LaunchPoint_combo.Location = new System.Drawing.Point(105, 101);
      this.LaunchPoint_combo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.LaunchPoint_combo.Name = "LaunchPoint_combo";
      this.LaunchPoint_combo.Size = new System.Drawing.Size(301, 26);
      this.LaunchPoint_combo.TabIndex = 2;
      this.LaunchPoint_combo.SelectedIndexChanged += new System.EventHandler(this.LaunchPoint_combo_SelectedIndexChanged);
      // 
      // LandingStatus_combo
      // 
      this.LandingStatus_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.LandingStatus_combo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.LandingStatus_combo.FormattingEnabled = true;
      this.LandingStatus_combo.Location = new System.Drawing.Point(105, 135);
      this.LandingStatus_combo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.LandingStatus_combo.Name = "LandingStatus_combo";
      this.LandingStatus_combo.Size = new System.Drawing.Size(127, 26);
      this.LandingStatus_combo.TabIndex = 3;
      this.LandingStatus_combo.SelectedIndexChanged += new System.EventHandler(this.LandingStatus_combo_SelectedIndexChanged);
      // 
      // file_textbox
      // 
      this.file_textbox.Location = new System.Drawing.Point(18, 69);
      this.file_textbox.Name = "file_textbox";
      this.file_textbox.ReadOnly = true;
      this.file_textbox.Size = new System.Drawing.Size(425, 25);
      this.file_textbox.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 138);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(69, 18);
      this.label2.TabIndex = 6;
      this.label2.Text = "弾道 / 減速";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(15, 104);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(32, 18);
      this.label3.TabIndex = 7;
      this.label3.Text = "射点";
      // 
      // button_save
      // 
      this.button_save.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.button_save.Location = new System.Drawing.Point(18, 179);
      this.button_save.Name = "button_save";
      this.button_save.Size = new System.Drawing.Size(413, 48);
      this.button_save.TabIndex = 8;
      this.button_save.Text = "Image Save";
      this.button_save.UseVisualStyleBackColor = true;
      this.button_save.Click += new System.EventHandler(this.button_save_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button_save);
      this.groupBox1.Controls.Add(this.LRopen_button);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.file_textbox);
      this.groupBox1.Controls.Add(this.LaunchPoint_combo);
      this.groupBox1.Controls.Add(this.LandingStatus_combo);
      this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.groupBox1.Location = new System.Drawing.Point(12, 13);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(449, 248);
      this.groupBox1.TabIndex = 9;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Landing Range File";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.checkBox_Acclc);
      this.groupBox2.Controls.Add(this.textBox_Acclc);
      this.groupBox2.Controls.Add(this.label8);
      this.groupBox2.Controls.Add(this.checkBox_Vlc);
      this.groupBox2.Controls.Add(this.textBox_Vlc);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.checkBox_Va_top);
      this.groupBox2.Controls.Add(this.textBox_Va_top);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.checkBox_Mach_max);
      this.groupBox2.Controls.Add(this.textBox_Mach_max);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.checkBox_Va_max);
      this.groupBox2.Controls.Add(this.textBox_Va_max);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.checkBox_Altitude);
      this.groupBox2.Controls.Add(this.textBox_Altitude);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.button_result_edit);
      this.groupBox2.Controls.Add(this.textBox_ResultDirectory);
      this.groupBox2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.groupBox2.Location = new System.Drawing.Point(12, 277);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(449, 299);
      this.groupBox2.TabIndex = 10;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Result Directory";
      // 
      // checkBox_Acclc
      // 
      this.checkBox_Acclc.AutoSize = true;
      this.checkBox_Acclc.Location = new System.Drawing.Point(18, 237);
      this.checkBox_Acclc.Name = "checkBox_Acclc";
      this.checkBox_Acclc.Size = new System.Drawing.Size(173, 22);
      this.checkBox_Acclc.TabIndex = 23;
      this.checkBox_Acclc.Text = "LaunchClear Acceleration";
      this.checkBox_Acclc.UseVisualStyleBackColor = true;
      this.checkBox_Acclc.CheckedChanged += new System.EventHandler(this.checkBox_Acclc_CheckedChanged);
      // 
      // textBox_Acclc
      // 
      this.textBox_Acclc.Location = new System.Drawing.Point(197, 235);
      this.textBox_Acclc.Name = "textBox_Acclc";
      this.textBox_Acclc.ReadOnly = true;
      this.textBox_Acclc.Size = new System.Drawing.Size(100, 25);
      this.textBox_Acclc.TabIndex = 22;
      this.textBox_Acclc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(303, 238);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(27, 18);
      this.label8.TabIndex = 21;
      this.label8.Text = "[G]";
      // 
      // checkBox_Vlc
      // 
      this.checkBox_Vlc.AutoSize = true;
      this.checkBox_Vlc.Location = new System.Drawing.Point(18, 206);
      this.checkBox_Vlc.Name = "checkBox_Vlc";
      this.checkBox_Vlc.Size = new System.Drawing.Size(147, 22);
      this.checkBox_Vlc.TabIndex = 20;
      this.checkBox_Vlc.Text = "LaunchClear Velocity";
      this.checkBox_Vlc.UseVisualStyleBackColor = true;
      this.checkBox_Vlc.CheckedChanged += new System.EventHandler(this.checkBox_Vlc_CheckedChanged);
      // 
      // textBox_Vlc
      // 
      this.textBox_Vlc.Location = new System.Drawing.Point(197, 204);
      this.textBox_Vlc.Name = "textBox_Vlc";
      this.textBox_Vlc.ReadOnly = true;
      this.textBox_Vlc.Size = new System.Drawing.Size(100, 25);
      this.textBox_Vlc.TabIndex = 19;
      this.textBox_Vlc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(303, 207);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(42, 18);
      this.label7.TabIndex = 18;
      this.label7.Text = "[m/s]";
      // 
      // checkBox_Va_top
      // 
      this.checkBox_Va_top.AutoSize = true;
      this.checkBox_Va_top.Location = new System.Drawing.Point(18, 175);
      this.checkBox_Va_top.Name = "checkBox_Va_top";
      this.checkBox_Va_top.Size = new System.Drawing.Size(139, 22);
      this.checkBox_Va_top.TabIndex = 17;
      this.checkBox_Va_top.Text = "Apogee Air Velocity";
      this.checkBox_Va_top.UseVisualStyleBackColor = true;
      this.checkBox_Va_top.CheckedChanged += new System.EventHandler(this.checkBox_Va_top_CheckedChanged);
      // 
      // textBox_Va_top
      // 
      this.textBox_Va_top.Location = new System.Drawing.Point(197, 173);
      this.textBox_Va_top.Name = "textBox_Va_top";
      this.textBox_Va_top.ReadOnly = true;
      this.textBox_Va_top.Size = new System.Drawing.Size(100, 25);
      this.textBox_Va_top.TabIndex = 16;
      this.textBox_Va_top.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(303, 176);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(42, 18);
      this.label6.TabIndex = 15;
      this.label6.Text = "[m/s]";
      // 
      // checkBox_Mach_max
      // 
      this.checkBox_Mach_max.AutoSize = true;
      this.checkBox_Mach_max.Location = new System.Drawing.Point(18, 144);
      this.checkBox_Mach_max.Name = "checkBox_Mach_max";
      this.checkBox_Mach_max.Size = new System.Drawing.Size(136, 22);
      this.checkBox_Mach_max.TabIndex = 14;
      this.checkBox_Mach_max.Text = "Max Mach Number";
      this.checkBox_Mach_max.UseVisualStyleBackColor = true;
      this.checkBox_Mach_max.CheckedChanged += new System.EventHandler(this.checkBox_Mach_max_CheckedChanged);
      // 
      // textBox_Mach_max
      // 
      this.textBox_Mach_max.Location = new System.Drawing.Point(197, 142);
      this.textBox_Mach_max.Name = "textBox_Mach_max";
      this.textBox_Mach_max.ReadOnly = true;
      this.textBox_Mach_max.Size = new System.Drawing.Size(100, 25);
      this.textBox_Mach_max.TabIndex = 13;
      this.textBox_Mach_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(303, 145);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(23, 18);
      this.label5.TabIndex = 12;
      this.label5.Text = "[-]";
      // 
      // checkBox_Va_max
      // 
      this.checkBox_Va_max.AutoSize = true;
      this.checkBox_Va_max.Location = new System.Drawing.Point(18, 113);
      this.checkBox_Va_max.Name = "checkBox_Va_max";
      this.checkBox_Va_max.Size = new System.Drawing.Size(120, 22);
      this.checkBox_Va_max.TabIndex = 11;
      this.checkBox_Va_max.Text = "Max Air Velocity";
      this.checkBox_Va_max.UseVisualStyleBackColor = true;
      this.checkBox_Va_max.CheckedChanged += new System.EventHandler(this.checkBox_Va_max_CheckedChanged);
      // 
      // textBox_Va_max
      // 
      this.textBox_Va_max.Location = new System.Drawing.Point(197, 111);
      this.textBox_Va_max.Name = "textBox_Va_max";
      this.textBox_Va_max.ReadOnly = true;
      this.textBox_Va_max.Size = new System.Drawing.Size(100, 25);
      this.textBox_Va_max.TabIndex = 10;
      this.textBox_Va_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(303, 114);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(42, 18);
      this.label4.TabIndex = 9;
      this.label4.Text = "[m/s]";
      // 
      // checkBox_Altitude
      // 
      this.checkBox_Altitude.AutoSize = true;
      this.checkBox_Altitude.Location = new System.Drawing.Point(18, 82);
      this.checkBox_Altitude.Name = "checkBox_Altitude";
      this.checkBox_Altitude.Size = new System.Drawing.Size(72, 22);
      this.checkBox_Altitude.TabIndex = 8;
      this.checkBox_Altitude.Text = "Altitude";
      this.checkBox_Altitude.UseVisualStyleBackColor = true;
      this.checkBox_Altitude.CheckedChanged += new System.EventHandler(this.checkBox_Altitude_CheckedChanged);
      // 
      // textBox_Altitude
      // 
      this.textBox_Altitude.Location = new System.Drawing.Point(197, 80);
      this.textBox_Altitude.Name = "textBox_Altitude";
      this.textBox_Altitude.ReadOnly = true;
      this.textBox_Altitude.Size = new System.Drawing.Size(100, 25);
      this.textBox_Altitude.TabIndex = 7;
      this.textBox_Altitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(303, 83);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(30, 18);
      this.label1.TabIndex = 6;
      this.label1.Text = "[m]";
      // 
      // button_result_edit
      // 
      this.button_result_edit.Location = new System.Drawing.Point(383, 24);
      this.button_result_edit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_result_edit.Name = "button_result_edit";
      this.button_result_edit.Size = new System.Drawing.Size(60, 25);
      this.button_result_edit.TabIndex = 1;
      this.button_result_edit.Text = "Edit";
      this.button_result_edit.UseVisualStyleBackColor = true;
      this.button_result_edit.Click += new System.EventHandler(this.button_result_edit_Click);
      // 
      // textBox_ResultDirectory
      // 
      this.textBox_ResultDirectory.Location = new System.Drawing.Point(18, 24);
      this.textBox_ResultDirectory.Name = "textBox_ResultDirectory";
      this.textBox_ResultDirectory.ReadOnly = true;
      this.textBox_ResultDirectory.Size = new System.Drawing.Size(359, 25);
      this.textBox_ResultDirectory.TabIndex = 5;
      // 
      // LandingRangeViewer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1148, 703);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.Graph_Range);
      this.Controls.Add(this.groupBox1);
      this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "LandingRangeViewer";
      this.ShowIcon = false;
      this.Text = "Landing Range Viewer";
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.Graph_Range)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart Graph_Range;
    private System.Windows.Forms.Button LRopen_button;
    private System.Windows.Forms.OpenFileDialog LandingRangeFile;
    private System.Windows.Forms.ComboBox LaunchPoint_combo;
    private System.Windows.Forms.ComboBox LandingStatus_combo;
    private System.Windows.Forms.TextBox file_textbox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button_save;
    private System.Windows.Forms.OpenFileDialog openFileDialog_result;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button button_result_edit;
    private System.Windows.Forms.TextBox textBox_ResultDirectory;
    private System.Windows.Forms.CheckBox checkBox_Altitude;
    private System.Windows.Forms.TextBox textBox_Altitude;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox checkBox_Va_max;
    private System.Windows.Forms.TextBox textBox_Va_max;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.CheckBox checkBox_Va_top;
    private System.Windows.Forms.TextBox textBox_Va_top;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.CheckBox checkBox_Mach_max;
    private System.Windows.Forms.TextBox textBox_Mach_max;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.CheckBox checkBox_Acclc;
    private System.Windows.Forms.TextBox textBox_Acclc;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.CheckBox checkBox_Vlc;
    private System.Windows.Forms.TextBox textBox_Vlc;
    private System.Windows.Forms.Label label7;
  }
}

