﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmOS.Models
{
    public class ApplicationUser : IdentityUser

    {
        public ApplicationUser() : base() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }
    }
}
