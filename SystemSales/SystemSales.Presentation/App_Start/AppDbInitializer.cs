using System.Data.Entity;
using SystemSales.Presentation.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SystemSales.Presentation
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var adminRole = new IdentityRole("Admins");
            var userRole = new IdentityRole("Users");
            roleManager.Create(adminRole);
            roleManager.Create(userRole);
            var admin = new ApplicationUser() { UserName = "Admin" };
            var result = userManager.Create(admin, "123");
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
            }
            base.Seed(context);
        }
    }
}