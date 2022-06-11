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

    }
    public DbSet<User> Users { set; get;}

}
