using Microsoft.EntityFrameworkCore;
using Mini_Blockchain.Models;

namespace Mini_Blockchain.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Block> Blocks { get; set; }
    }
}