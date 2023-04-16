using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.BookingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Interface
{
    public interface IBookingRequestService : ICrudService<BookingRequest, BookingRequestDto>
    {
        Task<List<BookingRequestDto>> GetAllAsync();
        Task<BookingRequestDto> GetBookingReqAsync(int id);
        Task<BookingRequestDto> GetBookingAsyncBookingReqId(int id);
        Task<BookingRequestDto> UpdateAsync(BookingRequestDto bookReq);
        Task<BookingRequestDto> InsertAsync(BookingRequestDto bookReq);
    }
}
