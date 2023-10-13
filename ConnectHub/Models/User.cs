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

        [Required(ErrorMessage = "Come on, don't leave your name blank!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Your name should be between 2 and 50 characters.")]
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

