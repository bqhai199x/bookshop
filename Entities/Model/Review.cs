using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Review")]
    public partial class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; } = 0;

        public int? AccountId { get; set; } = null;

        public int? ProductId { get; set; } = null;

        public int? Rating { get; set; } = null;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public Account? Account { get; set; } = null;

        public Product? Product { get; set; } = null;
    }
}
