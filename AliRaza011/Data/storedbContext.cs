using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AliRaza011.Models;

namespace AliRaza011.Data
{
    public class storedbContext : DbContext
    {
        public storedbContext (DbContextOptions<storedbContext> options)
            : base(options)
        {
        }

        public DbSet<AliRaza011.Models.ordermodel> ordermodel { get; set; }
    }
}
