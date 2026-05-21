using Microsoft.AspNetCore.Mvc;

namespace HotelBooking;




[ApiController]
[Route("[controller]/[action]")]
public class RoomController(IRoomService service): ControllerBase
{
    [HttpGet]
    public ActionResult<List<Room>> GetAll()
    {
        return Ok(service.GetAll());
    }

    [HttpGet("{id:int:min(0)}")]
    public ActionResult<Room> GetById([FromRoute] int id)
    {
        var room = service.GetById(id);
        if (room is null)
        {
            return NotFound("Room was not found");
        }

        return Ok(room);
    }

    [HttpPost]
    public ActionResult<string> CreateNewRoom([FromBody] Room room)
    {
        if (!service.AddNewRoom(room))
        {
            return Conflict("Already exists");
        }

        return Ok("Added");
    }

    [HttpPut("{id:int:min(0)}")]
    public ActionResult<string> BookRoom([FromRoute] int id, [FromQuery] string guestName)
    {
        if (service.BookRoom(id, guestName))
        {
            return Ok("room booke succesfully");
        }

        return BadRequest("Already booked");
    }

    [HttpPut("{id:int:min(0)}")]
    public ActionResult<string> CheckOutGuest([FromRoute] int id)
    {
        if (service.CheckoutGuest(id))
        {
            return Ok("Guest was checked out");
        }

        return BadRequest("Already empty");
    }
    
}