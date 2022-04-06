using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stuffy.API.Entities;

namespace Stuffy.API.Data
{
    public class StuffyAPIContext : DbContext
    {
        public StuffyAPIContext (DbContextOptions<StuffyAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
    }
}
