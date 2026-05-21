namespace MyAspNetProject.Models.DTO.Response;

public class KlassCreateResponseDto : BaseModelResponseDto{}



public class KlassListDto : BaseModelResponseDto
{
    public int Year { get; set; }
    public required string Group { get; set; }
}