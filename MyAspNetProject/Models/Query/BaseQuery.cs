namespace MyAspNetProject.Models.Query;


public record BaseQuery
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 10;
}