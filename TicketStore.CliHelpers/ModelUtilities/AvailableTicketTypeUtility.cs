using System.Collections.Generic;
using TicketStore.Business.Models;
using TicketStore.Business.Services;
using TicketStore.CliHelpers.Helpers;

namespace TicketStore.CliHelpers.ModelUtilities
{
	public class AvailableTicketTypeUtility
	{
		private UserInterface _userInterface = new UserInterface();
		public string Name;
		public double Price;
		public int AvailablePlaces;
		public 
			int AvailablePlacesSum(EventBl chosenEvent)
		{
			int allAvailableTickets = 0;
			foreach (var availableTicketType in chosenEvent.AvailableTicketTypes)
			{
				allAvailableTickets += availableTicketType.AvailablePlaces;
			}

			return allAvailableTickets;
		}
		public List<AvailableTicketTypeUtility> GetTicketTypesFromUser()
		{
			var availableTicketTypesForChosenEvent = new List<AvailableTicketTypeUtility>();
			var amountOfTicketTypes = _userInterface.GetIntFromUser("How many ticket types would like to enter?");
			for (var i = 0; i < amountOfTicketTypes; i++)
			{
				availableTicketTypesForChosenEvent.Add(new AvailableTicketTypeUtility
				{
					Name = _userInterface.GetStringFromUser("Please enter the name of your ticket type."),
					AvailablePlaces = _userInterface.GetIntFromUser("Please enter the amount of available places."),
					Price = _userInterface.GetDoubleFromUser("Please enter the price of the ticket.")
				});
			}

			return availableTicketTypesForChosenEvent;
		}

		public List<AvailableTicketTypeBl> SetTicketTypes(int amountOfTicketTypes)
		{
			var availableTicketTypeService = new AvailableTicketTypeService();
			var availableTicketTypes = new List<AvailableTicketTypeBl>();
			for (int i = 1; i <= amountOfTicketTypes; i++)
			{			    
				availableTicketTypes.Add(availableTicketTypeService.CreateAvailableTicketType(
					_userInterface.GetStringFromUser($"Please enter the name of your {i}. ticket type."),
					_userInterface.GetIntFromUser("Please enter the amount of available places."),
					_userInterface.GetDoubleFromUser("Please enter the price of the ticket.")));
			}

			return availableTicketTypes;
		}
	}

}
