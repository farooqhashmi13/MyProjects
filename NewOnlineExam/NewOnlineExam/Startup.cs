using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using NewOnlineExam.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewOnlineExam.Startup))]
namespace NewOnlineExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login    
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Super User"))
            {

                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "Super User";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "farooq@teccraft.net";
                user.Email = "farooq@teccraft.net";
                user.FullName = "Farooq Hashmi";
                string userPWD = "facebook07";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Super User");
                }
            }

            // creating Creating Manager role     
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "admin@domain.com";
                user.Email = "admin@domain.com";
                user.FullName = "Admin";
                string userPWD = "facebook07";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Basic User"))
            {
                var role = new IdentityRole();
                role.Name = "Basic User";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "user@domain.com";
                user.Email = "user@domain.com";
                user.FullName = "User";
                string userPWD = "facebook07";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Basic User");
                }
            }
        }
    }
}
