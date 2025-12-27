using Microsoft.AspNetCore.Identity;
using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.Data.DbContext
{
    public class DbSeeder
    {
        public async Task SeedRolesAndUsers(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await SeedManagerRoleAndUser(roleManager, userManager);
            await DoctorRole(roleManager, userManager);
            await NurseRole(roleManager, userManager);
        }
        public async Task SeedManagerRoleAndUser(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            string roleName = "Hospital Manager";

            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                await roleManager.CreateAsync(role);
            }

            var user = await userManager.FindByEmailAsync("ahmad.w.bitar@gmail.com");
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
       

        public async Task DoctorRole(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var role = await roleManager.FindByNameAsync("Doctor");
            if (role == null)
                await roleManager.CreateAsync(new ApplicationRole("Doctor"));

            var user = await userManager.FindByEmailAsync("Doctor@gmail.com");
            if (user == null)
            {
                var doctor = new Doctor
                {
                    UserName = "Doctor",
                    Gender = "Male",
                    FullName = "Doctor",
                    Email = "Doctor@gmail.com",
                    PhoneNumber = "123456789",
                    UserType = "Doctor"
                };
                var result = await userManager.CreateAsync(doctor, "Ahmad@ab12");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(doctor, "Doctor");
            }
        }

      

        public async Task NurseRole(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var role = await roleManager.FindByNameAsync("Nurse");
            if (role == null)
                await roleManager.CreateAsync(new ApplicationRole("Nurse"));

            var user = await userManager.FindByEmailAsync("Nurse@gmail.com");
            if (user == null)
            {
                var nurse = new Nurse
                {
                    UserName = "Nurse",
                    Gender = "Male",
                    FullName = "Nurse",
                    Email = "Nurse@gmail.com",
                    PhoneNumber = "123456789",
                    UserType = "Nurse"
                };
                var result = await userManager.CreateAsync(nurse, "Ahmad@ab12");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(nurse, "Nurse");
            }
        }
    }
}
