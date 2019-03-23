using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Data.Repositories;
using TicketStore.Business.Models;

namespace TicketStore.Business.Services
{
	public class AvailableTicketTypeService
	{

		public int AvailablePlacesSum(EventBl chosenEvent)
		{
			int allAvailableTickets = 0;
			foreach (var availableTicketType in chosenEvent.AvailableTicketTypes)
			{
				allAvailableTickets += availableTicketType.AvailablePlaces;
			}

			foreach (var bookedticket in chosenEvent.BookedTickets)
			{
				allAvailableTickets--;
			}

			return allAvailableTickets;
		}

		
		public AvailableTicketTypeBl CreateAvailableTicketType(
			string ticketTypeName, 
			int ticketTypeAvailablePlaces,
			double ticketTypePrice)
		{
			return new AvailableTicketTypeBl()
			{
				Name = ticketTypeName,
				AvailablePlaces = ticketTypeAvailablePlaces,
				Price = ticketTypePrice
			};

		}

		public void AddToEvent(List<AvailableTicketTypeBl> availableTicketTypes, EventBl chosenEvent)
		{
			chosenEvent.AvailableTicketTypes.AddRange(availableTicketTypes);
		}

	}
}