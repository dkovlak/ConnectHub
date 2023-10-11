using System;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectHub.Models
{
	public class User
	{
		public int UserID { get; set; }

		public string Firstname { get; set; }

		public string Lastname { get; set; }

		public string About { get; set; }

		public string Username { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime LastLogin { get; set; }

		public ICollection<Post> Posts { get; set; }

		public byte[] ProfilePicture { get; set; }

		public IEnumerable<Category> Categories { get; set; }

        public User()
		{
            CreatedAt = DateTime.Now;
            LastLogin = DateTime.Now;
		}
    }
}

