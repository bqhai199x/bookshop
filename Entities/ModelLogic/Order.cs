namespace Entities
{
    public partial class Order
    {
        public string Code
        {
            get { return Id.ToString("DH000"); }
        }

        public int? TotalQuantity
        {
            get { return OrderDetails.Sum(x => x.Quantity); }
        }

        public decimal? SubTotal
        {
            get { return OrderDetails.Sum(x => x.Quantity * x.Product?.Price); }
        }

        public decimal? GrandTotal
        {
            get
            {
                decimal? grandTotal = SubTotal;
                if (CouponId != null)
                {
                    grandTotal *= Coupon?.Discount;
                }
                if (ShipperId != null)
                {
                    grandTotal += Shipper?.Price;
                }
                return grandTotal;
            }
        }

        public decimal? Discount
        {
            get
            {
                return SubTotal - GrandTotal;
            }
        }
    }
}
