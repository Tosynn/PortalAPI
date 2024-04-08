using Microsoft.EntityFrameworkCore;
using PortalAPI.Entities;

namespace PortalAPI.Data
{
    public class DataContext : DbContext
    {
        internal readonly object HeroesDTO;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
