using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TicketStore.Business.FileManager
{
	public class JsonFileManager
	{
		public void SaveFile(string fileName, Report report)
		{
			if (File.Exists(fileName) || Path.GetExtension(fileName) != ".json")
			{
				Console.WriteLine($"Run into an error. Please check if there is no file with name " +
				                  $"'{fileName}' or if the extension of the file was provided");
				return;
			}

			string json = JsonConvert.SerializeObject(report, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(fileName, json);

			Console.WriteLine("File successfully added.");
		}
	}
}
