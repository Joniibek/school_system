namespace MyAspNetProject.Models.Query;

public record KlassListQuery : BaseQuery
{
    public string? Group { get; set; }
    public int Year { get; set; }
}