using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Dtos.StudentsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Interface
{
    public interface IBookingService : ICrudService<Booking, BookingDto>
    {
        BookingDto getBookingByTitle(string title);
        BookingDto GetBookingByName(string userName);


        Task<List<BookingDto>> GetAllAsync();
        Task<BookingDto> GetBookingAsync(int id);
        Task<BookingDto> GetBookingAsyncBookingCode(string bookingCode);
        Task<BookingDto> UpdateAsync(BookingDto user);
        Task<BookingDto> InsertAsync(BookingDto user);
    }
}
