using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DB
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Computing> Computings { get; set; }
    }
}
