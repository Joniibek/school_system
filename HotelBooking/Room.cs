using System.ComponentModel.DataAnnotations;

namespace HotelBooking;

public enum RoomType
{
    Single,
    Double,
    Suite,
}


public class Room
{
    public int Id { get; set; }
    [Required]
    [Range(0, 10)]
    public int RoomNumber { get; set; }
    public RoomType RoomType { get; set; }
    [Required]
    [Range(0, 9999.99)]
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public string? GuestName { get; set; }
}