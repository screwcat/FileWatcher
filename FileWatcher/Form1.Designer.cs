namespace FileWatcher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MonitorTip = new System.Windows.Forms.CheckBox();
            this.MiniToTable = new System.Windows.Forms.CheckBox();
            this.AutoRun = new System.Windows.Forms.CheckBox();
            this.StartMonit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MsgListBox = new System.Windows.Forms.ListBox();
            this.StopMonit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MonitorTip);
            this.groupBox1.Controls.Add(this.MiniToTable);
            this.groupBox1.Controls.Add(this.AutoRun);
            this.groupBox1.Location = new System.Drawing.Point(5, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 77);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "监测设置";
            // 
            // MonitorTip
            // 
            this.MonitorTip.AutoSize = true;
            this.MonitorTip.Location = new System.Drawing.Point(22, 47);
            this.MonitorTip.Name = "MonitorTip";
            this.MonitorTip.Size = new System.Drawing.Size(72, 16);
            this.MonitorTip.TabIndex = 0;
            this.MonitorTip.Text = "监测提示";
            this.MonitorTip.UseVisualStyleBackColor = true;
            this.MonitorTip.CheckedChanged += new System.EventHandler(this.MonitorTip_CheckedChanged);
            // 
            // MiniToTable
            // 
            this.MiniToTable.AutoSize = true;
            this.MiniToTable.Location = new System.Drawing.Point(215, 25);
            this.MiniToTable.Name = "MiniToTable";
            this.MiniToTable.Size = new System.Drawing.Size(96, 16);
            this.MiniToTable.TabIndex = 0;
            this.MiniToTable.Text = "最小化至托盘";
            this.MiniToTable.UseVisualStyleBackColor = true;
            this.MiniToTable.CheckedChanged += new System.EventHandler(this.MiniToTable_CheckedChanged);
            // 
            // AutoRun
            // 
            this.AutoRun.AutoSize = true;
            this.AutoRun.Location = new System.Drawing.Point(22, 25);
            this.AutoRun.Name = "AutoRun";
            this.AutoRun.Size = new System.Drawing.Size(120, 16);
            this.AutoRun.TabIndex = 0;
            this.AutoRun.Text = "开机启动监测程序";
            this.AutoRun.UseVisualStyleBackColor = true;
            this.AutoRun.CheckedChanged += new System.EventHandler(this.AutoRun_CheckedChanged);
            // 
            // StartMonit
            // 
            this.StartMonit.Location = new System.Drawing.Point(241, 168);
            this.StartMonit.Name = "StartMonit";
            this.StartMonit.Size = new System.Drawing.Size(75, 23);
            this.StartMonit.TabIndex = 14;
            this.StartMonit.Text = "开  始";
            this.StartMonit.UseVisualStyleBackColor = true;
            this.StartMonit.Click += new System.EventHandler(this.StartMonit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "浏览...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 21);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "C:\\Users\\Administrator\\Documents\\Tencent Files\\33982755\\Image\\Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "监控路径：";
            // 
            // MsgListBox
            // 
            this.MsgListBox.FormattingEnabled = true;
            this.MsgListBox.ItemHeight = 12;
            this.MsgListBox.Location = new System.Drawing.Point(5, 197);
            this.MsgListBox.Name = "MsgListBox";
            this.MsgListBox.Size = new System.Drawing.Size(413, 208);
            this.MsgListBox.TabIndex = 18;
            // 
            // StopMonit
            // 
            this.StopMonit.Location = new System.Drawing.Point(343, 168);
            this.StopMonit.Name = "StopMonit";
            this.StopMonit.Size = new System.Drawing.Size(75, 23);
            this.StopMonit.TabIndex = 16;
            this.StopMonit.Text = "停  止";
            this.StopMonit.UseVisualStyleBackColor = true;
            this.StopMonit.Click += new System.EventHandler(this.StopMonit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.MaximumSize = new System.Drawing.Size(400, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(5, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 71);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明：";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(341, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "浏览...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(68, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(262, 21);
            this.textBox2.TabIndex = 22;
            this.textBox2.Text = "D:\\360Downloads";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "目标路径：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 489);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartMonit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MsgListBox);
            this.Controls.Add(this.StopMonit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "QQ图片监控程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox MonitorTip;
        private System.Windows.Forms.CheckBox MiniToTable;
        private System.Windows.Forms.CheckBox AutoRun;
        private System.Windows.Forms.Button StartMonit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox MsgListBox;
        private System.Windows.Forms.Button StopMonit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
    }
}

