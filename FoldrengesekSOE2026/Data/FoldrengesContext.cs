using Microsoft.EntityFrameworkCore;
using FoldrengesekSOE2026.Models;

namespace FoldrengesekSOE2026.Data
{
    public class FoldrengesContext : DbContext
    {
        public FoldrengesContext(DbContextOptions<FoldrengesContext> options) : base(options)
        {
        }
        public DbSet<Naplo> Naplok { get; set; } = null!; // adattábla neve: Naplok
        public DbSet<Telepules> Telepulesek { get; set; } = null!; // adattábla neve: Telepulesek
    }
}
