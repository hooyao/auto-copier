using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace AutoCopier
{
    public partial class copierForm : Form
    {
        private static Stack<Copier> copierList = new Stack<Copier>();

        private string sourcePath = "Z:\\";

        private string targetPath = "F:\\";

        private Thread thread;

        private static bool runThread = true;

        public copierForm()
        {
            InitializeComponent();
        }

        private void srcBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                sourcePath = folderBrowserDialog.SelectedPath;
                this.srcText.Text = sourcePath;
            }
            folderBrowserDialog = null;
        }

        private void tgtBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                targetPath = folderBrowserDialog.SelectedPath;
                this.tgtText.Text = targetPath;

            }
            folderBrowserDialog = null;
        }

        private void startMonBtn_Click(object sender, EventArgs e)
        {
            FileSystemWatcher watch = new FileSystemWatcher();
            watch.Path = sourcePath;

            watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;

            watch.Filter = "*.rar";

            watch.Changed += new FileSystemEventHandler(OnChanged);
            watch.Created += new FileSystemEventHandler(OnChanged);
            watch.Renamed += new RenamedEventHandler(OnChanged);
            watch.EnableRaisingEvents = true;
            this.thread = new Thread(new ThreadStart(copyFun));
            this.thread.Start();
            Console.WriteLine("Start Monitoring");
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            string fileName = e.Name;
            lock (copierList)
            {
                copierList.Push(new Copier(e.FullPath, this.targetPath + @"\\" + fileName));
                Console.WriteLine("File: " + e.Name + " " + e.ChangeType);
                Monitor.Pulse(copierList);
            }
        }

        private static void copyFun(){
            lock (copierList)
            {
                while (runThread)
                {
                    if (copierList.Count > 0)
                    {
                        Copier cop = copierList.Pop();
                        cop.startCopy();

                    }
                    else
                    {
                        Monitor.Wait(copierList);
                    }
                }
            }
            Console.WriteLine("thread terminates");
        }

        private void copierForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            runThread = false;
            lock (copierList)
            {
                if (this.thread != null && this.thread.IsAlive)
                {
                    Monitor.Pulse(copierList);

                }
            }
        }
    }
}
