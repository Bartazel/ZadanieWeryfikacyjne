using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ZadanieWeryfikacyjne.Models
{
    [SwaggerSchema]
    public class AddCategoryRequest
    {
        public AddCategoryRequest(
            string name,
            string? description,
            int code)
        {
            Name = name;
            Description = description;
            Code = code;
        }

        [Required]
        [SwaggerSchema(Description = "Display name")]
        public string Name { get; set; }
        [SwaggerSchema(Description = "Description of a category")]
        public string? Description { get; set; }
        [Required]
        [SwaggerSchema(Description = "Cdoe of a category", Format = "number")]
        public int Code { get; set; }
    }
}
