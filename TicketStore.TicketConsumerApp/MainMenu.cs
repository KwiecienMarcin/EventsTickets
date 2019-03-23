using System;
using System.Linq;
using TicketStore.Business.Services;
using TicketStore.CliHelpers.Helpers;
using TicketStore.CliHelpers.ModelUtilities;

namespace TicketStore.TicketConsumerApp
{
	internal class MainMenu
	{
		private Menu _menu = new Menu();
		private Menu _loginMenu = new Menu();
		private EventService _eventService = new EventService();
		private UserService _userService = new UserService();
		private AttendantService _attendantService = new AttendantService();
		private TicketService _ticketService = new TicketService();
		private EventUtility _eventUtility = new EventUtility();
		private TicketUtility _ticketUtility = new TicketUtility();
		private UserInterface _userInterface = new UserInterface();
		Drawer _drawer = new Drawer();
		bool succesfullyRegisteredOrLoggedIn = false;
		private string actualUserName;
		internal void UserInputMenu()
		{
			Console.WriteLine("Welcome to H0TicketStoreApp by BetterThanJava Sp. z o.o.");
			_loginMenu.AddCommand("LeaveApp", LeaveApp);
			_loginMenu.AddCommand("Login", Login);
			_loginMenu.AddCommand("Register", Register);
			
			while (!succesfullyRegisteredOrLoggedIn)
			{
				_loginMenu.PrintCommands();
				var command = _userInterface.GetStringFromUser("Enter command");
				_loginMenu.RunCommand(command);
			}
			_menu.AddCommand("LeaveApp", LeaveApp);
			_menu.AddCommand("ListAllUpcomingEvents", ListAllUpcomingEvents);
			_menu.AddCommand("ListAllAvailableEvents", ListAllAvailableEvents);
			_menu.AddCommand("SelectEventAndShowAvailableTicketTypes", SelectEventAndShowAvailableTicketTypes);
			_menu.AddCommand("SelectEventAndBuyTickets", SelectEventAndBuyTickets);
			_menu.AddCommand("DisplayHistoryOfAllBougthTickets", DisplayHistoryOfAllBougthTickets);


			while (true)
			{
				_menu.PrintCommands();
				var command = _userInterface.GetStringFromUser("Enter command");
				_menu.RunCommand(command);
			}
		}

		private void DisplayHistoryOfAllBougthTickets()
		{
			Console.WriteLine("These are the ticket you have bought before");
			foreach (var ticket in _ticketService.GetAllTickets().Where(t => t.BuyingUser == _userService.Get(actualUserName)))
			{
				Console.WriteLine($"Attendant: {ticket.Attendant.FirstName} {ticket.Attendant.LastName}, Ticket type: {ticket.ChosenTicketType}, Price: {ticket.Price}, Event: {ticket.ChosenEvent.Name} ");

			}
		}

		private void Register()
		{
			var userName = _userInterface.GetStringFromUser("Please enter your Username:");
			while (_userService.IsUserNameAlreadyExisting(userName))
			{
				userName = _userInterface.GetStringFromUser("This Username is already taken, please try one more time.");
			}
			_userService.Add(
				userName,
				_userInterface.GetStringFromUser("Please enter your Password:"),
				_attendantService.Create(
					_userInterface.GetStringFromUser("In order to be able to buy tickets we need your personal information.\nPlease enter your first name:"),
					_userInterface.GetStringFromUser("Please enter your last name:"),
					_userInterface.GetIntFromUser("Please enter your age:"))
				);
			actualUserName = userName;
		}

		private void Login()
		{

			var userName = _userInterface.GetStringFromUser("Please enter your Username:");
			var passWord = _userInterface.GetStringFromUser("Please enter your Password:");
			while (_userService.AreCredentialsCorrect(userName,passWord))
			{
				Console.WriteLine("It seems that your password or your Username is incorrect. Please try one more time.");
				userName = _userInterface.GetStringFromUser("Please enter your Username:");
				passWord = _userInterface.GetStringFromUser("Please enter your Password:");
			}

			succesfullyRegisteredOrLoggedIn = true;
			actualUserName = userName;
		}

		private void SelectEventAndBuyTickets()
		{

			var myEvent = _eventUtility.SelectEvent(_eventService.GetEvents());
			var ticketsToBookAmount = _userInterface.GetIntFromUser("Enter the amount of tickets you would like to buy.");
			var loggedUser = _userService.Get(actualUserName);
			_ticketUtility.BookTickets(loggedUser, myEvent.BookedTickets, myEvent, ticketsToBookAmount);
		}

		private void ListAllAvailableEvents()
		{
			_eventUtility.DrawAvailableEventsList(_eventService.GetEvents());
		}

		private void ListAllUpcomingEvents()
		{

			_eventUtility.DrawAllEventsList(_eventService.GetEvents());
		}


		private void SelectEventAndShowAvailableTicketTypes()
		{
			var myEvent = _eventUtility.SelectEvent(_eventService.GetEvents());
			_drawer.DrawAllAvailableTypesList(myEvent);
		}

		private void LeaveApp()
		{
			Console.WriteLine("Thank you for using the H0Tickestore App.");
			System.Threading.Thread.Sleep(1000);
			Environment.Exit(0);
		}
	}
}
