using System.ComponentModel;
using System.Configuration.Install;

namespace DisableUAC
{
	[RunInstaller(true)]
	public partial class ProjectInstaller : Installer
	{
		public ProjectInstaller()
		{
			this.InitializeComponent();
		}
	}
}
