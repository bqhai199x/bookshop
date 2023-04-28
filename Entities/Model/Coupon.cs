namespace Entities
{
    public partial class Coupon
    {
        public int Id { get; set; } = 0;

        public string Code { get; set; } = string.Empty;

        public decimal? Discount { get; set; } = null;

        public DateTime? StartDate { get; set; } = null;

        public DateTime? EndDate { get; set; } = null;

        public int? Quantity { get; set; } = null;

        public string Description { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = new();
    }
}
