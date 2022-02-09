using DogApp.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DogApp.Models;

namespace DogApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogApp.Models.DogCreateViewModel> DogCreateViewModel { get; set; }
        public DbSet<DogApp.Models.DogDetailsViewModel> DogDetailsViewModel { get; set; }
    }
}
