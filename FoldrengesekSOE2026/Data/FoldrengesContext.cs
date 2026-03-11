using Microsoft.EntityFrameworkCore;

namespace FoldrengesekSOE2026.Data
{
    public class FoldrengesContext : DbContext
    {
        public FoldrengesContext(DbContextOptions<FoldrengesContext> options) : base(options)
        {
        }
        public DbSet<Models.Naplo> Naplok { get; set; } = null!;
        public DbSet<Models.Telepules> Telepulesek { get; set; } = null!;
    }
}
