using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("product")]
    public partial class Product
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public int? PublisherId { get; set; } = null;

        public string Author { get; set; } = string.Empty;

        public int? CategoryId { get; set; } = null;

        public string Size { get; set; } = string.Empty;

        public int? NumPage { get; set; } = null;

        public decimal? Price { get; set; } = null;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
