using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("category")]
    public partial class Category
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
