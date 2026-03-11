using Microsoft.EntityFrameworkCore;
using FoldrengesekSOE2026.Models;

namespace FoldrengesekSOE2026.Data
{
    public class FoldrengesContext : DbContext
    {
        public FoldrengesContext(DbContextOptions<FoldrengesContext> options) : base(options)
        {
        }
        public DbSet<Naplo> Naplok { get; set; } = null!;
        public DbSet<Telepules> Telepulesek { get; set; } = null!;
    }
}
