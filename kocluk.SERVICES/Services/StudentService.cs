using AutoMapper;
using kocluk.CORE.Repository;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Dtos.UserData;
using kocluk.SERVICES.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Services
{
    public class StudentService : CrudService<Students, StudentsDto>, IStudentService
    {
        public StudentService(IRepository<Students> students, IMapper mapper) : base(students, mapper)
        {

        }

        public async Task<List<StudentsDto>> GetAllAsync()
        {
            var entities = await _repository.Where(x => x.Id > 0).Include("user").ToListAsync();
            var entityDtos = _mapper.Map<List<Students>, List<StudentsDto>>(entities);
            return entityDtos;
        }

        public async Task<StudentsDto> GetStudentAsync(int id)
        {
            var entities = await _repository.Where(x => x.Id == id).SingleOrDefaultAsync();
            var entityDtos = _mapper.Map<Students, StudentsDto>(entities);
            return entityDtos;
        }

        public async Task<StudentsDto> GetStudentAsyncStudentName(string userName)
        {
            var entities = await _repository.Where(x => x.StudentName == userName).SingleOrDefaultAsync();
            var entityDtos = _mapper.Map<Students, StudentsDto>(entities);
            return entityDtos;
        }

        public StudentsDto GetStudentByName(string userName)
        {
            var entities = _repository.Where(x => x.StudentName == userName).SingleOrDefault();
            var entityDto = _mapper.Map<Students, StudentsDto>(entities);
            return entityDto;
        }

        public async Task<StudentsDto> InsertAsync(StudentsDto user)
        {
            var entity = _mapper.Map<StudentsDto, Students>(user);
            await _repository.Add(entity);
            _repository.Save();
            user.Id = entity.Id;
            return user;
        }

        public async Task<StudentsDto> UpdateAsync(StudentsDto user)
        {
            var entity = _mapper.Map<StudentsDto, Students>(user);
            _repository.Update(entity);
            _repository.Save();
            return user;
        }
    }
}
