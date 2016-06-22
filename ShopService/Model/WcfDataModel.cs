namespace ShopService.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WcfDataModel : DbContext
    {
        public WcfDataModel()
            : base("name=WcfDataModel")
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
