using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace FileWatcher.AppCode
{
    //class ShareWatchFile
    //{
    //}
    
    public delegate void FileSystemEvent(String path);

    public interface IDirectoryMonitor
    {
        event FileSystemEvent Change;
        void Start();
    }

    public class DirectoryMonitor : IDirectoryMonitor
    {
        private readonly FileSystemWatcher m_fileSystemWatcher = new FileSystemWatcher();
        private readonly Dictionary<string, DateTime> m_pendingEvents = new Dictionary<string, DateTime>();
        private readonly Timer m_timer;
        private bool m_timerStarted = false;
        private string SavePath;
        private Form1 form = new Form1();

        public DirectoryMonitor(string dirPath, string outPath, Form1 parForm)
        {
            SavePath = outPath;
            m_fileSystemWatcher.Path = dirPath;
            form = parForm;
            m_fileSystemWatcher.IncludeSubdirectories = true;
            m_fileSystemWatcher.Created += new FileSystemEventHandler(OnChange);
            m_fileSystemWatcher.Changed += new FileSystemEventHandler(OnChange);

            m_timer = new Timer(OnTimeout, null, Timeout.Infinite, Timeout.Infinite);
        }

        public event FileSystemEvent Change;

        public void Start()
        {
            m_fileSystemWatcher.EnableRaisingEvents = true;
        }



        private void OnChange(object sender, FileSystemEventArgs e)
        {
            string extName = e.FullPath.Substring(e.FullPath.LastIndexOf('.') + 1, 3).ToLower();
            if (extName == "jpg" || extName == "gif" || extName == "png")
            {
                // Don't want other threads messing with the pending events right now（现在不想让其他线程搞乱等待事件）
                lock (m_pendingEvents)
                {
                    // Save a timestamp for the most recent event for this path（保存此路径的最近事件的时间戳）
                    m_pendingEvents[e.FullPath] = DateTime.Now;

                    // Start a timer if not already started（启动定时器，如果尚未启动）
                    if (!m_timerStarted)
                    {
                        m_timer.Change(100, 100);
                        m_timerStarted = true;
                    }
                }
            }
        }

        private void OnTimeout(object state)
        {
            List<string> paths;

            // Don't want other threads messing with the pending events right now（现在不想让其他线程搞乱等待事件）
            lock (m_pendingEvents)
            {
                // Get a list of all paths that should have events thrown（获取应该抛出事件的所有路径的列表）
                paths = FindReadyPaths(m_pendingEvents);

                // Remove paths that are going to be used now（移除将要使用的路径）
                paths.ForEach(delegate (string path)
                {
                    m_pendingEvents.Remove(path);
                });

                // Stop the timer if there are no more events pending（如果没有更多的事件挂起，请停止计时器）
                if (m_pendingEvents.Count == 0)
                {
                    m_timer.Change(Timeout.Infinite, Timeout.Infinite);
                    m_timerStarted = false;
                }
            }

            // Fire an event for each path that has changed（为每个改变的路径触发一个事件）
            paths.ForEach(delegate (string path)
            {
                FireEvent(path);
            });
        }

        private List<string> FindReadyPaths(Dictionary<string, DateTime> events)
        {
            List<string> results = new List<string>();
            DateTime now = DateTime.Now;

            foreach (KeyValuePair<string, DateTime> entry in events)
            {
                // If the path has not received a new event in the last 75ms（如果路径在最近75ms内没有收到新的事件）
                // an event for the path should be fired（路径的事件应该被触发）
                double diff = now.Subtract(entry.Value).TotalMilliseconds;
                if (diff >= 75)
                {
                    results.Add(entry.Key);
                }
            }

            return results;
        }

        private void FireEvent(string path)
        {
            //System.Windows.Forms.MessageBox.Show(path);
            //FileSystemEvent evt = Change;
            //Change += DirectoryMonitor_Change;
            //if (evt != null)
            //{
            //    evt(path);
            //}
            string newFileName = path.Substring(path.LastIndexOf('\\'));
            newFileName = newFileName.Substring(0, newFileName.LastIndexOf('.') + 4);
            try
            {
                File.Copy(path.Substring(0, path.LastIndexOf('.') + 4), SavePath + newFileName, true);
                form.SetText(DateTime.Now.ToString("yyyy-M-d H:mm:ss：") + "文件【" + newFileName + "】复制成功");
            }
            catch (Exception e)
            {
                form.SetText(e.Message);
            }
        }



        private void DirectoryMonitor_Change(string path)
        {
            System.Windows.Forms.MessageBox.Show(path);
        }
    }
}
