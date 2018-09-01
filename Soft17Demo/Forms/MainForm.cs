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
    public partial class MainForm : Form {
        int counter = 0;
        AsyncWorker worker;
        public MainForm() {
            InitializeComponent();
            this.Load += MainForm_Load;
            startButton.Click += StartButton_Click;
        }

        private void StartButton_Click(object sender, EventArgs e) {
            if (counter == 3) {
                return;
            }
            worker = new AsyncWorker();
            worker.AsyncWorkerEvent += Worker_AsyncWorkerEvent;
            counter++;
            Task.Factory.StartNew(() => {
                Application.Run(worker);
            });
        }

        private void Worker_AsyncWorkerEvent(object sender, AsyncWorkerEventArgs e) {
            AsyncStatus status = e.Status;
            if (e.Status == AsyncStatus.STOPPED) {
                counter--;
            }
            string name = (sender as AsyncWorker).Name;
            this.Invoke(new Action(() => {
                switch (name) {
                    case "AsyncWorker_0":
                        if (status == AsyncStatus.STOPPED) {
                            statusLabel1.Text = e.Status.ToString();
                        }
                        else {
                            statusLabel1.Text = string.Format("PROGRESS {0}%", e.PercentCmpleted);
                        }
                        break;
                    case "AsyncWorker_1":
                        if (status == AsyncStatus.STOPPED) {
                            statusLabel2.Text = e.Status.ToString();
                        }
                        else {
                            statusLabel2.Text = string.Format("PROGRESS {0}%", e.PercentCmpleted);
                        }
                        break;
                    case "AsyncWorker_2":
                        if (status == AsyncStatus.STOPPED) {
                            statusLabel3.Text = e.Status.ToString();
                        }
                        else {
                            statusLabel3.Text = string.Format("PROGRESS {0}%", e.PercentCmpleted);
                        }
                        break;
                    default:
                        return;
                }
            }));
        }

        private void MainForm_Load(object sender, EventArgs e) {
            //throw new NotImplementedException();
        }
    }
}
