using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

using Soft17Demo.Events;

namespace Soft17Demo.Forms {
    public partial class AsyncWorker : Form {
        private BackgroundWorker worker;
        private static int nameIndex = 0;
        public new string Name { get; private set; }
        public event EventHandler<AsyncWorkerEventArgs> AsyncWorkerEvent = delegate { };

        public AsyncWorker() {
            InitializeComponent();
            this.Load += AsyncWorker_Load;
            this.FormClosing += AsyncWorker_FormClosing;
            startButton.Click += StartButton_Click;
            stopButton.Click += StopButton_Click;
        }

        private void AsyncWorker_FormClosing(object sender, FormClosingEventArgs e) {
            nameIndex--;
            if (worker != null && worker.IsBusy) {
                worker.ProgressChanged -= Worker_ProgressChanged;
                worker.RunWorkerCompleted -= Worker_RunWorkerCompleted;
                worker.CancelAsync();
            }
            AsyncWorkerEventArgs args = new AsyncWorkerEventArgs(AsyncStatus.STOPPED, 0);
            AsyncWorkerEvent(this, args);
        }

        private void StopButton_Click(object sender, EventArgs e) {
            if (worker.IsBusy) { 
                worker.CancelAsync();
            }
            AsyncWorkerEventArgs args = new AsyncWorkerEventArgs(AsyncStatus.STOPPED, 0);
            AsyncWorkerEvent(this, args);
        }

        private void StartButton_Click(object sender, EventArgs e) {
            if(worker.IsBusy){
                return;
            }
            AsyncWorkerEventArgs args = new AsyncWorkerEventArgs(AsyncStatus.PROCESSING, 0);
            AsyncWorkerEvent(this, args);
            worker.RunWorkerAsync();
        }

        private void AsyncWorker_Load(object sender, EventArgs e) {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            Name = string.Format("AsyncWorker_{0}", nameIndex++);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.statusLabel.Invoke(new Action(() => {
                statusLabel.Text = "Stopped";
            }));
            this.resultProgressBar.Invoke(new Action(() => {
                resultProgressBar.Value = 0;
            }));
            AsyncWorkerEventArgs args = new AsyncWorkerEventArgs(AsyncStatus.STOPPED);
            AsyncWorkerEvent(this, args);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            this.statusLabel.Invoke(new Action(() => {
                statusLabel.Text = string.Format("Progress: {0}", e.ProgressPercentage);
            }));
            this.resultProgressBar.Invoke(new Action(() => {
                resultProgressBar.Value = e.ProgressPercentage;
            }));
            AsyncWorkerEventArgs args = new AsyncWorkerEventArgs(AsyncStatus.STEP, e.ProgressPercentage);
            AsyncWorkerEvent(this, args);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e) {
            for (int i = 0; i < 100; i++) {
                Thread.Sleep(200);
                worker.ReportProgress(i);
                if (worker.CancellationPending) {
                    return;
                }
            }
        }
    }
}
