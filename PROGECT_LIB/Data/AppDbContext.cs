using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PROGECT_LIB.Data.Model;


namespace PROGECT_LIB.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasQueryFilter(u => !u.IsDeleted);





            base.OnModelCreating(modelBuilder); 
        }
        public async Task SeedManagerRoleAndUser(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            string roleName = "Manager";

            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                await roleManager.CreateAsync(role);
            }

            var user = await userManager.FindByEmailAsync("ahmad.bitar@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "ahmadbitar",
                    Gender = "Male",
                    FullName = "Ahmad Bitar",
                    Email = "ahmad.w.bitar@gmail.com",
                    PhoneNumber = "123456789",
                    UserType = roleName,
                };

                string password = "Ahmad@ab12";
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && e.Entity is ApplicationUser))
            {
                entry.State = EntityState.Modified;
                entry.CurrentValues["IsDeleted"] = true;
            }
            return base.SaveChanges();
        }
    }
}
