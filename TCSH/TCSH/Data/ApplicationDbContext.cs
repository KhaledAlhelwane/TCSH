using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TCSH.Models;

namespace TCSH.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       public DbSet<Clothe> Clothe { get; set; }
        public DbSet<TypeOfClothe> TypeOfClothe { get; set; }
        public DbSet<AgeType> AgeType { get; set; }
        public DbSet<AddtionalPicture> AddtionalPicture { get; set; }
    }
}