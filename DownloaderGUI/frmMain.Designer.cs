namespace DownloaderGUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.ProgressBarContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.ProgressBarTotal = new System.Windows.Forms.ProgressBar();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(27, 334);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(120, 34);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(499, 12);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(428, 286);
            this.txtProgress.TabIndex = 1;
            // 
            // ProgressBarContainer
            // 
            this.ProgressBarContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ProgressBarContainer.Location = new System.Drawing.Point(27, 12);
            this.ProgressBarContainer.Name = "ProgressBarContainer";
            this.ProgressBarContainer.Size = new System.Drawing.Size(452, 286);
            this.ProgressBarContainer.TabIndex = 3;
            // 
            // ProgressBarTotal
            // 
            this.ProgressBarTotal.Location = new System.Drawing.Point(27, 305);
            this.ProgressBarTotal.Name = "ProgressBarTotal";
            this.ProgressBarTotal.Size = new System.Drawing.Size(452, 23);
            this.ProgressBarTotal.TabIndex = 4;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(154, 335);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(112, 33);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause!";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(273, 334);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(111, 34);
            this.btnResume.TabIndex = 6;
            this.btnResume.Text = "Resume!";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 383);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.ProgressBarTotal);
            this.Controls.Add(this.ProgressBarContainer);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.btnGo);
            this.Name = "frmMain";
            this.Text = "DownloaderGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.FlowLayoutPanel ProgressBarContainer;
        private System.Windows.Forms.ProgressBar ProgressBarTotal;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnResume;
    }
}

