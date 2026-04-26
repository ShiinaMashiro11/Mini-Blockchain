using Microsoft.EntityFrameworkCore;
using Mini_Blockchain.Domain.Entities;

namespace Mini_Blockchain.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Block> Blocks => Set<Block>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.DocumentHash)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(b => b.PreviousBlockHash)
                    .HasMaxLength(64);

                entity.Property(b => b.Data)
                    .IsRequired();

                entity.HasIndex(b => b.Timestamp);
            });
        }
    }
}