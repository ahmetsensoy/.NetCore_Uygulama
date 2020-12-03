using EmlakOfisi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmlakOfisi.DataAccess
{
    public class EmlakOfisiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=SQL5063.site4now.net; Database=DB_A6476C_msensoy; uid=DB_A6476C_msensoy_admin; pwd=Mehmet1*;");
        }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
    }
}
