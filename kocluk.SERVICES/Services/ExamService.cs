using AutoMapper;
using kocluk.CORE.Repository;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.ExamsData;
using kocluk.SERVICES.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Services
{
    public class ExamService : CrudService<Exams, ExamsDto>, IExamService
    {
        public ExamService(IRepository<Exams> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public List<ExamsDto> GetExamsByPaths()
        {
            var entity = _repository.Where(x => x.Id > 0).Include("teacher").Include("study").Include("student").OrderByDescending(x => x.Id).ToList();
            var entityDto = _mapper.Map<List<Exams>, List<ExamsDto>>(entity);
            return entityDto;
        }
    }
}
