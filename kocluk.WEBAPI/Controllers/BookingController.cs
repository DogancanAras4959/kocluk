using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Interface;
using kocluk.SERVICES.Services;
using Microsoft.AspNetCore.Mvc;

namespace kocluk.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingDto>>> GetBookings()
        {
            return await _bookingService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookingDto>> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingAsync(id);
            return booking == null ? NotFound() : booking;
        }


        [HttpGet("getBooking")]
        public async Task<ActionResult<BookingDto>> GetBookingsByBookingCode([FromQuery] string bookingCode)
        {
            var booking = await _bookingService.GetBookingAsyncBookingCode(bookingCode);
            return booking == null ? NotFound() : booking;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBooking(int id, BookingDto booking)
        {
            if (id == booking.Id)
                return BadRequest();

            await _bookingService.UpdateAsync(booking);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BookingDto>> PostBooking(BookingDto booking)
        {
            await _bookingService.InsertAsync(booking);
            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingDto>> DeleteBooking(int id)
        {
            var booking = await _bookingService.GetBookingAsync(id);
            if (booking != null)
                _bookingService.Delete(booking.Id);
            return NoContent();
        }


    }
}
