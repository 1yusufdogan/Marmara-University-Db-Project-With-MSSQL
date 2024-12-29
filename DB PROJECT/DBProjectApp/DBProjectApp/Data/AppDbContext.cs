using DBProjectApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DBProjectApp.Data
{
    public class AppDbContext : ScaffoldedDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ETCRT;Integrated Security=True;Encrypt=False");
        }
    }
}
