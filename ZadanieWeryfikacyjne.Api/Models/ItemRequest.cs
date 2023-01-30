using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Zadanie_weryfikacyjne.Models
{
    [SwaggerSchema]
    public class ItemRequest
    {
        public ItemRequest(
            string name,
            decimal price,
            int categoryCode)
        {
            Name = name;
            Price = price;
            CategoryCode = categoryCode;
        }

        [Required]
        [SwaggerSchema(Description = "Display name")]
        public string Name { get; set; }
        [Required]
        [SwaggerSchema(Description = "Price of an item", Format = "number")]
        public decimal Price { get; set; }
        [Required]
        [SwaggerSchema(Description = "Code of category the item will be assigned to", Format = "number")]
        public int CategoryCode { get; set; }
    }
}
