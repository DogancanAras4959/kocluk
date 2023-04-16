using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

namespace kocluk.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingRequestController : Controller
    {
        private readonly IBookingRequestService _bookingRequestService;

        public BookingRequestController(IBookingRequestService bookingRequestService)
        {
            _bookingRequestService = bookingRequestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingRequestDto>>> GetBookingRequests()
        {
            return await _bookingRequestService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookingRequestDto>> GetBookingRequest(int id)
        {
            var bookReq = await _bookingRequestService.GetBookingReqAsync(id);
            return bookReq == null ? NotFound() : bookReq;
        }


        [HttpGet("getBookingReq")]
        public async Task<ActionResult<BookingRequestDto>> GetBookingsByBookingId([FromQuery] int id)
        {
            var bookReq = await _bookingRequestService.GetBookingAsyncBookingReqId(id);
            return bookReq == null ? NotFound() : bookReq;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBookingRequest(int id, BookingRequestDto bookReq)
        {
            if (id == bookReq.Id)
                return BadRequest();

            await _bookingRequestService.UpdateAsync(bookReq);
            return NoContent();
        }

        [HttpPost("PostBookingRequesting")]
        public async Task<ActionResult<BookingRequestDto>> PostBookingRequesting(BookingRequestDto bookReq)
        {
            await _bookingRequestService.InsertAsync(bookReq);
            return CreatedAtAction("GetBookingRequest", new { id = bookReq.Id }, bookReq);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingRequestDto>> DeleteBookingReq(int id)
        {
            var bookReq = await _bookingRequestService.GetBookingReqAsync(id);
            if (bookReq != null)
                _bookingRequestService.Delete(bookReq.Id);
            return NoContent();
        }



    }
}
