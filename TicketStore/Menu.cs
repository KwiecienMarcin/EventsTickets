using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore
{
	class Menu
	{
		private Dictionary<string, Action> _actionsDictionary
			= new Dictionary<string, Action>();

		public void AddCommand(string name, Action action)
		{
			_actionsDictionary.Add(name, action);
		}

		public void RunCommand(string name)
		{
			_actionsDictionary[name]();
		}

		internal void PrintCommands()
		{
			Console.WriteLine("Available commands:");

			foreach (var name in _actionsDictionary.Keys)
			{
				Console.WriteLine($"- {name}");
			}
		}
	}
}
