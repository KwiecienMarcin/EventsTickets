using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Data.Models;
using System.Data.Entity;

namespace TicketStore.Data.Repositories
{
	public interface IEventRepository
	{
		List<Event> GetAll();
		Event Get(string eventName);
		void AddEvent(Event chosenEvent);
		AvailableTicketType GetSelectedAvailableTicketType(Event chosenEvent, string availableTicketTypeName);
	}
	public class EventRepository : IEventRepository
	{
		public List<Event> GetAll()
		{
			using (var dbContext = new TicketStoreDbContext())
			{

				List<Event> tempEventList = dbContext.Events
					.Include(e => e.AvailableTicketTypes)
					.Include(e => e.Tickets)
					.Include(e => e.AvailableTicketTypes)
					.Include(e => e.Tickets.Select(a => a.Attendant))
					.ToList();


				return tempEventList;
			}
		}

		public Event Get(string eventName)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				return dbContext.Events.FirstOrDefault(e => e.Name == eventName);
			}
			
		}
		

		public void AddEvent(Event chosenEvent)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				if (dbContext.Events.Any(e => e.Name == chosenEvent.Name))
				{
					var e = new Exception("There is already an event with this name existing");
					throw e;
				}
				
				dbContext.Events.Add(chosenEvent);
				dbContext.SaveChanges(); 
			}
		}

		public AvailableTicketType GetSelectedAvailableTicketType(Event chosenEvent, string availableTicketTypeName)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				//var myEvent = dbContext.Events.FirstOrDefault(e => e == chosenEvent);
				var events = dbContext.Events;
				var eventId = chosenEvent.Id;
				var myEvent = dbContext.Events.Include(e => e.AvailableTicketTypes).FirstOrDefault(e => e.Id == chosenEvent.Id);
				var myAvailableTicketType = myEvent.AvailableTicketTypes.FirstOrDefault(t => t.Name == availableTicketTypeName);
				return myAvailableTicketType;
				//return dbContext.Events.FirstOrDefault(e => e == chosenEvent).AvailableTicketTypes.FirstOrDefault(t => t.Name == availableTicketTypeName);
			}
			
		}		
	}
}
