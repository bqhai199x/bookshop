namespace Entities
{
    public partial class Review
    {
        public int Id { get; set; } = 0;

        public int? AccountId { get; set; } = null;

        public int? ProductId { get; set; } = null;

        public int? Rating { get; set; } = null;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
