using System;
using System.Globalization;

namespace TicketStore.CliHelpers.Helpers
{
	public class UserInterface
	{
		public string GetStringFromUser(string stringEntry)
		{
			Console.WriteLine($"{stringEntry}");
			return Console.ReadLine();
		}

		public int GetIntFromUser(string stringEntry)
		{
			Console.WriteLine($"{stringEntry}");
			int number;
			stringEntry = Console.ReadLine();
			while (!int.TryParse(stringEntry, out number))
			{
				Console.WriteLine("Thats not an number, try it once more.");
				stringEntry = Console.ReadLine();
			}

			return number;
		}

		public double GetDoubleFromUser(string stringEntry)
		{
			Console.WriteLine($"{stringEntry}");
			double number;
			stringEntry = Console.ReadLine();
			while (!double.TryParse(stringEntry, out number))
			{
				Console.WriteLine("Thats not an number, try it once more.");
				stringEntry = Console.ReadLine();
			}

			return number;
		}
		
		public DateTime GetDateTimeFromUser()
		{
			var message = "Please enter the Date in the following format dd-mm-yyyy";
			while (true)
			{
				var userEntry = GetStringFromUser(message);
				var isCorrect = CheckIfDateIsCorrect(userEntry, out var datetime);

				if (!isCorrect)
				{
					message = "You entered your Date in wrong format, please try one more time. The correct format is dd-mm-yyyy";
					continue;
				}
				return datetime;
			}
		}

		private bool CheckIfDateIsCorrect(string userEntry, out DateTime dateTime)
		{
			var format = "dd-mm-yyyy";
			return DateTime.TryParseExact(userEntry, format,
				CultureInfo.InvariantCulture,
				DateTimeStyles.None, out dateTime);
		}

		public void TrafficLightConsoleForeground(int allAvailableTickets)
		{
			if (allAvailableTickets == 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			else if (allAvailableTickets <= 10)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}

		}
	}
}
