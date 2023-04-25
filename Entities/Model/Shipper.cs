using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Shipper")]
    public partial class Shipper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShipperId { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public decimal? Price { get; set; } = null;

        public string Phone { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = new();
    }
}