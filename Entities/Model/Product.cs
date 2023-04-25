using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public int? PublisherId { get; set; } = null;

        public string Author { get; set; } = string.Empty;

        public int? CategoryId { get; set; } = null;

        public string Size { get; set; } = string.Empty;

        public int? NumPage { get; set; } = null;

        public decimal? Price { get; set; } = null;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } = null;

        [ForeignKey("PublisherId")]
        public Publisher? Publisher { get; set; } = null;

        public List<Image> Images { get; set; } = new();

        public List<Review> Reviews { get; set; } = new();

        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}
