using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloaderGUI
{
    public partial class frmMain : Form
    {
        private List<DownloadPartWithUi> _parts = new List<DownloadPartWithUi>();
        
        public frmMain()
        {
            InitializeComponent();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            _parts = CreateDownloadParts();
            var doitTasks = _parts.Select(p => p.DownloadPart.Go()).ToList();

            UpdateButtonsState();

            await Task.WhenAll(doitTasks.ToArray());

            UpdateButtonsState();
        }

        private class DownloadPartWithUi
        {
            public DownloadPart DownloadPart;
            public ProgressBar ProgressBar;
        }

        private List<DownloadPartWithUi> CreateDownloadParts(int numParts = 6, int partSize = 250)
        {
            var parts = new List<DownloadPartWithUi>();

            var totalBytes = numParts * partSize;

            ProgressBarContainer.Controls.Clear();
            ProgressBarTotal.Value = 0;
            ProgressBarTotal.Maximum = totalBytes;

            foreach(int i in Enumerable.Range(1, numParts))
            {
                var part = new DownloadPart(
                                                "Part " + i.ToString(),
                                                (i - 1) * partSize,
                                                partSize,
                                                new Progress<long>( (ignoredLong) => UpdateUi(parts)));
                var progressBar = new ProgressBar()
                    {
                        Minimum = 0,
                        Maximum = partSize,
                    };
                ProgressBarContainer.Controls.Add(progressBar);
                
                parts.Add(new DownloadPartWithUi{DownloadPart = part, ProgressBar = progressBar});
            }

            return parts;
        }

        private void UpdateUi(List<DownloadPartWithUi> parts)
        {
            var progressMessage = new StringBuilder();

            var totalBytesDone = (int) parts.Sum(partWithUi => partWithUi.DownloadPart.BytesDone);
            ProgressBarTotal.Value = totalBytesDone;

            foreach (var partWithUi in parts)
            {
                var part = partWithUi.DownloadPart;

                progressMessage.AppendFormat("{0} ({1}): {2} bytes of {3} downloaded\r\n", part.Id, part.DownloadWaitTime.TotalMilliseconds, part.BytesDone, part.PartBytesCount);

                partWithUi.ProgressBar.Value = (int) part.BytesDone;
            }

            txtProgress.Text = progressMessage.ToString();

            UpdateButtonsState();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            foreach (var part in _parts)
            {
                part.DownloadPart.Pause();
            }

            UpdateButtonsState();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            foreach (var part in _parts)
            {
                part.DownloadPart.Go();
            }

            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool someUnfinished = _parts.Any(part => !part.DownloadPart.IsDone);
            bool someRunning = _parts.Any(part => part.DownloadPart.IsRunning);

            btnGo.Enabled = !someUnfinished;
            btnPause.Enabled = someUnfinished && someRunning;
            btnResume.Enabled = someUnfinished && !someRunning;
        }
    }
}
