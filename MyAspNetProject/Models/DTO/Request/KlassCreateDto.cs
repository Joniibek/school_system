using System.ComponentModel.DataAnnotations;

namespace MyAspNetProject.Models.DTO.Request;

public class KlassCreateDto
{
    [Required]
    [Range(1, 11, ErrorMessage = "Invalid year of school education")]
    public short Year  { get; set; }
    
    [Required]
    [MaxLength(1, ErrorMessage = "Invalid quantity of group name")]
    public required string Group { get; set; }
}