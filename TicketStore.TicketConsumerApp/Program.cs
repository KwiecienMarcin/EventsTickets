using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.TicketConsumerApp
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program().Run();
		}

		private MainMenu _mainMenu = new MainMenu();

		private void Run()
		{
			_mainMenu.UserInputMenu();
		}
	}
}
