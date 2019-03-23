using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Business.Models
{
	public class TicketBl
	{
		public int Id { get; set; }
		public double Price { get; set; }

		public UserBl BuyingUser { get; set; }
		public int? UserId { get; set; }

		public AttendantBl Attendant { get; set; }
		public int AttendantId { get; set; }

		public EventBl ChosenEvent { get; set; }
		public int EventId { get; set; }

		public AvailableTicketTypeBl ChosenTicketType { get; set; }
		public int AvailableTicketTypeId { get; set; }

		public TicketBl(AttendantBl attendant, EventBl chosenEvent, AvailableTicketTypeBl chosenTicketType)
		{
			Attendant = attendant;
			ChosenEvent = chosenEvent;
			ChosenTicketType = chosenTicketType;
			Price = chosenTicketType.Price;
		}
	}
}
