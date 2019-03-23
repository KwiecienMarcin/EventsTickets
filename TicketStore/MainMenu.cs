using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Business.Models;
using TicketStore.Business.Services;
using TicketStore.Business;
using TicketStore.Business.FileManager;
using TicketStore.CliHelpers.Helpers;
using TicketStore.CliHelpers.ModelUtilities;


namespace TicketStore
{
	internal class MainMenu
	{
		private Menu _menu = new Menu();
		private EventService _eventService = new EventService();
		private ReportCalculationService _reportCalculationService = new ReportCalculationService();
		private TicketService _ticketService = new TicketService();
		private EventUtility _eventUtility = new EventUtility();
		private TicketUtility _ticketUtility = new TicketUtility();
		private AvailableTicketTypeUtility _availableTicketTypeUtility = new AvailableTicketTypeUtility();
		private Drawer _drawer = new Drawer();
		private UserInterface _userInterface = new UserInterface();

		internal void UserInputMenu()
		{
			Console.WriteLine("Welcome to H0TicketStore by BetterThanJava Sp. z o.o.");
			_menu.AddCommand("LeaveApp", LeaveApp);
			_menu.AddCommand("ListAllUpcomingEvents", ListAllUpcomingEvents);
			_menu.AddCommand("ListAllAvailableEvents", ListAllAvailableEvents);
			_menu.AddCommand("AddAnEvent", AddAnEvent);
			_menu.AddCommand("GetAReport", GetAReport);
			_menu.AddCommand("SaveAReport", SaveAReport);
			_menu.AddCommand("SelectEventShowBookedTickets", SelectEventShowBookedTickets);
			_menu.AddCommand("SelectEventAndShowAvailableTicketTypes", SelectEventAndShowAvailableTicketTypes);
			_menu.AddCommand("SelectEventAndBuyTickets", SelectEventAndBuyTickets);

			while (true)
			{
				_menu.PrintCommands();
				var command = _userInterface.GetStringFromUser("Enter command");
				_menu.RunCommand(command);
			}
		}

		private void SaveAReport()
		{
			var _jsonFileManager = new JsonFileManager();
			var myEvent = _eventUtility.SelectEvent(_eventService.GetEvents());
			var myAvailableTicketType = _eventService.GetAvailableTicketTypeFromSelectedEvent(
				_userInterface.GetStringFromUser("Please enter Ticketype name for which you want to save a report."), myEvent);
			var myReport = new Report(myEvent, myAvailableTicketType);
			_jsonFileManager.SaveFile(_userInterface.GetStringFromUser("Enter the reports file name"),myReport);

		}

		private void SelectEventAndBuyTickets()
		{
			var myEvent = _eventUtility.SelectEvent(_eventService.GetEvents());
			var ticketsToBookAmount = _userInterface.GetIntFromUser("Enter the amount of tickets you would like to buy.");
			_ticketUtility.BookTickets(myEvent.BookedTickets, myEvent, ticketsToBookAmount);
		}

		private void GetAReport()
		{
			var myEvent = _eventUtility.SelectEvent(_eventService.GetEvents());
			var myAvailableTicketType = _eventService.GetAvailableTicketTypeFromSelectedEvent(
				_userInterface.GetStringFromUser("Please enter Ticketype name for which you want the report."), myEvent);
			var myReport = new Report(myEvent, myAvailableTicketType);

			Console.WriteLine($"Your Report of {myEvent.Name}:");
			Console.WriteLine($"The oldest attendant of {myEvent.Name} is {myReport.AgeOfOldestAttendantOfChosenEvent} years old.");
			Console.WriteLine($"The youngest attendant of {myEvent.Name} is {myReport.AgeOfYoungestAttendantOfChosenEvent} years old.");
			Console.WriteLine($"The average age of an attendant of {myEvent.Name} is {myReport.AverageAgeOfAttendantsOfChosenEvent} years old.");
			Console.WriteLine($"The total income of {myEvent.Name} is {myReport.TotalIncomeOfSoldTicketsOfChosenEvent} Dollars");

			Console.WriteLine($"Your Report of {myEvent.Name}'s ticket type \"{myAvailableTicketType.Name}\":");
			Console.WriteLine($"The oldest attendant is {myReport.AgeOfOldestAttendantOfChosenTicketTypeAndEvent} years old.");
			Console.WriteLine($"The youngest attendant is {myReport.AgeOfYoungestAttendantOfChosenTicketTypeAndEvent} years old.");
			Console.WriteLine($"The average age of an attendant is {myReport.AverageAgeOfAttendantsOfChosenTicketTypeAndEvent} years old.");
			Console.WriteLine($"The total income is {myReport.TotalIncomeOfSoldTicketsOfChosenTicketTypeAndEvent} Dollars");

		}

		private void AddAnEvent()
		{
			_eventService.AddEvent(_eventService.CreateNewEvent(
				_userInterface.GetStringFromUser("Please enter the name of the Event:"),
				_userInterface.GetStringFromUser("Please enter the description of the Event: "),
				_userInterface.GetDateTimeFromUser(),
				_availableTicketTypeUtility.SetTicketTypes(
					_userInterface.GetIntFromUser("How many ticket types would like to enter?"))));
		}

		private void ListAllAvailableEvents()
		{
			_eventUtility.DrawAvailableEventsList(_eventService.GetEvents());
		}

		private void ListAllUpcomingEvents()
		{

			_eventUtility.DrawAllEventsList(_eventService.GetEvents());
		}

		private void SelectEventShowBookedTickets()
		{
			var myEvent = _eventUtility.SelectEvent(_eventService.GetEvents());
			_drawer.DrawBookedTicketsList(myEvent);
		}

		private void SelectEventAndShowAvailableTicketTypes()
		{
			var myEvent = _eventUtility.SelectEvent(_eventService.GetEvents());
			_drawer.DrawAllAvailableTypesList(myEvent);
		}

		private void LeaveApp()
		{
			Console.WriteLine("Thank you for using H0Tickestore.");
			System.Threading.Thread.Sleep(1000);
			Environment.Exit(0);
		}
	}
}
