using COA_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace COA_Api.DataAccess.Seeder.Users
{
    internal class UserConfiguration
    {
        private ModelBuilder modelBuilder;

        public UserConfiguration(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            // Property Configurations 
            var user = modelBuilder.Entity<User>();

            user.ToTable("Users");
            user.Property(c => c.ID)
                .HasColumnName("ID_user");

            user.Property(c => c.isActive)
                .HasColumnName("Active")
                .HasDefaultValue(true);    

            //Seed data
            user.HasData(
                new User
                {
                    ID = 1,
                    UserName = "Gustav77",
                    Name = "Gustavo Allende",
                    Email = "gustavo.allende@gmail.com",
                    Phone = "+54-333-3100234"      
                },
                new User
                {
                    ID = 2,
                    UserName = "Adrianno#Q",
                    Name = "Adrian Navarro",
                    Email = "adrian.navarro@gmail.com",
                    Phone = "+54-333-3112326"      
                },
                new User
                {
                    ID = 3,
                    UserName = "Noe-Fishl1",
                    Name = "Noelia Fishl",
                    Email = "noelia.fishl@gmail.com",
                    Phone = "+54-333-3100666"      
                },
                new User
                {
                    ID = 4,
                    UserName = "FlorHHen4",
                    Name = "Florencia Hallen",
                    Email = "florencia.hallen2@gmail.com",
                    Phone = "+54-333-3104554"      
                },
                new User
                {
                    ID = 5,
                    UserName = "MikaEss3n",
                    Name = "Micaela Essen",
                    Email = "micaela.essen66@gmail.com",
                    Phone = "+54-333-3101212"      
                }
            );
        }
    }
}    