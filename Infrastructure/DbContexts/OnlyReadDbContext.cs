using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class OnlyReadDbContext: DbContext
    {

        public OnlyReadDbContext(DbContextOptions<OnlyReadDbContext> options):base(options) {}
        public DbSet<Usuario> usuarioSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnlyReadDbContext).Assembly);
        }
    }
}
