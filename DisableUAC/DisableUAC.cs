using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace DisableUAC
{
	using System.Configuration;

	public partial class DisableUAC : ServiceBase
	{
		private Timer regTimer;
		const string DefaultTimerInterval = @"30000"; //every 30 seconds

		public DisableUAC()
		{
			this.InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			this.regTimer = new Timer
								{
									Interval =
										Convert.ToDouble(ConfigurationManager.AppSettings[@"TimerIntervalInSeconds"] ?? DefaultTimerInterval)
								};

			this.regTimer.Elapsed += this.regTimer_Tick;
			this.regTimer.Enabled = true;
			Library.WriteErrorLog("Disable UAC Service has started.");
		}

		private void regTimer_Tick(object sender, ElapsedEventArgs e)
		{
			try
			{
				Library.WriteUACRegistryValue();
			}
			catch (Exception ex)
			{
				//Bad stuff!
				Debug.Print("Exception!");
				Library.WriteErrorLog(ex);
			}

		}

		protected override void OnStop()
		{
			this.regTimer.Stop();
			Library.WriteErrorLog("Disable UAC Service has stopped.");
		}
	}
}
