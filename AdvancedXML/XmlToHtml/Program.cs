using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace XmlToHtml
{
	public class Program
	{
		private const int RequiredCountOfArgs = 3;
		public static void Main(string[] args)
		{
			ValidateArgs(args);
			try
			{
				var transform = new XslCompiledTransform();
				var stylesheet = args[1];
				var inputXml = args[0];
				var resultHtml = args[2];

				transform.Load(args[1]);
				transform.Transform(inputXml, resultHtml);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}

			Console.WriteLine("Html file has been generated!");
		}

		private static bool ValidateArgs(string[] args)
		{
			if (args.Length != RequiredCountOfArgs)
			{
				Console.WriteLine($"Wrong number of parameters.(Enter {RequiredCountOfArgs} parameters)");

				return false;
			}
			if (!TryOpenFile(args[0]) || !TryOpenFile(args[1]))
			{
				return false;
			}

			return true;
		}

		private static bool TryOpenFile(string filePath)
		{
			try
			{
				using (var file = File.Open(filePath, FileMode.Open))
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
