using System;
using System.Data;
using Dapper;

namespace ConnectHub.Models
{
	public class UserRepository : IUserRepository
	{
        private readonly IDbConnection _conn;

		public UserRepository(IDbConnection conn)
		{
            _conn = conn;
		}

        public IEnumerable<User> GetAllUsers()
        {
            return _conn.Query<User>("SELECT * FROM user;");
        }

        public User GetUser(int id)
        {
            return _conn.QuerySingle<User>("SELECT * FROM user WHERE userID = @id",
                new { id = id });
        }

    }
}

