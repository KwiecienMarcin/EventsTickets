using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Business.Models;

namespace TicketStore.Business.Services
{
	interface IReportCalculationService
	{
		int GetAgeOfOldestAttendant(EventBl chosentEvent);
		int GetAgeOfOldestAttendant(AvailableTicketTypeBl ticketType, EventBl chosenEvent);
		int GetAgeOfYoungestAttendant(EventBl chosenEvent);
		int GetAgeOfYoungestAttendant(AvailableTicketTypeBl ticketType, EventBl chosenEvent);
		double GetAverageAgeOfAttendants(EventBl chosenEvent);
		double GetAverageAgeOfAttendants(AvailableTicketTypeBl ticketType, EventBl chosenEvent);
		double GetTotalIncomeOfSoldTickets(EventBl chosenEvent);
		double GetTotalIncomeOfSoldTickets(AvailableTicketTypeBl ticketType, EventBl chosenEvent);

	}

	public class ReportCalculationService : IReportCalculationService
	{
		

		public int GetAgeOfOldestAttendant(EventBl chosenEvent)
		{
			return chosenEvent.BookedTickets.Max(x => x.Attendant.Age);
		}

		public int GetAgeOfYoungestAttendant(EventBl chosenEvent)
		{
			return chosenEvent.BookedTickets.Min(x => x.Attendant.Age);
		}
		

		public double GetAverageAgeOfAttendants(EventBl chosenEvent)
		{
			return chosenEvent.BookedTickets.Average(x => x.Attendant.Age);
		}

		public double GetTotalIncomeOfSoldTickets(EventBl chosenEvent)
		{
			return chosenEvent.BookedTickets.Sum(t => t.Price);
		}

		public int GetAgeOfOldestAttendant(AvailableTicketTypeBl ticketType, EventBl chosenEvent)
		{
			return chosenEvent.BookedTickets.
				Where(t => t.ChosenTicketType == ticketType).Max(x => x.Attendant.Age);
		}

		public int GetAgeOfYoungestAttendant(AvailableTicketTypeBl ticketType, EventBl chosenEvent)
		{
			return chosenEvent.BookedTickets.
				Where(t => t.ChosenTicketType == ticketType).Min(x => x.Attendant.Age);
		}

		public double GetAverageAgeOfAttendants(AvailableTicketTypeBl ticketType, EventBl chosenEvent)
		{
			return chosenEvent.BookedTickets.
				Where(t => t.ChosenTicketType == ticketType).Average(x => x.Attendant.Age);
		}

		public double GetTotalIncomeOfSoldTickets(AvailableTicketTypeBl ticketType, EventBl chosenEvent)
		{
			return chosenEvent.BookedTickets.
				Where(t => t.ChosenTicketType == ticketType).Sum(t => t.Price);
		}
	}
}
