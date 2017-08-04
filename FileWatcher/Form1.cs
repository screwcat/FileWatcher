using FileWatcher.AppCode;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileWatcher
{
    public partial class Form1 : Form
    {
        private delegate void SetTextDelegate(string text);
        //public static FileSystemWatcher watcher = new FileSystemWatcher();
        public delegate void SendMessage(object sender, String e);
        public static event SendMessage message;
        private bool MTip;
        private string MonitFolder = "";
        private bool MinToTable;
        public Form1()
        {
            InitializeComponent();
            this.label2.Text = "如遇360拦截，请选择“允许程序所有操作”，该检测软件对文件下的所有文件创建进行监控，并把创建的文件保存到指定文件夹，如使用中有什么问题，请联系作者，带头大哥QQ：33982755";
            this.StopMonit.Enabled = false;
            message += Form1_message;
            //Form1.watcher.NotifyFilter = (NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Attributes | NotifyFilters.LastWrite | NotifyFilters.LastAccess);
            //Form1.watcher.Filter = "*.*";
            //Form1.watcher.Changed += new FileSystemEventHandler(this.OnChanged);
            //Form1.watcher.Created += new FileSystemEventHandler(this.OnChanged);
            //Form1.watcher.Deleted += new FileSystemEventHandler(this.OnChanged);
            //Form1.watcher.Renamed += new RenamedEventHandler(this.OnRenamed);
        }

        private void Form1_message(object sender, string e)
        {
            SetText(e);
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            this.SetText(string.Concat(new object[]
            {
                "文件: ",
                e.FullPath,
                " ",
                e.ChangeType
            }));
            //File.Copy(e.FullPath, textBox2.Text + "\\" + e.Name);

            
        }

        private void CopyFile(string sourceFileName, string destFileName)
        {
            if (File.Exists(sourceFileName))
            {
                //1.创建读入文件流对象
                FileStream streamRead = new FileStream(sourceFileName, FileMode.Open);
                //2.创建1个字节数组，用于接收文件流对象读操作文件值
                byte[] data = new byte[1024 * 1024];//1M
                int length = 0;
                FileStream streamWrite = new FileStream(sourceFileName.Substring(sourceFileName.IndexOf('\\')), FileMode.Create, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite);
                do
                {
                    //3.文件流读方法的参数1.data-文件流读出数据要存的地方，2. 0--从什么位置读，3. data.Length--1次读多少字节数据
                    //3.1 Read方法的返回值是一个int类型的，代表他真实读取 字节数据的长度，
                    length = streamRead.Read(data, 0, data.Length);//大文件读入时候，我们定义字节长度的可能会有限，如果文件超大，要接收文件流对象的Read()方法，会返回读入的实际长度
                                                                   //加密 和解密
                    for (int i = 0; i < length; i++)
                    {
                        data[i] = (byte)(255 - data[i]);
                    }
                    streamWrite.Write(data, 0, length);
                } while (length == data.Length); //如果实际写入长度等于我们设定的长度，有两种情况1.文件正好是我们设定的长度2.文件超大只上传了截取的一部分
            }
        }


        public void SetText(string text)
        {
            if (this.MsgListBox.InvokeRequired)
            {
                Form1.SetTextDelegate method = new Form1.SetTextDelegate(this.SetText);
                base.Invoke(method, new object[]
                {
                    text
                });
                return;
            }
            this.MsgListBox.Items.Add(text);
            this.MsgListBox.TopIndex = this.MsgListBox.Items.Count - 1;
            this.MsgListBox.SetSelected(this.MsgListBox.Items.Count - 1, true);
        }

        private void StartMonit_Click(object sender, EventArgs e)
        {
            this.MonitFolder = this.textBox1.Text;
            try
            {
                if (!new DirectoryInfo(this.MonitFolder).Exists)
                {
                    MessageBox.Show("检测文件不存在,请核实");
                }
                else
                {
                    this.notifyIcon1.Text = "文件夹检测中";
                    this.MsgListBox.Items.Add("文件夹监测中......");
                    this.MsgListBox.SetSelected(this.MsgListBox.Items.Count - 1, true);
                    //Form1.watcher.Path = this.MonitFolder;
                    //Form1.watcher.EnableRaisingEvents = true;
                    this.StopMonit.Enabled = true;
                    this.StartMonit.Enabled = false;
                    this.button1.Enabled = false;
                    this.textBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常：" + ex.Message);
            }
            IDirectoryMonitor iDM = new DirectoryMonitor(MonitFolder, textBox2.Text, this);
            iDM.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "检测文件夹选择...";
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void StopMonit_Click(object sender, EventArgs e)
        {
            this.StopMonit.Enabled = false;
            this.StartMonit.Enabled = true;
            //Form1.watcher.EnableRaisingEvents = false;
            this.button1.Enabled = true;
            this.textBox1.Enabled = true;
            this.MsgListBox.Items.Add("文件夹监测终止.");
            this.notifyIcon1.Text = "文件夹监测";
            this.MsgListBox.SetSelected(this.MsgListBox.Items.Count - 1, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "目标文件夹选择...";
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void AutoRun_CheckedChanged(object sender, EventArgs e)
        {
            if (this.AutoRun.Checked)
            {
                try
                {
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    registryKey.SetValue("文件夹监测.exe", Application.ExecutablePath);
                    registryKey.Close();
                    return;
                }
                catch (IOException)
                {
                    return;
                }
            }
            RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string[] valueNames = registryKey2.GetValueNames();
            string[] array = valueNames;
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                if (text.Equals("文件夹监测.exe"))
                {
                    registryKey2.DeleteValue("文件夹监测.exe");
                    registryKey2.Close();
                    return;
                }
            }
        }

        private void MiniToTable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.MiniToTable.Checked)
            {
                this.MinToTable = true;
                this.notifyIcon1.Visible = true;
                return;
            }
            this.MinToTable = false;
            this.notifyIcon1.Visible = false;
        }

        private void MonitorTip_CheckedChanged(object sender, EventArgs e)
        {
            if (this.MonitorTip.Checked)
            {
                this.MTip = true;
                return;
            }
            this.MTip = false;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized && this.MinToTable)
            {
                this.notifyIcon1.Visible = true;
                base.ShowInTaskbar = false;
                this.notifyIcon1.ShowBalloonTip(30, "监控中", "文件夹正在监视中！", ToolTipIcon.Info);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            notifyIcon1.Visible = true;
            string[] valueNames = registryKey.GetValueNames();
            string[] array = valueNames;
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                if (text.Equals("文件夹监测.exe"))
                {
                    this.AutoRun.Checked = true;
                    registryKey.Close();
                    return;
                }
            }
        }
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.WindowState = FormWindowState.Normal;
                base.Activate();
                base.ShowInTaskbar = true;
            }
        }
    }
}
