namespace HotelBooking;

public interface IRoomService
{
    List<Room> GetAll();
    Room? GetById(int id);
    bool AddNewRoom(Room room);
    bool BookRoom(int id, string guestName);
    bool CheckoutGuest(int id);
    // void DeleteRoom(int id);
}


public class RoomService(IRoomRepo repository): IRoomService
{
    public List<Room> GetAll()
    {
        return repository.GetAll();
    }

    public Room? GetById(int id)
    {
        return repository.GetById(id);
    }

    public bool AddNewRoom(Room room)
    {
        if (repository.ExistsByNumber(room.RoomNumber))
        {
            return false;
        }
        repository.AddNewRoom(room);
        return true;

    }

    public bool BookRoom(int id, string guestName)
    {
        if (repository.IsBooked(id))
        {
            return false;
        }

        repository.Book(id, guestName);
        return true;
    }

    public bool CheckoutGuest(int id)
    {
        if (repository.IsBooked(id) || repository.GetById(id) is null)
        {
            return false;
        }

        repository.CheckOutGuest(id);
        return true;
    }
}