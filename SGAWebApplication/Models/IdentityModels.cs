using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SGAWebApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Points { get; set; }
        public string UserRole { get; set; }
        public Nullable<int> ClubsId { get; set; }

        [ForeignKey("ClubsId")]
        public virtual Clubs Clubs { get; set; }
        public virtual ICollection<Events> Events { get; set; }
        public virtual ICollection<ClubEvents> ClubEvents { get; set; }

        public ApplicationUser()
        {
            this.Events = new HashSet<Events>();
            this.ClubEvents = new HashSet<ClubEvents>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Clubs> clubs { get; set; }
        public DbSet<ClubEvents> clubEvents { get; set; }
        public DbSet<Events> events { get; set; }
    }
}