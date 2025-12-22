using MedicalPark.Models;
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
            await AdminRole(roleManager, userManager);
            await NurseRole(roleManager, userManager);
        }

        public async Task SeedManagerRoleAndUser(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var role = await roleManager.FindByNameAsync("Hospital Manager");
            if (role == null)
            {
                role = new ApplicationRole("Hospital Manager");
                await roleManager.CreateAsync(role);
            }

            var user = await userManager.FindByEmailAsync("ahmad.w.bitar@gmail.com");
            if (user == null)
            {
                user = new Admin
                {
                    UserName = "ahmadbitar",
                    Gender = "Male",
                    Name = "Ahmad Bitar",
                    Email = "ahmad.w.bitar@gmail.com",
                    PhoneNumber = "123456789",
                    UserType = "Hospital Manager",
                };
                var result = await userManager.CreateAsync(user, "Ahmad@ab12");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Hospital Manager");
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
                    Name = "Doctor",
                    Email = "Doctor@gmail.com",
                    PhoneNumber = "123456789",
                    UserType = "Doctor"
                };
                var result = await userManager.CreateAsync(doctor, "Ahmad@ab12");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(doctor, "Doctor");
            }
        }

        public async Task AdminRole(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var role = await roleManager.FindByNameAsync("Admin");
            if (role == null)
                await roleManager.CreateAsync(new ApplicationRole("Admin"));

            var user = await userManager.FindByEmailAsync("Admin@gmail.com");
            if (user == null)
            {
                var admin = new Admin
                {
                    UserName = "Admin",
                    Gender = "Male",
                    Name = "Admin",
                    Email = "Admin@gmail.com",
                    PhoneNumber = "123456789",
                    UserType = "Admin"
                };
                var result = await userManager.CreateAsync(admin, "Ahmad@ab12");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Admin");
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
                    Name = "Nurse",
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
