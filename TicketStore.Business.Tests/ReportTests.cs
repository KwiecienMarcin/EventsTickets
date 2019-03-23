using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicketStore.Business.Tests
{
	[TestClass]
	class ReportTests
	{
		private TestableComplexEventBl _testableComplexEventBl = new TestableComplexEventBl();

		[TestMethod]
		public void Report_ValidEventAndValidTicketType_CorrectReportResult()
		{
			//ARRANGE
			Report reportResult;
			//ACT
			reportResult= new Report(_testableComplexEventBl.ChosenEventBl, _testableComplexEventBl.AvailableTicketTypesBl[0]);
			var someInt = 0;
			var someDouble = 0d;
			//ASSERT

			Assert.AreEqual(reportResult.AgeOfOldestAttendantOfChosenEvent, someInt);
			Assert.AreEqual(reportResult.AgeOfOldestAttendantOfChosenTicketTypeAndEvent, someInt);
			Assert.AreEqual(reportResult.AgeOfYoungestAttendantOfChosenEvent, someInt);
			Assert.AreEqual(reportResult.AgeOfYoungestAttendantOfChosenTicketTypeAndEvent, someInt);
			Assert.AreEqual(reportResult.AverageAgeOfAttendantsOfChosenEvent, someDouble);
			Assert.AreEqual(reportResult.AverageAgeOfAttendantsOfChosenTicketTypeAndEvent, someDouble);
			Assert.AreEqual(reportResult.TotalIncomeOfSoldTicketsOfChosenEvent, someDouble);
			Assert.AreEqual(reportResult.TotalIncomeOfSoldTicketsOfChosenTicketTypeAndEvent, someDouble);

		}
	}
}
