namespace Soft17Demo.Forms {
    partial class AsyncWorker {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.statusLabel = new System.Windows.Forms.Label();
            this.resultProgressBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(258, 52);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(52, 13);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Waiting...";
            // 
            // resultProgressBar
            // 
            this.resultProgressBar.Location = new System.Drawing.Point(12, 88);
            this.resultProgressBar.Name = "resultProgressBar";
            this.resultProgressBar.Size = new System.Drawing.Size(557, 23);
            this.resultProgressBar.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 135);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(213, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start async operation";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(347, 135);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(222, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop async operation";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // AsyncWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 184);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.resultProgressBar);
            this.Controls.Add(this.statusLabel);
            this.Name = "AsyncWorker";
            this.Text = "AsyncWorker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ProgressBar resultProgressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
    }
}