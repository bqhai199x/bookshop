using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Order")]
    public partial class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; } = 0;

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public OrderStatus Status { get; set; } = OrderStatus.None;

        public string FullName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public Payment Payment { get; set; } = Payment.None;

        public int? ShipperId { get; set; } = null;

        public int? CouponId { get; set; } = null;

        public int? AccountId { get; set; } = null;

        [ForeignKey("AccountId")]
        public Account? Account { get; set; } = null;

        [ForeignKey("CouponId")]
        public Coupon? Coupon { get; set; } = null;

        [ForeignKey("ShipperId")]
        public Shipper? Shipper { get; set; } = null;

        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}
