using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Business.Models;
using TicketStore.Business.Services;

namespace TicketStore.Business
{
	public class Report
	{
		private ReportCalculationService _reportCalculationService = new ReportCalculationService();
		public int AgeOfOldestAttendantOfChosenEvent { get; set; }

		public int AgeOfYoungestAttendantOfChosenEvent { get; set; }

		public double AverageAgeOfAttendantsOfChosenEvent { get; set; }

		public double TotalIncomeOfSoldTicketsOfChosenEvent { get; set; }

		public int AgeOfOldestAttendantOfChosenTicketTypeAndEvent { get; set; }

		public int AgeOfYoungestAttendantOfChosenTicketTypeAndEvent { get; set; }

		public double AverageAgeOfAttendantsOfChosenTicketTypeAndEvent { get; set; }

		public double TotalIncomeOfSoldTicketsOfChosenTicketTypeAndEvent { get; set; }

		public Report(EventBl chosenEvent, AvailableTicketTypeBl chosenAvailableTicketType)
		{
			AgeOfOldestAttendantOfChosenEvent = _reportCalculationService
				.GetAgeOfOldestAttendant(chosenEvent);

			AgeOfYoungestAttendantOfChosenEvent = _reportCalculationService
				.GetAgeOfYoungestAttendant(chosenEvent);

			AverageAgeOfAttendantsOfChosenEvent = _reportCalculationService
				.GetAverageAgeOfAttendants(chosenEvent);

			TotalIncomeOfSoldTicketsOfChosenEvent = _reportCalculationService
				.GetTotalIncomeOfSoldTickets(chosenEvent);

			AgeOfOldestAttendantOfChosenTicketTypeAndEvent = _reportCalculationService
				.GetAgeOfOldestAttendant(chosenAvailableTicketType, chosenEvent);

			AgeOfYoungestAttendantOfChosenTicketTypeAndEvent = _reportCalculationService
				.GetAgeOfYoungestAttendant(chosenAvailableTicketType, chosenEvent);

			AverageAgeOfAttendantsOfChosenTicketTypeAndEvent = _reportCalculationService
				.GetAverageAgeOfAttendants(chosenAvailableTicketType, chosenEvent);

			TotalIncomeOfSoldTicketsOfChosenTicketTypeAndEvent = _reportCalculationService
				.GetTotalIncomeOfSoldTickets(chosenAvailableTicketType, chosenEvent);
		}
	}
}
