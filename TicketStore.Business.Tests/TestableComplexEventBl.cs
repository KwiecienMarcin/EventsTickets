using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Business.Models;

namespace TicketStore.Business.Tests
{
	public class TestableComplexEventBl
	{
		public 
			string NameBl = "Audioriver";
		public static string DescriptionBl = "Alternative Electronic Music Festival that is lasting 3 days";
		public static DateTime DateTimeBl = new DateTime(2019, 07, 27);
		public static bool IsSoldOutBl = false;
		public List<AvailableTicketTypeBl> AvailableTicketTypesBl;
		public List<AttendantBl> AttendantsBl;
		public EventBl ChosenEventBl;
		public List<TicketBl> TicketsBl;

		public TestableComplexEventBl()
		{
			AvailableTicketTypesBl = new List<AvailableTicketTypeBl>
			{
				new AvailableTicketTypeBl
				{
					Name = "2 Days",
					AvailablePlaces = 1000,
					Price = 279.99
				},
				new AvailableTicketTypeBl
				{
					Name = "3 Days",
					AvailablePlaces = 642,
					Price = 389.99
				}
			};

			AttendantsBl = new List<AttendantBl>
			{
				new AttendantBl
				{
					FirstName = "Jocko",
					LastName = "Willink",
					Age = 42
				},
				new AttendantBl
				{
					FirstName = "Jordan",
					LastName = "Peterson",
					Age = 53
				},
				new AttendantBl
				{
					FirstName = "Anthony",
					LastName = "Robbins",
					Age = 58
				},
				new AttendantBl
				{
					FirstName = "Ray",
					LastName = "Dalio",
					Age = 63
				}
			};


			TicketsBl = new List<TicketBl>
			{
				new TicketBl(AttendantsBl[0],ChosenEventBl,AvailableTicketTypesBl[0]),
				new TicketBl(AttendantsBl[2],ChosenEventBl,AvailableTicketTypesBl[0]),
				new TicketBl(AttendantsBl[1],ChosenEventBl,AvailableTicketTypesBl[1]),
				new TicketBl(AttendantsBl[3],ChosenEventBl,AvailableTicketTypesBl[1])
			};
			ChosenEventBl = new EventBl(NameBl, DescriptionBl, DateTimeBl, AvailableTicketTypesBl) { BookedTickets = TicketsBl };
		}
	}
}
