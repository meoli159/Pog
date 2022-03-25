using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pog.Data
{
    public class ApplicationDbContext : IdentityDbContext<CUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Topic> Topics { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        public DbSet<QA> QA { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        //public DbSet<Vote> Votes { get; set; }
        public DbSet<testmodel> testmodels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            builder.Entity<IdentityRole>().HasData(
               new IdentityRole() { Id = "Admin", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
               new IdentityRole() { Id = "QAManager", Name = "QAManager", ConcurrencyStamp = "2", NormalizedName = "Quality Assurance Manager" },
               new IdentityRole() { Id = "QACoordinator", Name = "QACoordinator ", ConcurrencyStamp = "3", NormalizedName = "Quality Assurance coordinator " },
               new IdentityRole() { Id = "Staff", Name = "Staff", ConcurrencyStamp = "4", NormalizedName = "Staff" }
               );

        }

        private void SeedUsers(ModelBuilder builder)
        {
            CUser user = new CUser() {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PhoneNumber = "1234567890",
                PasswordHash= "AQAAAAEAACcQAAAAEO4VH+iHiqX5vn83W8iNN3b0ICITS+WntFgRJd8j83L+Z+TI3MRoBx8OUJcqT6XqUQ==",
                SecurityStamp = "4e6bc8a6-8784-47ea-bbc5-cbbf835aed40",
                ConcurrencyStamp = "e08e079f-3173-4e89-80e2-0384008f6888"
            };


            builder.Entity<CUser>().HasData(user);
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "Admin", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }

    }


}