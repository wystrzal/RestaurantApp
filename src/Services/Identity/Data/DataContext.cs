using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity
{
    public class DataContext : IdentityDbContext<User>
    {   
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
