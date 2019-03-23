using System;
using System.Linq;
using TicketStore.Data.Models;

namespace TicketStore.Data.Repositories
{
	public class UserRepository
	{
		public void Add(string userName, string passWord, Attendant attendant)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				if (AreCredentialsCorrect(userName, passWord) == false)
				{
					dbContext.Users.Add(new User(userName, passWord, attendant));
				}
				dbContext.SaveChanges();
			}
		}

		public User Get(string userName)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				return dbContext.Users.FirstOrDefault(u => u.UserName == userName);
			}
		}

		public bool AreCredentialsCorrect(string userNameToCheck, string passWordToCheck)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				var user = dbContext.Users.FirstOrDefault(u => u.UserName == userNameToCheck && u.PassWord == passWordToCheck);
				if (user == null)
				{
					return false;
				}

				return true;

			}
			
		}
		public bool IsUserNameAlreadyExisting(string userNameToCheck)
		{
			using (var dbContext = new TicketStoreDbContext())
			{
				var user = dbContext.Users.FirstOrDefault(u => u.UserName == userNameToCheck);
				if (user == null)
				{
					return false;
				}

				return true;
			}
		}

	}
}