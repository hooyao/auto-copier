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

        private string intExt = "*.rar,*.zip";

        private Thread thread;

        private static bool runThread = true;

        private bool ifDel = true;

        private bool isMon = false;
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
            if (!isMon)
            {
                if (copyRdBtn.Checked)
                    ifDel = false;
                if (cutRdBtn.Checked)
                    ifDel = true;

                intExt = txtExt.Text;
                string[] extFilter = intExt.Split(new char[] { ',' });

                foreach (String ext in extFilter)
                {
                    FileSystemWatcher watch = new FileSystemWatcher();
                    watch.Path = sourcePath;

                    watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;

                    watch.Filter = ext;

                    watch.Changed += new FileSystemEventHandler(OnChanged);
                    watch.Created += new FileSystemEventHandler(OnChanged);
                    watch.Renamed += new RenamedEventHandler(OnChanged);
                    watch.EnableRaisingEvents = true;
                }
                this.thread = new Thread(new ThreadStart(copyFun));
                runThread = true;
                this.thread.Start();
                Console.WriteLine("Start Monitoring");
                //change UI status to monitoring
                statusPgBar.Style = ProgressBarStyle.Marquee;
                statusPgBar.ForeColor = Color.Green;
                foreach (Control ct in ctrlList)
                {
                    ct.Enabled = false;
                }
                isMon = true;
            }
            else
            {
                runThread = false;
                lock (copierList)
                {
                    if (this.thread != null && this.thread.IsAlive)
                    {
                        Monitor.Pulse(copierList);
                    }
                }
                this.thread.Join();
                this.thread = null;
                statusPgBar.Style = ProgressBarStyle.Continuous;
                foreach (Control ct in ctrlList)
                {
                    ct.Enabled = true;
                }
                isMon = false;
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            string fileName = e.Name;
            lock (copierList)
            {
                Copier copier = new Copier(e.FullPath, this.targetPath + @"\\" + fileName);
                copier.IfDel = ifDel;
                copierList.Push(copier);
                copier = null;
                Console.WriteLine("File: " + e.Name + " " + e.ChangeType);
                Monitor.Pulse(copierList);
            }
        }

        private static void copyFun()
        {
            lock (copierList)
            {
                while (runThread)
                {
                    if (copierList.Count > 0)
                    {
                        Copier cop = copierList.Pop();
                        //Invoke(new updatePgBarCallBack(updatePgBar), new object[] { true });
                        cop.startCopy();
                    }
                    else
                    {
                        Monitor.Wait(copierList);
                    }
                    //this.Invoke(new updatePgBarCallBack(updatePgBar), new object[] { false });
                }
            }
            Console.WriteLine("thread terminates");
        }

        private delegate void updatePgBarCallBack(bool isCopy);

        private void updatePgBar(bool isCopy)
        {
            if (isCopy)
                statusPgBar.ForeColor = Color.Red;
            else statusPgBar.ForeColor = Color.Green;
        }

        private void copierForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            runThread = false;
            if (this.thread != null && this.thread.IsAlive)
            {
                lock (copierList)
                {
                    Monitor.Pulse(copierList);
                }
                this.thread.Join();
            }
        }
    }
}
