using System;
using System.Collections.Generic;
using System.Linq;
using TicketStore.Business.Models;
using TicketStore.Business.Services;
using TicketStore.CliHelpers.Helpers;

namespace TicketStore.CliHelpers.ModelUtilities
{
	public class TicketUtility
	{
		private Drawer _drawer = new Drawer();
		private UserInterface _userInterface = new UserInterface();
		public void BookTickets(List<TicketBl> tickets, EventBl myEvent, int ticketsToBookAmount)
		{

			var attendantService = new AttendantService();
			for (var i = 0; i < ticketsToBookAmount; i++)
			{
				_drawer.DrawAllAvailableTypesList(myEvent);
				var newAttendant = attendantService.Create(
					_userInterface.GetStringFromUser("Enter the first name of the ticket owner:"),
					_userInterface.GetStringFromUser("Enter the second name of the ticket owner:"),
					_userInterface.GetIntFromUser("Enter the age of the ticket owner:"));
				CreateTicket(tickets, myEvent, newAttendant, null);

			}
		}

		public void BookTickets(UserBl user, List<TicketBl> tickets, EventBl myEvent, int ticketsToBookAmount)
		{

			var attendantService = new AttendantService();
			var userService = new UserService();
			for (var i = 0; i < ticketsToBookAmount; i++)
			{
				_drawer.DrawAllAvailableTypesList(myEvent);
				var newAttendant = attendantService.Create(
					_userInterface.GetStringFromUser("Enter the first name of the ticket owner:"),
					_userInterface.GetStringFromUser("Enter the second name of the ticket owner:"),
					_userInterface.GetIntFromUser("Enter the age of the ticket owner:"));
				CreateTicket(tickets, myEvent, newAttendant, user);

			}
		}

		public void CreateTicket(List<TicketBl> tickets, EventBl myEvent, AttendantBl newAttendant, UserBl user)
		{
			var ticketService = new TicketService();
			 
			var chosenTicketTypeStringFromUser = _userInterface.GetStringFromUser("Enter one of the available ticket types:");
			_drawer.DrawAvailableTypesList(myEvent);

			var chosenTicketType =
				myEvent.AvailableTicketTypes.Find(ticketType => ticketType.Name == chosenTicketTypeStringFromUser);

			if (chosenTicketType.AvailablePlaces == 0)
			{
				Console.WriteLine($"{chosenTicketType.Name} is already sold out.");
				return;
			}

			myEvent.AvailableTicketTypes.FirstOrDefault(a => a.Name == chosenTicketType.Name).AvailablePlaces--;
			var myTicket = new TicketBl(newAttendant, myEvent, chosenTicketType)
				{ EventId = myEvent.Id, AttendantId = newAttendant.Id, AvailableTicketTypeId = chosenTicketType.Id};
			myTicket.BuyingUser = user;

			ticketService.AddTicket(myEvent, myTicket);
		}

		
		
	}
}
