using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int? ProductCode { get; set; }

        public string? ProductCategory { get; set; }
        public string? ProductImage { get; set; }
        public int Price { get; set; }

        public int MinQuantity { get; set; }

        public double? DiscountRate { get; set; }




    }
}
