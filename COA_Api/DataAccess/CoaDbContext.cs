using COA_Api.DataAccess.Seeder.Users;
using COA_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace COA_Api.DataAccess;

public class CoaDbContext : DbContext
{
    public CoaDbContext(DbContextOptions<CoaDbContext> options) : base(options)
    {
    }    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {      
        base.OnModelCreating(modelBuilder);
        
        // Implement seed data
        new UserConfiguration(modelBuilder).Seed();
    }
    public DbSet<User> Users { set; get;}

}
