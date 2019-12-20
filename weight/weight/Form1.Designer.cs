namespace weight
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_weigh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_com = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_comopen = new System.Windows.Forms.Button();
            this.button_comclose = new System.Windows.Forms.Button();
            this.button_comupdate = new System.Windows.Forms.Button();
            this.comboBox_bps = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_weigh
            // 
            this.textBox_weigh.Location = new System.Drawing.Point(72, 67);
            this.textBox_weigh.Name = "textBox_weigh";
            this.textBox_weigh.Size = new System.Drawing.Size(79, 21);
            this.textBox_weigh.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前重量";
            // 
            // comboBox_com
            // 
            this.comboBox_com.FormattingEnabled = true;
            this.comboBox_com.Location = new System.Drawing.Point(60, 22);
            this.comboBox_com.Name = "comboBox_com";
            this.comboBox_com.Size = new System.Drawing.Size(62, 20);
            this.comboBox_com.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "串口号";
            // 
            // button_comopen
            // 
            this.button_comopen.Location = new System.Drawing.Point(266, 19);
            this.button_comopen.Name = "button_comopen";
            this.button_comopen.Size = new System.Drawing.Size(75, 23);
            this.button_comopen.TabIndex = 4;
            this.button_comopen.Text = "打开串口";
            this.button_comopen.UseVisualStyleBackColor = true;
            this.button_comopen.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_comclose
            // 
            this.button_comclose.Enabled = false;
            this.button_comclose.Location = new System.Drawing.Point(360, 19);
            this.button_comclose.Name = "button_comclose";
            this.button_comclose.Size = new System.Drawing.Size(75, 23);
            this.button_comclose.TabIndex = 4;
            this.button_comclose.Text = "关闭串口";
            this.button_comclose.UseVisualStyleBackColor = true;
            this.button_comclose.Click += new System.EventHandler(this.button_comclose_Click);
            // 
            // button_comupdate
            // 
            this.button_comupdate.Location = new System.Drawing.Point(441, 19);
            this.button_comupdate.Name = "button_comupdate";
            this.button_comupdate.Size = new System.Drawing.Size(75, 23);
            this.button_comupdate.TabIndex = 5;
            this.button_comupdate.Text = "刷新串口";
            this.button_comupdate.UseVisualStyleBackColor = true;
            this.button_comupdate.Click += new System.EventHandler(this.button_comupdate_Click);
            // 
            // comboBox_bps
            // 
            this.comboBox_bps.FormattingEnabled = true;
            this.comboBox_bps.Location = new System.Drawing.Point(175, 22);
            this.comboBox_bps.Name = "comboBox_bps";
            this.comboBox_bps.Size = new System.Drawing.Size(72, 20);
            this.comboBox_bps.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "波特率";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "KG";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 426);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_bps);
            this.Controls.Add(this.button_comupdate);
            this.Controls.Add(this.button_comclose);
            this.Controls.Add(this.button_comopen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_com);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_weigh);
            this.Name = "Form1";
            this.Text = "体重模拟器       华仔";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_weigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_com;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_comopen;
        private System.Windows.Forms.Button button_comclose;
        private System.Windows.Forms.Button button_comupdate;
        private System.Windows.Forms.ComboBox comboBox_bps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

