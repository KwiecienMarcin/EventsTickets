using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicketStore.Business.Services;
using TicketStore.Data.Repositories;

namespace TicketStore.Business.Tests
{
	[TestClass]
	public class TicketServiceTests
	{
		private TestableComplexEventBl _testableComplexEventBl = new TestableComplexEventBl();
		private TestableComplexEvent _testableComplexEvent = new TestableComplexEvent();
		[TestMethod]
		public void GetAllTickets_ValidEvent_CorrectEventResult()
		{
			//ARRANGE
			var ticketRepositoryMock = new Mock<ITicketRepository>();
			ticketRepositoryMock.Setup(x => x.GetAll()).Returns(_testableComplexEvent.Tickets);

			var dataObjectMapperMock = new Mock<IDataObjectsMapper>();
			dataObjectMapperMock.Setup(x => x.MapTicketListToTicketBlList(_testableComplexEvent.Tickets))
				.Returns(_testableComplexEventBl.TicketsBl);

			var ticketService = new TicketService(ticketRepositoryMock.Object,dataObjectMapperMock.Object);

			//ACT

			var validResult = ticketService.GetAllTickets();

			//Assert

			Assert.AreEqual(_testableComplexEventBl.TicketsBl, validResult);

		}
	}
}
