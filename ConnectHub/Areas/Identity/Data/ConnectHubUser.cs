using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConnectHub.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ConnectHubUser class
public class ConnectHubUser : IdentityUser
{
    public int UserID { get; set; }

    [BindProperty]
    public string Firstname { get; set; } = "";

    public required string Lastname { get; set; }

    public required string About { get; set; }

    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastLogin { get; set; }

    public ICollection<Post> Posts { get; set; }

    public byte[] ProfilePicture { get; set; }

    public IEnumerable<Category> Categories { get; set; }

}

