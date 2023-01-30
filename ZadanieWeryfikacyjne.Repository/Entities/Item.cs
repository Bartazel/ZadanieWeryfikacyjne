namespace ZadanieWeryfikacyjne.Repository.Entities
{
    public class Item
    {
        public string Id { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public Category Category { get; set; } = null!;
    }
}
