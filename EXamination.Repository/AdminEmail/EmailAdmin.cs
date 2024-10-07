using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Repository.AdminEmail
{
    public static class EmailAdmin
    {
        public static async Task SeedAdmin(UserManager<IdentityUser> userManager)
        {
            // Check if the admin user already exists
            var adminUser = await userManager.FindByEmailAsync("admin@Kenana.com");
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@Kenana.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded) 
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }

            }
        }

    }
}
