namespace Entities
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; } = 0;

        public int ProductId { get; set; } = 0;

        public int Quantity { get; set; } = 0;

        public Order? Order { get; set; } = null;

        public Product? Product { get; set; } = null;
    }
}
