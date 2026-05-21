namespace MyAspNetProject.Models.Query;

public record StudentListQuery : BaseQuery
{
    public int? KlassId { get; set; }
    public int? Year { get; set; }
}