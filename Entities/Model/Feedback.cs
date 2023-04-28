namespace Entities
{
    public partial class Feedback
    {
        public int Id { get; set; } = 0;
        
        public string Email { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
