using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;      

namespace StudentWebApi.Data
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider){
            var context = serviceProvider.GetRequiredService<StudentContext>();
            var userManger = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if(!context.Users.Any())
            {
                ApplicationUser user=new ApplicationUser()
                {
                    Email = "abc@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Admin"
                };
                userManger.CreateAsync(user, "Password@123");
            }
        }
    }
}