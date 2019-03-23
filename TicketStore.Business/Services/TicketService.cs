using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Business.Models;
using TicketStore.Data.Repositories;

[assembly: InternalsVisibleTo("TicketStore.Business.Tests")]
namespace TicketStore.Business.Services
{
	public class TicketService
	{
		
		private ITicketRepository _ticketRepository;
		private IDataObjectsMapper _dataObjectsMapper;


		public TicketService()
		{
			_dataObjectsMapper = new DataObjectsMapper();
			_ticketRepository = new TicketRepository();
		}
		internal TicketService(
			ITicketRepository ticketRepository, 
			IDataObjectsMapper dataObjectsMapper)
		{
			_dataObjectsMapper = dataObjectsMapper;
			_ticketRepository = ticketRepository;
		}

		public List<TicketBl> GetTicketsOfEvent(EventBl myEvent)
		{
			return myEvent.BookedTickets;
		}

		public List<TicketBl> GetAllTickets()
		{
			var tickets = _ticketRepository.GetAll();
			return _dataObjectsMapper.MapTicketListToTicketBlList(tickets);
		}

		public void AddTicket(EventBl chosenEvent, TicketBl ticket)
		{
			_ticketRepository.AddTicket(
				_dataObjectsMapper.MapEventBlToEvent(chosenEvent), 
				_dataObjectsMapper.MapTicketBlToTicket(ticket));
		}
	}
}
