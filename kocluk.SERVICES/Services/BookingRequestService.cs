using AutoMapper;
using kocluk.CORE.Repository;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Services
{
    public class BookingRequestService : CrudService<BookingRequest, BookingRequestDto>, IBookingRequestService
    {
        public BookingRequestService(IRepository<BookingRequest> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public async Task<List<BookingRequestDto>> GetAllAsync()
        {
            var entities = await _repository.Where(x => x.Id > 0)
               .Select(x => new BookingRequest
               {
                   BookingTime = x.BookingTime,
                   IsActive = x.IsActive,
                   StudentName = x.StudentName,
                   StudyName = x.StudyName,
                   TeacherName = x.TeacherName,
               })
               .ToListAsync();

            var entityDtos = _mapper.Map<List<BookingRequest>, List<BookingRequestDto>>(entities);
            return entityDtos;
        }

        public Task<BookingRequestDto> GetBookingAsyncBookingReqId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingRequestDto> GetBookingReqAsync(int id)
        {
            var entities = await _repository.Where(x => x.Id == id).SingleOrDefaultAsync();
            var entityDtos = _mapper.Map<BookingRequest, BookingRequestDto>(entities);
            return entityDtos;
        }

        public async Task<BookingRequestDto> InsertAsync(BookingRequestDto bookReq)
        {
            var entity = _mapper.Map<BookingRequestDto, BookingRequest>(bookReq);
            await _repository.Add(entity);
            _repository.Save();
            bookReq.Id = entity.Id;
            return bookReq;
        }

        public async Task<BookingRequestDto> UpdateAsync(BookingRequestDto bookReq)
        {
            var entity = _mapper.Map<BookingRequestDto, BookingRequest>(bookReq);
            _repository.Update(entity);
            _repository.Save();
            return bookReq;
        }
    }
}
