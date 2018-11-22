using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace XmlToRss
{
	public class Program
	{
		private const int RequiredCountOfArgs = 1;
		public static void Main(string[] args)
		{

			if (!ValidateArgs(args))
			{
				Console.WriteLine("Something was wrong");
				return;
			}

			try
			{
				PerformTransformation(args);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}

			Console.WriteLine("The File has been successfully transformed.");
		}

		private static void PerformTransformation(string[] args)
		{
			var stylesheetPath = ConfigurationManager.AppSettings["XmlToRss_Xslt"];

			try
			{
				var transform = new XslCompiledTransform();
				transform.Load(stylesheetPath);

				transform.Transform(args[0], "BookRss.xml");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw ex;
			}
		}

		private static bool ValidateArgs(string[] args)
		{
			if (args.Length != RequiredCountOfArgs)
			{
				Console.WriteLine($"Wrong number of parameters.(Enter {RequiredCountOfArgs} parameter)");

				return false;
			}
			try
			{
				using (var file = File.Open(args[0], FileMode.Open))
				{
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);

				return false;
			}

			return true;
		}
	}
}
