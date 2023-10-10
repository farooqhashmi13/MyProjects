using KnowledgeTestLibrary.Models;
using Microsoft.AspNetCore.Identity;

namespace knowledgeTestUI.Utilities
{
    public class SeedUserAndRoles
    {
        public static async Task CreateUserAndRolesAsync(IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            string[] roles = { "Owner", "Admin", "User" };

            foreach (var role in roles)
            {
                var roleExists = await RoleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await RoleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }

            //Here you could create a super user who will maintain the web app
            var ownerUser = new ApplicationUser
            {

                UserName = configuration["AppSettings:OwnerUserName"],
                Email = configuration["AppSettings:OwnerUserEmail"],
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD = configuration["AppSettings:OwnerUserPassword"];
            var _user = await UserManager.FindByEmailAsync(configuration["AppSettings:OwnerUserEmail"]);

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(ownerUser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(ownerUser, "Owner");

                }
            }
        }
    }
}
