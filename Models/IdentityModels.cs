using Microsoft.AspNet.Identity.EntityFramework;

namespace OCCSolution.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary> IdentifyModels.cs
        /// OCCEntities2 is the name of the connectionString defiend inte main web.config CD 09/12/2014
        /// </summary>
        public ApplicationDbContext()
            //: base("DefaultConnection")
            : base("OCCEntities2")
        {
        }
    }
}