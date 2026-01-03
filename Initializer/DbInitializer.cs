using Microsoft.EntityFrameworkCore;
using Security_Feature_Project.Data;
using Security_Feature_Project.Models;

namespace Security_Feature_Project.Repositories
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate(); 

            
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                   
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                    RoleId = 1
                });
                context.SaveChanges();
            }
        }
    }
}
