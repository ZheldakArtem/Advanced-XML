using System;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace ValidateXml
{
	public class Program
	{
		private const int RequiredCountOfArgs = 2;
		private static bool success = true;

		public static void Main(string[] args)
		{
			if (!ValidateArgs(args))
			{
				Console.WriteLine("Try again");
				return;
			}

			try
			{
				PerformValidation(args);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			if (success)
			{
				Console.WriteLine($"{args[0]} has been successfully verified. Press any keys");
			}

			Console.ReadKey();
		}

		private static void PerformValidation(string[] args)
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.Schemas.Add(ConfigurationManager.AppSettings["namespace"], args[1]);
			settings.ValidationEventHandler += ValidationCallBack;

			settings.ValidationFlags = settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
			settings.ValidationType = ValidationType.Schema;

			XmlReader reader = XmlReader.Create(args[0], settings);

			while (reader.Read()) ;
		}

		private static void ValidationCallBack(object sender, ValidationEventArgs e)
		{
			success = false;
			Console.WriteLine($"[Line {e.Exception.LineNumber} : Position {e.Exception.LinePosition}] {e.Message}");
		}

		private static bool ValidateArgs(string[] args)
		{
			if (args.Length != RequiredCountOfArgs)
			{
				Console.WriteLine($"Enter {RequiredCountOfArgs} arguments. The first argument should have *.xml, the second should have *.xsd format");

				return false;
			}
			else
			{
				var first = Path.GetExtension(args[0]);
				var second = Path.GetExtension(args[1]);
				if (first != ".xml" || second != ".xsd")
				{
					Console.WriteLine("Incorrect file format. The first argument should be *.xml, the second should be *.xsd format");
					return false;
				}
			}

			return true;
		}
	}
}
