using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace HDDKeepSpinning
{
    public partial class ServiceMain : ServiceBase
    {
        private Timer _timer;
        private long _interval = 10000;
        private List<char> _targets;

        public ServiceMain()
        {
            _targets = new List<char>();

            InitializeComponent();
            InitializeTimer();

            LoadConfig();
        }

        protected override void OnStart(string[] args)
        {
            InitializeService();
        }

        protected override void OnStop()
        {
            FinalizeService();
        }

        private void InitializeService()
        {
            _timer.Enabled = true;
        }

        private void FinalizeService()
        {
            _timer.Enabled = false;
        }

        private void LoadConfig()
        {
            // get interval setting
            string intervalString = ConfigurationManager.AppSettings["Interval"];
            _interval = long.Parse(intervalString);
            _timer.Interval = _interval;

            // get drive setting
            _targets.Clear();
            string drivesString = ConfigurationManager.AppSettings["Targets"];
            for (int i = 0; i < drivesString.Length; i++)
            {
                char driveLetterChar = drivesString[i];
                if (('a' <= driveLetterChar && driveLetterChar <= 'z') ||
                    ('A' <= driveLetterChar && driveLetterChar <= 'Z'))
                {
                    _targets.Add(driveLetterChar);
                }
            }
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Enabled = false;
            _timer.AutoReset = false;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            for (int i = 0; i < _targets.Count; i++)
            {
                char target = _targets[i];
                string tempDirPath = Convert.ToString(target) + @":\hddspinup";

                try
                {
                    Directory.CreateDirectory(tempDirPath);
                }
                catch
                {
                    // TODO: write a system log
                }

                try
                {
                    Directory.Delete(tempDirPath);
                }
                catch
                {
                    // TODO: write a system log
                }
            }

            LoadConfig();

            // restart timer (it's not AutoReset timer)
            _timer.Enabled = true;
        }
    }
}