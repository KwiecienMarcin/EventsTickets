using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Business.Services;
using TicketStore.Business.Models;

namespace TicketStore
{
	public class Program
	{
		public static void Main(string[] args)
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
