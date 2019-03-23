using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Data.Models
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string PassWord { get; set; }
		public Attendant Attendant { get; set; }
		//public int AttendantId { get; set; }
		//public List<Ticket> Tickets { get; set; }

		public User()
		{
			
		}
		public User(string userName, string passWord, Attendant attendant)
		{
			//Id = Guid.NewGuid();
			UserName = userName;
			PassWord = passWord;
			Attendant = attendant;
		}
	}
}
