using Microsoft.EntityFrameworkCore;

namespace ZadanieWeryfikacyjne.Repository.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public class Category
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Code { get; set; }
    }
}
