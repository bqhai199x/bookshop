using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public partial class OrderDetail
    {
        public decimal? Total
        {
            get
            {
                return Quantity * Product?.Price;
            }
        }
    }
}
