using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Business.Models
{
    public class EventBl
    {
	    public int Id { get; set; }
		public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsSoldOut = false;
        public List<AvailableTicketTypeBl> AvailableTicketTypes;
        public List<TicketBl> BookedTickets = new List<TicketBl>();


        public EventBl(string name, string description, DateTime date, List<AvailableTicketTypeBl> availableTicketTypes)
        {
            Name = name;
            Date = date;
            Description = description;
            AvailableTicketTypes = availableTicketTypes;
        }
        
    }
}
