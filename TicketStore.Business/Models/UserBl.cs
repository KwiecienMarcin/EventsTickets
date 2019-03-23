using System;
using System.Collections.Generic;
using TicketStore.Data.Models;

namespace TicketStore.Business.Models
{
	public class UserBl
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string PassWord { get; set; }
		public AttendantBl Attendant { get; set; }
		public List<TicketBl> Tickets { get; set; }
		public UserBl(string userName, string passWord, AttendantBl attendant)
		{
			UserName = userName;
			PassWord = passWord;
			Attendant = attendant;
		}
	}
}
