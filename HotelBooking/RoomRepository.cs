namespace HotelBooking;


public interface IRoomRepo
{
    List<Room> GetAll();
    Room? GetById(int id);
    void AddNewRoom(Room room);
    bool ExistsByNumber(int number);
    bool IsBooked(int id);
    void Book(int id, string name);
    void CheckOutGuest(int id);
}


public class RoomRepository: IRoomRepo
{
    private static readonly List<Room> Entities = new();
    private static int _nextId = 1;

    public List<Room> GetAll()
    {
        return Entities;
    }

    public bool ExistsByNumber(int number)
    {
        return Entities.Exists(x => x.RoomNumber == number);
    }

    public Room? GetById(int id)
    {
        return Entities.FirstOrDefault(x => x.Id == id);
    }

    public void AddNewRoom(Room room)
    {
        room.Id = _nextId++;
        Entities.Add(room);
    }

    public bool IsBooked(int id)
    {
        return Entities.Exists(x => x.Id == id && x.IsAvailable == false);
    }

    public void Book(int id, string name)
    {
        var room = Entities.First(x => x.Id == id);
        room.IsAvailable = false;
        room.GuestName = name;

    }

    public void CheckOutGuest(int id)
    {
        var room = Entities.First(x => x.Id == id);
        room.GuestName = null;
        room.IsAvailable = true;
    }
}