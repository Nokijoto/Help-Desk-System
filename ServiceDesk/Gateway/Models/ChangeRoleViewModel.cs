using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Gateway.Models
{
    public class ChangeRoleViewModel
    {
        public IdentityUser User { get; set; }
        public List<string> Roles { get; set; }
        public string SelectedRole { get; set; }
    }
}
