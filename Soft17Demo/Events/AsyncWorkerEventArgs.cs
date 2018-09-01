using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soft17Demo.Events {
    public class AsyncWorkerEventArgs : EventArgs {
        public readonly AsyncStatus Status;
        public readonly int PercentCmpleted;

        public AsyncWorkerEventArgs(AsyncStatus status) {
            Status = status;
            PercentCmpleted = 0;
        }

        public AsyncWorkerEventArgs(AsyncStatus status, int percentCompleted) : this(status) {
            PercentCmpleted = percentCompleted;
        }
    }
    public enum AsyncStatus {
        STOPPED,
        STEP,
        PROCESSING
    }
}
