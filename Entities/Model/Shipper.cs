namespace Entities
{
    public partial class Shipper
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public decimal? Price { get; set; } = null;

        public string Phone { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}