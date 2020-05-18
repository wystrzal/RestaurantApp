using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Account.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public List<string> RoleClaims { get; set; }
    }
}
