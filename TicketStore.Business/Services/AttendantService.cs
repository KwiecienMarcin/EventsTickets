using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Business.Models;
using TicketStore.Data.Repositories;

namespace TicketStore.Business.Services
{
	public class AttendantService
	{
		private AttendantRepository _attendantRepository = new AttendantRepository();
		private IDataObjectsMapper _dataObjectsMapper = new DataObjectsMapper();


		public AttendantBl Create(string firstName, string lastName, int age)
		{
			var newAttendant = new AttendantBl
			{
				FirstName = firstName,
				LastName = lastName,
				Age = age
			};

			var attendant = _dataObjectsMapper.MapAttendantBlToAttendant(newAttendant);

			_attendantRepository.Create(attendant);
			newAttendant.Id = attendant.Id;
			return newAttendant;
		} 
	}
}
