using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Data.Models;

namespace TicketStore.Data.Repositories
{
	public interface ITicketRepository
	{
		List<Ticket> GetAll();

		void AddTicket(Event chosenEvent, Ticket ticket);


	}
public class TicketRepository : ITicketRepository
	{
		public List<Ticket> GetAll()
		{
			
			using (var dbContext = new TicketStoreDbContext())
			{
				return dbContext.Tickets.ToList();
			}
		}

		public void AddTicket(Event chosenEvent, Ticket ticket)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				ticket.EventId = chosenEvent.Id;
				dbContext.Tickets.Add(ticket);
				//chosenEvent.Tickets.FirstOrDefault(t => t.Id == ticket.Id).AttendantId = ticket.AttendantId;
				dbContext.Events.Attach(chosenEvent);
				dbContext.Attendants.Attach(ticket.Attendant);
				
				
				dbContext.Events.FirstOrDefault(e => e.Id == chosenEvent.Id).Tickets.Add(ticket);
				dbContext.SaveChanges();
			}
		}
	}
}
