using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;
using StudentWebApi.Data;
using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentWebApi.Data
{
    public class StudentContext : IdentityDbContext<ApplicationUser>
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {  
        }

        public virtual DbSet<Student> Students { get; set; }


    }
}