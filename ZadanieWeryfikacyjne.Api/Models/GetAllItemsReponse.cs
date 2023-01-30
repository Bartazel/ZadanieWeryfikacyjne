using Swashbuckle.AspNetCore.Annotations;

namespace Zadanie_weryfikacyjne.Models
{
    [SwaggerSchema]
    public class GetAllItemsReponse
    {
        public GetAllItemsReponse(
            string id,
            string code,
            string name,
            decimal price)
        {
            Id = id;
            Code = code;
            Name = name;
            Price = price;
        }

        [SwaggerSchema(Description = "Unique identifier", Nullable = false)]
        public string Id { get; set; }
        [SwaggerSchema(Description = "Shortened unique identifier", Nullable = false)]
        public string Code { get; set; }
        [SwaggerSchema(Description = "Display name", Nullable = false)]
        public string Name { get; set; }
        [SwaggerSchema(Description = "Item price", Nullable = false)]
        public decimal Price { get; set; }
    }
}
