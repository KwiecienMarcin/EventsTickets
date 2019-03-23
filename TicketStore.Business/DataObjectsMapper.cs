using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Business.Models;
using TicketStore.Data.Models;

namespace TicketStore.Business
{
	public interface IDataObjectsMapper
	{

		Attendant MapAttendantBlToAttendant(AttendantBl attendantBl);

		AttendantBl MapAttendantToAttendantBl(Attendant attendant);
		User MapUserBlToUser(UserBl userBl);

		UserBl MapUserToUserBl(User user);

		AvailableTicketType MapAvailableTicketTypeBlToAvailableTicketType(
			AvailableTicketTypeBl availableTicketTypeBl);

		AvailableTicketTypeBl MapAvailableTicketTypeToAvailableTicketTypeBl(
			AvailableTicketType availableTicketType);

		Ticket MapTicketBlToTicket(TicketBl ticketBl);

		TicketBl MapTicketToTicketBl(Ticket ticket);

		List<AvailableTicketType> MapAvailableTicketTypeBlListToAvailableTicketTypeList(
			List<AvailableTicketTypeBl> availableTicketTypeBlList);

		List<AvailableTicketTypeBl> MapAvailableTicketTypeListToAvailableTicketTypeBlList(
			List<AvailableTicketType> availableTicketTypeList);

		List<Ticket> MapTicketBlListToTicketList(List<TicketBl> ticketBlList);

		List<TicketBl> MapTicketListToTicketBlList(List<Ticket> ticketList);

		Event MapEventBlToEvent(EventBl eventBl);

		EventBl MapEventToEventBl(Event anEvent);
		List<EventBl> MapEventListToEventBlList(List<Event> eventList);
	}
	public class DataObjectsMapper : IDataObjectsMapper
	{

		public Attendant MapAttendantBlToAttendant(AttendantBl attendantBl)
		{
			var attendant = new Attendant
			{
				Id = attendantBl.Id,
				FirstName = attendantBl.FirstName,
				LastName = attendantBl.LastName,
				Age = attendantBl.Age
			};

			return attendant;
		}

		public AttendantBl MapAttendantToAttendantBl(Attendant attendant)
		{
			var attendantBl = new AttendantBl
			{
				Id = attendant.Id,
				FirstName = attendant.FirstName,
				LastName = attendant.LastName,
				Age = attendant.Age
			};

			return attendantBl;
		}

		public AvailableTicketType MapAvailableTicketTypeBlToAvailableTicketType(
			AvailableTicketTypeBl availableTicketTypeBl)
		{
			var availableTicketType = new AvailableTicketType
			{
				Id = availableTicketTypeBl.Id,
				Name = availableTicketTypeBl.Name,
				Price = availableTicketTypeBl.Price,
				AvailablePlaces = availableTicketTypeBl.AvailablePlaces
			};

			return availableTicketType;
		}

		public AvailableTicketTypeBl MapAvailableTicketTypeToAvailableTicketTypeBl(
			AvailableTicketType availableTicketType)
		{
			var availableTicketTypeBl = new AvailableTicketTypeBl
			{
				Id = availableTicketType.Id,
				Name = availableTicketType.Name,
				Price = availableTicketType.Price,
				AvailablePlaces = availableTicketType.AvailablePlaces
			};

			return availableTicketTypeBl;
		}

		public Ticket MapTicketBlToTicket(TicketBl ticketBl)
		{

			var ticket = new Ticket(
				MapAttendantBlToAttendant(ticketBl.Attendant),
				MapEventBlToEvent(ticketBl.ChosenEvent),
				MapAvailableTicketTypeBlToAvailableTicketType(ticketBl.ChosenTicketType))
			{
				Id = ticketBl.Id,
				UserId = ticketBl.UserId,
				AttendantId = ticketBl.AttendantId,
				EventId = ticketBl.EventId,
				AvailableTicketTypeId = ticketBl.AvailableTicketTypeId,
				Price = ticketBl.Price
				
			};
			if (ticketBl.BuyingUser != null)
			{
				ticket.BuyingUser = MapUserBlToUser(ticketBl.BuyingUser);
			}

			return ticket;
		}

		public TicketBl MapTicketToTicketBl(Ticket ticket)
		{

			var ticketBl = new TicketBl(
				MapAttendantToAttendantBl(ticket.Attendant),
				MapEventToEventBl(ticket.ChosenEvent),
				MapAvailableTicketTypeToAvailableTicketTypeBl(ticket.ChosenTicketType))
			{
				Id = ticket.Id,
				UserId = ticket.UserId,
				AttendantId = ticket.AttendantId,
				EventId = ticket.EventId,
				AvailableTicketTypeId = ticket.AvailableTicketTypeId,
				Price = ticket.Price
			};
			if (ticket.BuyingUser != null)
			{
				ticketBl.BuyingUser = MapUserToUserBl(ticket.BuyingUser);
			}

			return ticketBl;
		}

		public List<AvailableTicketType> MapAvailableTicketTypeBlListToAvailableTicketTypeList(
			List<AvailableTicketTypeBl> availableTicketTypeBlList)
		{
			var availableTicketTypeList = new List<AvailableTicketType>();
			foreach (var availableTicketTypeBl in availableTicketTypeBlList)
			{
				availableTicketTypeList.Add(
					MapAvailableTicketTypeBlToAvailableTicketType(availableTicketTypeBl));
			}
			return availableTicketTypeList;
		}

		public List<AvailableTicketTypeBl> MapAvailableTicketTypeListToAvailableTicketTypeBlList(
			List<AvailableTicketType> availableTicketTypeList)
		{
			var availableTicketTypeBlList = new List<AvailableTicketTypeBl>();
			if (availableTicketTypeList == null)
			{
				return null;
			}
			foreach (var availableTicketType in availableTicketTypeList)
			{
				availableTicketTypeBlList.Add(
					MapAvailableTicketTypeToAvailableTicketTypeBl(availableTicketType));
			}
			return availableTicketTypeBlList;
		}

		public List<Ticket> MapTicketBlListToTicketList(List<TicketBl> ticketBlList)
		{
			var ticketList = new List<Ticket>();
			foreach (var ticketBl in ticketBlList)
			{
				ticketList.Add(MapTicketBlToTicket(ticketBl));
			}

			return ticketList;
		}

		public List<TicketBl> MapTicketListToTicketBlList(List<Ticket> ticketList)
		{
			if (ticketList == null)
			{
				return null;
			}
			var ticketBlList = new List<TicketBl>();
			foreach (var ticket in ticketList)
			{
				ticketBlList.Add(MapTicketToTicketBl(ticket));
			}

			return ticketBlList;
		}

		public Event MapEventBlToEvent(EventBl eventBl)
		{
			var anEvent = new Event(
				eventBl.Name,
				eventBl.Description,
				eventBl.Date,
				MapAvailableTicketTypeBlListToAvailableTicketTypeList(eventBl.AvailableTicketTypes))
			{
				Id = eventBl.Id,
				Tickets = MapTicketBlListToTicketList(eventBl.BookedTickets),
				IsSoldOut = eventBl.IsSoldOut
			};

			return anEvent;
		}

		public EventBl MapEventToEventBl(Event anEvent)
		{
			var anEventBl = new EventBl(
				anEvent.Name,
				anEvent.Description,
				anEvent.Date,
				MapAvailableTicketTypeListToAvailableTicketTypeBlList(anEvent.AvailableTicketTypes))
			{
				Id = anEvent.Id,
				BookedTickets = MapTicketListToTicketBlList(anEvent.Tickets),
				IsSoldOut = anEvent.IsSoldOut

			};

			return anEventBl;
		}
		public List<EventBl> MapEventListToEventBlList(List<Event> eventList)
		{
			var eventBlList = new List<EventBl>();
			foreach (var chosenEvent in eventList)
			{
				eventBlList.Add(MapEventToEventBl(chosenEvent));
			}
			return eventBlList;
		}

		public UserBl MapUserToUserBl(User user)
		{
			var userBl = new UserBl(
				user.UserName, 
				user.PassWord, 
				MapAttendantToAttendantBl(user.Attendant))
			{
				Id = user.Id,
			};
			return userBl;
		}

		public User MapUserBlToUser(UserBl userBl)
		{
			var user = new User(
				userBl.UserName, 
				userBl.PassWord, 
				MapAttendantBlToAttendant(userBl.Attendant))
			{
				Id = userBl.Id,
			}; ;
			return user;
		}

	}
}