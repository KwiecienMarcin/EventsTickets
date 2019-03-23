using System;
using System.Collections.Generic;
using EventsTickets.Data;
using EventsTickets.Models;

namespace EventsTickets
{
    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the system EMPIK v.2.0!");
            Console.ResetColor();

            Console.WriteLine("Log in into EMPIK v.2.0 system, write password:");
            Console.WriteLine("Password: (default: empik )");

            var events = DataProvider.eventsList;///////////////////
            var clients = DataProvider.clients;
            var tickets = DataProvider.tickets;

            while (true)
            {
                string password = "empik";
                string passwordFromUser = "pass";

                while (password != passwordFromUser)
                {
                    passwordFromUser = Console.ReadLine();
                    Console.WriteLine(string.Empty);
                    if (password == passwordFromUser)
                    {
                        Console.WriteLine("Log in succesful. Now you can work!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong password. Try again.");
                    }
                }

                FunctionalityDescription();

                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("MAKING EVENT MODULE");
                        CreateEvent(DataProvider.eventsList);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("SHOWING AVAILIBLE EVENTS MODULE");
                        AllAvailableEvents(events);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("SHOWING ALL EVENTS MODULE");
                        AllEvents(events);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("SELLING TICKETS MODULE");
                        Event choosenEvent = SelectEvent(events);
                        Console.WriteLine("Please to choose command");
                        Console.WriteLine("1. List of booked tickets");
                        Console.WriteLine("2. List of all availible ticket types");
                        Console.WriteLine("3. Buying a ticket option");
                        string command1 = Console.ReadLine();
                        var ticketsToBook = 0;
                        
                        switch (command1)
                        {
                            case "1":
                                
                                TicketListBook(choosenEvent);
                                break;
                            case "2":
                                AvailableTypesList(choosenEvent);
                                break;
                            case "3":
                                ticketsToBook = GetIntFromUser("Enter the amount of tickets you would like to buy.");
                                BookTicket(clients, tickets, choosenEvent, ticketsToBook);
                                break;
                            default:
                                Console.WriteLine("Wrong number.");
                                break;
                        }
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("SHOWING DETAILS OF EVENTS MODULE");
                        break;
                    case "6":
                        Console.WriteLine("Thanks for using EMPIK v.2.0 system.");
                        Console.WriteLine("Click enter, bye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("You have chosen the wrong number. Write password again and write good number.");
                        break;
                }
            }
        }

        private static void FunctionalityDescription()
        {
            Console.WriteLine("Select a functionality:");
            ///////////////////////////////////////////////
            Console.Write("1. To choose making events module write ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1");
            Console.ResetColor();

            Console.Write("2. To showing available events module write ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2");
            Console.ResetColor();

            Console.Write("3. To showing all events module write ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3");
            Console.ResetColor();

            Console.Write("4. To selling tickets module write ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3");
            Console.ResetColor();

            Console.Write("5. To showing details making events module write ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4");
            Console.ResetColor();

            Console.Write("6. To close program write ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5");
            Console.ResetColor();

            Console.WriteLine(string.Empty);
        }

        private static void BookTicket(List<Client> client, List<Ticket> tickets, Event choosenEvent, int ticketsToBookAmount)
        {
            for (int i = 0; i < ticketsToBookAmount; i++)
            {
                AvailableTypesList(choosenEvent);
                Client newClient = CreateClient(client);
                CreateTicket(tickets, choosenEvent, newClient);
            }
        }

        private static Event SelectEvent(List<Event> events)
        {
            var EventStringFromUser = GetStringFromUser("Please enter the Event you want to see Details from: ");
            var myEvent = events.Find(e => e.NameOfEvent == EventStringFromUser);
            while (myEvent.IsSold)
            {
                Console.WriteLine($"The {myEvent.NameOfEvent} event is already sold out! Try another one.");
                myEvent = events.Find(e => e.NameOfEvent == EventStringFromUser);
            }
            Console.WriteLine($"Description: {myEvent.DescriptionOfEvent}");
            return myEvent;
        }

        private static void AllEvents(List<Event> events)
        {

            foreach (var chosenEvent in events)
            {
                string SumNumbers = null;
                if (SumNumbers == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Name of event: {chosenEvent.NameOfEvent}, date of event: {chosenEvent.DateOfEvent}, description of event: {chosenEvent.DescriptionOfEvent}.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Name of event: {chosenEvent.NameOfEvent}, date of event: {chosenEvent.DateOfEvent}, description of event: {chosenEvent.DescriptionOfEvent}.");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the password again to continue");
            Console.ResetColor();
            
        }
        private static void AllAvailableEvents(List<Event> events)
        {

            foreach (var chosenEvent in events)
            {
                string SumNumbers = null;
                if (SumNumbers != "0")
                    Console.WriteLine($"Name of event: {chosenEvent.NameOfEvent}, date of event: {chosenEvent.DateOfEvent}, description of event: {chosenEvent.DescriptionOfEvent}.");

 
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the password again to continue");
            Console.ResetColor();

        }
        private static void AvailableEventsListInitiator(List<Event> events)
        {
            foreach (var chosenEvent in events)
            {
                int allAvailableTickets = AvailablePlacesSum(chosenEvent);

                if (allAvailableTickets != 0)
                {
                    BlockOfEventList(chosenEvent, allAvailableTickets);
                }
                else
                {
                    chosenEvent.IsSold = true;
                }

            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////
        private static void CreateEvent(List<Event> eventsList)
        {
            var newEvent = new Event
            {
                NameOfEvent = GetStringFromUser("Name of Event:"),
                DateOfEvent = GetStringFromUser("Date of Event: (format: DD-MM-YYYY)"),
                HourOfEvent = GetStringFromUser("Hour of Event: (format: HH-MM)"),
                DescriptionOfEvent = GetStringFromUser("Description of Event:"),
                EventCode = GetStringFromUser("Event Code:"),
                StandingPlacesPrice = GetIntFromUser("Price of standing place (PLN)"),
                StandingNumberOfPlaces = GetIntFromUser("Number of standing places"),
                SittingPlacesPrice = GetIntFromUser("Price of sitting place (PLN)"),
                SittingNumberOfPlaces = GetIntFromUser("Number of sitting places")
                
            };
            
            newEvent.AvailableTicketTypes.Add(new AvailableTicket
            {
                Name = "Standing",
                AvailablePlaces = newEvent.StandingNumberOfPlaces,
                Price = newEvent.StandingPlacesPrice,

            });

            newEvent.AvailableTicketTypes.Add(new AvailableTicket
            {
                Name = "Sitting",
                AvailablePlaces = newEvent.SittingNumberOfPlaces,
                Price = newEvent.SittingPlacesPrice,

            });



            foreach (var eventChoosen in eventsList)
            {
                if(eventChoosen.EventCode == newEvent.EventCode)
                {
                    Console.WriteLine($"Event with code {newEvent.EventCode} already exists!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter the password again to continue");
                    Console.ResetColor();
                    return;
                }
            }

            eventsList.Add(newEvent);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the password again to continue");
            Console.ResetColor();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////
        private static void CreateTicket(List<Ticket> tickets, Event myEvent, Client newAttendant)
        {
            var chosenTicketTypeStringFromUser = GetStringFromUser("Enter one of the ticket types:");
            bool enlistOnlyAvailableTypes = true;
            BlockAvailible(myEvent, enlistOnlyAvailableTypes);

            AvailableTicket chosenTicketType = myEvent.AvailableTicketTypes.Find(ticketType => ticketType.Name == chosenTicketTypeStringFromUser);

            var newTicket = new Ticket(newAttendant, myEvent, chosenTicketType);
            {
                newTicket.Client = newAttendant;
                newTicket.ChosenEvent = myEvent;
                newTicket.ChosenTicketType = chosenTicketType;
            }
            tickets.Add(newTicket);
        }

        private static Client CreateClient(List<Client> attendants)
        {
            Client newClient = new Client();
            {
                newClient.FirstName = GetStringFromUser("Enter the name");
                newClient.LastName = GetStringFromUser("Enter the surname");

            }
            attendants.Add(newClient);
            return newClient;
        }

        private static void TicketListBook(Event myEvent)
        {
            foreach (var ticket in myEvent.BookedTickets)
            {

                Console.WriteLine($" {ticket.Client.FirstName} {ticket.Client.LastName}");
                Console.WriteLine($" {ticket.ChosenTicketType.Name}");
            }
        }

        private static void AvailableTypesList(Event myEvent)
        {
            Console.WriteLine($"Choose Availible tickets {myEvent.NameOfEvent} at the {myEvent.DateOfEvent}.");
            foreach (var availableTicketType in myEvent.AvailableTicketTypes)
            {
                FOreground(availableTicketType.AvailablePlaces);
                Console.WriteLine($"{availableTicketType.Name} - {availableTicketType.Price}$ - {availableTicketType.AvailablePlaces} places left. ");
            }
            Console.ResetColor();
        }
        private static void BlockAvailible(Event myEvent, bool enlistOnlyAvailableTypes)
        {
            Console.WriteLine($"Choose Availible tickets {myEvent.NameOfEvent} at the {myEvent.DateOfEvent}.");
            foreach (var availableTicketType in myEvent.AvailableTicketTypes)
            {
                if (availableTicketType.AvailablePlaces != 0)
                {
                    FOreground(availableTicketType.AvailablePlaces);
                    Console.WriteLine($"{availableTicketType.Name} - {availableTicketType.Price}$ - {availableTicketType.AvailablePlaces} places left. ");
                }

            }
            Console.ResetColor();
        }

        private static int AvailablePlacesSum(Event chosenEvent)
        {
            int allAvailableTickets = 0;
            foreach (var availableTicketType in chosenEvent.AvailableTicketTypes)
            {
                allAvailableTickets += availableTicketType.AvailablePlaces;
            }

            return allAvailableTickets;
        }

        private static void BlockOfEventList(Event chosenEvent, int allAvailableTickets)
        {
            FOreground(allAvailableTickets);

            Console.WriteLine($"|{chosenEvent.DateOfEvent} - {chosenEvent.NameOfEvent} - Available Tickets of all types: {allAvailableTickets}");
            Console.ResetColor();
            Console.WriteLine($"Description: {chosenEvent.DescriptionOfEvent}");
        }

        private static void FOreground(int allAvailableTickets)
        {
            if (allAvailableTickets == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

        }


        private static string GetStringFromUser(string message)
        {
            Console.Write($"{message}: ");
            return Console.ReadLine();
        }

        private static double GetDoubleFromUser(string stringEntry)
        {
            Console.WriteLine($"{stringEntry}");
            double number;
            stringEntry = Console.ReadLine();
            while (!double.TryParse(stringEntry, out number))
            {
                Console.WriteLine("Thats not an number, try it once more.");
            }

            return number;
        }
        private static int GetIntFromUser(string message)
        {
            Console.Write($"{message}: ");

            int number;
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("The given value is not a number! Enter number now...");
            }

            return number;
        }
        
    }
}