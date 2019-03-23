using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Data.Models;


namespace TicketStore.Data.Repositories
{
	public class AttendantRepository
	{
		public List<Attendant> GetAll()
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				return dbContext.Attendants.ToList();
			}
		} // might be useful later @kuba please ignore this method :)

		public void Create(string firstName, string lastName, int age)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				var attendant = new Attendant {FirstName = firstName, LastName = lastName, Age = age};
				dbContext.Attendants.Add(attendant);
				dbContext.SaveChanges();
			}

		}

		public void Create(Attendant attendant)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				
				dbContext.Attendants.Add(attendant);
				dbContext.SaveChanges();
			}

		}

	}
}