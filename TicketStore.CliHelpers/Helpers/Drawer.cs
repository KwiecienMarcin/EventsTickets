using System;
using TicketStore.Business.Models;

namespace TicketStore.CliHelpers.Helpers
{
    public class Drawer 
    {
	    private UserInterface _userInterface = new UserInterface();
		public void DrawAllAvailableTypesList(EventBl myEvent)
        {
            Console.WriteLine($"\nPlease choose one of the available tickets for {myEvent.Name} at the {myEvent.Date}.");
            foreach (var availableTicketType in myEvent.AvailableTicketTypes)
            {
	            _userInterface.TrafficLightConsoleForeground(availableTicketType.AvailablePlaces);
                Console.WriteLine($"{availableTicketType.Name} - {availableTicketType.Price}$ - {availableTicketType.AvailablePlaces} places left. ");
            }
            Console.ResetColor();
        }

        public void DrawAvailableTypesList(EventBl myEvent)
        {
            Console.WriteLine($"\nPlease choose one of the available tickets for {myEvent.Name} at the {myEvent.Date}.");
            foreach (var availableTicketType in myEvent.AvailableTicketTypes)
            {
                if (availableTicketType.AvailablePlaces == 0) continue;

	            _userInterface.TrafficLightConsoleForeground(availableTicketType.AvailablePlaces);
                Console.WriteLine($"{availableTicketType.Name} - {availableTicketType.Price}$ - {availableTicketType.AvailablePlaces} places left. ");
            }
            Console.ResetColor();
        }

        public void DrawBookedTicketsList(EventBl myEvent)
        {
            Console.WriteLine($"\nAll tickets booked in H0TicketStore for {myEvent.Name}:");
            foreach (var ticket in myEvent.BookedTickets)
            {
                Console.WriteLine("____________________________________________________________________________");
                Console.WriteLine($"|Ticket Owner: {ticket.Attendant.FirstName} {ticket.Attendant.LastName}");
                Console.WriteLine($"|Ticket Type: {ticket.ChosenTicketType.Name}");
            }
        }

        public void DrawEventListCell(EventBl chosenEvent, int allAvailableTickets)
        {
	        _userInterface.TrafficLightConsoleForeground(allAvailableTickets);
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine($"|{chosenEvent.Date} - {chosenEvent.Name} - Available Tickets of all types: {allAvailableTickets}");
            Console.ResetColor();
            Console.WriteLine($"Description: {chosenEvent.Description}");
        }
    }
}
