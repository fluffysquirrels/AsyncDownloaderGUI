using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderGUI
{
    public class DownloadPart
    {
        public DownloadPart(string id, long partBytesStartIndex, long partBytesCount, IProgress<long> progressListener)
        {
            this.Id = id;
            this.PartBytesStartIndex = partBytesStartIndex;
            this.PartBytesCount = partBytesCount;
            this._progressListener = progressListener;
        }

        public readonly string Id;
        public readonly long PartBytesStartIndex;
        public readonly long PartBytesCount;
        private long _bytesDone = 0;

        public long BytesDone
        {
            get { return _bytesDone; }
        }

        private readonly IProgress<long> _progressListener;

        public const long DownloadChunkSize = 10;
        public readonly TimeSpan DownloadWaitTime = GetWaitTime();

        private static readonly Random rand = new Random();

        private static TimeSpan GetWaitTime()
        {
            lock (rand)
            {
                var millis = rand.Next(50, 150);
                return TimeSpan.FromMilliseconds(millis);
            }
        }

        private volatile bool _paused = true;

        public bool IsDone
        {
            get { return _bytesDone >= PartBytesCount; }
        }

        public bool IsRunning
        {
            get { return !_paused; }
        }

        public void Pause()
        {
            _paused = true;
        }

        public async Task Go()
        {
            _paused = false;

            while (!IsDone)
            {
                if (_paused)
                {
                    return;
                }

                _bytesDone += DownloadChunkSize;
                await Task.Delay(DownloadWaitTime);

                if (_progressListener != null)
                {
                    _progressListener.Report(_bytesDone);
                }
            }
        }
    }
}
