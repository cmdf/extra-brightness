using System;
using System.Management;

namespace App {
	class Program {

		// data
		/// <summary>
		/// WMI Namespace.
		/// </summary>
		private static string WmiNs = "root\\WMI";


		// static methods
		/// <summary>
		/// You have to dream before your dreams can come true.
		/// : A. P. J. Abdul Kalam
		/// </summary>
		/// <param name="args">Input arguments.</param>
		static void Main(string[] args) {
			if (args.Length == 0) Get(args);
			else Set(args);
		}

		/// <summary>
		/// Get monitor brightness.
		/// </summary>
		/// <param name="args">NA.</param>
		private static void Get(string[] args) {
			ManagementObject o = Obj(WmiNs, "WmiMonitorBrightness");
			Console.WriteLine(o == null ? "-1" : o.GetPropertyValue("CurrentBrightness"));
		}

		/// <summary>
		/// Set monitor brightness.
		/// </summary>
		/// <param name="args">brightness.</param>
		private static void Set(string[] args) {
			double v = 0;
			double.TryParse(args[0], out v);
			ManagementObject o = Obj(WmiNs, "WmiMonitorBrightnessMethods");
			if (o == null) Console.Error.WriteLine("err: WMI interfacing failed");
			else o.InvokeMethod("WmiSetBrightness", new object[] { uint.MaxValue, (byte)v });
		}

		/// <summary>
		/// Get object of specified Management class.
		/// </summary>
		/// <param name="ns">Namespace.</param>
		/// <param name="cls">Class.</param>
		/// <returns>Management object.</returns>
		private static ManagementObject Obj(string ns, string cls) {
			ManagementScope scp = new ManagementScope(ns);
			SelectQuery qry = new SelectQuery(cls);
			using(ManagementObjectSearcher srch = new ManagementObjectSearcher(scp, qry)) {
				using(ManagementObjectCollection coll = srch.Get()) {
					foreach (ManagementObject obj in coll) return obj;
				}
			}
			return null;
		}
	}
}
