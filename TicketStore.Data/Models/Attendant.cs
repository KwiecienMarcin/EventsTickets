using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TicketStore.Data.Models
{
	public class Attendant
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }

		public Attendant()
		{
			//Id = Guid.NewGuid();
		}
	}
}
