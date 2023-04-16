using AutoMapper;
using kocluk.CORE.Repository;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Services
{
    public class BookingService : CrudService<Booking, BookingDto>, IBookingService
    {
        public BookingService(IRepository<Booking> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public BookingDto getBookingByTitle(string title)
        {
            var entity = _repository.Where(x => x.BookingName == title).Include("study").Include("user").Include("student").SingleOrDefault();
            var entityDto = _mapper.Map<Booking, BookingDto>(entity!);
            return entityDto;
        }

        public async Task<List<BookingDto>> GetAllAsync()
        {
            var entities = await _repository.Where(x => x.Id > 0)
                .Select(x => new Booking 
                { 
                  BookingCode = x.BookingCode,
                  BookingName = x.BookingName,
                  BookingTime = x.BookingTime,
                  Tip = x.Tip,
                  IsActive = x.IsActive,
                  StudentName = x.StudentName,
                  PlaceId = x.PlaceId,
                  StudyName= x.StudyName,
                  UserName = x.UserName,
                })
                .ToListAsync();

            var entityDtos = _mapper.Map<List<Booking>, List<BookingDto>>(entities);
            return entityDtos;
        }

        public async Task<BookingDto> GetBookingAsync(int id)
        {
            var entities = await _repository.Where(x => x.Id == id).SingleOrDefaultAsync();
            var entityDtos = _mapper.Map<Booking, BookingDto>(entities);
            return entityDtos;
        }

        public async Task<BookingDto> GetBookingAsyncBookingCode(string bookingCode)
        {
            var entities = await _repository.Where(x => x.BookingCode == bookingCode).SingleOrDefaultAsync();
            var entityDtos = _mapper.Map<Booking, BookingDto>(entities);
            return entityDtos;
        }

        public BookingDto GetBookingByName(string userName)
        {
            var entities = _repository.Where(x => x.BookingName == userName).SingleOrDefault();
            var entityDto = _mapper.Map<Booking, BookingDto>(entities);
            return entityDto;
        }

        public async Task<BookingDto> InsertAsync(BookingDto user)
        {
            var entity = _mapper.Map<BookingDto, Booking>(user);
            await _repository.Add(entity);
            _repository.Save();
            user.Id = entity.Id;
            return user;
        }

        public async Task<BookingDto> UpdateAsync(BookingDto user)
        {
            var entity = _mapper.Map<BookingDto, Booking>(user);
            _repository.Update(entity);
            _repository.Save();
            return user;
        }
    }
}
