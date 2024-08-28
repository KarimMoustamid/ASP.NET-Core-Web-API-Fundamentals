namespace CityInfo.API.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PointOfInterestForUpdateDto
    {
        [MaxLength(50)] [Required(ErrorMessage = "You Should provide a name value.")] public string Name { get; set; } = string.Empty;
        [MaxLength(200)] public string? Description { get; set; }
    }
}