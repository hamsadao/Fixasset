//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Wilson.ORMapper
{
	internal class DemoProvider : LicenseProvider
	{
		public override License GetLicense(LicenseContext context,
			Type type, object instance, bool allowExceptions) {
#if (DEMO)
			if (context.UsageMode == LicenseUsageMode.Designtime || Debugger.IsAttached) {
				return new DemoLicense(true);
			}
			else {
				string webMatrix = "WebMatrix";
				string msCassini = "WebServer";
				string orHelper = "ORHelper";
				bool runMatrix;
				try {
					runMatrix = ((Process.GetProcessesByName(webMatrix).Length > 0)
						|| (Process.GetProcessesByName(msCassini).Length > 0)
						|| (Process.GetProcessesByName(orHelper).Length > 0));
				}
				catch {
					runMatrix = false;
				}
				if (runMatrix) {
					return new DemoLicense(true);
				}
				else {
					return null;
				}
			}
#else
			return new DemoLicense(false);
#endif
		}

		private class DemoLicense : License
		{
			private bool development;

			public DemoLicense(bool Development) {
				this.development = Development;
			}

			public override string LicenseKey {
				get {	return (this.development ? "Development" : "Production"); }
			}

			public override void Dispose() { }
		}
	}
}
