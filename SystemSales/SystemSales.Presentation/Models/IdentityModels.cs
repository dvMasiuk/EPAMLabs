using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SystemSales.Presentation.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager()
            : this(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        { }
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            PasswordValidator = new MinimumLengthValidator(3);
        }
    }
}