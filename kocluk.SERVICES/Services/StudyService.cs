using AutoMapper;
using kocluk.CORE.Repository;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Dtos.StudyData;
using kocluk.SERVICES.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Services
{
    public class StudyService : CrudService<Studies, StudyDto>, IStudyService
    {
        public StudyService(IRepository<Studies> repositoey, IMapper mapper) : base(repositoey, mapper)
        {

        }

        public async Task<List<StudyDto>> GetAllAsync()
        {
            var entities = await _repository.Where(x => x.Id > 0)
                .Select(x => new Studies
                {
                   StudyName = x.StudyName,
                   Color = x.Color,
                   IsActive = x.IsActive,
                   Type = x.Type
                })
                .ToListAsync();

            var entityDtos = _mapper.Map<List<Studies>, List<StudyDto>>(entities);
            return entityDtos;
        }

        public async Task<StudyDto> GetStudyAsync(int id)
        {
            var entities = await _repository.Where(x => x.Id == id).SingleOrDefaultAsync();
            var entityDtos = _mapper.Map<Studies, StudyDto>(entities);
            return entityDtos;
        }

        public StudyDto getStudyByName(string nameLesson)
        {
            var entity = _repository.Where(x => x.StudyName == nameLesson).SingleOrDefault();
            var entityDto = _mapper.Map<Studies, StudyDto>(entity);
            return entityDto;
        }

        public async Task<StudyDto> InsertAsync(StudyDto study)
        {
            var entity = _mapper.Map<StudyDto, Studies>(study);
            await _repository.Add(entity);
            _repository.Save();
            study.Id = entity.Id;
            return study;
        }

        public async Task<StudyDto> UpdateAsync(StudyDto study)
        {
            var entity = _mapper.Map<StudyDto, Studies>(study);
            _repository.Update(entity);
            _repository.Save();
            return study;
        }
    }
}
