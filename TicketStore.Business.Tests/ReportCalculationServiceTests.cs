using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicketStore.Business.Models;
using TicketStore.Business;
using TicketStore.Business.Services;
using TicketStore.Data.Models;
using TicketStore.Data.Repositories;

namespace TicketStore.Business.Tests
{
	[TestClass]
	public class ReportCalculationServiceTests
	{

		private TestableComplexEventBl _testableComplexEventBl = new TestableComplexEventBl();

		[TestMethod]
		public void GetAgeOfOldestAttendant_ValidEventWithValidTickets_CorrectOldestAgeResult()
		{
			//Arrange
			var reportCalculationService = new ReportCalculationService();
			//Act
			var result = reportCalculationService.
				GetAgeOfOldestAttendant(_testableComplexEventBl.ChosenEventBl);
			
			//Assert
			var expectedAge = _testableComplexEventBl.AttendantsBl.Max(x => x.Age);
			Assert.AreEqual(expectedAge, result);
		}

		[TestMethod]
		public void GetAgeOfOldestAttendant_ValidAvailableTicketTypeValidTickets_CorrectOldestAgeResult()
		{
			//Arrange
			var reportCalculationService = new ReportCalculationService();
			var availableTicketType = _testableComplexEventBl.AvailableTicketTypesBl[0];
			//Act
			var result = reportCalculationService.
				GetAgeOfOldestAttendant(availableTicketType, _testableComplexEventBl.ChosenEventBl);
			//Assert
			Assert.AreEqual(58, result);
		}

		[TestMethod]
		public void GetAgeOfYoungestAttendant_ValidEventWithValidTickets_CorrectYoungestAgeResult()
		{
			//Arrange
			var reportCalculationService = new ReportCalculationService();
			//Act
			var result = reportCalculationService.
				GetAgeOfYoungestAttendant(_testableComplexEventBl.ChosenEventBl);
			//Assert
			Assert.AreEqual(42,result);
		}

		[TestMethod]
		public void GetAgeOfYoungestAttendant_ValidAvailableTicketTypeWithValidTickets_CorrectYoungestAgeResult()
		{
			//Arrange
			var reportCalculationService = new ReportCalculationService();
			var availableTicketType = _testableComplexEventBl.AvailableTicketTypesBl[1];
			//Act
			var result = reportCalculationService.
				GetAgeOfYoungestAttendant(availableTicketType, _testableComplexEventBl.ChosenEventBl);
			//Assert
			Assert.AreEqual(53,result);
		}

		[TestMethod]
		public void GetAverageAgeOfAttendants_ValidEventWithValidTickets_CorrectAverageAgeResult()
		{
			//Arrange
			var reportCalculationService = new ReportCalculationService();
			//Act
			var result = reportCalculationService.
				GetAverageAgeOfAttendants(_testableComplexEventBl.ChosenEventBl);
			//Assert
			Assert.AreEqual(54d,result);
		}

		[TestMethod]
		public void GetAverageAgeOfAttendants_ValidAvailableTicketTypeWithValidTickets_CorrectAverageAgeResult()
		{
			//Arrange
			var reportCalculationService = new ReportCalculationService();
			var availableTicketType = _testableComplexEventBl.AvailableTicketTypesBl[0];
			//Act
			var result = reportCalculationService.
				GetAverageAgeOfAttendants(availableTicketType, _testableComplexEventBl.ChosenEventBl);
			//Assert
			Assert.AreEqual(50d, result);
		}

		[TestMethod]
		public void GetTotalIncomeOfSoldTickets_ValidEventWithValidTickets_CorrectTotalIncomeResult()
		{
			//Arrange
			var reportCalculationService = new ReportCalculationService();
			//Act
			var result = reportCalculationService.
				GetTotalIncomeOfSoldTickets(_testableComplexEventBl.ChosenEventBl);
			//Assert
			Assert.AreEqual(1339.96,result);
		}

		[TestMethod]
		public void GetTotalIncomeOfSoldTickets_ValidAvailableTicketTypeWithValidTickets_CorrectTotalIncomeResult()
		{
			//Arrange
			var reportCalculationService = new ReportCalculationService();
			var availableTicketType = _testableComplexEventBl.AvailableTicketTypesBl[0];
			//Act
			var result = reportCalculationService.
				GetTotalIncomeOfSoldTickets(availableTicketType, _testableComplexEventBl.ChosenEventBl);
			//Assert
			Assert.AreEqual(559.98, result);
		}
	}
}