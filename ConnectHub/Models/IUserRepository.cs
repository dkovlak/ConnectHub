using System;
using System.Collections.Generic;

namespace ConnectHub.Models
{
	public interface IUserRepository
	{
		public IEnumerable<User> GetAllUsers();

		public User GetUser(int id);
	}
}

