using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Business.Models;
using TicketStore.Data.Repositories;

namespace TicketStore.Business.Services
{
	public class EventService
	{
		private IEventRepository _eventRepository;
		private IDataObjectsMapper _dataObjectsMapper;

		public EventService()
		{
			_eventRepository = new EventRepository();
			_dataObjectsMapper = new DataObjectsMapper();
		}

		public EventService(IEventRepository eventRepository, IDataObjectsMapper dataObjectsMapper)
		{
			_eventRepository = eventRepository;
			_dataObjectsMapper = dataObjectsMapper;
		}

		public List<EventBl> GetEvents()
		{
			return _dataObjectsMapper.MapEventListToEventBlList(_eventRepository.GetAll());
		}

		public void AddEvent(EventBl eventBl)
		{
			
			{
				_eventRepository.AddEvent(_dataObjectsMapper.MapEventBlToEvent(eventBl));
			}
			
		}

		public EventBl CreateNewEvent(string eventName, string eventDescription, DateTime eventDate,
			List<AvailableTicketTypeBl> availableTicketTypesOfEvent)
		{
			var name = eventName;
			var description = eventDescription;
			var date = eventDate;
			var availableTicketTypes = availableTicketTypesOfEvent;
			return new EventBl(name, description, date, availableTicketTypes);
		}

		public EventBl GetEvent(List<EventBl> events, string myEventStringFromUser)
		{
			return events.Find(e => e.Name == myEventStringFromUser);
		}

		public AvailableTicketTypeBl GetAvailableTicketTypeFromSelectedEvent(
			string availableTicketTypeName,
			EventBl chosenEventBl)
		{
			return _dataObjectsMapper.
				MapAvailableTicketTypeToAvailableTicketTypeBl(
					_eventRepository.GetSelectedAvailableTicketType(
						_dataObjectsMapper.MapEventBlToEvent(chosenEventBl),
						availableTicketTypeName));
		}

	}
}