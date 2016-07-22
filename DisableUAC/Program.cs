using System.ServiceProcess;

namespace DisableUAC
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			var servicesToRun = new ServiceBase[] 
											{ 
												new DisableUAC() 
											};
			ServiceBase.Run(servicesToRun);
		}
	}
}
