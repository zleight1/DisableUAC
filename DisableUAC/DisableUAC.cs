using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DisableUAC
{
    public partial class DisableUAC : ServiceBase
    {
        private Timer regTimer = null;

        public DisableUAC()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            regTimer = new Timer();
            this.regTimer.Interval = 10000; //10 seconds for testing
            //this.regTimer.Interval = 300000; //every 5 minutes
            this.regTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.regTimer_Tick);
            this.regTimer.Enabled = true;
            Library.WriteErrorLog("Disable UAC Service has started.");
        }

        private void regTimer_Tick(object sender, ElapsedEventArgs e)
        {
            Library.WriteErrorLog("Setting registry keys...");
        }

        protected override void OnStop()
        {
            Library.WriteErrorLog("Disable UAC Service has stopped.");
        }
    }
}
