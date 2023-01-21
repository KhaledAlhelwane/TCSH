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
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<AgeType>().HasData(new AgeType { AgeTypeId = 1, Type_Title = "(11-12)" });
			builder.Entity<AgeType>().HasData(new AgeType { AgeTypeId = 2, Type_Title = "(12-13)" });
			builder.Entity<AgeType>().HasData(new AgeType { AgeTypeId = 3, Type_Title = "(13-14)" });
			builder.Entity<AgeType>().HasData(new AgeType { AgeTypeId = 4, Type_Title = "(14-15)" });
			builder.Entity<AgeType>().HasData(new AgeType { AgeTypeId = 5, Type_Title = "(15-16)" });
			builder.Entity<AgeType>().HasData(new AgeType { AgeTypeId = 6, Type_Title = "(16-17)" });

			builder.Entity<TypeOfClothe>().HasData(new TypeOfClothe { TypeOfClotheId = 1, TypeOfTitle = "Scarf" });
			builder.Entity<TypeOfClothe>().HasData(new TypeOfClothe { TypeOfClotheId = 2, TypeOfTitle = "Jeans" });
			builder.Entity<TypeOfClothe>().HasData(new TypeOfClothe { TypeOfClotheId = 3, TypeOfTitle = "Pants" });
			builder.Entity<TypeOfClothe>().HasData(new TypeOfClothe { TypeOfClotheId = 4, TypeOfTitle = "Tishirt" });
			builder.Entity<TypeOfClothe>().HasData(new TypeOfClothe { TypeOfClotheId = 5, TypeOfTitle = "Socks" });
			builder.Entity<TypeOfClothe>().HasData(new TypeOfClothe { TypeOfClotheId = 6, TypeOfTitle = "Sweater" });
			builder.Entity<TypeOfClothe>().HasData(new TypeOfClothe { TypeOfClotheId = 7, TypeOfTitle = "Twins" });
			builder.Entity<TypeOfClothe>().HasData(new TypeOfClothe { TypeOfClotheId = 8, TypeOfTitle = "Hat" });
			builder.Entity<TypeOfClothe>().HasData(new TypeOfClothe { TypeOfClotheId = 9, TypeOfTitle = "Jacket" });

		}

		public DbSet<Clothe> Clothe { get; set; }
        public DbSet<TypeOfClothe> TypeOfClothe { get; set; }
        public DbSet<AgeType> AgeType { get; set; }
        public DbSet<AddtionalPicture> AddtionalPicture { get; set; }
    }
}