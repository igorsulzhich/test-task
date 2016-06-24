namespace ShopService.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class Users
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
