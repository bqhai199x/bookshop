namespace Entities
{
    public partial class Order
    {
        public int Id { get; set; } = 0;

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
    }
}
