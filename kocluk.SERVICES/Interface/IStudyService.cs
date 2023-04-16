using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Dtos.StudyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Interface
{
    public interface IStudyService : ICrudService<Studies, StudyDto>
    {
        StudyDto getStudyByName(string nameLesson);

        Task<List<StudyDto>> GetAllAsync();
        Task<StudyDto> GetStudyAsync(int id);
        Task<StudyDto> UpdateAsync(StudyDto study);
        Task<StudyDto> InsertAsync(StudyDto study);
    }
}
