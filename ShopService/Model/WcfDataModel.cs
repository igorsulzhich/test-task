namespace ShopService.Model
{
    using System.Data.Entity;

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
        }
    }
}
