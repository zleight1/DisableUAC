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

            this.regTimer.Interval = 60000; //every 60 seconds
            this.regTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.regTimer_Tick);
            this.regTimer.Enabled = true;
            Library.WriteErrorLog("Disable UAC Service has started.");
        }

        private void regTimer_Tick(object sender, ElapsedEventArgs e)
        {
            Library.WriteErrorLog("Setting registry keys...");
            try
            {
                Library.WriteUACRegistryValue();
                Library.WriteErrorLog("Registry keys set...");
            }
            catch (Exception ex)
            {
                //Bad stuff?
                Debug.Print("Exception!");
                Library.WriteErrorLog(ex);
            }

        }

        protected override void OnStop()
        {
            regTimer.Stop();
            Library.WriteErrorLog("Disable UAC Service has stopped.");
        }
    }
}
