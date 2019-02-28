using Fadiou.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fadiou.Startup))]
namespace Fadiou
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool 
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                //Here we create a Admin super user who will maintain the website 
                var user = new ApplicationUser();
                user.UserName = "glIam2019";
                user.Email = "glIam2019@yopmail.com";
                string userPWD = "P@sser123";
                var chkUser = UserManager.Create(user, userPWD);
                //Add default User to Role Admin 
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            // creating Creating Manager role 
            if (!roleManager.RoleExists("Medecin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Medecin";
                roleManager.Create(role);
            }
            // creating Creating Employee role 
            if (!roleManager.RoleExists("Infirmier"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Infirmier";
                roleManager.Create(role);
            }
            // creating Creating Employee role 
            if (!roleManager.RoleExists("Comptable"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Comptable";
                roleManager.Create(role);
            }
            // creating Creating Employee role 
            if (!roleManager.RoleExists("Administration"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Administration";
                roleManager.Create(role);
            }
        }
    }
}
