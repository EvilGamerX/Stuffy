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

        
    }
}
