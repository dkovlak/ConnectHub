﻿using System;
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

    public string Firstname { get; set; }

    public string Lastname { get; set; }

  
}

