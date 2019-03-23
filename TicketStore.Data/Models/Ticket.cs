using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Data.Models
{
	public class Ticket
	{
		public int Id { get; set; }

		public double Price { get; set; }

		public User BuyingUser { get; set; }
		public int? UserId { get; set; }

		public Attendant Attendant { get; set; }
		public int AttendantId { get; set; }

		public Event ChosenEvent { get; set; }
		public int EventId { get; set; }

		public AvailableTicketType ChosenTicketType { get; set; }
		public int AvailableTicketTypeId { get; set; }

		public Ticket()
		{
			
		}

		public Ticket(Attendant attendant, Event chosenEvent, AvailableTicketType chosenTicketType)
		{
			//Id = Guid.NewGuid();
			Attendant = attendant;
			ChosenEvent = chosenEvent;
			ChosenTicketType = chosenTicketType;
			Price = chosenTicketType.Price;
		}
		
	}
}
