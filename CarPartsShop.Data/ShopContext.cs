namespace CarPartsShop.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext()
            : base("ShopContext", throwIfV1Schema:false)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

        public virtual DbSet<OrderedParts> OrderedParts { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public static ShopContext Create()
        {
            return new ShopContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>().HasMany<Part>(car => car.Parts).WithMany(part => part.Cars);
        //    modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
        //    modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        //}
    }
}