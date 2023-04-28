namespace Entities
{
    public partial class Category
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new();
    }
}
