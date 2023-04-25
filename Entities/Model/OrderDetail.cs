using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; } = 0;

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; } = 0;

        public int Quantity { get; set; } = 0;

        [ForeignKey("OrderId")]
        public Order? Order { get; set; } = null;

        [ForeignKey("ProductId")]
        public Product? Product { get; set; } = null;
    }
}
