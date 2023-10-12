using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("image")]
    public partial class Image
    {
        public int Id { get; set; } = 0;

        public string ImageURL { get; set; } = string.Empty;

        public ImageType Type { get; set; } = ImageType.None;

        public int TypeId { get; set; } = 0;
    }
}
