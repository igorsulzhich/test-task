namespace ShopService.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class Products
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageLink { get; set; }
    }
}
