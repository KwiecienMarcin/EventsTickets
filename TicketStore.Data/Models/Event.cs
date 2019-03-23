using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Data.Models
{
	public class Event
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public List<Ticket> Tickets { get; set; } = new List<Ticket>();
		public List<AvailableTicketType> AvailableTicketTypes { get; set; }
		public bool IsSoldOut { get; set; } = false;

		public Event()
		{
			
		}

		public Event(string name, string description, DateTime date, List<AvailableTicketType> availableTicketTypes)
		{
			//Id = Guid.NewGuid();
			Name = name;
			Date = date;
			Description = description;
			AvailableTicketTypes = availableTicketTypes;
		}
	  
	}
}
