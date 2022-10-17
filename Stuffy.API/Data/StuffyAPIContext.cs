using Microsoft.EntityFrameworkCore;
using Stuffy.Entity;

namespace Stuffy.API.Data
{
    public class StuffyAPIContext : DbContext
    {
        public StuffyAPIContext (DbContextOptions<StuffyAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
