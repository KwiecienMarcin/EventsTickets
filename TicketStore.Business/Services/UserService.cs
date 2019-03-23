using System;
using TicketStore.Business.Models;
using TicketStore.Data;
using TicketStore.Data.Models;
using TicketStore.Data.Repositories;

namespace TicketStore.Business.Services
{
	public class UserService
	{
		private IDataObjectsMapper _dataObjectsMapper;
		private UserRepository _userRepository = new UserRepository();
		public void Add(string userName, string passWord, AttendantBl attendant)
		{
			
			if (IsUserNameAlreadyExisting(userName) == false)
			{
				_userRepository.Add(
					userName, 
					passWord, 
					_dataObjectsMapper.MapAttendantBlToAttendant(attendant));
			}
			
		}
		public UserBl Get(string userName)
		{
			return _dataObjectsMapper.
				MapUserToUserBl(_userRepository.Get(userName));
		}

		public bool AreCredentialsCorrect(string userNameToCheck, string passWordToCheck)
		{
			return _userRepository.AreCredentialsCorrect(
				userNameToCheck, 
				passWordToCheck);
		}
		public bool IsUserNameAlreadyExisting(string userNameToCheck)
		{
			return _userRepository.IsUserNameAlreadyExisting(userNameToCheck);
		}

	}
}