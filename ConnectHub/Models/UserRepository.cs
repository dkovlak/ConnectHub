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

        public User AssignCategory()
        {
            var categoryList = GetCategories();
            var user = new User();
            user.Categories = categoryList;
            return user;
        }

        public void DeleteUser(User user)
        {
            _conn.Execute("DELETE FROM user WHERE userid = @id", new { id = user.UserID });
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _conn.Query<User>("SELECT * FROM user;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories");
        }

        public User GetUser(int id)
        {
            return _conn.QuerySingle<User>("SELECT * FROM user WHERE userID = @id",
                new { id = id });
        }

        public void InsertUser(User user)
        {
            _conn.Execute("INSERT INTO user (" +
               "firstname, " +
               "lastname, " +
               "username, " +
               "about, " +
               "email, " +
               "password, " +
               "categoryname," +
               "ProfilePicture)" +
               "VALUES " +
               "(@firstname, @lastname, @username, @about, @email, @password, @categoryname, @profilePicture);",
               new
               {
                   categoryname = user.Categories,
                   firstname = user.Firstname,
                   lastname = user.Lastname,
                   username = user.Username,
                   about = user.About,
                   email = user.Email,
                   password = user.Password,
                   profilePicture = user.ProfilePicture
               });

        }

        public void UpdateUser(User user)
        {
            _conn.Execute("UPDATE user SET " +
                "firstname = @firstname, " +
                "lastname = @lastname, " +
                "username = @username, " +
                "about = @about, " +
                "email = @email, " +
                "password = @password, " +
                "ProfilePicture = (SELECT @picture) " +
                "WHERE userID = @id;",
                new { firstname = user.Firstname,
                    lastname = user.Lastname,
                    username = user.Username,
                    id = user.UserID,
                    about = user.About,
                    email = user.Email,
                    password = user.Password,
                    picture = user.ProfilePicture });
        }
    }
}

