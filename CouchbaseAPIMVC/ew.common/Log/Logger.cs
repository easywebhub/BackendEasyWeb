using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.common
{
    public partial class EwhLogger
    {
        public static Logger Common
        {
            get
            {
                return LogManager.GetCurrentClassLogger();
            }
        }

        public static PerfomanceChecker Perfomance
        {
            get { return PerfomanceChecker.Instance; }
        }

        public partial class PerfomanceChecker
        {
            private Stopwatch _stopwatch;
            private Logger _loggingService;
            private static readonly object padlock = new object();

            public PerfomanceChecker()
            {
                _loggingService = LogManager.GetCurrentClassLogger();
                _stopwatch = new Stopwatch();
            }

            private static PerfomanceChecker instance = null;
            public static PerfomanceChecker Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new PerfomanceChecker();
                        }
                        return instance;
                    }
                }
            }

            public void Start()
            {
                _stopwatch.Restart();
            }

            public double GetTotalSeconds()
            {
                return _stopwatch.Elapsed.TotalSeconds;
            }

            public void ExcutedTime(string funcName)
            {
                _loggingService.Debug(string.Format("{0} - ExecutedTime: {1} s ", funcName, _stopwatch.Elapsed.TotalSeconds));
            }

        }

        

    }
}
