using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Data.Models;

namespace TicketStore.Business.Tests
{
	public class TestableComplexEvent
	{
		public static string Name = "Audioriver";
		public static string Description = "Alternative Electronic Music Festival that is lasting 3 days";
		public static DateTime DateTime = new DateTime(2019, 07, 27);
		public static bool IsSoldOut = false;

		public static List<AvailableTicketType> AvailableTicketTypes = new List<AvailableTicketType>
		{
			new AvailableTicketType
			{
				Name = "2 Days",
				AvailablePlaces = 1000,
				Price = 279.99
			},
			new AvailableTicketType
			{
				Name = "3 Days",
				AvailablePlaces = 642,
				Price = 389.99
			}
		};

		public static List<Attendant> Attendants = new List<Attendant>
		{
			new Attendant
			{
				FirstName = "Jocko",
				LastName = "Willink",
				Age = 42
			},
			new Attendant
			{
				FirstName = "Jordan",
				LastName = "Peterson",
				Age = 53
			},
			new Attendant
			{
				FirstName = "Anthony",
				LastName = "Robbins",
				Age = 58
			},
			new Attendant
			{
				FirstName = "Ray",
				LastName = "Dalio",
				Age = 63
			}
		};

		public static Event ChosenEvent = new Event(Name, Description, DateTime, AvailableTicketTypes);

		public List<Ticket> Tickets = new List<Ticket>
		{
			new Ticket(Attendants[0],ChosenEvent,AvailableTicketTypes[0]),
			new Ticket(Attendants[2],ChosenEvent,AvailableTicketTypes[0]),
			new Ticket(Attendants[1],ChosenEvent,AvailableTicketTypes[1]),
			new Ticket(Attendants[3],ChosenEvent,AvailableTicketTypes[1])
		};
	}
}
