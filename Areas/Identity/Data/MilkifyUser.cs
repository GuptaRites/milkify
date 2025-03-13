using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace milkify.Areas.Identity.Data  // Ensure this matches the folder structure
{
    public class MilkifyUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;  // Ensure non-null default value
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}


