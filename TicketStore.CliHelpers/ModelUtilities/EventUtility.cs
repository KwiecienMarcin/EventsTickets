using System;
using System.Collections.Generic;
using TicketStore.Business.Models;
using TicketStore.Business.Services;
using TicketStore.CliHelpers.Helpers;

namespace TicketStore.CliHelpers.ModelUtilities
{
	public class EventUtility
	{
		private Drawer _drawer = new Drawer();
		private UserInterface _userInterface = new UserInterface();
		private AvailableTicketTypeService _availableTicketTypeService = new AvailableTicketTypeService();
		public void DrawAllEventsList(List<EventBl> events)
		{
			foreach (var chosenEvent in events)
			{
				var allAvailableTickets = _availableTicketTypeService.AvailablePlacesSum(chosenEvent);

				_drawer.DrawEventListCell(chosenEvent, allAvailableTickets);

				chosenEvent.IsSoldOut = allAvailableTickets == 0;
			}
		}
		public void DrawAvailableEventsList(List<EventBl> events)
		{
			foreach (var chosenEvent in events)
			{
				var allAvailableTickets = _availableTicketTypeService.AvailablePlacesSum(chosenEvent);
				

				if (allAvailableTickets != 0)
				{
					_drawer.DrawEventListCell(chosenEvent, allAvailableTickets);
					return;
				}

				chosenEvent.IsSoldOut = true;
			}
		}
		public EventBl SelectEvent(List<EventBl> events)
		{
			var _eventService = new EventService();
			var myEventStringFromUser = _userInterface.GetStringFromUser("Please enter the Event you want to see Details from: ");
			EventBl myEvent = _eventService.GetEvent(events, myEventStringFromUser);
			while (myEvent == null)
			{
				Console.WriteLine($"There is no event named as {myEventStringFromUser} existing! Please try one more time");
				myEventStringFromUser = _userInterface.GetStringFromUser("Please enter the Event you want to see Details from: ");
				myEvent = _eventService.GetEvent(events, myEventStringFromUser);
			}
			while (myEvent.IsSoldOut)
			{
				Console.WriteLine($"The {myEvent.Name} event is already sold out! Try another one.");
				myEventStringFromUser = _userInterface.GetStringFromUser("Please enter the Event you want to see Details from: ");
				myEvent = _eventService.GetEvent(events, myEventStringFromUser);
			}
			Console.WriteLine($"Description: {myEvent.Description}");
			return myEvent;
		}
	}
}
