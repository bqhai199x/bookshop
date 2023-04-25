using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Image")]
    public partial class Image
    {
        public int ImageId { get; set; } = 0;

        public string ImageURL { get; set; } = string.Empty;

        public ImageType Type { get; set; } = ImageType.None;

        public int TypeId { get; set; } = 0;
    }
}
