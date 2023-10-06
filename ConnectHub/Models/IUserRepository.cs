using System;
using System.Collections.Generic;

namespace ConnectHub.Models
{
	public interface IUserRepository
	{
		public IEnumerable<User> GetAllUsers();

		public User GetUser(int id);

		public void UpdateUser(User user);

		public void InsertUser(User userToInsert);

		public IEnumerable<Category> GetCategories();

		public User AssignCategory();

		public void DeleteUser(User user);
	}
}

