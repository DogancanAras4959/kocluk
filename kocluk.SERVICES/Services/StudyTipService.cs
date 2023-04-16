using AutoMapper;
using kocluk.CORE.Repository;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
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
    public class StudyTipService : CrudService<StudyTips, StudyTipDto>, IStudyTipService
    {
        public StudyTipService(IRepository<StudyTips> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public List<StudyTipDto> GetStudyTipsWithStudy(int id)
        {
            var entity = _repository.Where(x => x.StudyId == id).Include("study").ToList();
            var etnityDto = _mapper.Map<List<StudyTips>, List<StudyTipDto>>(entity);
            return etnityDto;
        }
    }
}
